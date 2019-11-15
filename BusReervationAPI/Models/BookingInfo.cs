using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BusReervationAPI.Models
{
    public class BookingInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username cannot be empty.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "UserMobile cannot be empty.")]
        
        public string UserMobile { get; set; }

        [Required(ErrorMessage = "Email cannot be empty.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

       
        public int BusInfoId { get; set; }

       
        public DateTime TravelDate { get; set; }
        public string SeatNo { get; set; }
    }
}
