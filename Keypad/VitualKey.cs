using System.Windows;
using System.Windows.Controls;

namespace Demo.Core.VirtualKeyboard
{

  public class VitualKey : Button
  {
    #region Construtors

    static VitualKey()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(VitualKey), new FrameworkPropertyMetadata(typeof(VitualKey)));
    }
    public VitualKey()
    {
      Focusable = false;
      IsTabStop = false;
    }

    #endregion

  }
}
