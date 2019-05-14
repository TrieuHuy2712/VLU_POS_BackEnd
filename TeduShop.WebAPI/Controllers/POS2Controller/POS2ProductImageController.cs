using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Service.POS1Service;
using TeduShop.Service.POS2Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Infrastructure.Extensions;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers.POS2Controller
{
    [RoutePrefix("api/POS2productImage")]
    public class POS2ProductImageController : ApiControllerBase
    {
        private IPOS2ProductImageService _productImageService;

        public POS2ProductImageController(IPOS2ProductImageService productImageService, IErrorService errorService) : base(errorService)
        {
            _productImageService = productImageService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int productId)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _productImageService.GetAll(productId);

                IEnumerable<ProductImageViewModel> modelVm = Mapper.Map<IEnumerable<ProductImage>, IEnumerable<ProductImageViewModel>>(model);

                response = request.CreateResponse(HttpStatusCode.OK, modelVm);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductImageViewModel productImageVm)
        {
            if (ModelState.IsValid)
            {
                var newImage = new ProductImage();
                try
                {
                    newImage.UpdateProductImage(productImageVm);

                    _productImageService.Add(newImage);
                    _productImageService.Save();
                    return request.CreateResponse(HttpStatusCode.OK, productImageVm);
                }
                catch (Exception dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            _productImageService.Delete(id);
            _productImageService.Save();

            return request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}