using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace Million.Book.Aplicacion.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper<T1, T2>()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T1, T2>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}