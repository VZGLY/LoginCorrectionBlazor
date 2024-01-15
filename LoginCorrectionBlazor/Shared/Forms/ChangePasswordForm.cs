using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCorrectionBlazor.Shared.Forms
{
    public class ChangePasswordForm
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
        [Compare("ConfirmationPassword")]
        public string Password { get; set; }

        [Required]
        public string ConfirmationPassword { get; set; }
    }
}
