using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserCRUD.data;
using UserCRUD.exceptions.InputExceptions;
using UserCRUD.Models;
using UserCRUD.Models.domain;
using UserCRUD.services.validators;

namespace UserCRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly UserCRUDdbContext userCRUDdbContext;
        public UserController(UserCRUDdbContext userCRUDdbContext)
        {
            this.userCRUDdbContext = userCRUDdbContext;
        }

        public UserCRUDdbContext UserCRUDdbContext { get; }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await userCRUDdbContext.Users.ToListAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel request)
        {
            List<User> userResult = await userCRUDdbContext.Users.Where(x => x.Id == request.Id).ToListAsync();

            if (userResult.Count > 0)
            {
                SetViewBagErrorMessageForClient("User ID is already exists in the DB.");
                return View("Error");
            }

            try
            {
                UserModelDataValidator.completeValidation(request);
                User user = PopulateUserEntity(request);
                await userCRUDdbContext.Users.AddAsync(user);
                await userCRUDdbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                SetViewBagErrorMessageForClient(ex.Message);
                return View("Error");
            }
                        
        }

        private static User PopulateUserEntity(AddUserViewModel request)
        {
            return new User()
            {
                InternalID = Guid.NewGuid(),    
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Phone = request.Phone
            };
        }

        [HttpGet]
        public async Task<IActionResult> ViewUser(Guid internalID)
        {
            
            var user = await userCRUDdbContext.Users.FirstOrDefaultAsync( x => x.InternalID == internalID);


            if (user != null)
            {
                var viewModel = new UpdateUserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    Phone = user.Phone
                };
                return await Task.Run(() => View("ViewUser", viewModel));
            }
            else 
            {
                SetViewBagErrorMessageForClient("User doesn't exists. Could not find user according to the given id");
                return View("Error");
            }

            
        }

        public void SetViewBagErrorMessageForClient(string error)
        {
            ViewBag.title = "Server Error";
            ViewBag.message = error;
        }

        [HttpPost]
        public async Task<IActionResult> ViewUser(UpdateUserViewModel request)
        {
            var userObj = await userCRUDdbContext.Users.FindAsync(request.InternalID);
            if (userObj == null)
            {
                SetViewBagErrorMessageForClient("Could not update user's details. Could not find user according to the supplied id");
                return View("Error");
            }
            try
                {
                    UserModelDataValidator.completeValidation(request);
                    userObj.Name = request.Name;
                    userObj.Email = request.Email;
                    userObj.Phone = request.Phone;
                    userObj.Id = request.Id;
                    userObj.Gender = request.Gender;
                    userObj.DateOfBirth = request.DateOfBirth;

                    await userCRUDdbContext.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    SetViewBagErrorMessageForClient(ex.Message);
                    return View("Error");
                }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(UpdateUserViewModel request)
        {
            var user = await userCRUDdbContext.Users.FindAsync(request.InternalID);
            if (user != null)
            {
                userCRUDdbContext.Users.Remove(user);
                await userCRUDdbContext.SaveChangesAsync();
            }
            else
            {
                SetViewBagErrorMessageForClient("Failed to delete user. Could not find user according to the given id");
                return View("Error");
            }
            return RedirectToAction("Index");



        }

    }
}
