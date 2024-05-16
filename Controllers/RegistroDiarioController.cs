using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tarea2.Data;
using Tarea2.Data.Entidades;
using Tarea2.Models;

namespace Tarea2.Controllers
{
    public class RegistroDiarioController : Controller
    {
        private readonly ILogger<RegistroDiarioController> _logger;
        private readonly Tarea2DBContext _dbContext;

        public RegistroDiarioController(ILogger<RegistroDiarioController> logger, Tarea2DBContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }

        public IActionResult Index()
        {
            var registros = _dbContext.RegistrosDiarios.Where(r=> r.Eliminado == false).ProjectToType<RegistroDiarioViewModel>().ToList();
            return View(registros);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            TempData["mensaje"] = null;
            var nuevoRegistro = new RegistroDiarioViewModel();
            nuevoRegistro.Fecha = DateTime.Now;
            nuevoRegistro.Taxis = _dbContext.Taxis.Where(t => t.Eliminado == false).ProjectToType<TaxiViewModel>().ToList().ConvertAll<SelectListItem>(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Placa,
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });

            return View(nuevoRegistro);
        }

        [HttpPost]
        public IActionResult Insertar(RegistroDiarioViewModel registroDiario)
        {
            var valido = registroDiario.ValidarModelo();
            if (!valido.IsValid)
            {
                registroDiario.Taxis = _dbContext.Taxis.Where(t => t.Eliminado == false).ProjectToType<TaxiViewModel>().ToList().ConvertAll<SelectListItem>(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.Placa,
                        Value = t.Id.ToString(),
                        Selected = false
                    };
                });
                TempData["mensaje"] = valido.Message;
                return View(registroDiario);
            }

            var taxi = _dbContext.Taxis.FirstOrDefault(t => t.Eliminado == false && t.Id == registroDiario.TaxiId);

            var nuevoRegistro = RegistroDiario.Create(
                registroDiario.TotalDia,
                registroDiario.Combustible,
                registroDiario.PagoBase,
                registroDiario.PagoConductor,
                registroDiario.PagoDueño,
                registroDiario.Gastos,
                registroDiario.Observacion,
                taxi,
                registroDiario.Fecha);

            _dbContext.RegistrosDiarios.Add(nuevoRegistro);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Guid registroId)
        {
            TempData["mensaje"] = null;
            var registroActual = _dbContext.RegistrosDiarios.Where(r => r.Eliminado == false && r.Id == registroId)
                .ProjectToType<RegistroDiarioViewModel>().FirstOrDefault();
            registroActual.Taxis = _dbContext.Taxis.Where(t => t.Eliminado == false).ProjectToType<TaxiViewModel>().ToList().ConvertAll<SelectListItem>(t =>
             {
                 return new SelectListItem()
                 {
                     Text = t.Placa,
                     Value = t.Id.ToString(),
                     Selected = false
                 };
             });
            return View(registroActual);
        }

        [HttpPost]
        public IActionResult Editar(RegistroDiarioViewModel registroDiario)
        {
            var valido = registroDiario.ValidarModelo();
            if (!valido.IsValid)
            {
                registroDiario.Taxis = _dbContext.Taxis.Where(t => t.Eliminado == false).ProjectToType<TaxiViewModel>().ToList().ConvertAll<SelectListItem>(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.Placa,
                        Value = t.Id.ToString(),
                        Selected = false
                    };
                });
                TempData["mensaje"] = valido.Message;
                return View(registroDiario);
            }

            var taxi = _dbContext.Taxis.FirstOrDefault(t => t.Eliminado == false && t.Id == registroDiario.TaxiId);
            var registroActual = _dbContext.RegistrosDiarios.FirstOrDefault(r => r.Eliminado == false && r.Id == registroDiario.Id);
            registroActual.TotalDia = registroDiario.TotalDia;
            registroActual.Combustible = registroDiario.Combustible;
            registroActual.PagoBase = registroDiario.PagoBase;
            registroActual.PagoConductor = registroDiario.PagoConductor;
            registroActual.PagoDueño = registroDiario.PagoDueño;
            registroActual.Gastos = registroDiario.Gastos;
            registroActual.Observacion = registroDiario.Observacion;
            registroActual.TaxiId = taxi.Id;
            registroActual.Taxi = taxi;
            registroActual.Fecha = registroDiario.Fecha;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(Guid registroId)
        {
            TempData["mensaje"] = null;
            var registroActual = _dbContext.RegistrosDiarios.Where(r => r.Eliminado == false && r.Id == registroId)
                .ProjectToType<RegistroDiarioViewModel>().FirstOrDefault();
            registroActual.Taxis = _dbContext.Taxis.Where(t => t.Eliminado == false).ProjectToType<TaxiViewModel>().ToList().ConvertAll<SelectListItem>(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Placa,
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            return View(registroActual);
        }

        [HttpPost]
        public IActionResult Eliminar(RegistroDiarioViewModel registroDiario)
        {
            
            var registroActual = _dbContext.RegistrosDiarios.FirstOrDefault(r => r.Eliminado == false && r.Id == registroDiario.Id);
            registroActual.Eliminado = true;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    
}
