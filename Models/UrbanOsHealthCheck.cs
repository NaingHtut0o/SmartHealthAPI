using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthAPI.Models
{
    public class UrbanOsHealthCheck
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("urban_os_id")]
        public string UrbanOsId { get; set; }

        [Column("check_date")]
        public DateOnly CheckDate { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
