using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Tarea2.Data.Entidades;

namespace Tarea2.Models
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
 
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
     
        public RolViewModel Rol { get; set; }
        public List<AgrupadoViewModel> Menu { get; set; }
        public AppResult ValidarDatosLogin()
        {

            if (string.IsNullOrEmpty(this.Email) || string.IsNullOrEmpty(this.Contraseña))
            {
                return AppResult.NoSuccess("El Email o la contraseña no puede estar vacia");
            }
            return AppResult.Success("valido", null);
        }
    }
}
