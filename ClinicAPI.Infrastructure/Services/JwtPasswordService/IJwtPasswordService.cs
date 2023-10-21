using System;
namespace ClinicAPI.Infrastructure.Services.JwtPasswordService
{
	public interface IJwtPasswordService
	{
        string HashPassword(string password);
        bool ValidatePassword(string password, string hashed);
        string GenerateJwtToken(string username,string role, long UserId);
        int GetUserId();
        //string GetRole();
    }
}

