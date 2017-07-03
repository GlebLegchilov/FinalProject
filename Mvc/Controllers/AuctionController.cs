using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Mvc.Infrastructure;
using Mvc.Infrastructure.Providers;
using Mvc.Models;
using BLLInterface.Services;
using Mvc.Infrastructure.Mappers;

namespace Mvc.Controllers
{
    public class AuctionController : Controller
    {

        private readonly IUserService userService;
        private readonly IAuctionService auctionService;
        private readonly ILotService lotService;
        private readonly IRateService rateService;

        public AuctionController( IAuctionService auctionService, IUserService userService, ILotService lotService, IRateService rateService)
        {
            this.userService = userService;
            this.lotService = lotService;
            this.auctionService = auctionService;
            this.rateService = rateService;
        }

        // GET: Auction
        public ActionResult Index()
        {
            var auctions = auctionService.GetAllAuction().Select(l => l.ToViewModelAuction());
            return View(auctions);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateAuction()
        {
            ViewBag.Lots = GetLotsList();
            //var lotsList = lotService.GetOwnerLots(User.Identity.Name).Select(u => u.ToLotViewModel());
            //ViewBag.Lots = lotsList;
            return View();
        }

        [HttpPost]
        [Authorize]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateAuction(AuctionViewModel newAuction)
        {
       
            //var lotsList = lotService.GetOwnerLots(User.Identity.Name).Select(u => u.ToLotViewModel());
            //foreach (var item in ViewBag.LotsToAuction)
            //{
            //    lotsList = lotsList.Where(l => l.Id != item);
            //}
            //ViewBag.Lots = lotsList;
            if (ModelState.IsValid)
            {
                newAuction.AvailabilityStatus = true;
                newAuction.CreatorId = userService.GetUserId(User.Identity.Name);
                var au = newAuction.ToBllAuction();
                au.LotId = lotService.GetLot(newAuction.LotId).Id;
                auctionService.CreateAuction(au);

                return RedirectToAction("Index");

            }
            ViewBag.Lots = GetLotsList();
            return View(newAuction);
        }

        [Authorize]
        public ActionResult AddLot(int LotId)
        {
            

            var lotsList = lotService
                .GetOwnerLots(User.Identity.Name)
                .Where(l=>l.Id!=LotId)
                .Select(u => u.ToLotViewModel());
            ViewBag.Lots = lotsList;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_LotsList");
            }
            ViewBag.Lot = LotId;
            return View("CreateAuction");
        }

        
        public ActionResult Details(int auctionId)
        {
           
            var auct  = auctionService.GetAuction(auctionId).ToViewModelAuction();
            ViewBag.Lot = lotService.GetLot(int.Parse(auct.LotId)).ToLotViewModel();
            return View(auct);
        }

 
        [Authorize]
        public ActionResult BuyAuction(int auctionId)
        {
            var auc = auctionService.GetAuction(auctionId);
           
                var user = userService.GetUserId(User.Identity.Name);
                var value = auc.Price;
    
                rateService.AddRate(new BLLInterface.Entities.RateEntity()
                    {
                        AuctionId = auctionId,
                        UserId = user,
                        Value = value
                    });
            

            auctionService.Buy(auctionId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddRate(AuctionViewModel model)
        {

            var auc = auctionService.GetAuction(model.Id);

            if (auctionService.PriceValid(auc, model.Price))
            {
                var user = userService.GetUserId(User.Identity.Name);
                var value = model.Price;
                rateService.AddRate(new BLLInterface.Entities.RateEntity()
                {
                    AuctionId = model.Id,
                    UserId = user,
                    Value = value
                });
                return RedirectToAction("Details", model.Id);

            }
            return View();
        }

        private List<string> GetLotsList()
        {
            List<String> listItems = new List<String>();
            var listCategory = lotService.GetOwnerLots(User.Identity.Name).Select(u => u.ToLotViewModel());
            foreach (var item in listCategory)
            {
                listItems.Add(item.Name);
            }
            return listItems;
        }
    }
}