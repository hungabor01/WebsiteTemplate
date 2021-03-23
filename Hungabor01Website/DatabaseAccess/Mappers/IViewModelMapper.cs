using BusinessLogic.ViewModels;
using Database.Core.Entities;

namespace DatabaseAccess.Mappers
{
    public interface IViewModelMapper<TEntity, TViewModel>
        where TEntity : IEntity
        where TViewModel : IViewModel
    {
        public TEntity FromViewModel(TViewModel model);

        public TViewModel ToViewModel(TEntity entity);
    }
}
