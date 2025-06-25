using System.ComponentModel.DataAnnotations;

namespace HirefyAI.Application.DataTransferObjects.Auth.Google
{
    public class GoogleDto
    {
        [Required]
        public string IdToken { get; set; }
    }
}
