using System.Text.Json;
using HotChocolate.Types.Descriptors;

namespace MetaData.WebAPI.GraphQL
{
  public class CamelCaseNamingConventions: DefaultNamingConventions
  {
    public override NameString GetEnumValueName(object value)
    {
      if (value == null)
      {
        throw new ArgumentNullException(nameof(value));
      }

      return JsonNamingPolicy.CamelCase.ConvertName(value.ToString() ?? string.Empty);
    }
  }
}
