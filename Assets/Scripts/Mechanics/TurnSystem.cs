using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Mechanics
{
    public class TurnSystem
    {
        public static bool BrownPlayerTurn;
        public static bool FirstMove;
        public static void EndTurn()
        {
            //After every turn check if someone won
            if (GameMechanics.SomeoneWin())
            {
                //Find a winner
                string winnerColor = GameMechanics.CheckWhoWon();

                //Write who won
                GameObject text = GameObject.Find("PlayerWinsText");
                text.GetComponent<TMPro.TextMeshPro>().text = $"{winnerColor} player wins";

                //Set camera position to winner scene
                CameraManager.SetCameraToWinnerScreenPosition();
            }
            
            //Make current player clickable, and enemy unclickable
            if (BrownPlayerTurn)
            {
                MakeBlueCheckersClickable();
                BrownPlayerTurn = false;
            }
            else
            {
                MakeBrownCheckersClickable();
                BrownPlayerTurn = true;
            }

            //Make firstmove variable true, if first move variable isnt true, only possible moves are jumps
            FirstMove = true;
        }
        public static void MakeBrownCheckersClickable()
        {
            for (int i = 0; i < 15; i++)
            {
                CheckerManager.BrownCheckers[i].GameObj.layer = 8;
                CheckerManager.BlueCheckers[i].GameObj.layer = 0;
            }
            // 8 - Clickable layer
            // 0 - Default, unclickable layer
        }
        public static void MakeBlueCheckersClickable()
        {
            for (int i = 0; i < 15; i++)
            {
                CheckerManager.BrownCheckers[i].GameObj.layer = 0;
                CheckerManager.BlueCheckers[i].GameObj.layer = 8;
            }
            // 8 - Clickable layer
            // 0 - Default, unclickable layer
        }
        public static void StartGame()
        {
            GameMechanics.ResetGame();
            MakeBrownCheckersClickable();
            BrownPlayerTurn = true;
            FirstMove = true;
        }

        public static void InitializeData()
        {
            CheckerManager.MakeCheckersArray();
            CheckerManager.GetDefaultCheckersPosition();
            FieldManager.MakeFieldsArray();
        }
    }
}
