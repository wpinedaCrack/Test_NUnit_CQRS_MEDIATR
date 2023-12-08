using Education.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.DTO
{
    public class CursoDTO
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        //public DateTime? FechaCreacion { get; set; }
        public Decimal Precio { get; set; }
    }
}
