using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinhThanhNam_241230799_DeThiMau2023.Models;

public partial class HangHoa
{
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên hàng không được để trống")]
    public string TenHang { get; set; } = null!;

    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(100,5000,ErrorMessage = "Giá phải là số từ 100 đến 5000")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"(?i)^.+\.(ipg|png|gif|tiff)$", ErrorMessage = "Ảnh phải có đuôi .ipg, .png, .gif, .tiff")]
    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
