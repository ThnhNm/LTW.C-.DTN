using System.ComponentModel.DataAnnotations;

namespace Lab05.Models
{
    public class Product
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

        [
            Display(Name = "Ảnh"),
            Required(ErrorMessage = "Ảnh không được để trống")
        ]
        public string Image { get; set; }

        [
            Display(Name = "Giá bán"),
            DataType(DataType.Text),
            Range(100000, float.MaxValue, ErrorMessage ="Giá phải lớn hơn hoặc bằng 100000"),
            Required(ErrorMessage = "Giá bán không được để trống")
        ]
        public float Price { get; set; }

        [
            Display(Name = "Giá giảm giá"),
            DataType(DataType.Text),
            Range(100000, float.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 100000"),
            Required(ErrorMessage = "Giá giảm giá không được để trống")
        ]
        public float SalePrice { get; set; }

        [
            Display(Name = "Mô tả sản phẩm"),
            MaxLength(1500,ErrorMessage ="Mô tả tối đa 1500 ký tự"),
            Required(ErrorMessage = "Mô tả không được để trống")
        ]
        public string Description { get; set; }


    }
}
