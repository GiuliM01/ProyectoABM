using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoABM.Models;

namespace ProyectoABM.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly ProyectoDb Ctx;

        public FacturacionController(ProyectoDb _ctx)
        {
            Ctx = _ctx;
        }

        public IActionResult Listado(string valor)
        {
            var model = new FacturacionListadoModel();
            var query = Ctx.Facturaciones.AsQueryable();
            if (!string.IsNullOrEmpty(valor))
            {
                query = query.Where(x => x.Cliente.Contains(valor));
            }
            model.Clientes = query.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(Facturacion modelo)
        {
            if (modelo.Id == 0)
            {
                Ctx.Facturaciones.Add(modelo);
            }
            else
            {
                Ctx.Attach(modelo);
                Ctx.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            Ctx.SaveChanges();
            return View(modelo);
        }
        public IActionResult Editar(string id)
        {
            Facturacion model;
            int Id = 0;
            int.TryParse(id, out Id);
            if (Id == 0)
            {
                model = new();
            }
            else
            {
                model = Ctx.Facturaciones.Find(id);
            }


            return View(model);
        }
        public IActionResult Index(string id, string Cliente, string Numero, string Precio)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int Id = 0;
                if (int.TryParse(id, out Id))
                {
                    Ctx.Facturaciones.Add(new Facturacion { Id = Id, Cliente = Cliente, Numero = Numero, Precio = Precio });
                    Ctx.SaveChanges();
                }
            }
            return View();




        }
    }
}
