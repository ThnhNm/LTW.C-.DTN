using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinhThanhNam_241230799_DeThiMau2026.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public int MaTl { get; set; }

    [Required(ErrorMessage = "Tên sách không được để trống")]
    public string TenSach { get; set; } = null!;

    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(50,1000, ErrorMessage = "Giá phải là số từ 50 đến 1000")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"(?i)^.+\.(jpg|jepg|png|webp)$", ErrorMessage = "Ảnh phải có đuôi .jpg, .jepg, .png, .webp")]
    public string? Anh { get; set; }

    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
