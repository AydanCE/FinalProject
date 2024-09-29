using Business.Abstract;
using Business.BusinessAspect.Autofac.Secured;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.FluentValidation;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;

        [SecuredOperation("admin,moderator")]
        [ValidationAspect<Product>(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult DeleteProduct(int id)
        {
            Product deleteProduct = null;
            Product resultProduct = _productDal.Get(p => p.IsDeleted == false && p.Id == id);
            if (resultProduct != null)
                deleteProduct = resultProduct;
            deleteProduct.IsDeleted = true;
            _productDal.Delete(deleteProduct);
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAllProducts()
        {
            var products = _productDal.GetAll(p => p.IsDeleted == false).ToList();
            if (products.Count != 0)
            {
                return new SuccessDataResult<List<Product>>(products);
            }
            return new ErrorDataResult<List<Product>>(products);
        }

        public IDataResult<Product> GetProduct(int id)
        {
            Product getProduct = _productDal.Get(p => p.Id == id && p.IsDeleted == false);
            if (getProduct != null)
            {
                return new SuccessDataResult<Product>(getProduct);
            }
            return new ErrorDataResult<Product>(getProduct);
        }

        public IResult UpdateProduct(Product product)
        {
            Product updateProduct;
            updateProduct = _productDal.Get(p => p.Id == product.Id && p.IsDeleted == false);
            updateProduct.ProductName = product.ProductName;
            updateProduct.Description = product.Description;
            updateProduct.Price = product.Price;
            _productDal.Update(product);
            return new SuccessResult();
        }
    }
}
