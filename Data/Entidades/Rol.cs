namespace Tarea2.Data.Entidades
{
    public class Rol
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion2 { get; set; }
        public bool Eliminado { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<ModulosRoles> ModulosRoles { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
        public Rol()
        {
            ModulosRoles = new HashSet<ModulosRoles>();
            Usuario = new HashSet<Usuario>();
        }
    }
}
