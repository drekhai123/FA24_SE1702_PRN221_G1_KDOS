using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Data.Models
{
    public partial class Account
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        public int? CustomerId { get; set; }

        public int? StaffId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual Staff? Staff { get; set; }
    }

}
