using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.ViewModels
{
    public class EntradaListViewModel
    {
        [Required(ErrorMessage = "El valor no puede estar vacio")]
        public EntradaViewModel[] EntradaList { get; set; } = new EntradaViewModel[20];
        
    }
}
