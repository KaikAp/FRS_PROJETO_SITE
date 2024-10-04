using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityFramework
{
    public class Startup
    {
        public static void initializer(Context context)
        {
            if (context.Database.EnsureCreated())
            {

            }
        }
    }
}
