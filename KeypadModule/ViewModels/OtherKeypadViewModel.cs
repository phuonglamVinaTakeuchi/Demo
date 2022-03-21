using Demo.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace KeypadModule.ViewModels
{
    public class OtherKeypadViewModel : ViewModelBase, IDialogAware
    {
        public string _tempContent;
        public string TempContent
        {
            get => _tempContent;
            set => SetProperty(ref _tempContent, value);
        }

        public string _content;
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        private bool _isBottomDrawnerOpen;

        public bool IsBottomDrawnerOpen
        {
            get => _isBottomDrawnerOpen;
            set => SetProperty(ref _isBottomDrawnerOpen, value);
        }

        private bool _isTextBoxTempFocused;
        public bool IsTextBoxTempFocused
        {
            get => _isTextBoxTempFocused;
            set => SetProperty(ref _isTextBoxTempFocused, value);
        }
        public ICommand EnterPressCommand { get; private set; }
        public ICommand OpenDrawerCommand { get; private set; }
        public ICommand CloseDialogCommand { get; private set; }



        public OtherKeypadViewModel()
        {
            EnterPressCommand = new DelegateCommand(OnOkPress);
            OpenDrawerCommand = new DelegateCommand(OnOpenDrawer);
            CloseDialogCommand = new DelegateCommand<string>(OnCloseDialog);
        }

        private void OnOpenDrawer()
        {
            IsBottomDrawnerOpen = true ;
            IsTextBoxTempFocused = true;
        }
        private void OnOkPress()
        {
            Content = TempContent;
            IsBottomDrawnerOpen = false;
        }


        #region  IDialogAware

        private string _title;
        public string Title { get => _title; set => SetProperty(ref _title, value); }
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

        }

        #endregion

    }
}
