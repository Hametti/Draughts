using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CameraManager
    {
        public static GameObject Camera = GameObject.Find("Main Camera");

        public static void SetCameraToBoardPosition()
        {
            Camera = GameObject.Find("Main Camera");
            Vector3 startPos = Camera.transform.position;
            Vector3 endPos = new Vector3(5, 10, 5.5f);
            Camera.transform.position = Vector3.Lerp(startPos, endPos, 100);
        }
        public static void SetCameraToWinnerScreenPosition()
        {
            Camera = GameObject.Find("Main Camera");
            Vector3 startPos = Camera.transform.position;
            Vector3 endPos = new Vector3(5, 10, -15);
            Camera.transform.position = Vector3.Lerp(startPos, endPos, 100);
        }
    }
}
