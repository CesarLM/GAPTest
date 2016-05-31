using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperZapatosDTO;
using SuperZapatosMVC.ServicesConsumer;
using SuperZapatosMVC.ServicesConsumer.Contracts;

namespace SuperZapatosMVC.Controllers
{
    public class StoreController : Controller
    {
        StoreConsumer _storeConsumer;
        public StoreController()
        {
            _storeConsumer = new StoreConsumer();
        }

        // GET: Store
        public ActionResult Index()
        {
            var stores = _storeConsumer.GetStores();
            return View(stores);
        }

        // GET: Store/Details/5
        public ActionResult Details(Guid id)
        {
            var store = _storeConsumer.GetStore(id);
            return View(store);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                StoreContract store = new StoreContract()
                {
                    Store = new Store()
                    {
                        Id = Guid.NewGuid(),
                        Name = collection["Name"],
                        Adress = collection["Adress"],
                    }
                };
                _storeConsumer.InsertStore(store);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(Guid id)
        {
            var store = _storeConsumer.GetStore(id);
            return View(store);
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                StoreContract store = new StoreContract()
                {
                    Store = new Store()
                    {
                        Id = new Guid(collection["Id"]),
                        Name = collection["Name"],
                        Adress = collection["Adress"],
                    }
                };
                _storeConsumer.UpdateStore(store);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(Guid id)
        {
            var store = _storeConsumer.GetStore(id);
            return View(store);
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                _storeConsumer.DeleteStore(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
