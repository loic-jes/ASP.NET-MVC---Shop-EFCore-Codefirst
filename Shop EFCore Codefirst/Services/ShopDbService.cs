using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_EFCore_Codefirst.Services
{
    public class ShopDbService<TModel> : IShopDbServices<TModel> where TModel : class
    {

        private readonly Models.ShopDBContext context;
        protected DbSet<TModel> DbSet;

        public ShopDbService(Models.ShopDBContext _context)
        {
            context = _context;
            DbSet = context.Set<TModel>();
        }



        public async Task CreateAsync(TModel entity)
        {
            DbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TModel entity)
        {
            DbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await DbSet.ToArrayAsync();
        }

        public async Task<TModel> GetByIdAsync(Guid? id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TModel entity)
        {
            DbSet.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
