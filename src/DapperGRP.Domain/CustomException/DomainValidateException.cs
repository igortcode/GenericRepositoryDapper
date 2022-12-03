namespace DapperGRP.Domain.CustomException
{
    public class DomainValidateException : Exception
    {
        public DomainValidateException(string message) : base(message){}

        public static void When(bool condition, string message)
        {
            if(condition)
                throw new DomainValidateException(message);
        }
    }
}
