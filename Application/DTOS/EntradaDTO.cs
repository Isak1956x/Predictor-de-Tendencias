using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class EntradaDTO
    {
        
      required  public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        required  public double Valor { get; set; }
    }
}
