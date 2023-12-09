using Hotel.application.Contract;
using Hotel.application.Core;
using Hotel.application.Dtos;
using Hotel.application.Dtos.User;
using Hotel.web.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        HttpClientHandler clientHandler = new HttpClientHandler();
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        //Get: UserController
        public ActionResult Index()
        {
            UserListResponse userList = new UserListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5125/api/User/GetUsers").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        userList = JsonConvert.DeserializeObject<UserListResponse>(apiResponse);

                        if (!userList.success)
                        {
                            ViewBag.Message = userList.message;
                            return View();
                        }

                    }
                    else
                    {
                        userList.message = "Error conectandose al api.";
                        userList.success = false;
                        ViewBag.Message = userList.message;
                        return View();
                    }
                }
            }

            return View(userList.data);

        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            UserDetailResponse userDetailResponse = new UserDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5125/api/User/GetUser?UserId={id}";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        userDetailResponse = JsonConvert.DeserializeObject<UserDetailResponse>(apiResponse);

                        if (userDetailResponse.success)
                            ViewBag.Message = userDetailResponse.message;
                    }
                }
            }

            return View(userDetailResponse.data);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDtoAdd userDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5125/api/User/SaveUser";

                    userDtoAdd.ChangeDate = DateTime.Now;
                    userDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(userDtoAdd), System.Text.Encoding.UTF8, "application/json");

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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            UserDetailResponse userDetailResponse = new UserDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5125/api/User/GetUser?UserId={id}";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        userDetailResponse = JsonConvert.DeserializeObject<UserDetailResponse>(apiResponse);
                    }
                }
            }

            return View(userDetailResponse.data);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDtoUpdate userDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5125/api/User/UpdateUser";

                    userDtoUpdate.ChangeDate = DateTime.Now;
                    userDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(userDtoUpdate), System.Text.Encoding.UTF8, "application/json");

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
