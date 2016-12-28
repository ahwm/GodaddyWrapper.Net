using GodaddyWrapper.Attributes;
using System;
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
                {
                    if (IsSimple(property.PropertyType.GetTypeInfo()))
                    {
                        var queryStringToUpperAttribute = property.GetCustomAttribute(typeof(QueryStringToUpperAttribute)) as QueryStringToUpperAttribute;
                        if (queryStringToUpperAttribute == null)
                            url += $"{property.Name}={property.GetValue(RequestObject).ToString().ToLower()}&";
                        else
                            url += $"{property.Name}={property.GetValue(RequestObject).ToString().ToUpper()}&";
                    }
                    else
                        url += $"{property.Name}={Newtonsoft.Json.JsonConvert.SerializeObject(property.GetValue(RequestObject))}&";
                }
            }
            return url;
        }

        static bool IsSimple(TypeInfo type)
        {
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal));
        }
    }
}
