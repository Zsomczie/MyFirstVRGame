using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text SliderValue;
    [SerializeField] CubeSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        //getting spawner gameobject
        spawner = GameObject.Find("CubeSpawner").GetComponent<CubeSpawner>(); 
        //changign value of slider to match the starting spawnrate
        slider.value = spawner.spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        //slider.onValueChanged.AddListener((v) => { SliderValue.text = v.ToString("0.00"); });

        //changing the text and the spawnrate to match the slider's value
        SliderValue.text = slider.value.ToString("0.00");
        spawner.spawnRate = slider.value;
    }
}
