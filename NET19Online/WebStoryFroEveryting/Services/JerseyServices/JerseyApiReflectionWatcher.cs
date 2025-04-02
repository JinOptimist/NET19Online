using System.Reflection;
using WebStoryFroEveryting.Controllers.ApiControllers;
using WebStoryFroEveryting.Models.Jerseys;

namespace WebStoryFroEveryting.Services.JerseyServices
{
    public class JerseyApiReflectionWatcher
    {
        public List<MethodInformation> GetAllInfo()
        {
            var list = new List<MethodInformation>();
            var type = typeof(JerseyController);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (var method in methods)
            {
                var attrs = method.GetCustomAttributes();
                var currentMethodInfo = new MethodInformation
                {
                    Name = method.Name,
                    Parameters = new List<MethodParameters>(),
                    ReturnType = method.ReturnType.Name
                };
                var signature = new List<string>();
                var parameters = method.GetParameters();
                foreach (var p in parameters)
                {
                    if (p.ParameterType.Name.Contains("ViewModel"))
                    {
                        signature.Add($"{p.ParameterType.Name} {p.Name}");
                        var parType = p.ParameterType.GetProperties();
                        foreach (var pt in parType)
                        {
                            currentMethodInfo.Parameters.Add(
                                new MethodParameters
                                {
                                    Name = pt.Name,
                                    HasDefaultValue = false,
                                    DefaultValue = null,
                                    ParameterType = pt.PropertyType
                                }
                            );
                        }
                    }
                    else
                    {
                        currentMethodInfo.Parameters.Add(
                                new MethodParameters
                                {
                                    Name = p.Name,
                                    HasDefaultValue = p.HasDefaultValue,
                                    DefaultValue = p.DefaultValue?.ToString(),
                                    ParameterType = p.ParameterType

                                }
                        );
                        signature.Add($"{p.ParameterType.Name} {p.Name}");
                    }
                    currentMethodInfo.Signature = "(" + String.Join(", ", signature) + ")";
                }
                list.Add(currentMethodInfo);
            }
            return list;
        }
    }
}
