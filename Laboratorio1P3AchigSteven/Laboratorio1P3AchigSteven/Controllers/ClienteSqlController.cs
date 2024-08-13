using Laboratorio1P3AchigSteven.Data;
using Microsoft.AspNetCore.Mvc;
using Laboratorio1P3AchigSteven.Models;

namespace Laboratorio1P3AchigSteven.Controllers
{
    public class ClienteSqlController : Controller
    {
        ClienteSqlDataAccessLayer objClienteDAL = new ClienteSqlDataAccessLayer();
        
        // GET: ClienteSqlController
        public ActionResult Index()
        {
            List<ClienteSql> listClient = new List<ClienteSql>();
            listClient = objClienteDAL.GetAllClientes().ToList();
            return View(listClient);
        }

        // GET: ClienteSqlController/Details/5
        public ActionResult Details(int id)
        {
            ClienteSql cliente = objClienteDAL.GetClienteById(id);
            return View(cliente);
        }

        // GET: ClienteSqlController/Create
        public ActionResult Create()
        {
            // Pasar una instancia vacía del modelo a la vista
            ClienteSql cliente = new ClienteSql();
            return View(cliente);
        }

        // POST: ClienteSqlController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ClienteSql cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objClienteDAL.InsertCliente(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                ViewBag.ErrorMessage = "Ocurrió un error al intentar guardar el cliente en el Controller. Inténtalo de nuevo.";
                return View();
            }
        }

        // GET: ClienteSqlController/Edit/5
        public ActionResult Edit(int id)
        {
            ClienteSql cliente = objClienteDAL.GetClienteById(id);
            return View(cliente);
        }

        // POST: ClienteSqlController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteSql cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objClienteDAL.UpdateCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }
                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteSqlController/Delete/5
        public ActionResult Delete(int id)
        {
            ClienteSql cliente = objClienteDAL.GetClienteById(id);
            return View(cliente);
        }

        // POST: ClienteSqlController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                objClienteDAL.DeleteCliente(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
