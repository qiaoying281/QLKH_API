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
    
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.Students = new HashSet<Student>();
            this.Tutors = new HashSet<Tutor>();
        }
    
        public int accountID { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public int decentralizationId { get; set; }
        public string resetPasswordToken { get; set; }
        public Nullable<System.DateTime> resetPasswordTokenExpiry { get; set; }
        public System.DateTime createAt { get; set; }
        public System.DateTime updateAt { get; set; }
    
        public virtual Decentralization Decentralization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tutor> Tutors { get; set; }
    }
}