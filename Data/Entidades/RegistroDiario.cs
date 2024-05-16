namespace Tarea2.Data.Entidades
{
    public class RegistroDiario
    {
        public Guid Id { get; set; }

        public decimal TotalDia { get; set; }

        public decimal Combustible { get; set; }

        public decimal PagoBase { get; set; }

        public decimal PagoConductor { get; set; }

        public decimal PagoDueño { get; set; }

        public decimal Gastos { get; set; }

        public string Observacion { get; set; }

        public bool Eliminado { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid UsuarioId { get; set; }

        public Guid TaxiId { get; set; }

        public Taxi Taxi { get; set; }

        public DateTime Fecha { get; set; }

        public static RegistroDiario Create(decimal totalDia, decimal combustible, decimal pagoBase, decimal pagoConductor, decimal pagoDueño, decimal gastos,
            string observacion, Taxi taxi, DateTime fecha)
        {
            return new RegistroDiario
            {
                TotalDia = totalDia,
                Combustible = combustible,
                PagoBase = pagoBase,
                PagoConductor = pagoConductor,
                PagoDueño = pagoDueño,
                Gastos = gastos,
                Observacion = observacion,
                Taxi = taxi,
                TaxiId = taxi.Id,
                Fecha = fecha,
                Eliminado = false,
                CreatedDate = DateTime.Now,
                UsuarioId = Guid.NewGuid()
            };
        }
     }
}
