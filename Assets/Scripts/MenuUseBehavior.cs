using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class MenuUseBehavior : VRTK_InteractableObject
    {
        public GameObject prefab;

        override public void StartUsing(GameObject currentUsingObject)
        {
            if (GameManager.instance.paused && !GameManager.instance.started)
            {
                Debug.Log(gameObject.name + " is being used");

                GameObject newProp = Instantiate(prefab);
                newProp.name = prefab.name;
                newProp.transform.position = transform.position;
                newProp.transform.parent = GameManager.instance.Levels[GameManager.instance.currentLevel].Props.transform;

                GameManager.LevelMan.GetOriginals();

                if (prefab.name == "Book" || prefab.name == "RaceC")
                    newProp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
        }
    }
}
