using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 4)]
        [Required(ErrorMessage = "Tên bắt buộc phải được nhập")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@gmail.com")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải được nhập")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9\s]).{8,}$",ErrorMessage = "Mật khẩu phải có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Branch bắt buộc phải được nhập")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Giới tính bắt buộc phải được chọn")]
        public Gender? Gender { get; set; }

        public bool IsRegular { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải được nhập")]
        public string? Address { get; set; }

        [Range(typeof(DateTime), "1/1/1963", "12/31/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải được nhập")]
        public DateTime DateOfBorth { get; set; }

        [Range(0.0, 10.0)]
        [Required(ErrorMessage = "Điểm bắt buộc phải được nhập")]
        public float? Diem { get; set; }
    }
}
