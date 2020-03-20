using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Purchase
    {
        
        public int PurchaseId { get; set; }

        [Required]
        [Display(Name = "Клиент")]
        public string Person { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "ID книги")]
        public int BookId { get; set; }

        [Display(Name = "Дата заказа")]
        public DateTime Date { get; set; }
        
    }
}