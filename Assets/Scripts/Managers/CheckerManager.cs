using Assets.Scripts.Base;
using UnityEngine;


namespace Assets.Scripts.Managers
{
    public class CheckerManager
    {
        public static Checker[] BlueCheckers = new Checker[15];
        public static Checker[] BrownCheckers = new Checker[15];

        public static Vector3[] BrownDefaultPositions = new Vector3[15];
        public static Vector3[] BlueDefaultPositions = new Vector3[15];
        public static void RemoveEnemyBetween(GameObject checker, GameObject field)
        {
            Vector3 enemyPos = checker.transform.position;
            enemyPos.x = (checker.transform.position.x + field.transform.position.x) / 2;
            enemyPos.z = (checker.transform.position.z + field.transform.position.z) / 2;
            enemyPos.y = 0.3f;

            Vector3 finalPos = enemyPos;
            finalPos.y = 50;

            FieldManager.ModifyFieldStateUnder(CheckerOnPosition(enemyPos).GameObj, 1);
            CheckerOnPosition(enemyPos).GameObj.transform.position = Vector3.Lerp(enemyPos, finalPos, 100);
        }
        public static void SelectChecker(GameObject checker)
        {
            for (int i = 0; i < 15; i++)
            {
                if (BlueCheckers[i].GameObj == checker)
                {
                    //If clicked checker already was selected, deselect it, otherwise select it
                    if (BlueCheckers[i].Selected)
                    {
                        BlueCheckers[i].Selected = false;
                        DropChecker(checker);
                        return;
                    }
                    else
                    {
                        BlueCheckers[i].Selected = true;
                        LiftChecker(checker);
                    }
                }
                if (BrownCheckers[i].GameObj == checker)
                {
                    //If clicked checker already was selected, deselect it, otherwise select it
                    if (BrownCheckers[i].Selected)
                    {
                        BrownCheckers[i].Selected = false;
                        DropChecker(checker);
                        return;
                    }
                    else
                    {
                        BrownCheckers[i].Selected = true;
                        LiftChecker(checker);
                    }
                }
            }
        }
        public static void DeselectCheckers()
        {
            for (int i = 0; i < 15; i++)
            {
                if (BlueCheckers[i].Selected)
                {
                    BlueCheckers[i].Selected = false;
                    DropChecker(BlueCheckers[i].GameObj);
                }
                if (BrownCheckers[i].Selected)
                {
                    BrownCheckers[i].Selected = false;
                    DropChecker(BrownCheckers[i].GameObj);
                }
            }
        }
        public static void LiftChecker(GameObject obj)
        {
            //dont drop checker if its on lifted position
            if (obj.transform.position.y > 0.5f) return;

            Vector3 endPos = obj.transform.position;
            endPos.y += 0.5f;
            obj.transform.position = Vector3.Lerp(obj.transform.position, endPos, 100);
        }
        public static void DropChecker(GameObject obj)
        {
            //dont drop checker if its on dropped position
            if (obj.transform.position.y < 0.5f) return;

            Vector3 endPos = obj.transform.position;
            endPos.y -= 0.5f;
            obj.transform.position = Vector3.Lerp(obj.transform.position, endPos, 100);
        }
        public static Checker SelectedChecker()
        {
            for (int i = 0; i < 15; i++)
            {
                if (BlueCheckers[i].Selected) 
                    return BlueCheckers[i];

                if (BrownCheckers[i].Selected) 
                    return BrownCheckers[i];
            }

            //If something went wrong, let user know that
            Debug.Log("Get Selected Object error, tried to get selected object while no object was selected");
            return BlueCheckers[0];
        }
        public static Checker CheckerOnPosition(Vector3 position)
        {
            for (int i = 0; i < 15; i++)
            {
                if (BlueCheckers[i].GameObj.transform.position == position) return BlueCheckers[i];
                if (BrownCheckers[i].GameObj.transform.position == position) return BrownCheckers[i];
            }
            
            //If something went wrong let user know that
            Debug.Log("FindCheckerByPosition error, there isn't any checker on this position.");
            return new Checker();
        }
        
        public static Checker CheckerWithGameobject(GameObject obj)
        {
            for (int i = 0; i < 15; i++)
            {
                if (BlueCheckers[i].GameObj == obj) return BlueCheckers[i];
                if (BrownCheckers[i].GameObj == obj) return BrownCheckers[i];
            }

            //If something went wrong let user know that
            Debug.Log("GameObjToPlayerChecker error, wrong object as argument");
            return new Checker();
        }

        //Assigns GameObjects to Checker array columns
        public static void MakeCheckersArray()
        {
            for (int i = 0; i < 15; i++)
            {
                BrownCheckers[i] = new Checker(GameObject.Find($"P1 ({i + 1})"), "Brown");
                BlueCheckers[i] = new Checker(GameObject.Find($"P2 ({i + 1})"), "Blue");
            }
        }
        public static void GetDefaultCheckersPosition()
        {
            for (int i=0; i<15; i++)
            {
                BrownDefaultPositions[i] = BrownCheckers[i].GameObj.transform.position;
                BlueDefaultPositions[i] = BlueCheckers[i].GameObj.transform.position;
            }
        }
        public static void ResetCheckersPosition()
        {
            for (int i=0; i<15; i++)
            {
                BrownCheckers[i].GameObj.transform.position = Vector3.Lerp(BrownCheckers[i].GameObj.transform.position, BrownDefaultPositions[i], 100);
                BlueCheckers[i].GameObj.transform.position = Vector3.Lerp(BlueCheckers[i].GameObj.transform.position, BlueDefaultPositions[i], 100);
            }
        }
        public static void ResetCheckersState()
        {
            for (int i = 0; i < 15; i++)
            {
                BrownCheckers[i].IsKing = false;
                BlueCheckers[i].IsKing = false;
            }
        }
    }
}
