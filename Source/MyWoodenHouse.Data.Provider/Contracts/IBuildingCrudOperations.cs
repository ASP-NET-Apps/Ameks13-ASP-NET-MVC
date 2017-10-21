using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Models;

namespace MyWoodenHouse.Data.Provider.Operations.Contracts
{
    public interface IBuildingCrudOperations : IEfCrudOperatons<Building>
    {
        new int Insert(Building entity);

        new int Update(Building entity);
    }
}