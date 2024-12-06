using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentDto
    {

        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 5 character")]
        [MaxLength(50, ErrorMessage = "Title must be at most 50 character")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must be at least 5 character")]
        [MaxLength(280, ErrorMessage = "Content must be at most 280 character")]
        public string Content { get; set; } = string.Empty;
        public int? StockId { get; set; }
        public DateTime CreatedOn { get; set; }

        //Navigation property: es una propiedad 
        //que hace referencia a otra entidad
        //de manera tal que se puede navegar a través de ella
    }
}