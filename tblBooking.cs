namespace P00196750_Mohammad_Munem_Sarwar_DDOOCP_Winter
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblBooking
    {
        public int Id { get; set; }

        public int? Uid { get; set; }

       
        public string BookingType { get; set; }

      
        public DateTime? bookingStartDate { get; set; }

       
        public DateTime? bookingEndDate { get; set; }

        public int? TotalDays { get; set; }

        
        public decimal? Amount { get; set; }

        public virtual tblUser tblUser { get; set; }
    }
}
