using System.Collections.Specialized;
using System.Reflection;
namespace GodaddyWrapper.Helper
{
    internal class QueryStringBuilder
    {
        public static string RequestObjectToQueryString(object RequestObject)
        {
            var url = "?";
            foreach (var property in RequestObject.GetType().GetRuntimeProperties())
            {
                if (property.GetValue(RequestObject) != null)
                    url += $"{property.Name}={Newtonsoft.Json.JsonConvert.SerializeObject(property.GetValue(RequestObject))}&";
            }
            return url;
        }
    }
}
