using Microsoft.AspNetCore.Mvc.Formatters;

namespace SalesSystem.API.Model
{
	public class Customer
	{
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string PhoneNr  { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDt { get; set; }

        public Customer()
        {

            if (FirstName == null)
            {
                FirstName = string.Empty;
            }
			if (LastName == null)
			{
				LastName = string.Empty;
			}
			if (PhoneNr == null)
			{
				PhoneNr = string.Empty;
			}
			if (Email == null)
			{
				Email = string.Empty;
			}
		}
	}
}
