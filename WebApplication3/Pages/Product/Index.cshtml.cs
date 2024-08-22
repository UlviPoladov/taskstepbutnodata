using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Entities;
using WebApplication3.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<WebApplication3.Entities.Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetAllProductsAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync(WebApplication3.Entities.Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(product);
                return RedirectToPage();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync(WebApplication3.Entities.Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(product);
                return RedirectToPage();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToPage();
        }
    }
}
