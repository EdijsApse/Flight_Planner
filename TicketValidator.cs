namespace Flight_Planner
{
    public class TicketValidator
    {
        private FlightTicket _ticket;

        public List<string> Errors = new List<string>();

        public TicketValidator(FlightTicket ticket)
        {
            _ticket = ticket;

            ValidateTicket();
        }

        public bool HasErrors()
        {
            return Errors.Count > 0;
        }

        private void ValidateTicket()
        {
            ValidateFromCode();
            ValidateToCode();
            ValidateDepartureTime();
            ValidateAirportUniqueness();
        }

        private void ValidateFromCode()
        {
            if (IsValidString(_ticket.From)) Errors.Add("Airport From Code is not valid!");
        }

        private void ValidateToCode()
        {
            if (IsValidString(_ticket.From)) Errors.Add("Airport To Code is not valid!");
        }

        private void ValidateDepartureTime()
        {
            if (IsValidString(_ticket.DepartureDate)) Errors.Add("Departure time is not valid!");

            DateTime departureTime;

            DateTime.TryParse(_ticket.DepartureDate, out departureTime);

            if (departureTime == default) Errors.Add("Departure time format is not valid!");
        }

        private void ValidateAirportUniqueness()
        {
            if (_ticket.From.Equals(_ticket.To)) Errors.Add("Airport From and To is the same!");
        }

        private bool IsValidString(string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
