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
    public class ArticleController : Controller
    {
        ArticleConsumer _articleConsumer;
        StoreConsumer _storeConsumer;
        public ArticleController()
        {
            _articleConsumer = new ArticleConsumer();
            _storeConsumer = new StoreConsumer();
        }

        // GET: Article
        public ActionResult Index()
        {
            var stores = _articleConsumer.GetArticles();
            return View(stores);
        }

        // GET: Article/Details/5
        public ActionResult Details(Guid id)
        {
            ViewBag.Stores = _storeConsumer.GetStores();
            var store = _articleConsumer.GetArticle(id);
            return View(store);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            ViewBag.Stores = _storeConsumer.GetStores().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                
                ArticleContract article = new ArticleContract()
                {
                    Article = new Article()
                    {
                        Id = Guid.NewGuid(),
                        Name = collection["Name"],
                        Description = collection["Description"],
                        Price = double.Parse(collection["Price"]),
                        Total_In_Shelf = Int32.Parse(collection["Total_In_Shelf"]),
                        Total_In_Vault = Int32.Parse(collection["Total_In_Vault"]),
                        StoreId = Guid.Parse(collection["StoreId"])
                    }
                };
                _articleConsumer.InsertArticle(article);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.Stores = _storeConsumer.GetStores().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            var store = _articleConsumer.GetArticle(id);
            return View(store);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                ArticleContract article = new ArticleContract()
                {
                    Article = new Article()
                    {
                        Id = new Guid(collection["Id"]),
                        Name = collection["Name"],
                        Description = collection["Description"],
                        Price = double.Parse(collection["Price"]),
                        Total_In_Shelf = Int32.Parse(collection["Total_In_Shelf"]),
                        Total_In_Vault = Int32.Parse(collection["Total_In_Vault"]),
                        StoreId = Guid.Parse(collection["StoreId"])
                    }
                };
                _articleConsumer.UpdateArticle(article);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(Guid id)
        {
            var store = _articleConsumer.GetArticle(id);
            return View(store);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                _articleConsumer.DeleteArticle(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
