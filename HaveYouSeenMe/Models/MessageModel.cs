using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaveYouSeenMe.Models
{
    public class MessageModel
    {
        [Required(ErrorMessage = "Please type your name.")]
        [StringLength(150, ErrorMessage = "You can only use 150 characters")]
        public string From { get; set; }
        [Required(ErrorMessage = "Please enter your email.")]
        [StringLength(150, ErrorMessage = "You can only use 150 characters")]
        public string Email { get; set; }
        [Phone]
        [DisplayFormat(ConvertEmptyStringToNull = true, DataFormatString = "(###) ###-####", ApplyFormatInEditMode = true)]
        public string PhoneNumber { get; set; }
        [FileExtensions(Extensions =".jpg, png")]
        public string TypeOfEmail { get; set; }
        [StringLength(150, ErrorMessage = "You can only use 150 characters")]
        public string Subject { get; set; }
        [StringLength(150, ErrorMessage = "You can only use 150 characters")]
        [Required (ErrorMessage ="Please type your message")]
        [AllowHtml]

        public string Message { get; set; }
  
    }
}