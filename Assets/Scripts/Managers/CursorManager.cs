using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CursorManager
    {
        //Change cursor texture to "clickable"
        public static void SetCursorToClickablePointer(ScriptManager obj) => Cursor.SetCursor(obj.clickableObjPointer, Vector2.zero, CursorMode.Auto);
        
        //Change cursor texture to default
        public static void SetCursorToNormalPointer(ScriptManager obj) => Cursor.SetCursor(obj.normalPointer, Vector2.zero, CursorMode.Auto);
    }
}
