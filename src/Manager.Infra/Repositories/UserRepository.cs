using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<User> GetByEmail(string email)
        {
            var obj = await _context.Users                
                .Where(x => 
                x.Email.ToLower() == email.ToLower())
                .AsNoTracking()
                .ToListAsync();
            
            return obj.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var allobj = await _context.Users                
                .Where(x => 
                x.Email.ToLower().Contains(email.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return allobj;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var allobj = await _context.Users                
                .Where(x => 
                x.Name.ToLower().Contains(name.ToLower()))
                .AsNoTracking()
                .ToListAsync();
            
            return allobj;
        }
    }
}