using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FindR1_2.Models
{
    public class CompleteAddress
    {
        [Key, Column("CompleteAddressId")]
        public int CompleteAddress_Id { get; set; }
        public string Street { get; set; }
        public string Floor { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }


        //one - to - many
        public int AddressId { get; set; }
        public Address Address { get; set; }


        //one - to - one
        public int HousingId { get; set; }
        public Housing Housing { get; set; }
    }
}
