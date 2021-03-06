﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class Marcas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de Marca")]
        public string Nombre { get; set; }
        public string Tipo_Activo { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Fecha de Creacion")]
        public DateTime Fecha_Creacion { get; set; }
        [Display(Name = "Usuario de Creacion")]
        public string Usuario_Creacion { get; set; }
        [Display(Name = "Fecha de Modificacion")]
        public DateTime Fecha_Modificacion { get; set; }
        [Display(Name = "Usuario de Modificacion")]
        public string Usuario_Modificacion { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
    }
}
