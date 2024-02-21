using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace AppView.Controllers
{
    public class SinhvienController : Controller
    {
        public SinhvienController()
        {

        }
        public async Task<IActionResult> Index() // Lấy ra tất cả danh sách sinh viên
        {
            // Call API ở đây
            string requestURL = "https://localhost:7146/api/AppAPI/get-all-sv";
            var HttpClient = new HttpClient();
            var response = await HttpClient.GetAsync(requestURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var sinhviens = JsonConvert.DeserializeObject<List<Sinhvien>>(apiData);
            return View(sinhviens); // truyền list vừa nhận được sang view
        }
        public async Task<IActionResult> Details(string id) // Xem thông tin của từng sinh viên
        {
            // Call API ở đây
            string requestURL = $"https://localhost:7146/api/AppAPI/get-sv-by-id?id={id}";
            var HttpClient = new HttpClient();
            var response = await HttpClient.GetAsync(requestURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var sinhvien = JsonConvert.DeserializeObject<Sinhvien>(apiData);
            return View(sinhvien); // truyền list vừa nhận được sang view
        }
        public ActionResult Create() // action này để hiển thị view tạo rỗng
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Sinhvien sv) // Thực hiện lấy data từ view và thêm vào csdl
        {
            // Call API ở đây
            string requestURL = $"https://localhost:7146/api/AppAPI/them-sinh-vien";
            var HttpClient = new HttpClient();
            var response = await HttpClient.PostAsJsonAsync(requestURL, sv); // truyền cả obj theo request url
            if (response.IsSuccessStatusCode) // nếu thực thi thành công thì ngay lập tức cho về trang index
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        public async Task<ActionResult> Edit(string id) // action này để hiển thị view tạo rỗng
        { // vìa là sửa nên chúng ta cần truyền được dữ liệu của sv sang
            string requestURL = $"https://localhost:7146/api/AppAPI/get-sv-by-id?id={id}";
            var HttpClient = new HttpClient();
            var response = await HttpClient.GetAsync(requestURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var sinhvien = JsonConvert.DeserializeObject<Sinhvien>(apiData);
            return View(sinhvien); // truyền list vừa nhận được sang view
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Sinhvien sv) // Thực hiện lấy data từ view và sửa trong csdl
        {
            // Call API ở đây
            string requestURL = $"https://localhost:7146/api/AppAPI/sua-sinh-vien";
            var HttpClient = new HttpClient();
            var response = await HttpClient.PostAsJsonAsync(requestURL, sv); // truyền cả obj theo request url
            if (response.IsSuccessStatusCode) // nếu thực thi thành công thì ngay lập tức cho về trang index
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id) // Thực hiện lấy data từ view và xóa trong csdl
        {
            // Call API ở đây
            string requestURL = $"https://localhost:7146/api/AppAPI/delete-by-id?id={id}";
            var HttpClient = new HttpClient();
            var response = await HttpClient.GetAsync(requestURL); // truyền cả obj theo request url
            if (response.IsSuccessStatusCode) // nếu thực thi thành công thì ngay lập tức cho về trang index
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
    }
}
