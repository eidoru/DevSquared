namespace DevSquared.Exceptions
{
    public class CourseNullException : Exception
    {
        public CourseNullException() { }
        public CourseNullException(string message) : base(message) { }
        public CourseNullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
