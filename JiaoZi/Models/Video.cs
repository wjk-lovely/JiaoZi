//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JiaoZi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Video
    {
        public int VideoID { get; set; }
        public string VideoPath { get; set; }
        public Nullable<int> downloadcount { get; set; }
        public Nullable<System.DateTime> Video_Time { get; set; }
        public int UserID { get; set; }
        public string Videoname { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
