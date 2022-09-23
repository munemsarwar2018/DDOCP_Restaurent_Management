namespace P00196750_Mohammad_Munem_Sarwar_DDOOCP_Winter
{
    using System;
    using System.Collections.Generic;
  
    public partial class tblReview
    {
        public int Id { get; set; }

        public int? Uid { get; set; }

        public string Remarks { get; set; }

        public bool? isPublic { get; set; }

        public DateTime? reviewDate { get; set; }
    }
}
