using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DJT.EntityFrameworkCore
{
    /// <summary>
    /// Extension methods which apply to <see cref="DbContext"/>
    /// </summary>
    public static class DbContextExtensions
    {
        
        /// <summary>
        /// Checks through all DbSets defined in the <see cref="DbContext"/> and runs the method OnModelCreating for each model
        /// implementing the interface ISelfDefine.
        /// 
        /// If entities are internal, the assembly attribute <see cref="InternalsVisibleToAttribute"/> may
        /// need specifying.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="modelBuilder"></param>
        public static void UseSelfDefiningModels(this DbContext dbContext, ModelBuilder modelBuilder)
        {
            Type dbContextType = dbContext.GetType();
            foreach (var prop in dbContextType.GetProperties())
            {
                var propType = prop.PropertyType;
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(DbSet<>))
                {
                    var itemType = propType.GenericTypeArguments[0];//.GetGenericTypeDefinition().GetGenericArguments()[0];
                    var method = itemType.GetMethod("OnModelCreating");
                    if (typeof(ISelfDefine).IsAssignableFrom(itemType) && method != null)
                    {
                        //If the "OnModelCreating(ModelBuilder modelBuilder)" method exists, run it with the given ModelBuilder
                        method.Invoke(Activator.CreateInstance(itemType, false), new object[] { modelBuilder });
                    }
                }
            }
        }
    }
}
