using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Reception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.web.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly IReceptionService receptionService;
        public ReceptionController(IReceptionService receptionService) 
        {
            this.receptionService = receptionService;
        }
        // GET: ReceptionController
        public ActionResult Index()
        {
            var result = this.receptionService.GetAll();

            if (!result.Success)
            { 
                ViewBag.Message= result.Message;
                return View();
            }
            return View(result.Data);

        }

        // GET: ReceptionController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.receptionService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // GET: ReceptionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReceptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReceptionDtoAdd receptionDtoAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = this.receptionService.Save(receptionDtoAdd);

                if(!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        // GET: ReceptionController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.receptionService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var datos = (ReceptionDtoGetAll)result.Data;
            ReceptionDtoUpdate receptionDto = new ReceptionDtoUpdate() 
            { 
                ReceptionId = datos.ReceptionId, 
                ClientId = datos.ClientId,
                RoomId = datos.RoomId,
                EntryDate = datos.EntryDate,
                DepartureDate = datos.DepartureDate,
                ConfirmationDepartureDate = datos.ConfirmationDepartureDate,
                StartingPrice = datos.StartingPrice,
                Advancement = datos.Advancement,
                RemainingPrice = datos.RemainingPrice,
                TotalPaid = datos.TotalPaid,
                CostPenalty = datos.CostPenalty,
                Observation = datos.Observation,
                State = datos.State,
            };

            return View(receptionDto);
        }

        // POST: ReceptionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReceptionDtoUpdate receptionDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = this.receptionService.Update(receptionDtoUpdate);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        
    }
}
