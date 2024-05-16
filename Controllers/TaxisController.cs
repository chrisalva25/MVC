using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tarea2.Data;
using Tarea2.Data.Entidades;
using Tarea2.Models;

namespace Tarea2.Controllers
{
    public class TaxisController : Controller
    {
        private readonly ILogger<TaxisController> _logger;
        private readonly Tarea2DBContext _dbContext;

        public TaxisController(ILogger<TaxisController> logger, Tarea2DBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var registros = _dbContext.Taxis.Where(r => r.Eliminado == false).ProjectToType<TaxiViewModel>().ToList();
            foreach(var taxi in registros)
            {
                taxi.Usuario = _dbContext.Usuarios.Where(u => u.Eliminado == false && u.Id == taxi.UsuarioId).ProjectToType<UsuarioViewModel>().FirstOrDefault();
            }
            return View(registros);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            TempData["mensaje"] = null;
            var nuevoRegistro = new TaxiViewModel();
            nuevoRegistro.Usuarios = _dbContext.Usuarios.Where(t => t.Eliminado == false).ProjectToType<UsuarioViewModel>().ToList().ConvertAll<SelectListItem>(t =>
            {
                return new SelectListItem()
                {
                    Text = t.NombreUsuario,
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            return View(nuevoRegistro);
        }

        [HttpPost]
        public IActionResult Insertar(TaxiViewModel taxi)
        {
            var valido = taxi.ValidarModelo();
            if (!valido.IsValid)
            {
                taxi.Usuarios = _dbContext.Usuarios.Where(t => t.Eliminado == false).ProjectToType<UsuarioViewModel>().ToList().ConvertAll<SelectListItem>(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.NombreUsuario,
                        Value = t.Id.ToString(),
                        Selected = false
                    };
                });
                TempData["mensaje"] = valido.Message;
                return View(taxi);
            }

            var usuario = _dbContext.Usuarios.FirstOrDefault(t => t.Eliminado == false && t.Id == taxi.UsuarioId);

            var nuevoRegistro = Taxi.Create(taxi.Placa, taxi.Observacion, usuario);

            _dbContext.Taxis.Add(nuevoRegistro);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Guid taxiId)
        {
            TempData["mensaje"] = null;
            var registroActual = _dbContext.Taxis.Where(r => r.Eliminado == false && r.Id == taxiId)
                .ProjectToType<TaxiViewModel>().FirstOrDefault();
            registroActual.Usuarios = _dbContext.Usuarios.Where(t => t.Eliminado == false).ProjectToType<UsuarioViewModel>().ToList().ConvertAll<SelectListItem>(t =>
            {
                return new SelectListItem()
                {
                    Text = t.NombreUsuario,
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            return View(registroActual);
        }

        [HttpPost]
        public IActionResult Editar(TaxiViewModel taxi)
        {
            var valido = taxi.ValidarModelo();
            if (!valido.IsValid)
            {
                taxi.Usuarios = _dbContext.Usuarios.Where(t => t.Eliminado == false).ProjectToType<UsuarioViewModel>().ToList().ConvertAll<SelectListItem>(t =>
                {
                    return new SelectListItem()
                    {
                        Text = t.NombreUsuario,
                        Value = t.Id.ToString(),
                        Selected = false
                    };
                });
                TempData["mensaje"] = valido.Message;
                return View(taxi);
            }

            var usuario = _dbContext.Usuarios.FirstOrDefault(t => t.Eliminado == false && t.Id == taxi.UsuarioId);
            var registroActual = _dbContext.Taxis.FirstOrDefault(r => r.Eliminado == false && r.Id == taxi.Id);
            registroActual.Placa = taxi.Placa;
            registroActual.Observacion = taxi.Observacion;
            registroActual.UsuarioId = usuario.Id;            
            
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(Guid taxiId)
        {
            TempData["mensaje"] = null;
            var registroActual = _dbContext.Taxis.Where(r => r.Eliminado == false && r.Id == taxiId)
                .ProjectToType<TaxiViewModel>().FirstOrDefault();
            registroActual.Usuarios = _dbContext.Usuarios.Where(t => t.Eliminado == false).ProjectToType<UsuarioViewModel>().ToList().ConvertAll<SelectListItem>(t =>
            {
                return new SelectListItem()
                {
                    Text = t.NombreUsuario,
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            return View(registroActual);
        }

        [HttpPost]
        public IActionResult Eliminar(TaxiViewModel taxi)
        {
            
            var registroActual = _dbContext.Taxis.FirstOrDefault(r => r.Eliminado == false && r.Id == taxi.Id);
            registroActual.Eliminado = true;

            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
