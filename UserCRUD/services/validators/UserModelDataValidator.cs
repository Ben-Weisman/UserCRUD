using Microsoft.AspNetCore.Components.Forms;
using System.Net.Mail;
using System.Text.RegularExpressions;
using UserCRUD.exceptions.InputExceptions;
using UserCRUD.Models;

namespace UserCRUD.services.validators
{
    public static class UserModelDataValidator
    {
        public static void completeValidation(AddUserViewModel model)
        {

            if (model == null) throw new InputException("Error in parsing user. No user was received by the server.");
            else if (model.Id.ToString().Length == 0 || model.Id.All(char.IsLetter)) throw new InputException("Illegal user id received.");
            else if (model.Name.Length <= 0 || ContainsDigits(model.Name)) throw new InputException("Illegal user's name received.");
            else if (model.DateOfBirth.Equals(null)) throw new InputException("Illegal date of birth");
            else if (model.Email != null && !ValidMail(model.Email)) throw new InputException("Illegal Email address entered.");
            else if (model.Phone != null && ContainsLetter(model.Phone)) throw new InputException("Illegal phone number received.");
        }
        public static void completeValidation(UpdateUserViewModel model)
        {

            if (model == null) throw new InputException("Error in parsing user. No user was received by the server.");
            else if (model.Id.ToString().Length == 0 || model.Id.All(char.IsLetter)) throw new InputException("Illegal user id received.");
            else if (model.Name.Length <= 0 || ContainsDigits(model.Name)) throw new InputException("Illegal user's name received.");
            else if (model.DateOfBirth.Equals(null)) throw new InputException("Illegal date of birth");
            else if (model.Email != null && !ValidMail(model.Email)) throw new InputException("Illegal Email address entered.");
            else if (model.Phone != null && ContainsLetter(model.Phone)) throw new InputException("Illegal phone number received.");
        }
        public static Boolean ContainsDigits(string s)
        {
            foreach(char c in s)
            {
                if (Char.IsDigit(c)) return true;
            }
            return false;
        }
        public static Boolean ContainsLetter(string s)
        {
            foreach (char c in s)
            {
                if (Char.IsLetter(c)) return true;
            }
            return false;
        }

        public static Boolean ValidMail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
