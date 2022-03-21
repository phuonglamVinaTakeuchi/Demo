using Demo.Core.Localization;
using Demo.Core.Services;
using KeypadModule.ViewModels;
using KeypadModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Services.Dialogs;
using WindowsInput;

namespace KeypadModule
{
  public class KeypadDemoModule : IModule
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.Register<IInputSimulator, InputSimulator>();
      //containerRegistry.Register<IDialogService, MaterialDesignDialogService>();
      //containerRegistry.RegisterDialog<DemoPrismDialogView, DemoPrismDialogViewModel>();
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();

      //regionManager.RegisterViewWithRegion(RegionName.MAIN_REGION, typeof(OtherKeypadView));
    }
  }
}
