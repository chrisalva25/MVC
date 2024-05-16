using Tarea2.Data.Entidades;

namespace Tarea2.Models
{
    public class RolViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Metodo { get; set; }
        public string Controller { get; set; }
        public List<ModulosRolesViewModel> ModulosRoles { get; set; }
    }
}
