
namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts
{
    public interface IGenericModelMapper<T1, T2> 
        where T1 : class
        where T2 : class
    {
        // T1 is the Model
        // T2 is the View Model
        T2 Model2ViewModel(T1 model);

        T1 ViewModel2Model(T2 viewModel);
    }
}