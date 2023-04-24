using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class WeaponSwitchInput : MonoBehaviour
{
    [SerializeField] GameObject sword, hammer, hammerCube, swordCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void OnSwitchSword() 
    {
        sword.SetActive(true);
        hammer.SetActive(false);
    }
    public void OnSwitchHammer()
    {
        hammer.SetActive(true);
        sword.SetActive(false);
    }
    public void OnSpawnHammerCube() 
    {

        Instantiate(hammerCube, new Vector3(0, 0.5f, 24), generateRotation());
    }
    public void OnSpawnSwordCube() 
    {
        Instantiate(swordCube, new Vector3(0, 0.5f, 24), generateRotation());
    }
    public static Quaternion generateRotation() 
    {
        int cubeRotation = Random.Range(0, 4);
        if (cubeRotation==0)
        {
            Quaternion fixRotation=Quaternion.Euler(0,0,0);
            return fixRotation;
        }
        if (cubeRotation == 1)
        {
            Quaternion fixRotation = Quaternion.Euler(0, 0, 90);
            return fixRotation;
        }
        if (cubeRotation == 2)
        {
            Quaternion fixRotation = Quaternion.Euler(0, 0, 180);
            return fixRotation;
        }
        else
        {
            Quaternion fixRotation = Quaternion.Euler(0, 0, 270);
            return fixRotation;
        }

    }
    public void OnVelocity() 
    {
        
    }
}
