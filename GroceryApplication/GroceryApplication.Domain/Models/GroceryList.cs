namespace GroceryApplication.Domain.Models
{
    public class GroceryList
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}
