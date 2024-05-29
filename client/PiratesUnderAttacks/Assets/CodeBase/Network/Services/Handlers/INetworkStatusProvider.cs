namespace CodeBase.Network.Services.Handlers
{
    public interface INetworkStatusProvider
    {
        bool IsLocalPlayer(string id);
    }
}