using Microsoft.Extensions.Logging;

namespace AwesomeBankingApp.Bootstrap
{
    public interface IModuleBootstrap
    {
        void Run(ILogger logger);
    }
}