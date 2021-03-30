using UnityEngine;

namespace Assets.Scripts.Base
{
    public class Field
    {
        public GameObject GameObject;
        public int State;
        //states:
        //1-free
        //2-occupied by brown player
        //3-occupied by blue player

        public Field()
        {
            GameObject = new GameObject();
            State = 1;
        }
        public Field(GameObject field, int state)
        {
            GameObject = field;
            State = state;
        }
    }
}
