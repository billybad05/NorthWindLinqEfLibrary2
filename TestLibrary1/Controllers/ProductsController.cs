using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWIndLinqEfLibrary2.Controllers;
using NorthWIndLinqEfLibrary2.Models;
using Microsoft.EntityFrameworkCore;



namespace NorthWIndLinqEfLibrary2.Controllers {

    public class ProductsController {

        private readonly AppDbContext _context = null!;
        public ProductsController(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Product> GetAll() {
            return _context.Products;
        }

        public Product? GetByPK(int productId) {
            return _context.Products.Find(productId);
        }
        /*
        public IEnumerable<Product> Contains(string subString) {
            IEnumerable<Product> products = from p in _context.Products
                                              where p.ProductName.Contains(subString)
                                              orderby p.LastName
                                              select p;
            return products;
        }
        */
        public void Update(int productId, Product product) {
            if (productId != product.ProductId) {
                throw new ArgumentException("Product id doesn't match product instance!");
            }
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public Product Insert(Product product) {
            if (product.ProductId != 0) {
                throw new ArgumentException("Inserting a new product detail requires the productId be set to zero!");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Delete(int productId) {
            Product? product = GetByPK(productId);
            if (product is null) {
                throw new Exception("Product not found!");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}

