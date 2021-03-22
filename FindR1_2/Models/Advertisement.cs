using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FindR1_2.Models
{
    public class Advertisement
    {
        [Key, Column("AdvertisementId")]
        public int Advertisement_Id { get; set; }

        //one - to - many
        public string ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public ApplicationUser Profile { get; set; }    //person who posted the ad

        //one - to - one
        public Housing Housing { get; set; }

        //public List<ApplicationUser> AttendeesList { get; set; }    //people who are already going to this housing (max number of people is the NoOfRooms of housing)
        public DateTime CheckInDate { get; set; }   //date of Check In
    }
}
