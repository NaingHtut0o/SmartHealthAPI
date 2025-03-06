using System.Reflection;

namespace SmartHealthAPI.Extensions
{
    public static class Extensions
    {
        public static void AddScopedServiceByNamespace( this IServiceCollection services, string namespaceFilter )
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Namespace != null && t.Namespace.StartsWith(namespaceFilter))
                .Select(t => new
                {
                    Service = t.GetInterfaces().FirstOrDefault(),
                    Implementation = t
                })
                .Where(t => t.Service != null);
            foreach( var type in types )
            {
                services.AddScoped( type.Service, type.Implementation );
            }
        }
    }
}
