using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace QLBanHang.Models;

public partial class HangHoa
{
   
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    public string TenHang { get; set; } = null!;

    [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000")]
	[RegularExpression(@"^\d*\.?\d+$", ErrorMessage = "Vui lòng nhập một số.")]
	public decimal? Gia { get; set; }

    [Required]
    [RegularExpression(@"^.*\.(jpg|png|gif|tiff)$", ErrorMessage = "Tên file phải có đuôi .jpg, .png, .gif, hoặc .tiff")]
    public string? Anh { get; set; }

    [BindNever]
    
	public virtual LoaiHang? MaLoaiNavigation { get; set; } = null!;
}
