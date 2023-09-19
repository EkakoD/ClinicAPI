namespace ClinicAPI.Infrastructure.Models
{
    public class TempCodeModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
