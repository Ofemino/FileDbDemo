using System.Threading;
using System.Windows;
using KioskCameraModule;
using KioskCameraModuleAForge;
using Microsoft.Win32;

namespace FileDbDemo
{
    /// <summary>
    /// Interaction logic for TestCamera.xaml
    /// </summary>
    public partial class TestCamera : Window
    {
        public TestCamera()
        {
            InitializeComponent();
        }

        private void GetCameraStatus(object sender, RoutedEventArgs e)
        {
            int s = CamModule.CameraStatus();
            if (s > 0)
            {
                MessageBox.Show("Status is ok!");
            }
            else
            {
                MessageBox.Show("Status not ok!");
            }

        }

        private void DoOpenPicture(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFile.ShowDialog() == true)
            {
                srcImg.Source = CamModule.ToBitmapSource(openFile.FileName);
            }

        }

        private void DoTakePictureBg(object sender, RoutedEventArgs e)
        {
            //srcImg.Source =
                CamModule.StartCamera(@"DEPOSIT");
        }

        private void DoTakePicture(object sender, RoutedEventArgs e)
        {
            CamModuleAForge.StartCamera();
            srcImg.Source = CamModuleAForge._imgSrc;
            //Thread.Sleep(1500);
            
        }

        private void StopCamera(object sender, RoutedEventArgs e)
        {
            CamModuleAForge.StopCamera();

        }
    }
}
