using Bytes2you.Validation;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations.Contracts;
using MyWoodenHouse.Ef.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace MyWoodenHouse.Data.Provider.Operations
{
    public class BuildingCrudOperations : EfCrudOperatons<Building>, IBuildingCrudOperations, IEfCrudOperatons<Building>
    {
        public BuildingCrudOperations(MyWoodenHouseDbContext context) 
            :  base(context)
        {            
        }

        public override int Insert(Building building)
        {
            Guard.WhenArgument(building, nameof(building)).IsNull().Throw();

            //var dbEntity = base.CopyStateFrom(building);
            building.Id = this.GetMaxId() + 1;
            DbEntityEntry entry = base.AttachIfDetached(building);
            entry.State = EntityState.Added;

            return building.Id;
        }

        public override int Update(Building building)
        {
            Guard.WhenArgument(building, nameof(building)).IsNull().Throw();

            base.DbSet.AddOrUpdate(building);
            //var dbEntity = base.CopyStateFrom(building);

            //var entry = base.AttachIfDetached(building);
            //entry.State = EntityState.Modified;

            return building.Id;
        }

    }
}
