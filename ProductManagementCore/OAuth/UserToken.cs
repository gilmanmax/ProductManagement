using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Core
{
    public class UserToken : DataClass
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(150)]
        public string SiteName { get; set; }
        public string AccessTokenString {  get; set; }
        public DateTime? AccessExpiration {  get; set; }
        public string RefreshTokenString { get; set; }
        public DateTime? RefreshExpiration { get; set; }
        public User User { get; set; }
    }
}
