namespace Tarea2.Data.Entidades
{
    public class AgrupadoModulos
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Modulo> Modulos { get; set; }
        public AgrupadoModulos()
        {
            Modulos = new HashSet<Modulo>();
        }
    }
}
