using Microsoft.EntityFrameworkCore;
using ordinacija_be.Data.Repositories;
using ordinacija_be.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private AuthRepository _authRepository;
        private AppointmentRepository appointmentRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IAuthRepository AuthRepository
        {
            get
            {
                if (_authRepository == null)
                {
                    _authRepository = new AuthRepository(_context, new HMACSHA512Generator());
                }

                return _authRepository;
            }
        }

        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                if (appointmentRepository == null)
                {
                    appointmentRepository = new AppointmentRepository(_context);
                }

                return appointmentRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
