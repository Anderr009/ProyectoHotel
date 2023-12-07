using Hotel.application.Contracts;
using Hotel.application.Dtos.Floor;
using Hotel.application.Dtos.Reception;
using Hotel.Web.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Hotel.Web.Controllers
{
    public class FloorController : Controller
    {
        HttpClientHandler clientHandler = new HttpClientHandler();

        // GET: StudentController
        public ActionResult Index()
        {
            FloorListResponse studentList = new FloorListResponse();

            //return View(new List<FloorViewResult>());

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5001/api/Floor/GetFloors").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        studentList = JsonConvert.DeserializeObject<FloorListResponse>(apiResponse);

                        if (!studentList.success)
                        {
                            ViewBag.Message = studentList.message;
                            return View();
                        }


                    }
                    else
                    {
                        studentList.message = "Error conectandose al api.";
                        studentList.success = false;
                        ViewBag.Message = studentList.message;
                        return View();
                    }
                }
            }

            return View(studentList.data);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {

            FloorDetailResponse studentDetailResponse = new FloorDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5001/api/Floor/GetFloor?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        studentDetailResponse = JsonConvert.DeserializeObject<FloorDetailResponse>(apiResponse);

                        if (!studentDetailResponse.success)
                            ViewBag.Message = studentDetailResponse.message;
                    }
                }
            }


            return View(studentDetailResponse.data);
        }




        //// GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FloorDtoAdd FloorDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5001/api/Floor/SaveFloor";

                    FloorDtoAdd.ChangeDate = DateTime.Now;
                    FloorDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(FloorDtoAdd), System.Text.Encoding.UTF8, "application/json");

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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            FloorDetailResponse floorDetailResponse = new FloorDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5001/api/Floor/GetFloor?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        floorDetailResponse = JsonConvert.DeserializeObject<FloorDetailResponse>(apiResponse);

                    }
                }
            }

            return View(floorDetailResponse.data);
        }

        public ActionResult Delete(int id)
        {
            FloorDetailResponse floorDetailResponse = new FloorDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {
                BaseResponse baseResponse = new BaseResponse();

                var url = $"http://localhost:5001/api/Floor/RemoveFloor";

                FloorDtoRemove floorDtoRemove = new FloorDtoRemove();
                floorDtoRemove.FloorId = id;
                floorDtoRemove.DateDeleted = DateTime.Now;
                floorDtoRemove.DeletedUserId = 1;
                floorDtoRemove.State = false;

                StringContent content = new StringContent(JsonConvert.SerializeObject(floorDtoRemove), System.Text.Encoding.UTF8, "application/json");

                using (var response = client.PostAsync(url, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                        if (!baseResponse.success)
                        {
                            ViewBag.Message = baseResponse.message;
                            return RedirectToAction(nameof(Index));
                        }

                    }
                    else
                    {
                        ViewBag.Message = baseResponse.message;
                        return RedirectToAction(nameof(Index));
                    }
                }
            }


            return RedirectToAction(nameof(Index));
        }



        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FloorDtoUpdate floorDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5001/api/Floor/UpdateFloor";

                    floorDtoUpdate.ChangeDate = DateTime.Now;
                    floorDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(floorDtoUpdate), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PutAsync(url, content).Result)
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
