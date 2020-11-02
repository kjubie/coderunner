using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace FHTW.CodeRunner.Services.AutoMapper
{
    /// <summary>
    /// A static class that provides the configuration for the AutoMapper.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class MapperProfile
    {
        /// <summary>
        /// Adds the created mapping profiles to the configuration.
        /// </summary>
        /// <returns>the configuration which includes all added mapping profiles.</returns>
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BlMapperProfile());
                cfg.AddProfile(new DalMapperProfile());
            });

            return config;
        }
    }
}
