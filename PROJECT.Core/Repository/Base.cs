using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Repository
{
     public abstract  class Base
    {

         public Database GetDatabase()
         {

             DatabaseProviderFactory factory = new DatabaseProviderFactory();
             Database db = factory.Create("StudentConnectionString");

             return db;
         }
      }
}
