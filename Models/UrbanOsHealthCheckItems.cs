using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthAPI.Models
{
    public class UrbanOsHealthCheckItems
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("health_check_id")]
        public int HealthCheckId { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("item_value")]
        public string ItemValue { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
