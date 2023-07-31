using HotChocolate.Types.Descriptors;
using MetaData.WebAPI.GraphQL;
using System.Diagnostics.CodeAnalysis;

namespace MetaData.WebAPI
{
  [ExcludeFromCodeCoverage]
  public static class InternalServiceConfiguration
  {
    public static void ConfigureInternalService(this IServiceCollection services, ConfigurationManager configurationManager)
    {
      
      #region GraphQL
      services.AddSingleton<INamingConventions, CamelCaseNamingConventions>();
      #endregion
    }
  }
}
