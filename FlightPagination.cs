using Flight_Planner.Models;

namespace Flight_Planner
{
    public class FlightPagination
    {
        private int _currentPage = 0;

        private int _itemsPerPage = 10;

        private List<Flight> _items;

        private List<FlightPage> _listOfFlightPages = new List<FlightPage>();

        public FlightPagination(List<Flight> items)
        {
            _items = items;
            CreatePages();
        }

        public FlightPage GetPage()
        {
            var page = _listOfFlightPages.Count <= _currentPage ? new FlightPage() : _listOfFlightPages[_currentPage];
            return page;
        }

        private void CreatePages()
        {
            var totalItems = _items.Count;
            var totalPages = (int)Math.Ceiling(totalItems / (decimal)_itemsPerPage);

            for (var page = 0; page < totalPages; page++)
            {
                var flightPage = CreateFlightPage(page);

                _listOfFlightPages.Add(flightPage);
            }
        }

        private FlightPage CreateFlightPage(int desiredPage)
        {
            var page = new FlightPage()
            {
                Page = desiredPage,
                TotalItems = _items.Count
            };

            for (var i = 0; i < _itemsPerPage; i++)
            {
                var itemIndex = (desiredPage * _itemsPerPage) + i;

                if (itemIndex < _items.Count)
                {
                    page.AddFlight(_items[itemIndex]);
                }
            }

            return page;
        }
    }
}
