using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummySample.Server.Model
{
    public class Demo

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DemoID { get; set; }
        public string Name { get; set; }
        public string? EID { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? DeletedBy { get; set; }
    }
}
