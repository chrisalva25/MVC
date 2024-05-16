namespace Tarea2.Data.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string NombreUsuario { get; set; }

        public string Contraseña { get; set; }

        public string Email { get; set; }

        public bool Eliminado { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CretedDate { get; set; }
        public Rol Rol { get; set; }
        public Guid RolId { get; set; }

    }
}
