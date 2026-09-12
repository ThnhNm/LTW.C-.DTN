using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Bai1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        //Danh sách các cuốn sách
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book(){
                    Id = 1,
                    Title = "Dế Mèn phiêu lưu ký",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b1.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book(){
                    Id = 2,
                    Title = "Yêu trên từng ngón tay",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "/images/products/b2.jpg",
                    Price = 340000,
                    Sumary = "",
                    TotalPage = 134
                },
                new Book(){
                    Id = 3,
                    Title = "Harry Potter và Bảo Bối Tử Thần",
                    AuthorId = 3,
                    GenreId = 3,
                    Image = "/images/products/b3.jpg",
                    Price = 570000,
                    Sumary = "",
                    TotalPage = 157
                },
                new Book(){
                    Id = 4,
                    Title = "Tua and the Elephant",
                    AuthorId = 4,
                    GenreId = 4,
                    Image = "/images/products/b4.jpg",
                    Price = 670000,
                    Sumary = "",
                    TotalPage = 167
                }
            };
            return books;
        }

        //Chi tiết một cuốn sách theo id
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        //SelectListItem Authors
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1", Text="Nam Cao"},
            new SelectListItem {Value="2", Text="Ngô Tất Tố"},
            new SelectListItem {Value="3", Text="Adamkhoom"},
            new SelectListItem {Value="4", Text="Thiền sư Thích Nhất Hạnh"}
        };

        //SelectListItem Genres
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1", Text="Truyện tranh"},
            new SelectListItem {Value="2", Text="Văn học đương đại"},
            new SelectListItem {Value="3", Text="Phật học phổ thông"},
            new SelectListItem {Value="4", Text="Truyện cười"}
        };
    }
}
