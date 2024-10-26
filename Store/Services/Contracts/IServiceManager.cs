namespace Services.Contracts
{
    public interface IServiceManager
    {
        IProductService ProductServices {get;}

        ICategoryService CategoryService {get;}

        IOrderService OrderService{get;}
    }
}