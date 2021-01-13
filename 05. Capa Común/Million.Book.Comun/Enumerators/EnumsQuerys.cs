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
	public class EnumsQuerys
	{
		public static string ConsultarEditorialesByDapper
		{
			get
			{
				return SentenciasQuery.ConsultarEditorialesByDapper.ToStringAttribute();
			}
		}

		#region Enumeradores

		/// <summary>
		/// Enum Status
		/// </summary>
		public enum SentenciasQuery
		{
			[StringValue("ConsultarEditorialesByDapper")]
			ConsultarEditorialesByDapper


		}

		#endregion Enumeradores
	}
}