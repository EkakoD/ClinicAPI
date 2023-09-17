using System;
namespace ClinicAPI.Application.Users.Query.GetDoctors
{
    public class DoctorsModel // Todo:  აქ უნდა ბაზის მოდელიდან გადმომეპვა
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Category { get; set; }
        public int Review { get; set; }
    }
}

