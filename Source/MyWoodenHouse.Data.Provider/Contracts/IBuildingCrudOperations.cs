using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Data.Provider.Operations.Contracts
{
    public interface IBuildingCrudOperations : IEfCrudOperatons<Building>
    {
        new int Insert(Building entity);
    }
}