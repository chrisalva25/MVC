using Microsoft.AspNetCore.Mvc.Rendering;
using Tarea2.Data.Entidades;

namespace Tarea2.Models
{
    public class RegistroDiarioViewModel
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

        public TaxiViewModel Taxi { get; set; }

        public List<SelectListItem> Taxis { get; set; }

        public DateTime Fecha { get; set; }

        public AppResult ValidarModelo()
        {
            if(TotalDia < 0)
            {
                return AppResult.NoSuccess("Total del día no puede ser negativo.");
            }
            if(Combustible < 0)
            {
                return AppResult.NoSuccess("Nivel de combustible no puede ser negativo.");
            }
            if (PagoBase < 0)
            {
                return AppResult.NoSuccess("Pago base no puede ser negativo");
            }
            if (PagoConductor < 0)
            {
                return AppResult.NoSuccess("Pago de conductor no puede ser negativo.");
            }
            if (PagoDueño < 0)
            {
                return AppResult.NoSuccess("Pago al dueño no puede ser negativo.");
            }
            if (Gastos < 0)
            {
                return AppResult.NoSuccess("Gastos no pueden ser negativo.");
            }
            if (TaxiId.Equals(Guid.Empty))
            {
                return AppResult.NoSuccess("Debe seleccionar un taxi");
            }
            return AppResult.Success("Datos validos", null);
        }
    }
}
