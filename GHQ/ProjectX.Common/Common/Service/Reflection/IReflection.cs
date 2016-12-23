namespace Service.Reflection
{
    public interface IReflection
    {
        void SetProperty(object src,string propertyName, object value);
    }
}
