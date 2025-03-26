
using System.Reflection;

namespace ReflectionExample
{
    internal class ReflectionHelper
    {
        public void WriteBaseInfo(object obj)
        {
            var type = obj.GetType();
            Console.WriteLine(type.FullName);
            Console.WriteLine($"constructors count: {type.GetConstructors().Length}");
        }

        public void WriteBaseInfo<T>()
        {
            var type = typeof(T);
            Console.WriteLine(type.FullName);
            Console.WriteLine($"constructors count: {type.GetConstructors().Length}");
        }

        public void WriteSecrurityInfo<T>()
        {
            var type = typeof(T);

            Console.WriteLine(type.FullName);

            var properties = type.GetProperties(BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.Public
                | BindingFlags.NonPublic);

            Console.WriteLine($"********* properties ********* ");
            foreach (var property in properties)
            {
                Console.WriteLine($"\t{property.PropertyType.Name} {property.Name}");
            }


            var fields = type.GetFields(BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.Public
                | BindingFlags.NonPublic);

            Console.WriteLine($"********* fields ********* ");
            foreach (var field in fields)
            {
                Console.WriteLine($"\t{field.FieldType.Name} {field.Name}");
            }

            var methods = type.GetMethods(BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.Public
                | BindingFlags.NonPublic);

            Console.WriteLine($"********* methods ********* ");
            foreach (var method in methods)
            {
                Console.WriteLine($"\t{method.ReturnType.Name} {method.Name}");

                var parameters = method.GetParameters();
                foreach (var param in parameters)
                {
                    Console.WriteLine($"\t\t" +
                        $"{param.ParameterType.Name} " +
                        $"{param.Name} " +
                        $"{(param.HasDefaultValue ? $" = {param.DefaultValue}" : "")}");
                }
            }

            var constructors = type.GetConstructors(BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.Public
                | BindingFlags.NonPublic);

            Console.WriteLine($"********* constructors ********* ");
            foreach (var constructor in constructors)
            {
                Console.WriteLine($"\t");

                var parameters = constructor.GetParameters();
                foreach (var param in parameters)
                {
                    Console.WriteLine($"\t\t" +
                        $"{param.ParameterType.Name} " +
                        $"{param.Name} " +
                        $"{(param.HasDefaultValue ? $" = {param.DefaultValue}" : "")}");
                }
            }
        }
    }
}
