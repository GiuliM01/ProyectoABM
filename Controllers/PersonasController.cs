using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoABM.Models;

namespace ProyectoABM.Controllers
{
    public class PersonasController : Controller
    {
        public ProyectoDb Ctx { get; set; }

        public PersonasController(ProyectoDb ctx)
        {
            Ctx = ctx;
        }
        public IActionResult Listado(string valor)
        {
            var model = new PersonasListadoModel();
            var query = Ctx.Personas.AsQueryable();
            if (!string.IsNullOrEmpty(valor))
            {
                query = query.Where(x => x.Nombre.Contains(valor));
            }
            model.Listado = query.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(Personas modelo)
        {
            if (modelo.Id == 0)
            {
                Ctx.Personas.Add(modelo);
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
            Personas model;
            int Id = 0;
            int.TryParse(id, out Id);
            if (Id== 0)
            {
                model = new();
            }
            else
            {
                model = Ctx.Personas.Find(id);
            }
            

            return View(model);
        }
        public IActionResult Index(string id, string nombre, string direccion, string codigo)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int Id = 0;
                if (int.TryParse(id, out Id))
                {
                    Ctx.Personas.Add(new Personas { Id = Id, Nombre = nombre, Direccion = direccion, Codigo = codigo});
                    Ctx.SaveChanges();
                }
            }
            return View();
        }
    }
}
