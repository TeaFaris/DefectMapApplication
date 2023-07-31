using Android.Graphics.Drawables;
using DefectMapApplication.Controls.Standard;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace DefectMapApplication.Platforms.ControlMappers
{
    public static class EntryMapper
    {
        public static void Map(IElementHandler handler, IElement view)
        {
            if(view is RoundedEntry entry)
            {
                var entryHandler = (EntryHandler)handler;

                var gd = new GradientDrawable();

                gd.SetCornerRadius((int)handler.MauiContext?.Context.ToPixels(entry.CornerRadius));
                gd.SetStroke((int)handler.MauiContext?.Context.ToPixels(entry.BorderThickness), entry.BorderColor.ToAndroid());

                if(entry.BackgroundColor is not null)
                {
                    gd.SetColor(entry.BackgroundColor.ToAndroid());
                }

                entryHandler.PlatformView.SetBackground(gd);

                var padTop = (int)handler.MauiContext?.Context.ToPixels(entry.Padding.Top);
                var padLeft = (int)handler.MauiContext?.Context.ToPixels(entry.Padding.Left);
                var padRight = (int)handler.MauiContext?.Context.ToPixels(entry.Padding.Right);
                var padBottom = (int)handler.MauiContext?.Context.ToPixels(entry.Padding.Bottom);

                entryHandler.PlatformView?.SetPadding(padLeft, padTop, padRight, padBottom);
            }
        }
    }
}
