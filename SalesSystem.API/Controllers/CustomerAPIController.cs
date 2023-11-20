using Dapper;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using SalesSystem.API.Model;
using System.Data;
using System.Xml.Linq;

namespace SalesSystem.API.Controllers
{
    [Route("api/CustomerAPI")]

    [ApiController]
	public class CustomerAPIController: ControllerBase
	{


        private IConfiguration _config;
		private IDbConnection _dbcon;
		public CustomerAPIController(IConfiguration config)
        {
			_config = config;
			_dbcon = new OracleConnection(_config.GetConnectionString("DefaultConnection"));
		}
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            
            string sql = @"Select 
                              CUSTOMER_ID CustomerId, 
                              FNAME       FirstName, 
                              LNAME       LastName, 
                              PHONENR     PhoneNr, 
                              CREATED_DT  CreatedDt, 
                              EMAIL       Email
                           from Customers order by Customer_id desc";
            Console.WriteLine(sql);
            IEnumerable<Customer> returnList = _dbcon.Query<Customer>(sql);
            return Ok( returnList);
	}
	    [HttpGet("custid", Name = "GetCustomerByID")]
        public ActionResult<Customer> GetCustomerByID(int id)
        {

            string sql = @"Select 
                              CUSTOMER_ID CustomerId, 
                              FNAME       FirstName, 
                              LNAME       LastName, 
                              PHONENR     PhoneNr, 
                              CREATED_DT  CreatedDt, 
                              EMAIL       Email
                           from Customers where CUSTOMER_ID = " + id.ToString();

            Customer customer = _dbcon.QuerySingle<Customer>(sql);
            return Ok(customer);
        }
        [HttpPost]
        public ActionResult AddCustomer( Customer customer)
        {
            string sql = @" insert into Customers(FNAME, LNAME, PHONENR,EMAIL) VALUES("
                + "' " + customer.FirstName 
				+ "', '" + customer.LastName 
				+ "', '" + customer.PhoneNr 
				+ "', '" + customer.Email + "')";

            int recCnt =_dbcon.Execute(sql);
            if (recCnt == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }

        }
	}
}
