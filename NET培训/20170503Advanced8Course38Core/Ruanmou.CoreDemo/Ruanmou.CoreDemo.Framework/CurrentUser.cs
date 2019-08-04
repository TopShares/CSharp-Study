using System;
using System.ComponentModel.DataAnnotations;

namespace Ruanmou.CoreDemo.Framework
{
    public class CurrentUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }

        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public DateTime LoginTime { get; set; }
    }
}