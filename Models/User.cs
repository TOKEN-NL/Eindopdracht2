using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Eindopdracht2.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
