using Hotel.application.Contracts;
using Hotel.application.Dtos.Floor;
using Hotel.application.Dtos.Reception;
using Hotel.application.Dtos.RoUser;
using Hotel.Web.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Hotel.Web.Controllers
{
    public class RolUserController : Controller
    {
    

        HttpClientHandler clientHandler = new HttpClientHandler();

       

        // GET: StudentController
        public ActionResult Index()
        {
            RolUserListResponse RolUserList = new RolUserListResponse();

            //return View(new List<FloorViewResult>());

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5001/api/RolUser/GetRolUsers").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        RolUserList = JsonConvert.DeserializeObject<RolUserListResponse>(apiResponse);

                        if (!RolUserList.success)
                        {
                            ViewBag.Message = RolUserList.message;
                            return View();
                        }


                    }
                    else
                    {
                        RolUserList.message = "Error conectandose al api.";
                        RolUserList.success = false;
                        ViewBag.Message = RolUserList.message;
                        return View();
                    }
                }
            }

            return View(RolUserList.data);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {

            RolUserDetailResponse studentDetailResponse = new RolUserDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {
                
                var url = $"http://localhost:5001/api/RolUser/GetRolUser?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        studentDetailResponse = JsonConvert.DeserializeObject<RolUserDetailResponse>(apiResponse);

                        if (!studentDetailResponse.success)
                            ViewBag.Message = studentDetailResponse.message;


                    }
                }
            }


            return View(studentDetailResponse.data);
        }

          public ActionResult Delete(int id)
        {
            RolUserDetailResponse floorDetailResponse = new RolUserDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {
                BaseResponse baseResponse = new BaseResponse();

                var url = $"http://localhost:5001/api/RolUser/RemoveRolUser";

                RolUserDtoRemove floorDtoRemove = new RolUserDtoRemove();
                floorDtoRemove.UserRoleId = id;
                floorDtoRemove.DateDeleted = DateTime.Now;
                floorDtoRemove.DeletedUserId = 1;
                floorDtoRemove.State = false;
                floorDtoRemove.Description = "DELETE";

                StringContent content = new StringContent(JsonConvert.SerializeObject(floorDtoRemove), System.Text.Encoding.UTF8, "application/json");

                using (var response = client.PostAsync(url, content).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        

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
        //// GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolUserDtoAdd FloorDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5001/api/RolUser/SaveRolUser";

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
            RolUserDetailResponse floorDetailResponse = new RolUserDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5001/api/RolUser/GetRolUser?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        floorDetailResponse = JsonConvert.DeserializeObject<RolUserDetailResponse>(apiResponse);

                    }
                }
            }

            return View(floorDetailResponse.data);
        }


        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RolUserDtoUpdate floorDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5001/api/RolUser/UpdateRolUser";

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
