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
    
    public partial class RemarkReply
    {
        public int RemarkReplyID { get; set; }
        public int RemarkCommentID { get; set; }
        public int UserID { get; set; }
        public string Reply_Content { get; set; }
        public Nullable<System.DateTime> Reply_Time { get; set; }
    
        public virtual RemarkComments RemarkComments { get; set; }
        public virtual RemarkComments RemarkComments1 { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
