using Hotel.application.Core;
using Hotel.application.Dtos.Client;
using Hotel.Web.Interface;
using Hotel.Web.Models.Response;
using Hotel.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Hotel.Web.Controllers
{
    
    public class ClientWithHttpsClientController : Controller
    {
        private IClientHttpService _iclientHttpService;
        private HttpClientHandler httpClientHandler = new HttpClientHandler();

        public ClientWithHttpsClientController(IClientHttpService iclientHttpService)
        {
            _iclientHttpService = iclientHttpService;
        }
        // GET: RoomWithHttpsClientController
        public ActionResult Index()
        {
            ClientListResponse roomList = new ClientListResponse();
            ServiceResult result = this._iclientHttpService.Get();
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
            ClientListResponse roomList = new ClientListResponse();
            ServiceResult result = this._iclientHttpService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);

        }

        // GET: RoomWithHttpsClientController/Create
        public ActionResult Create(ClientDtoAdd clientDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();
            ClientListResponse roomList = new ClientListResponse();
            ServiceResult result = this._iclientHttpService.Post(clientDtoAdd);
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

            ClientListResponse roomList = new ClientListResponse();
            ServiceResult result = this._iclientHttpService.GetById(id);
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
        public ActionResult Edit(ClientDtoUpdate roomDtoUpdate)
        {
            ClientListResponse roomList = new ClientListResponse();
            ServiceResult result = this._iclientHttpService.Put(roomDtoUpdate);
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
