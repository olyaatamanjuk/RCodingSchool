using RCodingSchool.EF;
using RCodingSchool.Repository;
using System;

namespace RCodingSchool.UnitOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue = false;
        private readonly RCodingSchoolContext _dbContext;
        private IUserRepository _userRepository;

        public UnitOfWork(RCodingSchoolContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }

                return _userRepository;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}