using Assets.Scripts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class FieldManager
    {
        public static Field[] BlackFieldsBoard = new Field[50];
        public static void MakeFieldsArray()
        {
            for (int i = 0; i < 50; i++)
            {
                //state 1 - field is free
                //state 2 - field is occupied by brown player
                //state 3 - field is occupied by blue player
                int state = 1;

                //brown checkers stands on (1-15) blackfields, blue checkers stands on (35-50) black fields
                if (i < 15) 
                    state = 2;

                if (i > 34) 
                    state = 3;

                BlackFieldsBoard[i] = new Field(GameObject.Find($"Black ({i + 1})"), state);
            }
        }
        public static Field[] GetSurroundingFields(Checker checker)
        {
            Field[] surroundingFields;

            //Every checker has 4 surrounding possible to move positions
            Vector3[] positionsArray = new Vector3[4];

            //top-left position
            positionsArray[0] = checker.GameObj.transform.position;
            positionsArray[0].z += 1;
            positionsArray[0].x -= 1;
            positionsArray[0].y = 0;

            //top-right position
            positionsArray[1] = checker.GameObj.transform.position;
            positionsArray[1].z += 1;
            positionsArray[1].x += 1;
            positionsArray[1].y = 0;

            //bottom-left position
            positionsArray[2] = checker.GameObj.transform.position;
            positionsArray[2].z -= 1;
            positionsArray[2].x -= 1;
            positionsArray[2].y = 0;

            //bottom-right position
            positionsArray[3] = checker.GameObj.transform.position;
            positionsArray[3].z -= 1;
            positionsArray[3].x += 1;
            positionsArray[3].y = 0;

            //Check how many of these fields exists on board, and make array with exact length
            int length = 0;
            for (int i = 0; i < positionsArray.Length; i++) 
                if (FieldExists(positionsArray[i])) 
                    length++;

            surroundingFields = new Field[length];

            //Add all fields that exists to surrounding fields array and return it
            int index = 0;
            for (int i = 0; i < positionsArray.Length; i++)
            {
                if (FieldExists(positionsArray[i]))
                {
                    surroundingFields[index] = GetFieldByPosition(positionsArray[i]);
                    index++;
                }
            }

            return surroundingFields;
        }
        public static Field[] GetSurroundingJumpingFields(Checker checker)
        {
            //Works same as GetSurroundingFields method
            Field[] surroundingFields;

            Vector3[] positionsArray = new Vector3[4];

            positionsArray[0] = checker.GameObj.transform.position;
            positionsArray[0].z += 2;
            positionsArray[0].x -= 2;
            positionsArray[0].y = 0;

            positionsArray[1] = checker.GameObj.transform.position;
            positionsArray[1].z += 2;
            positionsArray[1].x += 2;
            positionsArray[1].y = 0;

            positionsArray[2] = checker.GameObj.transform.position;
            positionsArray[2].z -= 2;
            positionsArray[2].x -= 2;
            positionsArray[2].y = 0;

            positionsArray[3] = checker.GameObj.transform.position;
            positionsArray[3].z -= 2;
            positionsArray[3].x += 2;
            positionsArray[3].y = 0;

            int length = 0;
            for (int i = 0; i < positionsArray.Length; i++) 
                if (FieldExists(positionsArray[i])) 
                    length++;

            surroundingFields = new Field[length];

            int index = 0;
            for (int i = 0; i < positionsArray.Length; i++)
            {
                if (FieldExists(positionsArray[i]))
                {
                    surroundingFields[index] = GetFieldByPosition(positionsArray[i]);
                    index++;
                }
            }
            return surroundingFields;
        }
        public static bool FieldExists(Vector3 position)
        {
            for (int i = 0; i < 50; i++) 
                if (BlackFieldsBoard[i].GameObject.transform.position == position) 
                    return true;

            return false;
        }
        public static Field GetFieldByPosition(Vector3 position)
        {
            for (int i = 0; i < 50; i++) 
                if (BlackFieldsBoard[i].GameObject.transform.position == position) 
                    return BlackFieldsBoard[i];

            //If something went wrong let user know that
            Debug.Log("FindFieldByPosition error, there isn't any field on this position.");
            return new Field();
        }

        public static Field FieldUnderChecker(GameObject checker)
        {
            //Make field position variable basing on checker position and check if field with that position exists and return it
            Vector3 fieldPos = checker.transform.position;
            fieldPos.y = 0;
            for (int i = 0; i < 50; i++) 
                if (BlackFieldsBoard[i].GameObject.transform.position == fieldPos) 
                    return BlackFieldsBoard[i];

            //If something went wrong let user know that
            Debug.Log("GetFieldFromChecker error, didn't find any correct field");
            return BlackFieldsBoard[0];
        }
        public static Field FieldWithGameObject(GameObject obj)
        {
            for (int i = 0; i < 50; i++) 
                if (BlackFieldsBoard[i].GameObject == obj) 
                    return BlackFieldsBoard[i];

            //If something went wrong let user know that
            Debug.Log("GameObjToBoardField error, wrong object as argument");
            return new Field();
        }
        public static void ResetFieldStates()
        {
            for(int i=0; i<50; i++)
            {
                if (i < 15) 
                    BlackFieldsBoard[i].State = 2;

                else if (i > 34) 
                    BlackFieldsBoard[i].State = 3;

                else BlackFieldsBoard[i].State = 1;
            }
        }
        public static void ModifyFieldStateUnder(GameObject checker, int state) => FieldUnderChecker(checker).State = state;
    }
}
