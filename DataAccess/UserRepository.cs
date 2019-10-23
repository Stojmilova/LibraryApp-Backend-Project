using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UserRepository : IRepository<UserDTO>
    {
        private readonly LibraryAppDbContext _context;
        public UserRepository(LibraryAppDbContext context)
        {
            _context = context;
        }
        public void Add(UserDTO entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(UserDTO entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _context.Users;
        }

        public void Update(UserDTO update)
        {
            _context.Users.Update(update);
            _context.SaveChanges();
        }
    }
}
