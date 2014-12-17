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
    
    public partial class Employee
    {
        public Employee()
        {
            this.BankDeposits = new HashSet<BankDeposit>();
            this.CLOUs = new HashSet<CLOU>();
            this.DeliveryMades = new HashSet<DeliveryMade>();
            this.DeliveryMades1 = new HashSet<DeliveryMade>();
            this.DeliveryReceiveds = new HashSet<DeliveryReceived>();
            this.DeliveryReceiveds1 = new HashSet<DeliveryReceived>();
            this.ExpenditureEvents = new HashSet<ExpenditureEvent>();
            this.PaymentReceiveds = new HashSet<PaymentReceived>();
            this.Procedures = new HashSet<Procedure>();
            this.ProjectEvents = new HashSet<ProjectEvent>();
            this.SoftwareInstallations = new HashSet<SoftwareInstallation>();
            this.SupportEvents = new HashSet<SupportEvent>();
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int Id { get; set; }
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Display(Name = "Last")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DOB { get; set; }
        public string SSN { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<int> EmployeeTypeID { get; set; }
        public Nullable<int> ContactInformationID { get; set; }
    
        public virtual ICollection<BankDeposit> BankDeposits { get; set; }
        public virtual ICollection<CLOU> CLOUs { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }
        public virtual ICollection<DeliveryMade> DeliveryMades { get; set; }
        public virtual ICollection<DeliveryMade> DeliveryMades1 { get; set; }
        public virtual ICollection<DeliveryReceived> DeliveryReceiveds { get; set; }
        public virtual ICollection<DeliveryReceived> DeliveryReceiveds1 { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public virtual ICollection<ExpenditureEvent> ExpenditureEvents { get; set; }
        public virtual ICollection<PaymentReceived> PaymentReceiveds { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }
        public virtual ICollection<ProjectEvent> ProjectEvents { get; set; }
        public virtual ICollection<SoftwareInstallation> SoftwareInstallations { get; set; }
        public virtual ICollection<SupportEvent> SupportEvents { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
