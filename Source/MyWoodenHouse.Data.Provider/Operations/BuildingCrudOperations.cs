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

        public override int Insert(Building entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // /*6- Attach courses because it came from client 
            //as detached state in disconnected scenario*/
            //if (dbCtx.Entry(c).State == System.Data.EntityState.Detached)
            //    dbCtx.Courses.Attach(c);

            // //7- Add course in existing student's course collection
            // existingStudent.Courses.Add(c);

            //bool isStateDetached = this.Context.GetEntityState(entity) == EntityState.Detached;
            //if (!isStateDetached)
            //{
            //    //this.Context.SetEntityState(entity, EntityState.Added);
            //    this.Context.SetEntityState(entity, EntityState.Unchanged);
            //}
            //else
            //{
            //    entity.Id = base.GetMaxId() + 1;
            //    this.DbSet.Add(entity);
            //}

            bool isStateDetached = base.Context.Entry(entity).State == EntityState.Detached;
            if (!isStateDetached)
            {
                base.Context.Buildings.Attach(entity);
            }
            else
            {
                entity.Id = base.GetMaxId() + 1;
                this.DbSet.Add(entity);
            }

            return entity.Id;
        }

        

        
    }
}
