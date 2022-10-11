namespace Kama.Organization.Core
{
    public interface IResultMessageProvider : AppCore.IResultMessageProvider
    {
        void Init(string filename);

        string Get(string error);
    }
}
