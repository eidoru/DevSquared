namespace DevSquared.Exceptions
{
    public class ActivityNullException : Exception
    {
        public ActivityNullException() { }
        public ActivityNullException(string message) : base(message) { }
        public ActivityNullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
