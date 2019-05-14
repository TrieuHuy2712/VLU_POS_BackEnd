using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Data.POS2Infrastructure;
using TeduShop.Data.Repositories.POS1Repository;
using TeduShop.Data.Repositories.POS2Repository;
using TeduShop.Model.Models;

namespace TeduShop.Service.POS2Service
{
    public interface IPOS2ProductImageService
    {
        void Add(ProductImage productImage);

        void Delete(int id);

        List<ProductImage> GetAll(int productId);

        void Save();
    }

    public class POS2ProductImageService : IPOS2ProductImageService
    {
        private IPOS2ProductImageRepository _productImageRepository;
        private IPOS2UnitOfWork _unitOfWork;

        public POS2ProductImageService(IPOS2ProductImageRepository productImageRepository, IPOS2UnitOfWork unitOfWork)
        {
            this._productImageRepository = productImageRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(ProductImage productImage)
        {
            _productImageRepository.Add(productImage);
        }

        public void Delete(int id)
        {
            _productImageRepository.Delete(id);
        }

        public List<ProductImage> GetAll(int productId)
        {
            return _productImageRepository.GetMulti(x => x.ProductId == productId).ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
