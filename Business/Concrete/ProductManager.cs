using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
         IProductDal  _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            // Bir method bir değer döndürebilirsinin birden fazla için encapsitoin unutma
            //business codes
            //Web API console için olur sadece
            //restful(JSON) farklı uygulamalar için
            //request -istek
            //responce- kelime
            if (product.ProductName.Length<2)
            {
                return new ErrorResult("Ürün ismi en az  2 karakter olmalıdır");
            }
            _productDal.Add(product);

            return new SuccessResult();
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //Yetkisi var mı?

            return _productDal.GelAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GelAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GelAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        IResult IProductService.Add(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
