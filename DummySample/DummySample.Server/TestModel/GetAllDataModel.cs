using Microsoft.EntityFrameworkCore;

namespace DummySample.Server.TestModel
{
    [Keyless]
    public class GetAllDataModel
    {
        public int? DemoID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? DeletedBy { get; set; }
    }
}
