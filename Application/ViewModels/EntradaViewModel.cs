using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class EntradaViewModel
    {

        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El Valor debe ser mayor a 0.")]
        public double Valor { get; set; }
    }
}
