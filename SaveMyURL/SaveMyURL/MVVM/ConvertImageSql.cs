using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace SaveMyURL.MVVM
{
    public static class ConvertImageSql
    {
        public static async Task<byte[]> ConvertToBytesAsync(BitmapImage image)
        {
            RandomAccessStreamReference streamRef = RandomAccessStreamReference.CreateFromUri(image.UriSource);
            IRandomAccessStreamWithContentType streamWithContent = await streamRef.OpenReadAsync();
            byte[] buffer = new byte[streamWithContent.Size];
            await streamWithContent.ReadAsync(buffer.AsBuffer(), (uint)streamWithContent.Size, InputStreamOptions.None);
            return buffer;
        }

        public static async Task<BitmapImage> ImageFromByteAsync(byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream strem = new InMemoryRandomAccessStream())
            {
                await strem.WriteAsync(bytes.AsBuffer());
                strem.Seek(0);
                await image.SetSourceAsync(strem);
            }
            return image;
        }
    }
}