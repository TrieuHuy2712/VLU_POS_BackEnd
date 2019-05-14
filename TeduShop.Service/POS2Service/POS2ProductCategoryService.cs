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
    public interface IPOS2ProductCategoryService
    {
        ProductCategory Add(ProductCategory ProductCategory);

        void Update(ProductCategory ProductCategory);

        ProductCategory Delete(int id);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string keyword);

        IEnumerable<ProductCategory> GetAllByParentId(int parentId);

        ProductCategory GetById(int id);

        void Save();
    }

    public class POS2ProductCategoryService : IPOS2ProductCategoryService
    {
        private IPOS2ProductCategoryRepository _productCategoryRepository;
        private IPOS2UnitOfWork _unitOfWork;

        public POS2ProductCategoryService(IPOS2ProductCategoryRepository ProductCategoryRepository, IPOS2UnitOfWork unitOfWork)
        {
            this._productCategoryRepository = ProductCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory ProductCategory)
        {
            return _productCategoryRepository.Add(ProductCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll().OrderBy(x => x.ParentID);
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentID);
            else
                return _productCategoryRepository.GetAll().OrderBy(x => x.ParentID);
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory ProductCategory)
        {
            _productCategoryRepository.Update(ProductCategory);
        }
    }
}