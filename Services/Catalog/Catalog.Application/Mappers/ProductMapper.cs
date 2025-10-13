using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Mappers
{
    public static class ProductMapper
    {
        private static readonly ILoggerFactory? _loggerFactory;
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(static () =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ProductMappingProfile>(); // Corrected to use the generic AddProfile method
            });

            return config.CreateMapper(); // Ensure a value is returned to fix CS1643
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
