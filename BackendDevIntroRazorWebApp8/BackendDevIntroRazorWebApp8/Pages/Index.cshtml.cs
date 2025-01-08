using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BackendDevIntroRazorWebApp8.Models;
using BackendDevIntroRazorWebApp8.Services;

namespace BackendDevIntroRazorWebApp8.Pages
{
    public class IndexModel : PageModel
    {
        public List<Customer> customers;

        public void OnGet()
        {
            customers = CustomersService.GetAll();
        }
    }
}
