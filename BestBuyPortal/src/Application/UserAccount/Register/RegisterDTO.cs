using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserAccount.Register
{
   public class RegisterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
