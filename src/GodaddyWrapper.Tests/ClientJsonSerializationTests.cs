#if NETCORE
using GodaddyWrapper.Serialization;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace GodaddyWrapper.Tests
{
    public class ClientJsonSerializationTests
    {
        private readonly ITestOutputHelper _output;

        public ClientJsonSerializationTests(ITestOutputHelper output) 
        {
            _output = output;
        }


        [Fact]
        public void ClientJsonRequestTest()
        {
            const string namespaceName = "GodaddyWrapper.Requests";
            HashSet<string> missingTypes = new HashSet<string>();
            Assembly assembly = typeof(GoDaddyClient).Assembly;
            var types = assembly.GetTypes().Where(x => x.Namespace == namespaceName).ToList();

            typeof(GoDaddyClient).GetMethods()
                .ToList()
                .ForEach(method =>
                {
                    var parameters = method.GetParameters();
                    if (parameters.Length > 0)
                    {
                        //_output.WriteLine($"Method: {nameof(GoDaddyClient)}.{method.Name}");

                        foreach (var p in parameters)
                        {
                            if (p.ParameterType.FullName.StartsWith(namespaceName))
                            {
                                //_output.WriteLine($"Parm: {p.ParameterType.Name}:{p.Name}");
                                bool found = JsonContext.Default.Options.TryGetTypeInfo(p.ParameterType, out _);
                                if (!found)
                                {
                                    _ = missingTypes.Add($"[JsonSerializable(typeof({p.ParameterType.Name}))]");
                                }
                            }
                            else if (p.ParameterType.IsGenericType && p.ParameterType.GenericTypeArguments.Any(a => a.FullName.StartsWith(namespaceName)))
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append(p.ParameterType.GetGenericTypeDefinition().Name.Split('`')[0]);
                                sb.Append('<');
                                foreach (var a in p.ParameterType.GenericTypeArguments)
                                {
                                    sb.Append(a.Name);
                                    sb.Append(',');
                                }
                                sb.Remove(sb.Length - 1, 1);
                                sb.Append('>');

                                //_output.WriteLine($"GParm: {sb.ToString()}:{p.Name}");
                                bool found = JsonContext.Default.Options.TryGetTypeInfo(p.ParameterType, out _);
                                if (!found)
                                {
                                    _ = missingTypes.Add($"[JsonSerializable(typeof({sb.ToString()}))]");
                                }
                            }
                        }
                    }
                });
            if(missingTypes.Count > 0)
            {
                _output.WriteLine($"Add the following attributes to the {nameof(JsonContext)} class:");
                foreach (var item in missingTypes)
                {
                    _output.WriteLine(item);
                }
            }
            Assert.Empty(missingTypes);
        }

        [Fact]
        public void ClientJsonResponseTest()
        {
            const string namespaceName = "GodaddyWrapper.Responses";
            HashSet<string> missingTypes = new HashSet<string>();
            Assembly assembly = typeof(GoDaddyClient).Assembly;
            var types = assembly.GetTypes().Where(x => x.Namespace == namespaceName).ToList();

            typeof(GoDaddyClient).GetMethods()
                .ToList()
                .ForEach(method =>
                {
                    var p = method.ReturnParameter;
                    if (p is not null)
                    {
                        //_output.WriteLine($"Method: {nameof(GoDaddyClient)}.{method.Name}");
                        Type parameterType = p.ParameterType;
                        if(parameterType.Name.StartsWith("Task"))
                        {
                            parameterType = parameterType.GenericTypeArguments.FirstOrDefault();
                        }
                        if (parameterType is not null)
                        {
                            if (parameterType.FullName.StartsWith(namespaceName))
                            {
                                //_output.WriteLine($"Parm: {parameterType.Name}:{p.Name}");
                                bool found = JsonContext.Default.Options.TryGetTypeInfo(parameterType, out _);
                                if (!found)
                                {
                                    _ = missingTypes.Add($"[JsonSerializable(typeof({parameterType.Name}))]");
                                }
                            }
                            else if (parameterType.IsGenericType && parameterType.GenericTypeArguments.Any(a => a.FullName.StartsWith(namespaceName)))
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append(parameterType.GetGenericTypeDefinition().Name.Split('`')[0]);
                                sb.Append('<');
                                foreach (var a in parameterType.GenericTypeArguments)
                                {
                                    sb.Append(a.Name);
                                    sb.Append(',');
                                }
                                sb.Remove(sb.Length - 1, 1);
                                sb.Append('>');

                                //_output.WriteLine($"GParm: {sb.ToString()}:{p.Name}");
                                bool found = JsonContext.Default.Options.TryGetTypeInfo(parameterType, out _);
                                if (!found)
                                {
                                    _ = missingTypes.Add($"[JsonSerializable(typeof({sb.ToString()}))]");
                                }
                            }
                        }
                    }
                });
            if (missingTypes.Count > 0)
            {
                _output.WriteLine($"Add the following attributes to the {nameof(JsonContext)} class:");
                foreach (var item in missingTypes)
                {
                    _output.WriteLine(item);
                }
            }
            Assert.Empty(missingTypes);
        }

    }
}
#endif