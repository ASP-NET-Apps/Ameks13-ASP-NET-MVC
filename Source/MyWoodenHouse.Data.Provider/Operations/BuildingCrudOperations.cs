using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations.Contracts;
using MyWoodenHouse.Ef.Models;
using System;
using System.Data.Entity;

namespace MyWoodenHouse.Data.Provider.Operations
{
    public class BuildingCrudOperations : EfCrudOperatons<Building>, IBuildingCrudOperations, IEfCrudOperatons<Building>
    {

        public BuildingCrudOperations(IMyWoodenHouseDbContext context) :  base(context)
        {            
        }

        public override int Insert(Building building)
        {
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            //bool isStateDetached = this.Context.GetEntityState(entity) == EntityState.Detached;
            //if (!isStateDetached)
            //{
            //    this.Context.SetEntityState(entity, EntityState.Added);
            //}
            //else
            //{
            //    entity.Id = this.GetMaxId() + 1;
            //    this.DbSet.Add(entity);
            //}

            bool isStateDetached = base.Context.Entry(building).State == EntityState.Detached;
            if (!isStateDetached)
            {
                base.Context.Buildings.Attach(building);
            }
            else
            {
                //building.Id = base.GetMaxId() + 1;
                //var materials = building.Materials;
                //foreach (var material in materials)
                //{
                //    bool isStateDetachedMaterial = base.Context.Entry(material).State == EntityState.Detached;
                //    base.Context.Materials.Remove(material);
                //}
                building.Id = base.GetMaxId() + 1;
                base.Context.Buildings.Add(building);
                               
            }

            return building.Id;
        }

        

        
    }
}
