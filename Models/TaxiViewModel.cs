using Microsoft.AspNetCore.Mvc.Rendering;
using Tarea2.Data.Entidades;

namespace Tarea2.Models
{
    public class TaxiViewModel
    {
        public Guid Id { get; set; }

        public string Placa { get; set; }

        public string Observacion { get; set; }

        public bool Eliminado { get; set; }

        public Guid UsuarioId { get; set; }

        public DateTime CreatedDate { get; set; }

        public UsuarioViewModel Usuario { get; set; }
        public List<SelectListItem> Usuarios { get; set; }

        public AppResult ValidarModelo()
        {
            if (string.IsNullOrEmpty(Placa))
            {
                return AppResult.NoSuccess("La placa no puede estar vacia");
            }            
            if (UsuarioId.Equals(Guid.Empty))
            {
                return AppResult.NoSuccess("Debe seleccionar un usuario");
            }
            return AppResult.Success("Datos validos", null);
        }
    }
}
