using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public BookGenre Genre { get; set; }
        public int NumbersOfCopies { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
    }    
}
