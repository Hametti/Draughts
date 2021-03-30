using NUnit.Framework;
using Assets.Scripts.Base;
using UnityEngine;
using Assets.Scripts.Managers;

namespace Tests
{
    class CameraManagerTests
    {
        [Test]
        public void CameraBoardPosition()
        {
            CameraManager.SetCameraToBoardPosition();
            Vector3 cameraPos = new Vector3(5, 10, 5.5f);
            Assert.AreEqual(CameraManager.Camera.transform.position, cameraPos);
        }

        [Test]
        public void CameraWinnerScreenPosition()
        {
            CameraManager.SetCameraToWinnerScreenPosition();
            Vector3 cameraPos = new Vector3(5, 10, -15);
            Assert.AreEqual(CameraManager.Camera.transform.position, cameraPos);
        }
    }
}
