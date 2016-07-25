using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DatabaseFirst_Demo
{
    class EntryPoint

    {
        static void Main(string[] args)
        {
            var context = new DatabaseFirstDemoEntities();

            context.Categories.Add(new Category()
            {
                Name = "Fantasy"
            });

            context.SaveChanges();
        }
    }
}
