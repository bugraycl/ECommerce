﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        [Display(Name = "Ürün")]
        public int ProductId { get; set; }

        [Display(Name = "Kalite")]
        public int Quantity { get; set; }

        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }

        [Display(Name = "Resim")]
        public string Image { get; set; }

        public int UserId { get; set; }
    }
}