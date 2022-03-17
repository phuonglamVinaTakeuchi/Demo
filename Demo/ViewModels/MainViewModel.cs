using Demo.Core.MVVM;
using Demo.Views;
using Prism.Ioc;
using Prism.Services.Dialogs;

namespace Demo.Test.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    #region Fields



    #endregion

    #region Properties

    public string Title { get; private set; }

    #endregion

    #region Command




    #endregion

    #region Constructors

    public MainViewModel()
    {

    }

    public MainViewModel(IContainerProvider container)
      : base(container)
    {
      Title = "Main Window";
    }

    #endregion




  }
}
