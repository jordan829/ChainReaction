using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceholderBehavior : MonoBehaviour {

    public List<MeshRenderer> meshes;
    private bool placed = false;

    void Update()
    {

        if (!GameManager.instance.paused && GameManager.instance.started)
            foreach (MeshRenderer mesh in meshes)
                mesh.enabled = false;

        else if (GameManager.instance.started || placed)
            foreach (MeshRenderer mesh in meshes)
                mesh.enabled = false;

        else
            foreach (MeshRenderer mesh in meshes)
                mesh.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == gameObject.name)
            placed = true;
            //foreach (MeshRenderer mesh in meshes)
                //mesh.enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == gameObject.name)
            placed = false;
            //foreach (MeshRenderer mesh in meshes)
                //mesh.enabled = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == gameObject.name)
            placed = true;
            //foreach (MeshRenderer mesh in meshes)
                //mesh.enabled = false;
    }

   
}
