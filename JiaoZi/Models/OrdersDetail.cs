using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace JiaoZi.Models
{
    public class OrdersDetail
    {
        [Display(Name="勾选")]
        public bool CheckBox { get; set; }

        [Display(Name ="图片")]
        public string Image { get; set; }


        [Display(Name ="数量")]
        public int Num { get; set; }


        [Display(Name ="单价")]
        public double Price { get; set; }


        [Display(Name ="小计")]
        public double Sum { get; set; }

        public IEnumerable<OrderDetails> O { get; set; }
    }
}