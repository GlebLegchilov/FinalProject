using System;
using System.Linq;
using System.Web.Mvc;
using Mvc.Infrastructure.Mappers;
using Mvc.Models;
using BLLInterface.Services;
using System.Web;
using System.IO;
using System.Collections.Generic;

namespace Mvc.Controllers
{
    public class LotController : Controller
    {
        private readonly IUserService userService;
        private readonly ILotService lotService;
        private readonly ICategoryService categoryService;

        public LotController(IUserService userService,  ILotService lotService, ICategoryService categoryService) { 
            this.userService = userService;
            this.lotService = lotService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var lots = lotService.GetAll().Select(l => l.ToLotViewModel());
            return View(lots);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int lotId)
        {
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);
            var lot = lotService.GetById(lotId).ToLotViewModel();
            return View(lot);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateLot()
        {

            ViewBag.Category = GetCategoryList();
            return View("");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLot(NewLotViewModel newLot, HttpPostedFileBase uploadImage)
        {
            ViewBag.Category = GetCategoryList();
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);
            if (lotService.Exist(newLot.ToBllLot()))
            {
                ModelState.AddModelError("", "Lot with this name already added");
                return View(newLot);
            }

            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    newLot.Img = imageData;
                }
                newLot.Creator = userService.GetUserId(User.Identity.Name);
                lotService.CreateLot(newLot.ToBllLot());
                

                return RedirectToAction("Index");

            }        
            return View( newLot);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditorLot(int lotId)
        {

            ViewBag.Category = GetCategoryList();
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);
            var lot = lotService.GetById(lotId).ToLotViewModel();
            return View( lot);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditorLot(LotViewModel editLot, HttpPostedFileBase uploadImage)
        {
            ViewBag.Category = GetCategoryList();
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);

            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    editLot.Img = imageData;
                }

                lotService.UdateLot(editLot.ToBllLot());

                return RedirectToAction("Index");

            }        
            return View( editLot);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLot(int lotId, string type)
        {
           
            lotService.DeleteLot(lotId);
            if (Request.IsAjaxRequest())
            {
                if (type == "PurchList")
                {
                    ViewBag.Purch = lotService.GetPurchaseLot(User.Identity.Name).Select(l => l.ToLotViewModel());
                    return PartialView("_LotsListPurch");
                }
                else
                {
                    ViewBag.myLots = lotService.GetMyLots(User.Identity.Name).Select(l => l.ToLotViewModel());
                    return PartialView("_LotsListMy");
                }

            }

            return RedirectToAction("MyLots");
        }

    


        [Authorize]
        public ActionResult MyLots()
        {
            ViewBag.Purch = lotService.GetPurchaseLot(User.Identity.Name).Select(l => l.ToLotViewModel());
            ViewBag.myLots = lotService.GetMyLots(User.Identity.Name).Select(l => l.ToLotViewModel());
            return View();
        }

        [Authorize]
        public ActionResult BuyLot(int lotId)
        {
            lotService.BuyLot(lotId, userService.GetByName(User.Identity.Name).Id);
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetCategoryList()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            var listCategory = categoryService.GetAll();
            foreach (var item in listCategory)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return listItems;
        }
    }
}