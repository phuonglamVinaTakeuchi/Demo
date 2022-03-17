using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Data;
using Demo.Core.Localization;
using MaterialDesignThemes.Wpf;
using Prism.Regions;

namespace Demo.Core.Adapter
{
  public class DialogHostRegionAdapter : RegionAdapterBase<DialogHost>
  {
    public DialogHostRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
      : base(regionBehaviorFactory)
    {
    }

    protected override IRegion CreateRegion()
    {
      return new SingleActiveRegion();
    }

    protected override void Adapt(IRegion region, DialogHost regionTarget)
    {
      if (regionTarget == null)
      {
        throw new ArgumentNullException(nameof(regionTarget));
      }

      if (regionTarget.Content != null ||
          BindingOperations.GetBinding(regionTarget, DialogHost.DialogContentProperty) != null)
      {
        throw new InvalidOperationException(LocalizationConstants.DIALOG_CONTENT_ALREADY_SET);
      }

      region.ActiveViews.CollectionChanged += (sender, e) => regionTarget.DialogContent = region.ActiveViews.FirstOrDefault();

      region.Views.CollectionChanged += delegate (object sender, NotifyCollectionChangedEventArgs e)
      {
        if (e.Action == NotifyCollectionChangedAction.Add && !region.ActiveViews.Any())
        {
          region.Activate(e.NewItems[0]);
        }
      };
    }
  }
}
