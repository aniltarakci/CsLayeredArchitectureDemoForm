using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                exampledbContext.Products.Add(entity);
                exampledbContext.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                exampledbContext.Products.Remove(exampledbContext.Products.SingleOrDefault(p => p.Id == entity.Id));
                exampledbContext.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                return exampledbContext.Products.ToList();
            }
        }

        public Product GetById(int id)
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                return exampledbContext.Products.SingleOrDefault(p => p.Id == id);
            }
        }

        public void Update(Product entity)
        {
            using (ExampledbContext exampledbContext = new ExampledbContext())
            {
                var productToUpdate = exampledbContext.Products.SingleOrDefault(p => p.Id == entity.Id);
                productToUpdate.CategoryId = entity.CategoryId;
                productToUpdate.ProductName = entity.ProductName;
                productToUpdate.UnitPrice = entity.UnitPrice;
                productToUpdate.UnitsInStock = entity.UnitsInStock;
                exampledbContext.SaveChanges();
            }
        }
    }
}
