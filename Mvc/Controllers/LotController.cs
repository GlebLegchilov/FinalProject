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

        public LotController(IUserService userService,  ILotService lotService) { 
            this.userService = userService;
            this.lotService = lotService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var lots = lotService.GetAllLots().Select(l => l.ToLotViewModel());
            return View(lots);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int lotId)
        {
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);
            var lot = lotService.GetLot(lotId).ToLotViewModel();
            //lot.Image = imageService.GetImageByLoId(lotId);
            return View(lot);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateLot()
        {

           
            return View("");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLot(NewLotViewModel newLot, HttpPostedFileBase uploadImage)
        {
           
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);
            if (lotService.IsExist(newLot.Id))
            {
                ModelState.AddModelError("", "Lot with this name already added");
                return View(newLot);
            }

            if (ModelState.IsValid)
            {
                newLot.OwnerId = userService.GetUserId(User.Identity.Name);
                var lot = newLot.ToBllLot();
                if (uploadImage != null)
                    lot.Image = uploadImage.ToImage();


                lotService.CreateLot(lot);

                return RedirectToAction("Index");

            }        
            return View( newLot);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditorLot(int lotId)
        {

          
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);
            var lot = lotService.GetLot(lotId).ToLotViewModel();
            return View( lot);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditorLot(LotViewModel editLot, HttpPostedFileBase uploadImage)
        {
          
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);
            var lot = editLot.ToBllLot();
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                    lot.Image = uploadImage.ToImage();
                

                lotService.UdateLot(lot);

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
                //if (type == "PurchList")
                //{
                //    ViewBag.Purch = lotService.GetPurchaseLot(User.Identity.Name).Select(l => l.ToLotViewModel());
                //    return PartialView("_LotsListPurch");
                //}
                //else
                //{
                //    ViewBag.myLots = lotService.GetMyLots(User.Identity.Name).Select(l => l.ToLotViewModel());
                //    return PartialView("_LotsListMy");
                //}

            }

            return RedirectToAction("MyLots");
        }

    


        [Authorize]
        public ActionResult MyLots()
        {
            //ViewBag.Purch = lotService.GetOwnerLots(User.Identity.Name).Select(l => l.ToLotViewModel());
            ViewBag.myLots = lotService.GetOwnerLots(User.Identity.Name).Select(l => l.ToLotViewModel());
            return View();
        }

        [Authorize]
        public ActionResult BuyLot(int lotId)
        {
            //lotService.BuyLot(lotId, userService.GetByName(User.Identity.Name).Id);
            return RedirectToAction("Index");
        }

       


      

    }
}