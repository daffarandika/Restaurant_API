namespace WebApplication1.Models
{
    public class OrderDTO
    {
        public int orderID { get; set; }
        public string member { get; set; }
        public string employee { get; set; }
        public string payment { get; set; }
        public string bank { get; set; }
        public DateTime date { get; set; }
        public List<DetailorderDTO> orders { get; set; }
    }
}
