using Prism.Ioc;
using Prism.Mvvm;

namespace Demo.Core.MVVM
{
  public abstract class ViewModelBase : BindableBase
  {
    #region Fields

    protected readonly IContainerProvider _container;
    
    #endregion

    #region Properties



    #endregion

    #region Command

   
    
    #endregion

    #region Constructors

    public ViewModelBase()
    {
    }

    public ViewModelBase(IContainerProvider container)
    {
      _container = container;
      
    }

    #endregion

    
  }
}
