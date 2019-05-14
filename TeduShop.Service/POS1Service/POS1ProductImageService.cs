using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Data.Repositories.POS1Repository;
using TeduShop.Model.Models;

namespace TeduShop.Service.POS1Service
{
    public interface IPOS1ProductImageService
    {
        void Add(ProductImage productImage);

        void Delete(int id);

        List<ProductImage> GetAll(int productId);

        void Save();
    }

    public class POS1ProductImageService : IPOS1ProductImageService
    {
        private IPOS1ProductImageRepository _productImageRepository;
        private IPOS1UnitOfWork _unitOfWork;

        public POS1ProductImageService(IPOS1ProductImageRepository productImageRepository, IPOS1UnitOfWork unitOfWork)
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
