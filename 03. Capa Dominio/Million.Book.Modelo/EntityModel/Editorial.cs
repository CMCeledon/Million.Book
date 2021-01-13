namespace Million.Book.Modelo.EntityModel
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class Editorial
    {
        [Key, Column(Order = 0)]
        [ForeignKey("idEditorial")]
        public long idEditorial { get; set; }
        public string nombre { get; set; }
        public string sede { get; set; }
    }
}
