﻿using CeMeOCore.DAL.Context;
using CeMeOCore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeMeOCore.DAL.Repositories
{
    public class MeetingRepository : GenericRepository<Meeting>
    {
        /// <summary>
        /// This constructor will pass the context through the base
        /// </summary>
        /// <param name="dbContext">The database context</param>
        public MeetingRepository(CeMeoContext dbContext) : base(dbContext)
        {

        }
    }
}