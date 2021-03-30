using Assets.Scripts.Base;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Mechanics
{
    public class GameMechanics
    {
        public static bool SomeoneWin()
        {
            if (!IsAnyMovePossible("Brown") || !IsAnyMovePossible("Blue")) 
                return true;

            return false;
        }

        public static string CheckWhoWon()
        {
            if (!IsAnyMovePossible("Brown")) 
                return "Blue";

            if (!IsAnyMovePossible("Blue")) 
                return "Brown";

            //If something went wrong let user know that
            return "CheckWhoWon error. Method was used when no one won.";
        }
        public static void Move(GameObject checker, Vector3 endPos)
        {
            //Set fields state as free
            FieldManager.ModifyFieldStateUnder(checker, 1);
            
            //Change field y position to checker y position
            endPos.y = 0.3f;

            //Move checker
            checker.transform.position = Vector3.Lerp(checker.transform.position, endPos, 100);

            //Change field state to occupied
            if (CheckerManager.CheckerWithGameobject(checker).PlayerColor == "Blue")
            {
                FieldManager.ModifyFieldStateUnder(checker, 3);

                if ((int)checker.transform.position.z == 1) 
                    CheckerManager.CheckerWithGameobject(checker).IsKing = true;
            }
            if (CheckerManager.CheckerWithGameobject(checker).PlayerColor == "Brown")
            {
                FieldManager.ModifyFieldStateUnder(checker, 2);

                if ((int)checker.transform.position.z == 10)
                    CheckerManager.CheckerWithGameobject(checker).IsKing = true;
            }
        }
        
        public static bool CanCheckerJump(Checker checker)
        {
            //Gets array of fields on which checker can jump and checks if it can jump on any of them
            Field[] possibleJumps = FieldManager.GetSurroundingJumpingFields(checker);

            for (int i = 0; i < possibleJumps.Length; i++) 
                if (IsJumpPossible(checker.GameObj, possibleJumps[i].GameObject)) 
                    return true;

            return false;
        }

        public static bool IsAnyJumpPossible(string player)
        {
            //Works same as CanCheckerJump method, but checks jumps for every checker
            if (player == "Brown")
            {
                for (int i = 0; i < 15; i++)
                    if(CanCheckerJump(CheckerManager.BrownCheckers[i])) 
                        return true;
            }

            if (player == "Blue")
                for (int i = 0; i < 15; i++)
                    if (CanCheckerJump(CheckerManager.BlueCheckers[i]))
                        return true;
            
            return false;
        }
        public static bool IsAnyCheckerOnPosition(Vector3 position)
        {
            //Checks if any checker has equal position as argument
            for (int i = 0; i < 15; i++)
            {
                if (CheckerManager.BlueCheckers[i].GameObj.transform.position == position) 
                    return true;

                if (CheckerManager.BrownCheckers[i].GameObj.transform.position == position) 
                    return true;
            }
            return false;
        }
        public static bool IsMovePossible(GameObject gameObjChecker, GameObject gameObjField)
        {
            //Find checker with selected GameObject
            Checker checker = CheckerManager.CheckerWithGameobject(gameObjChecker);

            //Check if field is free
            if (!IsFieldFree(gameObjField)) 
                return false;

            //Check if move has 1 field length
            double distance = Vector3.Distance(gameObjChecker.transform.position, gameObjField.transform.position);

            if (distance > 1.65f || distance < 1.4f) 
                return false;

            //Check if move isnt backwards && checker isnt a king
            if (!checker.IsKing)
            {
                if (checker.PlayerColor == "Brown" && (gameObjField.transform.position.z - gameObjChecker.transform.position.z) < 0)
                    return false;

                if (checker.PlayerColor == "Blue" && (gameObjField.transform.position.z - gameObjChecker.transform.position.z) > 0) 
                    return false;
            }

            return true;
        }

        public static bool IsFieldFree(GameObject obj)
        {
            //Find field with selected GameObject
            Field field = FieldManager.FieldWithGameObject(obj);
            
            //Check field state (1 - field isnt occupied)
            if (field.State == 1) 
                return true;

            else 
                return false;
        }
        public static bool AnyCheckerIsSelected()
        {
            for (int i = 0; i < 15; i++)
            {
                if (CheckerManager.BlueCheckers[i].Selected) 
                    return true;

                if (CheckerManager.BrownCheckers[i].Selected) 
                    return true;
            }

            return false;
        }
        public static bool IsJumpPossible(GameObject gameObjChecker, GameObject gameObjField)
        {
            //Search checker and fields array for variable with same GameObject as given as argument
            Checker checker = CheckerManager.CheckerWithGameobject(gameObjChecker);
            Field field = FieldManager.FieldWithGameObject(gameObjField);
            
            //Check if field is free
            if (!IsFieldFree(field.GameObject)) 
                return false;
            
            
            //Check if jumping distance is correct
            double distance = Vector3.Distance(checker.GameObj.transform.position, field.GameObject.transform.position);

            if (distance > 2.95f || distance < 2.8f) 
                return false;
            
            
            //Check if move isnt backwards && checker isnt a king
            if (!checker.IsKing)
            {
                if (checker.PlayerColor == "Brown" && (checker.GameObj.gameObject.transform.position.z - field.GameObject.transform.position.z) > 0) 
                    return false;

                if (checker.PlayerColor == "Blue" && (checker.GameObj.transform.position.z - field.GameObject.transform.position.z) < 0) 
                    return false;
            }

            //Check if enemy is between checker and field
            Vector3 enemyPos = checker.GameObj.transform.position;
            enemyPos.x = (checker.GameObj.transform.position.x + field.GameObject.transform.position.x) / 2;
            enemyPos.z = (checker.GameObj.transform.position.z + field.GameObject.transform.position.z) / 2;
            enemyPos.y = 0.3f;
      
            //Check if player wants to jump over enemy or over free field
            if (!IsAnyCheckerOnPosition(enemyPos)) 
                return false;
            
            //If player wants to jump over another checker, check if that checker is an enemy
            else
            {
                if (CheckerManager.CheckerOnPosition(enemyPos).PlayerColor == "Blue" && checker.PlayerColor == "Blue") 
                    return false; 

                if (CheckerManager.CheckerOnPosition(enemyPos).PlayerColor == "Brown" && checker.PlayerColor == "Brown") 
                    return false;
            }

            return true;
        }
        public static bool IsAnyMovePossible(string player)
        {
            //Get array of possible moves and jumps for every checker, and check if any of this moves is possible
            if (player == "Brown")
            {
                for (int i = 0; i < 15; i++)
                {
                    Field[] possibleMoves = FieldManager.GetSurroundingFields(CheckerManager.BrownCheckers[i]);

                    for (int j = 0; j < possibleMoves.Length; j++) 
                        if (IsMovePossible(CheckerManager.BrownCheckers[i].GameObj, possibleMoves[j].GameObject)) 
                            return true;

                    Field[] possibleJumps = FieldManager.GetSurroundingJumpingFields(CheckerManager.BrownCheckers[i]);

                    for (int j = 0; j < possibleJumps.Length; j++) 
                        if (IsJumpPossible(CheckerManager.BrownCheckers[i].GameObj, possibleJumps[j].GameObject)) 
                            return true;
                }
            }

            if (player == "Blue")
            {
                for (int i = 0; i < 15; i++)
                {
                    Field[] possibleMoves = FieldManager.GetSurroundingFields(CheckerManager.BlueCheckers[i]);

                    for (int j = 0; j < possibleMoves.Length; j++) 
                        if (IsMovePossible(CheckerManager.BlueCheckers[i].GameObj, possibleMoves[j].GameObject)) 
                            return true;

                    Field[] possibleJumps = FieldManager.GetSurroundingJumpingFields(CheckerManager.BlueCheckers[i]);

                    for (int j = 0; j < possibleJumps.Length; j++) 
                        if (IsJumpPossible(CheckerManager.BlueCheckers[i].GameObj, possibleJumps[j].GameObject)) 
                            return true;
                }
            }

            return false;
        }
        public static void ResetGame()
        {
            CheckerManager.ResetCheckersPosition();
            CheckerManager.ResetCheckersState();
            FieldManager.ResetFieldStates();
            CameraManager.SetCameraToBoardPosition();
        }
        public static void Exit() => Application.Quit();
    }
}
