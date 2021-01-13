
namespace Million.Book.Modelo.EntityModel
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class ExceptionControl
    {
        [Key, Column(Order = 0)]
        [ForeignKey("idLibro")]
        public long ExceptionId { get; set; }
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ExceptionStackTrack { get; set; }
        public System.DateTime ExceptionLogTime { get; set; }
        public string IdUsuario { get; set; }
    }
}
