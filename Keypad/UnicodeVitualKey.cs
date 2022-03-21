using System.Windows;
using WindowsInput;
using WindowsInput.Native;

namespace Demo.Core.VirtualKeyboard
{
  public class UnicodeVitualKey : VitualKey
  {
    #region Dependency Properties

    public static readonly DependencyProperty VirtualKeyProperty =
      DependencyProperty.RegisterAttached(nameof(VirtualKey), typeof(VirtualKeyCode), typeof(UnicodeVitualKey));

    public VirtualKeyCode VirtualKey
    {
      get => (VirtualKeyCode)GetValue(VirtualKeyProperty);
      set => SetValue(VirtualKeyProperty, value);
    }

    #endregion

    #region Constructors

    static UnicodeVitualKey()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(UnicodeVitualKey), new FrameworkPropertyMetadata(typeof(UnicodeVitualKey)));
    }

    #endregion

    #region overrides

    protected override void OnClick()
    {

      var sim = new InputSimulator();


      if (!string.IsNullOrEmpty(Content.ToString()))
        if (Content.ToString() == "00")
        {
          sim.Keyboard.TextEntry("0");
          sim.Keyboard.TextEntry("0");
        }
        else
        {
          sim.Keyboard.KeyPress(VirtualKey);
        }

      base.OnClick();
    }

    #endregion
  }
}
