using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(320)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string DoB { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
