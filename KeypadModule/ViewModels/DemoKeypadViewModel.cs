using Demo.Core.MVVM;
using System.Windows.Input;
using Prism.Commands;
using Prism.Services.Dialogs;
using KeypadModule.Views;
using Prism.Ioc;
using MaterialDesignThemes;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;

namespace KeypadModule.ViewModels
{
  /// <summary>
  /// The demo keypad view model2.
  /// </summary>
  public class DemoKeypadViewModel : ViewModelBase
  {
    private string _content;
    public string Content
    {
      get => _content;
      set
      {
        SetProperty(ref _content, value);
        (EnterPressCommand as DelegateCommand).RaiseCanExecuteChanged();
      }
    }


    public ICommand EnterPressCommand { get; }
    /// <summary>
    /// Initializes a new instance of the <see cref="DemoKeypadViewModel2"/> class.
    /// </summary>
    public DemoKeypadViewModel(IContainerProvider container) : base(container)
    {
      EnterPressCommand = new DelegateCommand(OnEnterPressExcute, CanEnterPressExcute);
    }

    private void OnEnterPressExcute()
    {
      ShowDialog();
    }

    private void ShowDialog()
    {
      var message = "This is a message that should be shown in the dialog.";

      ////using the dialog service as-is

      var dialogService = _container.Resolve<IDialogService>();
      var dialogParam = new DialogParameters();
      dialogParam.Add("message", message);
      dialogParam.Add("content", Content);
      dialogService.Show(nameof(DemoPrismDialogView), dialogParam, r =>
      {
        // Todo
        // Call Close DrawerHost at here
        //DrawerHost.CloseDrawerCommand.Execute(Dock.Bottom,null);
      });
    }
    private bool CanEnterPressExcute()
    {
      return !string.IsNullOrEmpty(Content);
    }
  }

}
