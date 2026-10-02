using System.ComponentModel.DataAnnotations;

namespace Lab05.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [
            Display(Name = "Họ và tên"),
            Required(ErrorMessage = "Họ tên không được để trống"),
            MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 ký tự"),
            MaxLength(150, ErrorMessage = "Họ tên tối đa 150 ký tự")
        ]
        public string Name { get; set; }
    }
}
