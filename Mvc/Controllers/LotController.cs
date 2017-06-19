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
        [Authorize]
        public ActionResult Index()
        {

            return View(lotService.GetAll().Select(l => l.ToLotViewModel()));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int lotId)
        {
            var lot = lotService.GetById(lotId).ToLotViewModel();
            return View(lot);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateLot()
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
          
            ViewBag.Category = listItems;
            return View("LotEditor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLot(NewLotViewModel newLot, HttpPostedFileBase uploadImage)
        {
            var someLot = lotService.GetAll().Any(l => l.Name.Contains(newLot.Name));
            if (someLot)
            {
                ModelState.AddModelError("", "Lot with this name already added");
                return View("LotEditor", newLot);
            }

            if (ModelState.IsValid )
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
                
                var userEntity = userService.GetUserEntityByName(User.Identity.Name);
                var id = userEntity.Id;
                newLot.Creator = userService.GetUserEntityByName(User.Identity.Name).Id;
                newLot.AddedDate = DateTime.Now;
                lotService.CreateLot(newLot.ToBllLot());

                return RedirectToAction("Index");
            }
            return View("LotEditor", newLot);
        }


        [Authorize]
        public ActionResult BuyLot(int lotId)
        {
            lotService.BuyLot(lotId, userService.GetUserEntityByName(User.Identity.Name).Id);
            return RedirectToAction("Index");
        }
    }
}