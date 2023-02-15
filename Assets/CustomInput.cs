using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInput : MonoBehaviour
{
    [SerializeField] GameObject MenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMenu() 
    {
        MenuCanvas.SetActive(!MenuCanvas.activeInHierarchy);
    }
}
