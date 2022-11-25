using System.ComponentModel.DataAnnotations.Schema;

namespace SundSalgBackend.Models.DataTransferObjects
{
    [Table("Counselors")]
    public class CounselorDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Desc { get; set; }
        public string? Picture { get; set; }
    }
}
