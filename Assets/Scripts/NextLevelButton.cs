using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class NextLevelButton : VRTK_InteractableObject
    {
        override public void StartUsing(GameObject currentUsingObject)
        {
            Debug.Log("HELLLOOOOOO?????");
            if (GameManager.instance.levelComplete)
            {
                GameManager.instance.NextLevel();
            }
        }
    }
}
