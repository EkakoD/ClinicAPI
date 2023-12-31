﻿using System;
namespace ClinicAPI.Application.Users.Query.GetUserDetails
{
    public class UserDetailsModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string ImageUrl { get; set; }
        public int? Review { get; set; }
        public int AppointmentCount { get; set; }
    }
}

