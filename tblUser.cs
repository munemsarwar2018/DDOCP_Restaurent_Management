namespace P00196750_Mohammad_Munem_Sarwar_DDOOCP_Winter
{
    using System;
    using System.Collections.Generic;
   
    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            tblBookings = new HashSet<tblBooking>();
        }

     
        public int Uid { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string UserType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBooking> tblBookings { get; set; }
    }
}
