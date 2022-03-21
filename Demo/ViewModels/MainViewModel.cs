using Demo.Core.MVVM;
using Demo.Test.Views;
using KeypadModule.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Windows.Input;

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

        public ICommand OpenDialogCommand { get; private set; }

    #endregion

    #region Constructors

    public MainViewModel()
    {

    }

    public MainViewModel(IContainerProvider container)
      : base(container)
    {
      Title = "Main Window";
            OpenDialogCommand = new DelegateCommand(OnOpenDialog);

    }

        #endregion

        private void OnOpenDialog()
        {
            var message = "This is a message that should be shown in the dialog.";

            ////using the dialog service as-is

            var dialogService = _container.Resolve<IDialogService>();
            var dialogParam = new DialogParameters();
            dialogParam.Add("message", message);
            dialogParam.Add("content", "content");
            dialogService.Show(nameof(OtherKeypadView), dialogParam, r =>
            {
                // Todo

            });
        }


  }
}
