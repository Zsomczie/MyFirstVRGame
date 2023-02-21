using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject rightHandController, Menu;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(rightHandController.GetComponent<XRDirectInteractor>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Menu.activeInHierarchy&&rightHandController.GetComponent<XRDirectInteractor>()&& !rightHandController.GetComponent<LineRenderer>())
        {
            DestroyImmediate(rightHandController.GetComponent<XRDirectInteractor>());
            rightHandController.AddComponent<XRRayInteractor>();
            rightHandController.AddComponent<XRInteractorLineVisual>();
            rightHandController.AddComponent<LineRenderer>();
        }
         else if (!Menu.activeInHierarchy&&!rightHandController.GetComponent<XRDirectInteractor>())
        {
            DestroyImmediate(rightHandController.GetComponent<XRRayInteractor>());
            DestroyImmediate(rightHandController.GetComponent<XRInteractorLineVisual>());
            DestroyImmediate(rightHandController.GetComponent<LineRenderer>());
            rightHandController.AddComponent<XRDirectInteractor>();
        }
        
            
        
    }
    
}
