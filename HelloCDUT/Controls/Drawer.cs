using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
 

namespace HelloCDUT.Controls
{
    public sealed class Drawer : ContentControl
    {

        #region Field

        private Border _touchBorder;
        private Border _drawerMaskBorder;
        private ContentPresenter _drawerContentPresenter;

        private Compositor _compositor;
        private Visual _drawerVisual;
        private Visual _drawerMaskVisual;


        #endregion

        #region Dependency Properties

        public object DrawerContent
        {
            get { return (object)GetValue(DrawerContentProperty); }
            set { SetValue(DrawerContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DrawerContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawerContentProperty =
            DependencyProperty.Register(nameof(DrawerContent), typeof(object), typeof(Drawer), new PropertyMetadata(null));

        public bool DrawerOpened
        {
            get { return (bool)GetValue(DrawerOpenedProperty); }
            set { SetValue(DrawerOpenedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DrawerOpened.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawerOpenedProperty =
            DependencyProperty.Register("DrawerOpened", typeof(bool), typeof(Drawer), new PropertyMetadata(false, DrawerOpenedCallback));

        private static void DrawerOpenedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var drawer = d as Drawer;
            drawer.ToggleDrawerAnimation((bool)e.NewValue);
            drawer.ToggleDrawerMaskAnimation((bool)e.NewValue);
        }

        public double DrawerOpenLength
        {
            get { return (double)GetValue(DrawerOpenLengthProperty); }
            set { SetValue(DrawerOpenLengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DrawerOpenLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawerOpenLengthProperty =
            DependencyProperty.Register(nameof(DrawerOpenLength), typeof(double), typeof(Drawer), new PropertyMetadata(300.0));


        public SolidColorBrush DrawerMaskerBrush
        {
            get { return (SolidColorBrush)GetValue(DrawerMaskerBrushProperty); }
            set { SetValue(DrawerMaskerBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DrawerMaskerBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawerMaskerBrushProperty =
            DependencyProperty.Register(nameof(DrawerMaskerBrush), typeof(SolidColorBrush), typeof(Drawer), new PropertyMetadata(new SolidColorBrush(Color.FromArgb((byte)0xCC, (byte)0x00, (byte)0x00, (byte)0x00))));


        #endregion

        #region Properties


        public bool CanOpen
        {
            get { return (bool)GetValue(CanOpenProperty); }
            set { SetValue(CanOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanOpenProperty =
            DependencyProperty.Register("CanOpen", typeof(bool), typeof(Drawer), new PropertyMetadata(true));


        //private bool _canOpen = true;

        //public bool CanOpen
        //{
        //    get { return _canOpen; }
        //    set
        //    {
        //        _canOpen = value;
        //    }
        //}


        #endregion

        public Drawer()
        {
            this.DefaultStyleKey = typeof(Drawer);
            if (!DesignMode.DesignModeEnabled)
            {
                this.SizeChanged += Drawer_SizeChanged;
                this.Loaded += Drawer_Loaded;
            }
            //this.SizeChanged += Drawer_SizeChanged;
            //this.Loaded += Drawer_Loaded;
        }

        private void Drawer_Loaded(object sender, RoutedEventArgs e)
        {
            _drawerMaskVisual.Opacity = 0;
            _drawerVisual.Offset = new Vector3(-(float)DrawerOpenLength, 0f, 0f);

            _drawerMaskBorder.Visibility = Visibility.Collapsed;

            //_drawerContentPresenter.Width = DrawerOpenLength;
        }

        private void Drawer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!DrawerOpened)
            {
                _drawerVisual.Offset = new Vector3(-(float)Window.Current.Bounds.Width, 0f, 0f);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _touchBorder = GetTemplateChild<Border>("TouchBorder");
            _drawerMaskBorder = GetTemplateChild<Border>("DrawerMaskBorder");
            _drawerContentPresenter = GetTemplateChild<ContentPresenter>("DrawerContentPresenter");

            InitializeComposition();

            _touchBorder.ManipulationDelta += _touchBorder_ManipulationDelta;
            _touchBorder.ManipulationCompleted += _touchBorder_ManipulationCompleted;

            _drawerMaskBorder.Tapped += _drawerMaskBorder_Tapped;

            _drawerContentPresenter.ManipulationDelta += _drawerContentPresenter_ManipulationDelta;
            _drawerContentPresenter.ManipulationCompleted += _drawerContentPresenter_ManipulationCompleted;
        }

        private void InitializeComposition()
        {
            _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
            _drawerVisual = ElementCompositionPreview.GetElementVisual(_drawerContentPresenter);
            _drawerMaskVisual = ElementCompositionPreview.GetElementVisual(_drawerMaskBorder);
        }

        #region TouchBorder
        private void _touchBorder_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            e.Handled = true;

            if (!CanOpen)
                return;
            
            if (_drawerMaskVisual.Opacity < 1)
            {
                _drawerMaskBorder.Visibility = Visibility.Visible;
                _drawerMaskVisual.Opacity += 0.02f;
            }
            var targetOffsetX = _drawerVisual.Offset.X + e.Delta.Translation.X;
            _drawerVisual.Offset = new Vector3((float)(targetOffsetX > 0 ? 0 : targetOffsetX), 0f, 0f);
        }


        private void _touchBorder_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            e.Handled = true;

            if (!CanOpen)
                return;

            if (e.Cumulative.Translation.X > 70)
            {
                if (!DrawerOpened)
                {
                    DrawerOpened = true;
                }
                else
                {
                    ToggleDrawerAnimation(true);
                    ToggleDrawerMaskAnimation(true);
                }
            }
            else
            {
                if (DrawerOpened)
                {
                    DrawerOpened = false;
                }
                else
                {
                    ToggleDrawerAnimation(false);
                    ToggleDrawerMaskAnimation(false);
                }
            }
        }

        #endregion


        #region DrawerMaskBorder

        private void _drawerMaskBorder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            DrawerOpened = false;
        }

        #endregion


        #region DrawerContentPresenter

        private void _drawerContentPresenter_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            e.Handled = true;

            if (_drawerMaskVisual.Opacity > 0)
            {
                float opacity = 1 - (float)(-e.Cumulative.Translation.X / DrawerOpenLength);
                _drawerMaskVisual.Opacity = opacity < 0 ? 1 : opacity;
            }
            var targetOffsetX = _drawerVisual.Offset.X + e.Delta.Translation.X;

            if (targetOffsetX <= -DrawerOpenLength)
                _drawerVisual.Offset = new Vector3((float)(-DrawerOpenLength), 0f, 0f);
            else if (targetOffsetX >= 0)
                _drawerVisual.Offset = new Vector3(0f, 0f, 0f);
            else
                _drawerVisual.Offset = new Vector3((float)targetOffsetX, 0f, 0f);
        }

        private void _drawerContentPresenter_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            e.Handled = true;

            _drawerMaskBorder.Visibility = Visibility.Visible;

            if (e.Cumulative.Translation.X <= -30)
            {
                if (DrawerOpened)
                {
                    DrawerOpened = false;
                }
                else
                {
                    ToggleDrawerAnimation(false);
                    ToggleDrawerAnimation(false);
                }
            }
            else
            {
                if (!DrawerOpened)
                {
                    DrawerOpened = true;
                }
                else
                {
                    ToggleDrawerAnimation(true);
                    ToggleDrawerAnimation(true);
                }
            }
        }

        #endregion


        #region Drawer animation
        private void ToggleDrawerAnimation(bool show)
        {
            var offsetAnim = _compositor.CreateScalarKeyFrameAnimation();
            offsetAnim.InsertKeyFrame(1f, show ? 0f : -(float)DrawerOpenLength);
            offsetAnim.Duration = TimeSpan.FromMilliseconds(300);

            _drawerVisual.StartAnimation("Offset.X", offsetAnim);
        }

        private void ToggleDrawerMaskAnimation(bool show)
        {
            if (show)
                _drawerMaskBorder.Visibility = Visibility.Visible;

            var fadeAnimation = _compositor.CreateScalarKeyFrameAnimation();
            fadeAnimation.InsertKeyFrame(1f, show ? 1f : 0f, _compositor.CreateLinearEasingFunction());
            fadeAnimation.Duration = TimeSpan.FromMilliseconds(300);

            var batch = _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
            _drawerMaskVisual.StartAnimation("Opacity", fadeAnimation);
            batch.Completed += (sender, e) =>
            {
                if (!show)
                    _drawerMaskBorder.Visibility = Visibility.Collapsed;
            };
            batch.End();
        }


        #endregion


        private T GetTemplateChild<T>(string childName) where T : FrameworkElement
        {
            return GetTemplateChild(childName) as T;
        }
    }
}
