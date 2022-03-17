using System;
using System.Windows;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Prism.Common;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Demo.Core.Services
{
  public class MaterialDesignDialogService : IDialogService
  {
    private readonly IContainerProvider _container;
    private readonly IRegionManager _regionManager;
    public MaterialDesignDialogService(IContainerProvider container, IRegionManager regionManager)
    {
      _container = container;
      _regionManager = regionManager;
    }
    public void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback)
    {
      var region = _regionManager.Regions["DialogRegion"];
      var view = _container.Resolve(typeof(object), name);

      if (!(view is UIElement))
      {
        throw new ArgumentException("A dialog must be a UIElement");
      }
      var dialog = view as FrameworkElement;

      if (dialog != null && !(dialog.DataContext is IDialogAware))
      {
        throw new ArgumentException("A dialog's ViewModel must implement IDialogAware interface");
      }

      if (dialog == null) return;
      
      var viewModel = dialog.DataContext as IDialogAware;

      DialogHost dialogHost = FindChild<DialogHost>(Application.Current.MainWindow, default);

      ConfigureEvents(dialogHost, viewModel, callback);
      MvvmHelpers.ViewAndViewModelAction<IDialogAware>(viewModel, d => d.OnDialogOpened(parameters));
      _ = region.Add(dialog);
      region.Activate(dialog);

      dialogHost.IsOpen = true;
    }

    public void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback, string windowName)
    {

    }

    public void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback)
    {

    }

    public void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback, string windowName)
    {

    }

    private void ConfigureEvents(DialogHost dialogHost, IDialogAware viewModel, Action<IDialogResult> callback)
    {
      IDialogResult temp = default;

      dialogHost.DialogOpened += DialogOpenedHandler;
      dialogHost.DialogClosing += DialogClosedHandler;

      void DialogOpenedHandler(object sender, RoutedEventArgs e)
      {
        dialogHost.DialogOpened -= DialogOpenedHandler;
        viewModel.RequestClose += RequestCloseHandler;
      }

      void RequestCloseHandler(IDialogResult result)
      {
        temp = result;
        dialogHost.IsOpen = false;
      }

      void DialogClosedHandler(object sender, RoutedEventArgs e)
      {
        dialogHost.DialogClosing -= DialogClosedHandler;
        viewModel.RequestClose -= RequestCloseHandler;

        viewModel.OnDialogClosed();

        callback?.Invoke(temp);
      }
    }

    public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
    {
      if (parent == null)
      {
        return default;
      }

      T foundChild = default;

      var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
      for (var i = 0; i < childrenCount; i++)
      {
        DependencyObject child = VisualTreeHelper.GetChild(parent, i);
        if (!(child is T))
        {
          foundChild = FindChild<T>(child, childName);
          if (foundChild != null)
          {
            break;
          }
        }
        else if (!string.IsNullOrEmpty(childName))
        {
          if (child is FrameworkElement frameworkElement && frameworkElement.Name == childName)
          {
            foundChild = (T)child;
            break;
          }
        }
        else
        {
          foundChild = (T)child;
          break;
        }
      }

      return foundChild;
    }
  }
}