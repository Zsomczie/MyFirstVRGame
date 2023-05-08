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
        
        spawner = GameObject.Find("CubeSpawner").GetComponent<CubeSpawner>();
        slider.value = spawner.spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        //slider.onValueChanged.AddListener((v) => { SliderValue.text = v.ToString("0.00"); });
        SliderValue.text = slider.value.ToString("0.00");
        spawner.spawnRate = slider.value;
    }
}
