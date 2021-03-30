using UnityEngine;

namespace Assets.Scripts.Base
{
    public class Checker
    {
        public GameObject GameObj;
        public string PlayerColor;
        public bool IsKing;
        public bool Selected;

        public Checker(GameObject obj, string color)
        {
            GameObj = obj;
            PlayerColor = color;
            IsKing = false;
            Selected = false;
        }
        public Checker()
        {
            GameObj = new GameObject();
            PlayerColor = "";
            IsKing = false;
            Selected = false;
        }
    }
}
