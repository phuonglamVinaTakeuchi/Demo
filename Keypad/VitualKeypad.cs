using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Demo.Core.VirtualKeyboard
{
  [TemplatePart(Name = ContentPresenterPart, Type = typeof(ContentControl))]
  public class VitualKeypad : ContentControl
  {
    public const string ContentPresenterPart = "PART_ContentPresenter";

    //private ContentPresenter _contentControl;

    #region fields

    #endregion

    #region Dependency Properties

    public static readonly DependencyProperty KeypadContentStyleProperty =
      DependencyProperty.RegisterAttached(nameof(KeypadContentStyle), typeof(Style), typeof(VitualKeypad), new PropertyMetadata(null));

    public Style KeypadContentStyle
    {
      get => (Style)GetValue(KeypadContentStyleProperty);
      set => SetValue(KeypadContentStyleProperty, value);
    }

    public static DependencyProperty OkButtonPressedProperty =
      DependencyProperty.RegisterAttached(nameof(OkButtonPressed), typeof(ICommand), typeof(VitualKeypad), new PropertyMetadata(null));
    public ICommand OkButtonPressed
    {
      get => (ICommand)GetValue(OkButtonPressedProperty); 
      set => SetValue(OkButtonPressedProperty, value); }
    #endregion


    #region Constructors
    static VitualKeypad()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(VitualKeypad), new FrameworkPropertyMetadata(typeof(VitualKeypad)));
    }

    public VitualKeypad()
    {
      Focusable = false;
      IsTabStop = false;
    }

    #endregion

    #region Overrides
    //public override void OnApplyTemplate()
    //{
    //  base.OnApplyTemplate();

    //  //if (!DesignerProperties.GetIsInDesignMode(this))
    //  //{
    //  //  _contentControl = GetTemplateChild(ContentPresenterPart) as ContentPresenter;
    //  //  SetKeyboardStyle();
    //  //}

    //}

    //private void SetKeyboardStyle()
    //{
    //  //if (_contentControl == null) return;

    //  //_contentControl.Style = KeypadContentStyle;

    //}
    #endregion



  }
}
