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
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Million.Book.Aplicacion.Implements
{
	public class EditorialService : IEditorialService
	{
		private readonly IEditorialRepository _editorialRepository;
		private readonly IMapper _mapper;



		public EditorialService(IEditorialRepository editorialRepository, IMapper mapper)
		{
			_editorialRepository = editorialRepository;
			_mapper = mapper;

		}


		public ResponseServices<List<EditorialDto>> ConsultarEditorialesByDapper()
		{
			var response = new ResponseServices<List<EditorialDto>>();
			response.Type = Enums.MensajeRespuesta.Consulta.ToStringAttribute();
			var resultList = _editorialRepository.ConsultarEditorialesByDapper();
			var listMap = _mapper.Map<List<EditorialDto>>(resultList);
			if (resultList.Any())
			{
				response.Info = listMap;
				response.Message = Enums.MensajeRespuesta.Ok.ToStringAttribute();
				response.State = true;
				return response;
			}
			response.Info = listMap;
			response.Message = Enums.MensajeRespuesta.Error.ToStringAttribute();
			response.State = false;
			return response;
		}

		public ResponseServices<int> InsertarEditorial(EditorialDto editorial)
		{
			var response = new ResponseServices<int>();
			response.Type = Enums.MensajeRespuesta.Insert.ToStringAttribute();
			var mapAdaptador = AutoMapperConfig.GetMapper<EditorialDto, Editorial>().Map<Editorial>(editorial);

			var result = _editorialRepository.InsertarEditorial(mapAdaptador);

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

		ResponseServices<List<EditorialDto>> IEditorialService.ConsultarEditoriales()
		{
			var response = new ResponseServices<List<EditorialDto>>();
			response.Type = Enums.MensajeRespuesta.Consulta.ToStringAttribute();
			var resultList = _editorialRepository.ConsultarEditoriales();
			var listMap = _mapper.Map<List<EditorialDto>>(resultList);
			if (resultList.Any())
			{
				response.Info = listMap;
				response.Message = Enums.MensajeRespuesta.Ok.ToStringAttribute();
				response.State = true;
				return response;
			}
			response.Info = listMap;
			response.Message = Enums.MensajeRespuesta.Error.ToStringAttribute();
			response.State = false;
			return response;
		}


	}
}
