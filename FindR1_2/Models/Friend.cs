using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FindR1_2.Models
{
    public class Friend
    {
        //If Person1 is friend with Person2 so does the opposite
        [Key, Column("FriendId")]
        public int Friend_Id { get; set; }

        public int Person1Id { get; set; }
        public int Person2Id { get; set; }
    }
}
