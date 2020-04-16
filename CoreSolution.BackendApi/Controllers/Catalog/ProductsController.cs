using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSolution.Application.Catalog.Products;
using CoreSolution.Models.Shop;
using CoreSolution.ViewModels.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreSolution.BackendApi.Controllers.Catalog
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IManageProductService _manageProductService;
        private readonly IPublicProductService _publicProductService;

        public ProductsController(IManageProductService manageProductService, IPublicProductService publicProductService)
        {
            _manageProductService = manageProductService;
            _publicProductService = publicProductService;
        }


        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetInfo(int productId, string languageId)
        {
            var product = await _manageProductService.GetInfo(productId, languageId);
            if (product == null)
                return BadRequest("Can't find product");
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery]ProductGetAllPagingRequest request, string languageId)
        {
            var products = await _publicProductService.GetAllPaging(languageId, request);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.IsValid);
            }

            var productId = await _manageProductService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }

            var product = await _manageProductService.GetInfo(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetInfo), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.IsValid);
            }

            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("productId")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _manageProductService.Delete(productId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("{productId}/price/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccess = await _manageProductService.UpdatePrice(productId, newPrice);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch("{productId}/stock/{addQuantity}")]
        public async Task<IActionResult> UpdateStock(int productId, int addQuantity)
        {
            var isSuccess = await _manageProductService.UpdateStock(productId, addQuantity);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch("{productId}/viewcount")]
        public async Task UpdateViewCount(int productId)
        {
            await _manageProductService.UpdateViewCount(productId);
        }
    }
}