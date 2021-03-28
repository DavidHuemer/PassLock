using PassLock.Bitwarden.Data.Basics;

namespace PassLock.Bitwarden.Data.DTOs.Objects
{
    public abstract class BitwardenObjectDTO<T> : BaseDTO<T>
    {
        public string Object { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
