using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;

public class WeaponSwitchInput : MonoBehaviour
{
    public GameObject sword, hammer, gun;
    public GameObject LastActive, rightHandController, leftHandController, PauseMenu, hammerCube, swordCube, gunCube;
    [SerializeField] InputActionProperty velocityProperty;
    [SerializeField] CubeSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        //just making sure time is always started when the scene starts
        Time.timeScale = 1;
        //finding spawner for possible value change in the pause menu
        spawner = GameObject.Find("CubeSpawner").GetComponent<CubeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(velocityProperty.action.ReadValue<Vector3>());
    }
    //switching between weapons
    public void OnSwitchSword()
    {
        sword.SetActive(true);
        hammer.SetActive(false);
        gun.SetActive(false);
    }
    public void OnSwitchHammer()
    {
        Debug.Log("hi");
        hammer.SetActive(true);
        sword.SetActive(false);
        gun.SetActive(false);
    }
    public void OnSwitchGun()
    {
        gun.SetActive(true);
        sword.SetActive(false);
        hammer.SetActive(false);
    }
    //developer tool: spawning different cubes with buttons
    public void OnSpawnHammerCube()
    {

        Instantiate(hammerCube, new Vector3(0, 0.5f, 24), generateRotation());
    }
    public void OnSpawnSwordCube()
    {
        Instantiate(swordCube, new Vector3(0, 0.5f, 24), generateRotation());
    }
    //method to generate random rotation for the cubes
    public Quaternion generateRotation()
    {
        int cubeRotation = Random.Range(0, 4);
        if (cubeRotation == 0)
        {
            Quaternion fixRotation = Quaternion.Euler(0, 0, 0);
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
    //when pause menu button is pressed
    public void OnBeatMenu()
    {
        if (Time.timeScale== 1 /*PauseMenu.activeSelf == false*/) //if this doesn't work, try disabling every cubes' movement script.
        {
            //var cubes = GameObject.FindObjectsOfType<CubeMove>().ToList();
            //foreach (var cube in cubes)
            //{
            //    cube.enabled = false;
            //}
            //var Spawner = GameObject.FindObjectOfType<CubeSpawner>();
            //Spawner.enabled = false;
            
            PauseMenu.SetActive(true);
            //adding all necessary componets to the hands
            rightHandController.AddComponent<XRRayInteractor>();
            rightHandController.AddComponent<XRInteractorLineVisual>();
            leftHandController.AddComponent<XRRayInteractor>();
            leftHandController.AddComponent<XRInteractorLineVisual>();
            //setting lastactive variable to the correct weapon
            if (sword.activeSelf == true)
            {
                LastActive = sword;
                sword.SetActive(false);
            }
            else if (hammer.activeSelf == true)
            {
                LastActive = hammer;
                hammer.SetActive(false);
            }
            else if (gun.activeSelf == true)
            {
                LastActive = gun;
                gun.SetActive(false);
            }
            //disabling spawner so value change counts
            spawner.enabled = false;
            //stopping time
            Time.timeScale = 0;
        }
        //when the button is pressed, but menu is already open, close it
        else if (Time.timeScale==0/*PauseMenu.activeSelf == true*/)
        {

            //var cubes = GameObject.FindObjectsOfType<CubeMove>().ToList();
            //foreach (var cube in cubes)
            //{
            //    cube.enabled = true;
            //}
            //var Spawner = GameObject.FindObjectOfType<CubeSpawner>();
            //Spawner.enabled = true;

            //remove all unnecessary components
            DestroyImmediate(rightHandController.GetComponent<XRRayInteractor>());
            DestroyImmediate(rightHandController.GetComponent<XRInteractorLineVisual>());
            DestroyImmediate(rightHandController.GetComponent<LineRenderer>());
            DestroyImmediate(leftHandController.GetComponent<XRRayInteractor>());
            DestroyImmediate(leftHandController.GetComponent<XRInteractorLineVisual>());
            DestroyImmediate(leftHandController.GetComponent<LineRenderer>());
            PauseMenu.SetActive(false);
            
            Time.timeScale = 1;
            //re-enable the spawner so changes in the pause menu are applied
            spawner.enabled = true;
            //get last active weapon back
            LastActive.SetActive(true);
        }
    }
}
