using DefectMapApplication.Controls.Standard;
using Microsoft.Maui.Handlers;
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
            }
        }
    }
}
