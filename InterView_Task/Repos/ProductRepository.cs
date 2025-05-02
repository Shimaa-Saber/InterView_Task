using InterView_Task.Interfaces;
using InterView_Task.Models;

namespace InterView_Task.Repos
{
    public class ProductRepository: IProduct
    {
        private readonly dbContext _context;
        public ProductRepository(dbContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
           
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            
        }
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(P=>P.Id==id);
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
           
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }

}

