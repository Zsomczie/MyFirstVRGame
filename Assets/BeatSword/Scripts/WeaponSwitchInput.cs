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
    public Vector3 velocity;
    [SerializeField] InputActionProperty velocityProperty;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //velocity = velocityProperty.action.ReadValue<Vector3>();
    }
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
    public void OnSpawnHammerCube()
    {

        Instantiate(hammerCube, new Vector3(0, 0.5f, 24), generateRotation());
    }
    public void OnSpawnSwordCube()
    {
        Instantiate(swordCube, new Vector3(0, 0.5f, 24), generateRotation());
    }
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
            rightHandController.AddComponent<XRRayInteractor>();
            rightHandController.AddComponent<XRInteractorLineVisual>();
            leftHandController.AddComponent<XRRayInteractor>();
            leftHandController.AddComponent<XRInteractorLineVisual>();
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
            Time.timeScale = 0;
        }
        else if (Time.timeScale==0/*PauseMenu.activeSelf == true*/)
        {

            //var cubes = GameObject.FindObjectsOfType<CubeMove>().ToList();
            //foreach (var cube in cubes)
            //{
            //    cube.enabled = true;
            //}
            //var Spawner = GameObject.FindObjectOfType<CubeSpawner>();
            //Spawner.enabled = true;
            DestroyImmediate(rightHandController.GetComponent<XRRayInteractor>());
            DestroyImmediate(rightHandController.GetComponent<XRInteractorLineVisual>());
            DestroyImmediate(rightHandController.GetComponent<LineRenderer>());
            DestroyImmediate(leftHandController.GetComponent<XRRayInteractor>());
            DestroyImmediate(leftHandController.GetComponent<XRInteractorLineVisual>());
            DestroyImmediate(leftHandController.GetComponent<LineRenderer>());
            PauseMenu.SetActive(false);
            
            Time.timeScale = 1;
            LastActive.SetActive(true);
        }
    }
}
