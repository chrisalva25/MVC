using Microsoft.AspNetCore.Mvc.Rendering;
using Tarea2.Data.Entidades;

namespace Tarea2.Models
{
    public class ModulosRolesViewModel
    {
        public Guid Id { get; set; }
        public Rol Rol { get; set; }
        public Guid RolId { get; set; }
        public Modulo Modulo { get; set; }
        public Guid ModuloId { get; set; }
        public List<SelectListItem> rol { get; set; }
        public List<SelectListItem> modulo { get; set; }
    }
}
