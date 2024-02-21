using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppAPI : ControllerBase
    {
        AppDbContext context = new AppDbContext(); // có thể gán thẳng cho chắc
        public AppAPI()
        {
            context = new AppDbContext();
        }
        [HttpGet("tinh-khoi-luong")]
        public double TinhKhoiLuong(double r, double d)
        {
            return 4 / 3 * 3.14 * r * r * r * d;
        }
        [HttpGet("get-all-sv")]
        public List<Sinhvien> GetAllSV()
        {
            return context.Sinhviens.ToList();
        }
        [HttpGet("get-sv-by-id")]
        public Sinhvien GetSVByID(string id)
        {
            return context.Sinhviens.Find(id);
            // return context.Sinhviens.FirstOrDefault(p => p.MaSV == id);
            // return context.Sinhviens.SingleOrDefault(p => p.MaSV == id);
        }
        [HttpPost("them-sinh-vien")]
        public bool CreateSinhvien(Sinhvien sinhvien)
        {
            try
            {
                context.Sinhviens.Add(sinhvien);
                context.SaveChanges();
                return true;    
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("sua-sinh-vien")]
        public bool UpdateSinhvien(Sinhvien sinhvien)
        {
            try
            {
                // Tìm đối tượng cần sửa
                var sv = context.Sinhviens.Find(sinhvien.MaSV);
                sv.Ten = sinhvien.Ten;
                sv.Lop = sinhvien.Lop;
                sv.Email = sinhvien.Email;
                context.Sinhviens.Update(sv);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet("delete-by-id")]
        public bool DeleteByID(string id)
        {
            try
            {
                var sv = context.Sinhviens.Find(id);
                context.Sinhviens.Remove(sv);
                context.SaveChanges();
                return true;    
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
