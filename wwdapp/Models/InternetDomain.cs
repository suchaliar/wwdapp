//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wwdapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class InternetDomain
    {
        public int Id { get; set; }
        public Nullable<int> AccountID { get; set; }
        public string Registrant { get; set; }
        [Display(Name = "Domain Name")]
        public string DomainName { get; set; }
        [Display(Name = "Registrar Name")]
        public string RegistrarName { get; set; }
        [Display(Name = "Registrar Home Page")]
        public string RegistrarHomepage { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Display(Name = "Administrative Contact Name")]
        public string AdministrativeContactName { get; set; }
        public Nullable<int> AdministrativeContactInformationID { get; set; }
        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CreatedOn { get; set; }
        [Display(Name = "Expires On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ExpiresOn { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }
    }
}
