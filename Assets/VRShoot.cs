using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    [SerializeField]GameObject bullet;
    [SerializeField]GameObject RightHand;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject End;
    Vector3 offset;
    Quaternion gunRotation;
    Vector3 gunpos;
    public Quaternion RHRotation;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RHRotation=RightHand.transform.rotation;
        gunRotation = gun.transform.rotation;
        
    }
    public void OnShoot() 
    {

        Instantiate(bullet, new Vector3(End.transform.position.x, End.transform.position.y, End.transform.position.z), RHRotation);
    }
}
