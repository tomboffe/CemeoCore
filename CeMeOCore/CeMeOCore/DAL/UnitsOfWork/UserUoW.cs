﻿using CeMeOCore.DAL.Repositories;
using CeMeOCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeMeOCore.DAL.UnitsOfWork
{
    public class UserUoW : IDisposable
    {
        private CeMeoContext context = new CeMeoContext();
        private UserProfileRepository _userProfileRepository;
        private GenericRepository<Location> _locationRepository;
        private InviteeRepository _inviteeRepository;

        public UserProfileRepository UserProfileRepository
        {
            get
            {
                if (this._userProfileRepository == null)
                {
                    this._userProfileRepository = new UserProfileRepository(context);
                }
                return this._userProfileRepository;
            }
        }

        public GenericRepository<Location> LocationRepository
        {
            get
            {
                if( this._locationRepository == null )
                {
                    this._locationRepository = new GenericRepository<Location>(context);
                }
                return this._locationRepository;
            }
        }

        public InviteeRepository InviteeRepository
        {
            get
            {
                if (this._inviteeRepository == null)
                {
                    this._inviteeRepository = new InviteeRepository(context);
                }
                return this._inviteeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}