using FullAjaxSample.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAjaxSample.DAL
{
     public class MyDbContext :DbContext
    {
        // עבור כל טבלה בדטה בייס צריך להיות דיביסט
        public DbSet<Product> Products { get; set; }

        public MyDbContext() : base("RafaelDB")
        {
            Products = Set<Product>();
        }

        //found on stack overflow to fix why EF sql dll not copied/ added
        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

    }
}
