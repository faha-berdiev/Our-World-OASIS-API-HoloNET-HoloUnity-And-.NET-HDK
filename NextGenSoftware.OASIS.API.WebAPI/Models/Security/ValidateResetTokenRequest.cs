using System.ComponentModel.DataAnnotations;

namespace NextGenSoftware.OASIS.API.ONODE.WebAPI.Models.Security
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}