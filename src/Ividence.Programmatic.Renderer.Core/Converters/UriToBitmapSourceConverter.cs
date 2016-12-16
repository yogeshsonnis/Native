using System;
using System.Globalization;
using System.IO;
using System.Runtime.Caching;

using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Ividence.Programmatic.Renderer.Core.Converters
{

    public class UriToBitmapSourceConverter : IValueConverter
    {
        private ImageDataModel GetDataWebClient(Uri uniqueResource)
        {
            var model = new ImageDataModel();
            var data = MemoryCache.Default.Get(uniqueResource.AbsoluteUri) as byte[];
            // We have Some already there.
            if (data != null)
            {
                model.Valid = true;
                model.Data = data;
                return model;
            }

            try
            {
                using (var client = new TimedoutWebClient { Timeout = TimeSpan.FromSeconds(5), Proxy = null })
                {
                    model.Data = client.DownloadData(uniqueResource.AbsoluteUri);
                    model.Valid = true;
                    MemoryCache.Default.Set(uniqueResource.AbsoluteUri, model.Data, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(15) });

                    return model;
                }
            }
            catch (Exception exc)
            {
                Log.Error("UriToBitmapSourceConverter",
                    String.Format("Unexcepted error while downloading [{0}]", uniqueResource.AbsoluteUri),
                      exc, 205);
                return model;
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var uri = value as String;
                if (String.IsNullOrEmpty(uri)) return null;

                // Few not wellformatted values might occur...
                uri = uri.Replace("\n", "").Replace("\r", "").Replace("\t", "");

                Uri imageUri;
                if (Uri.TryCreate(uri, UriKind.Absolute, out imageUri))
                {

                    UriBuilder builder = new UriBuilder(new Uri(uri));
                    //figureout  right Schema.
                    if (builder.Scheme == "file") builder.Scheme = "http";

                    if (!builder.Scheme.Contains("http")) return null;

                    var uniqueResource = builder.Uri;

                    var data = GetDataWebClient(uniqueResource);

                    if ((data != null) && (data.Valid))
                    {
                        var source = new BitmapImage();
                        source.BeginInit();
                        source.StreamSource = new MemoryStream(data.Data);
                        source.EndInit();
                        source.Freeze();

                        var targetDpi = 96d;
                        if (source.DpiX > targetDpi || source.DpiY > targetDpi)
                        {
                            if (String.Equals("#fix_dpi", imageUri.Fragment))
                            {
                                var width = source.PixelWidth;
                                var height = source.PixelHeight;
                                var format = source.Format;

                                int stride = width * (format.BitsPerPixel / 8); // 4 bytes per pixel
                                byte[] pixelData = new byte[stride * height];
                                source.CopyPixels(pixelData, stride, 0);

                                var newSource = BitmapSource.Create(width, height, targetDpi, targetDpi, format, null, pixelData, stride);
                                newSource.Freeze();
                                return newSource;
                            }
                        }
                        return source;
                    }
                }
                else
                {
                    Log.Error("UriToBitmapSourceConverter",
                       String.Format("Not Well formated URI [{0}]", uri),
                       null, 210);

                }
                return null;
            }
            catch (Exception e)
            {
                Log.Error("UriToBitmapSourceConverter", $"Convert Execption : {parameter}", e, 220);
                return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
