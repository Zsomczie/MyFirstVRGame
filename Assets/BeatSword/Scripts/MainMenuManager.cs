using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] WeaponSwitchInput switchInput;
    [SerializeField] GameObject rightHandController, leftHandController;
    
    // Start is called before the first frame update
    void Awake()
    {
        //getting switchinput script for future reference
        switchInput = GameObject.FindObjectOfType<WeaponSwitchInput>();

    }
    private void Start()
    {
        //making sure time starts when scene starts
        Time.timeScale = 1;
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    //start buttion for main menu
    public void StartLevelOne()
    {
        SceneManager.LoadScene("Beat sword");
    }
    //exit game button
    public void ExitGame() 
    {
        Application.Quit();
    }
    //resume button for pause menu
    public void ResumeButton() 
    {

        if (Time.timeScale == 0/*PauseMenu.activeSelf == true*/)
        {

            //var cubes = GameObject.FindObjectsOfType<CubeMove>().ToList();
            //foreach (var cube in cubes)
            //{
            //    cube.enabled = true;
            //}
            //var Spawner = GameObject.FindObjectOfType<CubeSpawner>();
            //Spawner.enabled = true;
            switchInput.PauseMenu.SetActive(false);
            DestroyImmediate(rightHandController.GetComponent<XRRayInteractor>());
            DestroyImmediate(rightHandController.GetComponent<XRInteractorLineVisual>());
            DestroyImmediate(rightHandController.GetComponent<LineRenderer>());
            DestroyImmediate(leftHandController.GetComponent<XRRayInteractor>());
            DestroyImmediate(leftHandController.GetComponent<XRInteractorLineVisual>());
            DestroyImmediate(leftHandController.GetComponent<LineRenderer>());
            

            Time.timeScale = 1;
            switchInput.LastActive.SetActive(true);
        }
    }
    //main menu button for pause menu
    public void MainMenu() 
    {
        SceneManager.LoadScene("Main Menu");
    }
    //restart button for pause menu
    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
