using FullAjaxSample.DAL;
using FullAjaxSample.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FullAjaxAmple.BL
{

    public class ProductManager : IDisposable
    {

        public MyDbContext _context { get; set; }

        public List<Product> GetAll()
        {
           var list = _context.Products.ToList();
            return list;
        }

        public ProductManager()
        {
            _context = new MyDbContext();
        }
        // כמו איינומרבל אבל עובד עם משאבים חיצוניים כמו אסקיואל
        //   var list = manager.Filter(x => x.ID >= 2 && x.DisplayName.StartsWith("a")).Take(10);
        // זה לדוגמא מחולק החלק הראשון זה אסקיואל והטייק זה לינק
        // MyDbContext _context מתרגם לינק לאסקיואל ומריץ שאילתת אסקיאל ומביא את הדטה
        public IQueryable<Product> Filter(Expression<Func<Product,bool>>predicate)
        {
            return _context.Products.Where(predicate);
        }

        public void Update(Product p)
        {
            _context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void Insert(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ID == id);
            _context.Products.Remove(product); 
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
