namespace BookApplication.Order.cs.Entity
{
    public class ResponseEntity<T>
    {

        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
