using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tarea2.Data;
using Tarea2.Data.Entidades;
using Tarea2.Models;

namespace Tarea2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private Tarea2DBContext _dbContext;

        public UsuarioController(ILogger<UsuarioController> logger, Tarea2DBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new UsuarioViewModel());
        }
        [HttpPost]

        public IActionResult Index(UsuarioViewModel vm)
        {
            var usuario = _dbContext.Usuarios.Where(w => w.Eliminado == false & w.Email == vm.Email).ProjectToType<UsuarioViewModel>().FirstOrDefault();
            if (usuario == null)
            {
                ViewBag.Error = "Usuario o la contraseña no existen";
                return View(new UsuarioViewModel());
            }
            if (usuario.Contraseña != Utilidades.Utilidades.GetMD5(vm.Contraseña))
            {
                ViewBag.Error = "Usuario o la contraseña no existen";
                return View(new UsuarioViewModel());
            }
            var modulosroles = _dbContext.ModulosRoles.Where(w => w.Eliminado == false && w.RolId == usuario.Rol.Id).ProjectToType<ModulosRolesViewModel>().ToList();
            var agrupadosid = modulosroles.Select(s => s.Modulo.AgrupadoModulosId).Distinct().ToList();
            var agrupados = _dbContext.AgrupadoModulos.Where(w => agrupadosid.Contains(w.Id)).ProjectToType<AgrupadoViewModel>().ToList();
            foreach (var item in agrupados)
            {
                var modulosactuales = modulosroles.Where(w => w.Modulo.AgrupadoModulosId == item.Id).Select(s => s.Modulo.Id).Distinct().ToList();
                item.Modulos = item.Modulos.Where(w => modulosactuales.Contains(w.Id)).ToList();
            }
            usuario.Menu = agrupados;
            var sessionjson = JsonConvert.SerializeObject(usuario);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(sessionjson);
            var sesionbas64 = System.Convert.ToBase64String(plainTextBytes);
            HttpContext.Session.SetString("UsuarioObjeto", sesionbas64);
            return RedirectToAction("Index", "Home");
        }
    }


}
