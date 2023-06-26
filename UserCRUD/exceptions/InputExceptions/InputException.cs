namespace UserCRUD.exceptions.InputExceptions
{
    public class InputException:Exception
    {
        public InputException() { }
        public InputException(string error) : base(error) { }
    }
}
