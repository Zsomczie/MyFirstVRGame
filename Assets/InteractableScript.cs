using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    MeshRenderer mr;
    Material defaultMaterial;
    [SerializeField] Material hovererMaterial;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        defaultMaterial = mr.material;
    }

    // Update is called once per frame
    public void hoverEnter() 
    {
        mr.material = hovererMaterial;
    }
    public void hoverExit()
    {
        mr.material = defaultMaterial;
    }
}
