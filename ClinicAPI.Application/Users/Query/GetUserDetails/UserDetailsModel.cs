using System;
namespace ClinicAPI.Application.Users.Query.GetUserDetails
{
    public class UserDetailsModel // Todo: user-ის ბაზის მოდელიდან გადმომეპვა
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; } //Todo: მოსაფიქრებელია ფოტოს როგორ შევინახავ
    }
}

