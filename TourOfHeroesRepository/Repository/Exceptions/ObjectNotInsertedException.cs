using System.Runtime.Serialization;

namespace TourOfHeroesRepository.Repository.Exceptions
{
    public class ObjectNotInsertedException : Exception
    {
        public ObjectNotInsertedException()
        {
        }

        public ObjectNotInsertedException(string? message) : base(message)
        {
        }

        public ObjectNotInsertedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ObjectNotInsertedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}