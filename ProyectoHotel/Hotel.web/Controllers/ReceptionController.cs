using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Reception;
using Hotel.web.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.web.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly IReceptionService receptionService;

        HttpClientHandler clientHandler = new HttpClientHandler();
        public ReceptionController(IReceptionService receptionService) 
        {
            this.receptionService = receptionService;
        }
        // GET: ReceptionController
        public ActionResult Index()
        {
            ReceptionListResponse receptionList = new ReceptionListResponse();

            using(var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5274/api/Reception/GetReceptions").Result)
                {
                    if(response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        receptionList = JsonConvert.DeserializeObject<ReceptionListResponse>(apiResponse);

                        if(!receptionList.success)
                        {
                            ViewBag.Message = receptionList.message;
                            return View();
                        }
                            
                    }
                    else
                    {
                        receptionList.message = "Error conectandose al api.";
                        receptionList.success = false;
                        ViewBag.Message = receptionList.message;
                        return View();
                    }
                }
            }

            return View(receptionList.data);

        }

        // GET: ReceptionController/Details/5
        public ActionResult Details(int id)
        {
            ReceptionDetailResponse receptionDetailResponse = new ReceptionDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5274/api/Reception/GetReception?id={ id }";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        receptionDetailResponse = JsonConvert.DeserializeObject<ReceptionDetailResponse>(apiResponse);

                        if (receptionDetailResponse.success)
                            ViewBag.Message = receptionDetailResponse.message;
                    }
                }
            }

            return View(receptionDetailResponse.data);
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
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5274/api/Reception/SaveReception";

                    receptionDtoAdd.ChangeDate = DateTime.Now;
                    receptionDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(receptionDtoAdd), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }
                        }
                        else
                        {
                            baseResponse.message = "Error conectandose al api.";
                            baseResponse.success = false;
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

        // GET: ReceptionController/Edit/5
        public ActionResult Edit(int id)
        {
            ReceptionDetailResponse receptionDetailResponse = new ReceptionDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5274/api/Reception/GetReception?id={id}";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        receptionDetailResponse = JsonConvert.DeserializeObject<ReceptionDetailResponse>(apiResponse);
                    }
                }
            }

            return View(receptionDetailResponse.data);
        }
    

        // POST: ReceptionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReceptionDtoUpdate receptionDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5274/api/Reception/UpdateReception";

                    receptionDtoUpdate.ChangeDate = DateTime.Now;
                    receptionDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(receptionDtoUpdate),System.Text.Encoding.UTF8,"application/json");

                    using (var response = client.PostAsync(url,content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if(!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

    }
}
