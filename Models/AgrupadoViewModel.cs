using Tarea2.Data.Entidades;

namespace Tarea2.Models
{
    public class AgrupadoViewModel
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public List<ModuloViewModel> Modulos { get; set; }
    }
}
