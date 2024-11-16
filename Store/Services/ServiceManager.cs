using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _prodcutService;
        private readonly ICategoryService _categoryService;

        private readonly IOrderService _orderService;

        private readonly IAuthService _authService;

        public ServiceManager(IProductService prodcutService, ICategoryService categoryService, IOrderService orderService, IAuthService authService)
        {
            _prodcutService = prodcutService;
            _categoryService = categoryService;
            _orderService = orderService;
            _authService = authService;
        }

        public IProductService ProductServices => _prodcutService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public IAuthService AuthService => _authService;
    }
}