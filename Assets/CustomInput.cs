using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomInput : MonoBehaviour
{
    [SerializeField] GameObject MenuCanvas, Player, cube;
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
    public void OnTp() 
    {
        //Player.transform.position = new Vector3(0, 0, 0);
        //Player.transform.rotation = new Quaternion(0,0,0,0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnSummonCube() 
    {
        int x = Random.Range(-11, -4);
        int y = 6;
        int z = Random.Range(7, 14);
        Vector3 cubePos = new Vector3(x, y, z);
        Instantiate(cube, cubePos, new Quaternion(0, 0, 0, 0));
    }
}
