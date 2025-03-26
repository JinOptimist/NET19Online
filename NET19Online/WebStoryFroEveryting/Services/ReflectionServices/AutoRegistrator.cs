using StoreData.Repostiroties;
using System.Reflection;

namespace WebStoryFroEveryting.Services.ReflectionServices
{
    public class AutoRegistrator
    {
        public void RegisterRepositories(IServiceCollection services, Type baseRepositoryType)
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
                Console.WriteLine($"{repositoriesType.Name} was regstered");
                services.AddScoped(repositoriesType);
            }
        }
    }
}
