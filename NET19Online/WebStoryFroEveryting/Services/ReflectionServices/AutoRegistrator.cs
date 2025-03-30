using System.Reflection;

namespace WebStoryFroEveryting.Services.ReflectionServices
{
    public class AutoRegistrator
    {
        private IServiceCollection _services;

        public AutoRegistrator(IServiceCollection services)
        {
            _services = services;
        }

        public void RegisterRepositories(Type baseRepositoryType)
        {
            var assemblyStoreData = Assembly.GetAssembly(baseRepositoryType);

            var repositoriesTypes = assemblyStoreData
                .GetTypes()
                .Where(type => type.IsClass
                    && type.BaseType != null
                    && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == baseRepositoryType);

            foreach (var repositoriesType in repositoriesTypes)
            {
                _services.AddScoped(repositoriesType);
                Console.WriteLine($"{repositoriesType.Name} was regstered");
            }
        }

        public void RegisterServiceByAttribute()
        {
            var attributeType = typeof(AutoRegistrationAttribute);

            var assembly = Assembly.GetAssembly(attributeType);

            var servicesTypes = assembly
                .GetTypes()
                .Where(type => type.IsClass
                    && type.GetCustomAttribute<AutoRegistrationAttribute>() != null
                );

            foreach (var serviceType in servicesTypes)
            {
                _services.AddScoped(serviceType);
                Console.WriteLine($"{serviceType.Name} was regstered");
            }
        }

        public void RegisterServiceByAttributeOnConstructor()
        {
            var attributeType = typeof(AutoRegistrationAttribute);

            var assembly = Assembly.GetAssembly(attributeType);

            var servicesTypes = assembly
                .GetTypes()
                .Where(type => type.IsClass
                    && type
                        .GetConstructors()
                        .Any(c => c.GetCustomAttribute<AutoRegistrationAttribute>() != null)
                );

            foreach (var serviceType in servicesTypes)
            {
                // serviceType == IdolGenerator
                _services.AddScoped(serviceType, (di) =>
                {
                    // IdolGenerator(NameGenerator nameGenerator)
                    var constructor = serviceType
                        .GetConstructors()
                        .First(c => c.GetCustomAttribute<AutoRegistrationAttribute>() != null);

                    var parameters = constructor
                        .GetParameters() // (NameGenerator nameGenerator)
                        .Select(parameterForConstructor =>
                            // parameterForConstructor ==> NameGenerator nameGenerator
                            di.GetRequiredService(parameterForConstructor.ParameterType))
                        .ToArray();
                    
                    var service = constructor.Invoke(parameters);

                    return service;
                });

                Console.WriteLine($"{serviceType.Name} was regstered");
            }
        }
    }
}
