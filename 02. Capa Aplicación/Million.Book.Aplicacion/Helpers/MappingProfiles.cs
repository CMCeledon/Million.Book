// ***********************************************************************
// Assembly         : Million.Book.Modelo.Entities
// Author           : www.cmceledon.com (Carlos Mario Celedón Rodelo)
// Created          : 2020-02-18 08:45:00.473
//
// Last Modified By : www.cmceledon.com (Carlos Mario Celedón Rodelo)
// Last Modified On : 2020-02-18 08:45:00.473
// ***********************************************************************
// <copyright file="TarifaOportunidad.cs" company="Million">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;
using Million.Book.Comun.Dto;
using Million.Book.Modelo.EntityModel;

namespace Million.Book.Aplicacion.Helpers
{
    /// <summary>
    /// Class MappingProfiles.
    /// Implements the <see cref="AutoMapper.Profile" />
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfiles"/> class.
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<Libro, LibroDto>().ReverseMap();
            CreateMap<Editorial, EditorialDto>().ReverseMap();
        }
    }
}