// ***********************************************************************
// Assembly         :  Million.Book.Comun.Enums
// Author           : cmceledon (Carlos Mario Celedón Rodelo)
// Created          : 06-11-2019
//
// Last Modified By : cmceledon (Carlos Mario Celedón Rodelo)
// Last Modified On : 08-12-2019
// ***********************************************************************
// <copyright file="Enums.cs" company="">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Million.Book.Comun.Enumerators
{
    /// <summary>
    /// Clase Enums
    /// </summary>
    public class Enums
    {
        #region Enumeradores
        /// <summary>
        /// Enum Status
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// The ok
            /// </summary>
            Ok = 1,
            /// <summary>
            /// The error
            /// </summary>
            Error = 0
        }
        /// <summary>
        /// Enum Mensajes Respuesta General
        /// </summary>
        public enum MensajeRespuesta
        {
            /// <summary>
            /// 
            /// </summary>
            [StringValue("Correcto")]
            Ok,
            /// <summary>
            /// 
            /// </summary>
            [StringValue("Crear")]
            Crear,
            /// <summary>
            /// 
            /// </summary>
            [StringValue("Duplicar")]
            Duplicar,
            /// <summary>
            /// 
            /// </summary>
            [StringValue("Error")]
            Error,

            /// <summary>
            /// 
            /// </summary>
            [StringValue("Sin Información")]
            SinDatos,

            /// <summary>
            /// 
            /// </summary>
            [StringValue("Tipo Consulta")]
            Consulta,

            /// <summary>
            /// 
            /// </summary>
            [StringValue("Inserción y Consulta")]
            InsertConsulta,

            /// <summary>
            /// 
            /// </summary>
            [StringValue("Eliminar Registro")]
            Eliminar,
            /// <summary>
            /// 
            /// </summary>
            [StringValue("Inserción")]
            Insert
        }

        #endregion
    }
}
