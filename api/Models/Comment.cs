using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? StockId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        //Navigation property: es una propiedad 
        //que hace referencia a otra entidad
        //de manera tal que se puede navegar a través de ella
        public Stock? Stock { get; set; }
    }
}