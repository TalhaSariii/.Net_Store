using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;




namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {

    private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            ViewData["Title"]="products";   
            var products= _manager.ProductServices.GetAllProductsWithDetails(p);
            var pagination=new Pagination()
            {
                CurrenPage =p.PageNumber,
                ItemsPerPage=p.PageSize,
                TotalItems=_manager.ProductServices.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products=products,
                Pagination=pagination
            });
           
        }

        public IActionResult Get([FromRoute(Name ="id")]int id)
        {
          var model=_manager.ProductServices.GetOneProduct(id,false);
          return View(model);
          
        }
    }
}