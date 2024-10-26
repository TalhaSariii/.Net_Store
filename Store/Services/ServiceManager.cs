using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _prodcutService;
        private readonly ICategoryService _categoryService;

        private readonly IOrderService _orderService;

        public ServiceManager(IProductService prodcutService, ICategoryService categoryService, IOrderService orderService)
        {
            _prodcutService = prodcutService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        public IProductService ProductServices => _prodcutService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;
    }
}