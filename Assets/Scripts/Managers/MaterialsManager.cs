using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class MaterialsManager
    {
        public static void ChangeObjectMaterialTo(ScriptManager mainObj, GameObject obj, int index)
        {
            if (obj.tag != "Field")
            {
                Renderer rend = obj.GetComponent<Renderer>();
                rend.enabled = true;
                rend.sharedMaterial = mainObj.material[index];
            }
            //Color index:
            //0 - BrownChecker normal - brown
            //1 - BrownKing - red
            //2 - BlueChecker normal - blue
            //3 - BlueKing - light blue
            //4 - Pointed - white
            //5 - Selected - gray
        }

        //Sets all colors depending on checker state
        public static void SetMaterialsToDefault(ScriptManager mainObj)
        {
            for (int i = 0; i < 15; i++)
            {
                if (!CheckerManager.BrownCheckers[i].Selected)
                {
                    if (!CheckerManager.BrownCheckers[i].IsKing) 
                        ChangeObjectMaterialTo(mainObj, CheckerManager.BrownCheckers[i].GameObj, 0);

                    else ChangeObjectMaterialTo(mainObj, CheckerManager.BrownCheckers[i].GameObj, 1);
                }

                else ChangeObjectMaterialTo(mainObj, CheckerManager.BrownCheckers[i].GameObj, 5);

                if (!CheckerManager.BlueCheckers[i].Selected)
                {
                    if (!CheckerManager.BlueCheckers[i].IsKing) 
                        ChangeObjectMaterialTo(mainObj, CheckerManager.BlueCheckers[i].GameObj, 2);

                    else ChangeObjectMaterialTo(mainObj, CheckerManager.BlueCheckers[i].GameObj, 3);
                }

                else ChangeObjectMaterialTo(mainObj, CheckerManager.BlueCheckers[i].GameObj, 5);
            }

            ChangeObjectMaterialTo(mainObj, GameObject.Find("RestartButton"), 6);
            ChangeObjectMaterialTo(mainObj, GameObject.Find("ExitButton"), 6);
        }
    }
}
