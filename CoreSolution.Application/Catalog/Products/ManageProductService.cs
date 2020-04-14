using CoreSolution.Common;
using CoreSolution.DBContext;
using CoreSolution.Models.Shop;
using CoreSolution.ViewModels.Catalog;
using System;
using System.Threading.Tasks;

namespace CoreSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
    }

    public class ManageProductService : IManageProductService
    {
        private readonly CoreDbContext _context;
        private readonly FileStorageService _fileStorageService;

        public ManageProductService(CoreDbContext coreDbContext, FileStorageService fileStorageService)
        {
            _context = coreDbContext;
            _fileStorageService = fileStorageService;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            //var product = new Product()
            //{ }
            throw new NotImplementedException();
        }

        public Task<int> Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
