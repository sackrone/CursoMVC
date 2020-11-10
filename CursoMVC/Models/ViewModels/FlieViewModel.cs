using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CursoMVC.Models.ViewModels
{
    public class FlieViewModel
    {
        [Required]
        [DisplayName("Mi Archivo")]
        public HttpPostedFileBase Archivo1 { get; set; }

        [Required]
        [DisplayName("Mi Archivo 2")]
        public HttpPostedFileBase Archivo2 { get; set; }

        [Required]
        [DisplayName("Mi Cadena")]
        public string Cadena { get; set; }
    }
}