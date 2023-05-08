using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] WeaponSwitchInput switchInput;
    [SerializeField] public float spawnRate = 1.5f;
    void Awake()
    {
        switchInput = GameObject.FindFirstObjectByType<WeaponSwitchInput>();
        //adding possible cubes to the list of spawnable objects
        prefabs.Add(switchInput.swordCube);
        prefabs.Add(switchInput.hammerCube);
        prefabs.Add(switchInput.gunCube);
    }
    private void Update()
    {
    }

    // Update is called once per frame

    //when the script is enabled, start spawning
    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    //when the script is disabled, stop spawning
    void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    //spawning a random type of cube with generated rotation
    void Spawn()
    {
        int whichObject = Random.Range(0, prefabs.Count);
        Instantiate(prefabs[whichObject],transform.position,switchInput.generateRotation());
    }
}
