using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACF.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
