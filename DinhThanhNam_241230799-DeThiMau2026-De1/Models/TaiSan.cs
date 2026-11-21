using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinhThanhNam_241230799_DeThiMau2026_De1.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên tài sản không được để trống")]
    public string TenTs { get; set; } = null!;

    [Required(ErrorMessage = "Nguyên giá không được để trống")]
    [Range(1,2000,ErrorMessage = "Nguyên giá phải là số từ 1 đến 2000")]
    public decimal? NguyenGia { get; set; }

    [RegularExpression(@"(?i)^.+\.(ipg|ipeg|png|webp)$",ErrorMessage = "Ảnh phải có đuôi .ipg,.ipeg,.png,.webp")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan MaLoaiNavigation { get; set; } = null!;
}
