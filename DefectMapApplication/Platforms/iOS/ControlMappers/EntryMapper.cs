using CoreGraphics;
using DefectMapApplication.Controls.Standard;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace DefectMapApplication.Platforms.ControlMappers
{
    public static class EntryMapper
    {
        public static void Map(IElementHandler handler, IElement view)
        {
            if (view is RoundedEntry entry)
            {
                var entryHandler = (EntryHandler)handler;

                if (entryHandler.PlatformView is null)
                {
                    return;
                }

                var paddingControl = (UITextField)entryHandler.PlatformView;

                paddingControl.Layer.CornerRadius = entry.CornerRadius;
                paddingControl.Layer.BorderWidth = entry.BorderThickness;
                paddingControl.Layer.BorderColor = entry.BorderColor.ToCGColor();
                paddingControl.LeftView = new UIView(new CGRect(0, 0, entry.Padding.Left, entry.Padding.Top));
                paddingControl.RightView = new UIView(new CGRect(0, 0, entry.Padding.Right, entry.Padding.Bottom));
            }
        }
    }
}
