
// ***********************************************************************
// Assembly         : Million.Book.Modelo.Entities
// Author           : www.cmceledon.com (Carlos Mario Celedón Rodelo)
// Created          : 2020-02-18 16:38:36.163
//
// Last Modified By : www.cmceledon.com (Carlos Mario Celedón Rodelo)
// Last Modified On : 2020-02-18 16:38:36.163
// ***********************************************************************
// <copyright file="ExceptionControl.cs" company="Million">
//     Copyright © 2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Million.Book.Comun.Dto
{
    public class LibroDto
    {
        public long idLibro { get; set; }
        public int isbn { get; set; }
        public long idEditorial { get; set; }
        public string titulo { get; set; }
        public string sinopsis { get; set; }
        public string numeroPagina { get; set; }

    }
}