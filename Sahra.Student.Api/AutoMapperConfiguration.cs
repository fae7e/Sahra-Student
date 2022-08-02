using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sahra.Student.Application.MapperProfile;
using System.Linq;
using System.Reflection;

namespace Sahra.Student.Api
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            IMapper mapper = GetConfiguration().CreateMapper();

            services.AddSingleton(mapper);
        }
        public static MapperConfiguration GetConfiguration()
        {
            var types = new[]
            {
                    typeof(StudentMapperProfile)
            };

            var profiles = types
                .Select(t => t.Assembly)
                .SelectMany(o => o.GetExportedTypes())
                .Where(t => typeof(Profile).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo()))
                .Where(t => !t.GetTypeInfo().IsAbstract);

            return new MapperConfiguration(mc =>
            {
                foreach (var profile in profiles)
                {
                    mc.AddProfile(profile);
                }
            });
        }
    }
}
