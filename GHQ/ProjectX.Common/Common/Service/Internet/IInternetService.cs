namespace Service.Internet
{
    public interface IInternetService
    {
        string NoInternetMessage { get; set; }
        bool HasInternetAccess();
    }
}
