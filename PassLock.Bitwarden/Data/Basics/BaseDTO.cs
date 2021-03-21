namespace PassLock.Bitwarden.Data.Basics
{
    /// <summary>
    /// Base class for all dtos
    /// </summary>
    /// <typeparam name="T">The real Object</typeparam>
    public abstract class BaseDTO<T>
    {
        public abstract T ConvertBack();
    }
}
