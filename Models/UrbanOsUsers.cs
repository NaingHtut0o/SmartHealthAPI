using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthAPI.Models
{
    public class UrbanOsUsers
    {
        [Column("urban_os_id")]
        public string UrbanOsId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
