using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving the cubes with a set speed
        transform.Translate(new Vector3(0,0,-speed)*Time.deltaTime);
    }
}
