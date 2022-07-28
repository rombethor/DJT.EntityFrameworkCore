using Microsoft.EntityFrameworkCore;

namespace DJT.EntityFrameworkCore
{
    /// <summary>
    /// For entities representing tables to define their own indexes, keys and other properties
    /// for neatness.  To be used in conjunction with <see cref="DbContextExtensions.UseSelfDefiningModels(DbContext, ModelBuilder)"/>
    /// </summary>
    public interface ISelfDefine
    {
        /// <summary>
        /// For use with <see cref="DbContextExtensions.UseSelfDefiningModels(DbContext, ModelBuilder)"/> 
        /// to define rules for the entity model within the class definition.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public void OnModelCreating(ModelBuilder modelBuilder);
    }
}