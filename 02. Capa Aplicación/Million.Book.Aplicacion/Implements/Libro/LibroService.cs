using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using Million.Book.Aplicacion.Abstract;
using Million.Book.Aplicacion.Helpers;
using Million.Book.Comun.Dto;
using Million.Book.Comun.Enumerators;
using Million.Book.Comun.Helpers;
using Million.Book.Infraestructura.Interfaces;
using Million.Book.Infraestructura.Repositorio;
using Million.Book.Infraestructura.Repositorio.DBContext;
using Million.Book.Modelo.EntityModel;

namespace Million.Book.Aplicacion.Implements
{
	public class LibroService : ILibroService
	{
		private readonly ILibroRepository _libroRepository;

		public LibroService(ILibroRepository libroRepository)
		{
			_libroRepository = libroRepository;
		}
	
		public ResponseServices<int> InsertarLibro(LibroDto exceptionControlDto)
		{
			var response = new ResponseServices<int>();
			response.Type = Enums.MensajeRespuesta.Insert.ToStringAttribute();
			var mapAdaptador = AutoMapperConfig.GetMapper<LibroDto, Libro>().Map<Libro>(exceptionControlDto);

			var result = _libroRepository.InsertarLibro(mapAdaptador);

			if (result > (int)Enums.Status.Error)
			{
				response.Info = result;
				response.Message = Enums.MensajeRespuesta.Ok.ToStringAttribute();
				response.State = true;
				return response;
			}
			response.Message = Enums.MensajeRespuesta.Error.ToStringAttribute();
			response.State = false;
			return response;
		}

	}
}
