using Basis.Service.Cashin.Client.ClientGenerator;

namespace Basis.Service.Cashin.Client.Factory
{
    public class CashinApiFactory : ICashinApiFactory
    {
        public ICashinApi CreateNew(string url)
        {
            var builder = new HttpClientGeneratorBuilder(url);
            return builder.Generate<ICashinApi>();
        }
    }
}
