﻿using System.ComponentModel.DataAnnotations;

namespace Eduhome_again.ViewModels
{
    public class LoginVM
    {
       

        [Required(ErrorMessage = "Bu xana bos ola bilmez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu xana bos ola bilmez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
