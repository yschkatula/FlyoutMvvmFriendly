using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace FlyoutMvvmFriendly.UWP.Example
{
    public class FlyoutButtonBaseBehavior : Behavior<ButtonBase>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Click += AssociatedObject_Click;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;

            base.OnDetaching();
        }

        private void AssociatedObject_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var button = sender as ButtonBase;
            if (button == null)
                return;

            DependencyObject parent = button;
            while ((parent != null) && (!(parent is FlyoutPresenter)))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            var presenter = parent as FlyoutPresenter;
            if (presenter == null)
                return;

            (presenter.Parent as Popup).IsOpen = false;
        }

    }
}
