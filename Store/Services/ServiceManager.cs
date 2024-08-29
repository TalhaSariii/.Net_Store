using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _prodcutService;
        private readonly ICategoryService _categoryService;

        public ServiceManager(IProductService prodcutService, ICategoryService categoryService)
        {
            _prodcutService = prodcutService;
            _categoryService = categoryService;
        } 

        public IProductService ProductServices => _prodcutService;

        public ICategoryService CategoryService => _categoryService;    
    }
}