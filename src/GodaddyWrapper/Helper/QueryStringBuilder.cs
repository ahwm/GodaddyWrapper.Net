﻿using GodaddyWrapper.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GodaddyWrapper.Helper
{
    internal static class QueryStringBuilder
    {
        public static string RequestObjectToQueryString(object RequestObject)
        {
            var settings = new JsonSerializerSettings 
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy
                    {
                        OverrideSpecifiedNames = false
                    }
                },
                NullValueHandling = NullValueHandling.Ignore 
            };
            var url = new StringBuilder("?");
            foreach (var property in RequestObject.GetType().GetRuntimeProperties())
            {
                if (property.GetValue(RequestObject) != null)
                {
                    if (IsSimple(property.PropertyType.GetTypeInfo()))
                    {
                        if (!(property.GetCustomAttribute(typeof(QueryStringToUpperAttribute)) is QueryStringToUpperAttribute))
                            url.Append($"{ToFirstLetterLower(property.Name)}={property.GetValue(RequestObject).ToString().ToLower()}&");
                        else
                            url.Append($"{ToFirstLetterLower(property.Name)}={property.GetValue(RequestObject).ToString().ToUpper()}&");
                    }
                    else if (IsList(property.PropertyType.GetTypeInfo()))
                        url.Append($"{ToFirstLetterLower(property.Name)}={ConvertFromList(property.GetValue(RequestObject))}&");
                    else
                        url.Append($"{ToFirstLetterLower(property.Name)}={JsonConvert.SerializeObject(property.GetValue(RequestObject), settings)}&");
                }
            }
            return url.ToString().Trim('&');
        }

        static bool IsSimple(TypeInfo type)
        {
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal));
        }

        static bool IsList(TypeInfo type)
        {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)) && type.GenericTypeArguments.FirstOrDefault() == typeof(string);
        }

        static string ConvertFromList(object obj)
        {
            List<string> list = obj as List<string>;

            return String.Join(",", list);
        }

        public static string ToFirstLetterLower(string text) { var charArray = text.ToCharArray(); charArray[0] = char.ToLower(charArray[0]); return new string(charArray); }
    }
}
