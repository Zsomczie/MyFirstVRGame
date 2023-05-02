using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text multiplierText;
    public int multiplier=1;
    public int fails = 0;
    public TMP_Text failsText;
    [SerializeField] GameObject dead;
    WeaponSwitchInput SwitchInput;
    // Start is called before the first frame update
    void Start()
    {
        SwitchInput = GameObject.FindFirstObjectByType<WeaponSwitchInput>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: "+ score.ToString();
        multiplierText.text = "Combo: " +multiplier.ToString() + "x";
        failsText.text = "Fails: " + fails.ToString();
        if (fails==5&& !SwitchInput.rightHandController.GetComponent<XRRayInteractor>())
        {
            dead.SetActive(true);
           SwitchInput.rightHandController.AddComponent<XRRayInteractor>();
            SwitchInput.rightHandController.AddComponent<XRInteractorLineVisual>();
            SwitchInput.leftHandController.AddComponent<XRRayInteractor>();
            SwitchInput.leftHandController.AddComponent<XRInteractorLineVisual>();
            if (SwitchInput.sword.activeSelf == true)
            {
                SwitchInput.sword.SetActive(false);
            }
            else if (SwitchInput.hammer.activeSelf == true)
            {
                SwitchInput.hammer.SetActive(false);
            }
            else if (SwitchInput.gun.activeSelf == true)
            {
                SwitchInput.gun.SetActive(false);
            }
            Time.timeScale = 0;
        }
    }
}
