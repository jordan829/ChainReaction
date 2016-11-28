using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class RetryLevelButton : VRTK_InteractableObject
    {

        override public void StartUsing(GameObject currentUsingObject)
        {
            if (GameManager.instance.levelComplete)
            {
                GameManager.instance.currentLevel--;
                GameManager.instance.NextLevel();
            }
        }
    }
}
