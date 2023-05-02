using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] WeaponSwitchInput switchInput;
    [SerializeField] float spawnRate = 1.5f;
    void Awake()
    {
        switchInput = GameObject.FindFirstObjectByType<WeaponSwitchInput>();
        prefabs.Add(switchInput.swordCube);
        prefabs.Add(switchInput.hammerCube);
        prefabs.Add(switchInput.gunCube);
    }
    private void Start()
    {
    }

    // Update is called once per frame
    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    void Spawn()
    {
        int whichObject = Random.Range(0, prefabs.Count);
        Instantiate(prefabs[whichObject],transform.position,switchInput.generateRotation());
    }
}
