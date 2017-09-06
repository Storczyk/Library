using System.Collections.Generic;
using System.ComponentModel;

namespace Library.Application.Queries.Users
{
    public class UserQuery
    {
        [DisplayName("ID")]
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [DisplayName("Orders")]
        public int OrdersCount { get; set; }
    }
}
