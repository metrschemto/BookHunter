using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHunterManagment.Classes
{
    class Book
    {
        public string ID { get; set; }
        public string book_name { get; set; }
        public string book_genre { get; set; }
        public string book_author { get; set; }
        public string books_in_storage { get; set; }
        public string book_cost { get; set; }
        public string publishing_house { get; set; }
        public string age_restriction { get; set; }
        public string publishing_year { get; set; }
        public string pages_count { get; set; }
        public string book_circulation { get; set; }
        public string book_image_path { get; set; }
    }
}
