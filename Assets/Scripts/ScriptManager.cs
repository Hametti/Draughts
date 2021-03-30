using UnityEngine;
using Assets.Scripts.Managers;
using Assets.Scripts.Mechanics;

public class ScriptManager : MonoBehaviour
{
    //Know what objects are clickable
    public LayerMask clickableLayer;

    //Cursor textures
    public Texture2D normalPointer; //normal pointer
    public Texture2D clickableObjPointer; //clickable objects pointer

    //Checker colours
    public Material[] material;
    public Renderer rend;

    //Start is called before the first frame update
    void Start()
    {
        //Assign checkers(gameobjects) and fields(gameobjects) to Checker(class) and Field(class) array, 
        TurnSystem.InitializeData();

        //Start first turn, make first player clickable, second player unclickable etc.
        TurnSystem.StartGame();
    }

    //Update is called once per frame
    void Update()
    {
        //Set checkers color depending on their state
        MaterialsManager.SetMaterialsToDefault(this);

        //If player cursor points on clickable object
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayer.value))
        {
            //Assign pointed object to variable
            GameObject selectedObject = hit.collider.gameObject;

            //Change cursor texture to "clickable" and change pointed checker color to white
            CursorManager.SetCursorToClickablePointer(this);
            MaterialsManager.ChangeObjectMaterialTo(this, selectedObject, 4);

            //If left mouse button was clicked
            if (Input.GetMouseButtonDown(0))
            {
                if (selectedObject.tag == "Exit")
                    GameMechanics.Exit();

                if (selectedObject.tag == "Restart")
                    TurnSystem.StartGame();

                //If player tries to move or jump
                if (selectedObject.tag == "Field" && GameMechanics.AnyCheckerIsSelected())
                {
                    //Distance variable measures distance between selected checker, and field on which player wants to move
                    //Basing on that distance, you can check if player tries to move or jump
                    double distance = Vector3.Distance(CheckerManager.SelectedChecker().GameObj.transform.position, selectedObject.transform.position);

                    //If player tries to move
                    if (distance < 1.65f)

                        //If its players first move allow to move, otherwise if player already jumped, allow only next jumps(if they are possible)
                        if (TurnSystem.FirstMove)
                        {
                            //Player have to always jump if its possible
                            if (GameMechanics.IsAnyJumpPossible(CheckerManager.SelectedChecker().PlayerColor)) 
                                Debug.Log("You have to jump.");

                            //If its first move and move is allowed, move player
                            else 
                                if (GameMechanics.IsMovePossible(CheckerManager.SelectedChecker().GameObj, selectedObject))
                                {
                                    GameMechanics.Move(CheckerManager.SelectedChecker().GameObj, selectedObject.transform.position);
                                    TurnSystem.EndTurn();
                                }
                        }

                        //If player already jumped and tries to move instead of jumping 
                        else 
                            Debug.Log("You have to jump.");

                    //If player tries to jump
                    if (distance > 1.65f && distance < 2.95f)
                        if (GameMechanics.IsJumpPossible(CheckerManager.SelectedChecker().GameObj, selectedObject))
                        {
                            CheckerManager.RemoveEnemyBetween(CheckerManager.SelectedChecker().GameObj, selectedObject);
                            GameMechanics.Move(CheckerManager.SelectedChecker().GameObj, selectedObject.transform.position);
                            TurnSystem.FirstMove = false;

                            //If selected checker after previous jump can do another jump, dont end turn and let user know that next move is possible
                            if (GameMechanics.CanCheckerJump(CheckerManager.SelectedChecker())) 
                                Debug.Log("Next move is possible");

                            else 
                                TurnSystem.EndTurn();
                        }
                }

                //If player didn't click on selected checker, deselect previous selected checker
                if (GameMechanics.AnyCheckerIsSelected() && CheckerManager.SelectedChecker().GameObj != selectedObject)
                    CheckerManager.DeselectCheckers();

                CheckerManager.SelectChecker(selectedObject);
            }
        }

        //If cursor doesn't point on anything clickable
        else
        {
            CursorManager.SetCursorToNormalPointer(this);

            if (Input.GetMouseButtonDown(0)) 
                CheckerManager.DeselectCheckers();
        }
    }
}










