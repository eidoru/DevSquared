namespace DevSquared.Exceptions
{
    public class ChapterNullException : Exception
    {
        public ChapterNullException() { }
        public ChapterNullException(string message) : base(message) { }
        public ChapterNullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
