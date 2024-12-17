namespace Basis.Service.Cashin.Client.Factory
{
    public interface ICashinApiFactory
    {
        ICashinApi CreateNew(string url);
    }
}
