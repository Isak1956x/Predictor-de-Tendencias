using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class EntradaListViewModelDTO
    {
        [Required(ErrorMessage = "El valor no puede estar vacio")]
        public EntradaDTO[] EntradaList { get; set; } = new EntradaDTO[20];
        
    }
}
