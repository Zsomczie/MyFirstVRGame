using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime,this.transform);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        speed = 0;
    }
}
