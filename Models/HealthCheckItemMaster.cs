using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthAPI.Models
{
    public class HealthCheckItemMaster
    {
        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("item_name")]
        public string ItemName { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
