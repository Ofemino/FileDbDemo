using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace KioskCameraModuleAForge
{
    public static class CamModuleAForge
    {
        public static FilterInfoCollection _videoCaptureDevices;
        public static VideoCaptureDevice _finalVideo;
        public static Bitmap _latestFrame;
        public static Bitmap _imgBitmap;
        public static ImageSource _imgSrc;

        static FilterInfoCollection GetAvailableVideoDevice()
        {
            _videoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in _videoCaptureDevices)
            {

            }
            return _videoCaptureDevices;
        }


        public static void StartCamera()
        {
            var devices = GetAvailableVideoDevice();
            _finalVideo = new VideoCaptureDevice(devices[0].MonikerString);
            _finalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            _finalVideo.Start();
        }

        public static void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventargs)
        {
            
            _imgBitmap = (Bitmap)eventargs.Frame.Clone();

            _imgSrc = ConvertToImageSource(_imgBitmap);
            //string folderPath = @"C:KioskImages\";
            //if (!Directory.Exists(folderPath))
            //    Directory.CreateDirectory(folderPath);
            //_imgBitmap.Save(folderPath + DateTime.Now.Ticks + @".jpg", ImageFormat.Jpeg);

            //pictureBox1.Image = imgBitmap;
        }


        public static void StopCamera()
        {
            if (_finalVideo.IsRunning)
            {
                _finalVideo.Stop();
            }
        }

        /// <summary>
        /// The convert to image source.
        /// </summary>
        /// <param name="bitmap"> The bitmap. </param>
        /// <returns> The <see cref="object"/>. </returns>
        public static ImageSource ConvertToImageSource(Bitmap bitmap)
        {
            var imageSourceConverter = new ImageSourceConverter();
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                var snapshotBytes = memoryStream.ToArray();
                return (ImageSource)imageSourceConverter.ConvertFrom(snapshotBytes); ;
            }
        }
    }
}
