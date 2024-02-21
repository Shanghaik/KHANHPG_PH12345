using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Sinhvien
    {
        [Key]
        public string MaSV { get; set; }
        [MaxLength(30, ErrorMessage = "Tên có độ dài tối đa là 30 kí tự")]
        public string Ten { get; set; }
        [Range(18, 30, ErrorMessage = "Tuổi phải nằm trong phạm vi từ 18 đến 30")]
        [Required(ErrorMessage ="Phải nhập tuổi")]
        public int Tuoi { get; set; }
        public string Lop { get; set; }
        [EmailAddress(ErrorMessage = "Email sai quy tắc")]
        public string Email { get; set; }
        [Range(0.0F, 10.0F, ErrorMessage = "Phạm vi điểm từ 0.0 đến 10.0")]
        public float DiemTB { get; set; }
        public bool TrangThai { get; set; }

    }
}
