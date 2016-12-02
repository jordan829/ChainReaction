using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
    public class ExitGameButton : VRTK_InteractableObject
    {
        override public void StartUsing(GameObject currentUsingObject)
        {
            Application.Quit();
        }
    }
}