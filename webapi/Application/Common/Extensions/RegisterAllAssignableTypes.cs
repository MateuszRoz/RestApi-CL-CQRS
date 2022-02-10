using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Extensions
{
    public static class RegisterAllAssignableTypes
    {
        public static void RegisterAllAssignableType<T>(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(p => typeof(T).IsAssignableFrom(p)).ToArray();

            var addTransientMethod = typeof(ServiceCollectionServiceExtensions).GetMethods().FirstOrDefault(m =>
                m.Name == "AddTransient" &&
                m.IsGenericMethod &&
                m.GetGenericArguments().Count() == 2);


            var interfaceList = types.Where(x => x.IsInterface).ToList();
            var classList = types.Where(x => !x.IsInterface).ToList();

            foreach (var type in interfaceList)
            {
                var cl = classList.FirstOrDefault(x => x.GetInterfaces().Any(c => c == type));
                if (cl == null)
                    continue;

                if (addTransientMethod is not null)
                {
                    var method = addTransientMethod.MakeGenericMethod(type, cl);
                    method.Invoke(services, new object[] { services });
                }
            }
        }

        public static TInterface ResolveByName<TInterface>(this IServiceProvider serviceProvider, string typeName)
        {
            var allRegisteredTypes = serviceProvider.GetRequiredService<IEnumerable<TInterface>>();
            var resolvedService = allRegisteredTypes.FirstOrDefault(p => p.GetType().FullName.Contains(typeName));

            if (resolvedService != null) return resolvedService;

            throw new Exception($"{typeName} type not found.");
        }
    }
}
