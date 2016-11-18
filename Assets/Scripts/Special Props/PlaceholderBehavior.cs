using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceholderBehavior : MonoBehaviour {

    public List<MeshRenderer> meshes;

    void Start()
    {
        //mesh = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == gameObject.name)
            foreach(MeshRenderer mesh in meshes)
                mesh.enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == gameObject.name)
            foreach (MeshRenderer mesh in meshes)
                mesh.enabled = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == gameObject.name)
            foreach (MeshRenderer mesh in meshes)
                mesh.enabled = false;
    }
}
