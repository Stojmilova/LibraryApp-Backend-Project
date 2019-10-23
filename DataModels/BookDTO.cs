using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels
{
    public class BookDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public int Genre { get; set; }
        public int NumbersOfCopies { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
