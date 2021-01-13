// ***********************************************************************
// Assembly         : Million.Book.Comun
// Author           : Carlos Mario Celedón Rodelo - cmceledon
// Created          : 28-11-2019
//
// Last Modified By : Carlos Mario Celedón Rodelo - cmceledon
// Last Modified On : 28-11-2019
// ***********************************************************************
// <copyright file="CommonHelpers.cs" company="Indra Colombia">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;

namespace Million.Book.Comun.Helpers
{
    /// <summary>
    /// Class CommonHelpers.
    /// </summary>
    public class CommonHelpers
    {
        #region Singleton

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static CommonHelpers Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new CommonHelpers());
                }
            }
        }

        #endregion Singleton

        #region Propiedades Privadas

        /// <summary>
        /// The instance
        /// </summary>
        private static CommonHelpers _instance;

        /// <summary>
        /// The padlock
        /// </summary>
        private static readonly object Padlock = new object();

        #endregion Propiedades Privadas

        #region Propiedades Públicas

     
        public string MillionEntitiesConnectionString { get; set; }



        #endregion Propiedades Públicas

    }
}