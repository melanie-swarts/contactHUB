using System;
using System.Collections.Generic;

namespace ContactHub.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Street { get; set; }
        public string BuildingApartment { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual IList<Province> Provinces { get; set; }
    }
}
