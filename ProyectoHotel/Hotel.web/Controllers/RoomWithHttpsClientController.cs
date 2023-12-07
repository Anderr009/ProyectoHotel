using Hotel.application.Core;
using Hotel.application.Dtos.Room;
using Hotel.web.Interface;
using Hotel.web.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Hotel.web.Controllers
{
    public class RoomWithHttpsClientController : Controller
    {
        private IRoomHttpService _iroomHttpService;      
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public RoomWithHttpsClientController(IRoomHttpService iroomHttpService)
        {
            _iroomHttpService = iroomHttpService;
        }

        // GET: RoomWithHttpsClientController
        public ActionResult Index()
        {
            RoomListResponse roomList  = new RoomListResponse();
            ServiceResult result = this._iroomHttpService.Get();
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
            
        }

        // GET: RoomWithHttpsClientController/Details/5
        public ActionResult Details(int id)
        {
            RoomListResponse roomList = new RoomListResponse();
            ServiceResult result = this._iroomHttpService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
          
        }

        // GET: RoomWithHttpsClientController/Create
        public ActionResult Create(RoomDtoAdd roomDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();
            RoomListResponse roomList = new RoomListResponse();
            ServiceResult result = this._iroomHttpService.Post(roomDtoAdd);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // POST: RoomWithHttpsClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomWithHttpsClientController/Edit/5
        public ActionResult Edit(int id)
        {

            RoomListResponse roomList = new RoomListResponse();
            ServiceResult result = this._iroomHttpService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // POST: RoomWithHttpsClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomDtoUpdate roomDtoUpdate)
        {
            RoomListResponse roomList = new RoomListResponse();
            ServiceResult result = this._iroomHttpService.Put(roomDtoUpdate);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
           
        }

        // GET: RoomWithHttpsClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomWithHttpsClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
