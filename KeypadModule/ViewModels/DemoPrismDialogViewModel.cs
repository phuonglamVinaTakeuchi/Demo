using System;
using Demo.Core.MVVM;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;

namespace KeypadModule.ViewModels
{
  // Auto Implement IDialogAware
  public class DemoPrismDialogViewModel : ViewModelBase, IDialogAware
  {
    #region Fields
    #endregion

    #region Properties

    private string _content;
    public string Content
    {
      get => _content;
      set => SetProperty(ref _content, value);
    }



    #endregion

    #region Commands

    public object CloseDialogCommand
    {
      get;
    }

    #endregion

    #region Constructors

    public DemoPrismDialogViewModel()
    {
    }

    public DemoPrismDialogViewModel(IContainerProvider container)
    {
      Content = "Hello World";
      // Initialize CloseDialogCommand
      CloseDialogCommand = new DelegateCommand<string>(OnCloseDialog);
    }
    #endregion

    #region Implement IDialogAware

    public string Title => "Demo Prism Dialog";

    private string _message;
    public string Message
    {
      get => _message;
      private set => SetProperty(ref _message, value);
    }

    protected virtual void OnCloseDialog(string param)
    {
      var result = ButtonResult.None;

      switch (param)
      {
        case "OK":
          result = ButtonResult.OK;
          break;
        case "Cancel":
          result = ButtonResult.Cancel;
          break;
        default:
          break;
      }

      RaiseRequestClose(new DialogResult(result));
    }

    protected virtual void RaiseRequestClose(IDialogResult dialogResult)
    {
      RequestClose?.Invoke(dialogResult);
    }

    public event Action<IDialogResult> RequestClose;

    public virtual bool CanCloseDialog() => true;

    public virtual void OnDialogClosed()
    {
      // Do nothing
    }



    public virtual void OnDialogOpened(IDialogParameters parameters)
    {
      Message = parameters.GetValue<string>("message");
      Content = parameters.GetValue<string>("content");
    }
    #endregion
  }
}
