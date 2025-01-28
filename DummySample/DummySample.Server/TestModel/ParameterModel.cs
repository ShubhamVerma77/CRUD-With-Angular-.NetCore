namespace DummySample.Server.TestModel
{
    public class ParameterModel
    {
        public class GetBYIDModel
        {
            public int ID { get; set; }
        }

        public class DeleteModel
        {
            public int ID { get; set; }

        }
        public class UpadteModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
        }
        public class InsertDataParamsmodel
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Type { get; set; }
        }

        public class UpdateParamModel
        {
            public int? DemoID { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Type { get; set; }
        }

        public class DeleteParamModel
        {
            public int? DemoID { get; set; }
        }
    }
}
