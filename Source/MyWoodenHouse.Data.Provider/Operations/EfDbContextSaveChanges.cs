﻿using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using System;

namespace MyWoodenHouse.Data.Provider.Operations
{
    public class EfDbContextSaveChanges : IEfDbContextSaveChanges
    {
        private readonly IMyWoodenHouseDbContext context;

        public EfDbContextSaveChanges(IMyWoodenHouseDbContext context)
        {
            if (context == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "MyWoodenHouseDbContext", "EfDbContextSaveChanges");
                throw new ArgumentNullException(errorMessage);
            }

            this.context = context;
        }

        public int SaveChanges()
        {
            int saveChangesResult = this.context.SaveChanges();

            return saveChangesResult;
        }
    }
}
