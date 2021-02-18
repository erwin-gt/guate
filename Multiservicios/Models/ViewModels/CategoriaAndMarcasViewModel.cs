using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models.ViewModels
{
    public class CategoriaAndMarcasViewModel
    {
        public IEnumerable<Categoria> CategoriaList { get; set; }
        public Marcas Marcas { get; set; }

        public List<string> MarcasList { get; set; }
        public string StatusMessage { get; set; }

    }
}
