namespace Flight_Planner.Core.Models
{
    public class FlightPage
    {
        public int Page { get; set; }

        public int TotalItems { get; set; }

        public List<Flight> Items { get; set; }

        public FlightPage(int page, int totalItems, List<Flight> items)
        {
            Page = page;
            TotalItems = totalItems;
            Items = items;
        }
    }
}
