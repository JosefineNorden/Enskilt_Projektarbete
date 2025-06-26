using Enskilt_Projektarbete.Data;
using Enskilt_Projektarbete.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibruary.Models;
using ClassLibruary.DTOs;

namespace Enskilt_Projektarbete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly PadelBookingContext _context;

        public CustomerController(PadelBookingContext context)
        {
            _context = context;
        }

        [HttpGet("basic")]
        public async Task<ActionResult<IEnumerable<CustomerBasicResponse>>> GetBasicCustomers()
        {
            var customers = await _context.Customers
                .Select(c => new CustomerBasicResponse
                {
                    Name = c.Name,
                    Email = c.Email
                })
                .ToListAsync();

            if (customers == null || customers.Count == 0)
            {
                return NotFound("Inga kunder hittades.");
            }

            return Ok(customers);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CustomerWithBookingsResponse>>> GetCustomer(int id)
        {
            var customer = await _context.Customers
        .Where(c => c.Id == id)
        .Select(c => new CustomerWithBookingsResponse
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Bookings = c.Bookings.Select(b => new BookingInfo
            {
                Id = b.Id,
                CourtNumber = b.CourtNumber,
                StartTime = b.StartTime,
                EndTime = b.EndTime
            })
        })
        .FirstOrDefaultAsync();

            if (customer == null)
                return NotFound("Kunden hittades inte.");

            return Ok(customer);
        }


        [HttpPost(Name = "Create customer")]
        public async Task<ActionResult> CreateCustomer(CreateCustomerDTO newCustomer)
        {
            if (newCustomer == null)
            {
                return BadRequest(new { errorMessage = "Ingen kunddata skickades." });
            }

            if (string.IsNullOrWhiteSpace(newCustomer.Name) || string.IsNullOrWhiteSpace(newCustomer.Email))
            {
                return BadRequest(new { errorMessage = "Namn och e-post får inte vara tomt." });
            }

            var customerToAdd = new Customer
            {
                Name = newCustomer.Name,
                Email = newCustomer.Email
            };

            _context.Customers.Add(customerToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customerToAdd.Id }, customerToAdd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer updatedCustomer)
        {
            if (id != updatedCustomer.Id)
            {
                return BadRequest("Id i URL matchar inte Id i objektet.");
            }

            if (string.IsNullOrWhiteSpace(updatedCustomer.Name) || string.IsNullOrWhiteSpace(updatedCustomer.Email))
            {
                return BadRequest("Namn och e-post får inte vara tomt.");
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound("Kunden hittades inte.");
            }

            customer.Name = updatedCustomer.Name;
            customer.Email = updatedCustomer.Email;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}", Name = "Delete customer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound(new { errorMessage = "Kunden hittades inte." });
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
