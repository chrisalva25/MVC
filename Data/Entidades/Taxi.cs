using Tarea2.Models;

namespace Tarea2.Data.Entidades
{
    public class Taxi
    {
        public Guid Id { get; set; }

        public string Placa { get; set; }

        public string Observacion { get; set; }

        public bool Eliminado { get; set; }

        public Guid UsuarioId { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<RegistroDiario> Registros { get; set; }

        public Taxi()
        {
            Registros = new HashSet<RegistroDiario>();
        }

        public static Taxi Create(string placa, string observacion, Usuario usuario)
        {
            return new Taxi
            {
                Placa = placa,
                Observacion = observacion,
                CreatedDate = DateTime.Now,
                UsuarioId = usuario.Id
            };
        }
    }
}
