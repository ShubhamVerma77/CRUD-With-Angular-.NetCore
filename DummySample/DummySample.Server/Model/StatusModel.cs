namespace DummySample.Server.Model
{
    public class StatusModel<T>
    {
        public bool IsComplete { get; set; }
        public int Status { get; set; }
        public string Message {  get; set; }
        public T Data { get; set; }
    }
}
