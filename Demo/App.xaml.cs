using System.Windows;
using Demo.Core.Adapter;
using Demo.Test.Views;
using KeypadModule;
using KeypadModule.ViewModels;
using KeypadModule.Views;
using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace Demo.Test
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : PrismApplication
  {
    protected override Window CreateShell() => Container.Resolve<MainView>();


    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {

            //containerRegistry.Register<IRegionAdapter, DialogHostRegionAdapter>();
            containerRegistry.RegisterDialog<OtherKeypadView, OtherKeypadViewModel>();

        }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
      moduleCatalog.AddModule<KeypadDemoModule>();
    }
    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
      base.ConfigureRegionAdapterMappings(regionAdapterMappings);
      regionAdapterMappings.RegisterMapping(typeof(DialogHost), Container.Resolve<DialogHostRegionAdapter>());
    }

  }
}
