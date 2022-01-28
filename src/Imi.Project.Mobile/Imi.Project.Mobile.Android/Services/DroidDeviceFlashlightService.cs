using Android.Content;
using Android.Hardware.Camera2;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(Imi.Project.Mobile.Droid.Services.DroidDeviceFlashlightService))]

namespace Imi.Project.Mobile.Droid.Services
{
    internal class DroidDeviceFlashlightService : IDeviceFlashlightService
    {
        public void TurnOff()
        {
            CameraManager cameraManager = (CameraManager)Android.App.Application.Context.GetSystemService(Context.CameraService);

            try
            {
                String cameraId = cameraManager.GetCameraIdList()[0];
                cameraManager.SetTorchMode(cameraId, false);
            }
            catch (CameraAccessException e)
            { }
        }

        public void TurnOn()
        {
            CameraManager cameraManager = (CameraManager)Android.App.Application.Context.GetSystemService(Context.CameraService);

            try
            {
                String cameraId = cameraManager.GetCameraIdList()[0];
                cameraManager.SetTorchMode(cameraId, true);
            }
            catch(CameraAccessException e)
            { }
        }
    }
}