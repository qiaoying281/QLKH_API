//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLKH_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentHistory
    {
        public int paymentHistoryID { get; set; }
        public int studentID { get; set; }
        public int paymentTypeID { get; set; }
        public string paymentName { get; set; }
        public int amount { get; set; }
        public System.DateTime createAt { get; set; }
        public System.DateTime updateAt { get; set; }
    
        public virtual PaymentType PaymentType { get; set; }
        public virtual Student Student { get; set; }
    }
}
