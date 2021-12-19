using Codebridge.Domain.Models;


namespace Codebridge.Domain.IServices.Communication
{
    public class SaveDogResponse : BaseResponse
    {
        public Dog Dog { get; private set; }

        private SaveDogResponse(bool success, string message, Dog dog) : base(success, message)
        {
            Dog = dog;
        }

        public SaveDogResponse(Dog dog) : this(true, string.Empty, dog)
        { }

        public SaveDogResponse(string message) : this(false, message, null)
        { }
    }
}
