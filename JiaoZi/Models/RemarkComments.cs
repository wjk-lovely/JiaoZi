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
    
    public partial class RemarkComments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RemarkComments()
        {
            this.RemarkReply = new HashSet<RemarkReply>();
            this.RemarkReply1 = new HashSet<RemarkReply>();
        }
    
        public int RemarkCommentID { get; set; }
        public Nullable<System.DateTime> Comment_Time { get; set; }
        public string Comment_Content { get; set; }
        public int UserID { get; set; }
        public int RemarkID { get; set; }
    
        public virtual Remarks Remarks { get; set; }
        public virtual Remarks Remarks1 { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RemarkReply> RemarkReply { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RemarkReply> RemarkReply1 { get; set; }
    }
}
