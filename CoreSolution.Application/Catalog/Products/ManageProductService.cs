using CoreSolution.Common;
using CoreSolution.Common.Exceptions;
using CoreSolution.DBContext;
using CoreSolution.Models.Shop;
using CoreSolution.ViewModels.Catalog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addQuantity);
        Task UpdateViewCount(int productId);
        Task<int> Delete(int productId);
        Task<ProductViewModel> GetInfo(int productId, string langueId);
    }

    public class ManageProductService : IManageProductService
    {
        private readonly CoreDbContext _context;
        private readonly IStorageService _iStorageService;

        public ManageProductService(CoreDbContext coreDbContext, IStorageService iStorageService)
        {
            _context = coreDbContext;
            _iStorageService = iStorageService;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    }
                }
            };

            _context.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId); 
            if (product == null) throw new CoreException($"Cannot find a product with id: {productId}");

            _context.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductViewModel> GetInfo(int productId, string languageId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new CoreException($"Cannot find a product with id: {productId}");

            var productTransaction = await _context.ProductTranslations.FirstAsync(x => x.ProductId == productId && x.LanguageId == languageId);
            var productViewModel = new ProductViewModel()
            {
                Id = productId,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
                DateCreated = product.DateCreated,

                Name = productTransaction != null ? productTransaction.Name : null,
                Description = productTransaction != null ? productTransaction.Description : null,
                Details = productTransaction != null ? productTransaction.Details : null,
                SeoDescription = productTransaction != null ? productTransaction.SeoDescription : null,
                SeoTitle = productTransaction != null ? productTransaction.SeoTitle : null,
                SeoAlias = productTransaction != null ? productTransaction.SeoAlias : null,
                LanguageId = productTransaction.LanguageId
            };
            return productViewModel;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);

            if (product == null || productTranslations == null) throw new CoreException($"Cannot find a product with id: {request.Id}");

            productTranslations.Name = request.Name;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoAlias = request.SeoAlias;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new CoreException($"Can't find with product id: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new CoreException($"Can't find with product id: {productId}");
            product.Stock += addQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new CoreException($"Can't find with product id: {productId}");
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }
    }
}
