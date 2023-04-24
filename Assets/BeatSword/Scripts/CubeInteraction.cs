using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class CubeInteraction : MonoBehaviour
{
    [SerializeField] GameObject sword, hammer;
    [SerializeField] bool IsSword;
    public InputActionProperty velocityProperty;
    [SerializeField] Quaternion rotation;
    [SerializeField] int rotationBool;
    //public Vector3 lol;
    // Start is called before the first frame update
    void Start()
    {

        rotation = this.transform.rotation;
        sword = GameObject.FindObjectsOfType<FindMe>(true).Select(x=>x.gameObject).Where(x=>x.gameObject.name.Contains("Sword")).First();
        hammer = GameObject.FindObjectsOfType<FindMe>(true).Select(x => x.gameObject).Where(x => x.gameObject.name.Contains("Hammer")).First();
        if (gameObject.name.Contains("Sword"))
        {
            IsSword = true;
        }
        else
        {
            IsSword = false;
        }
        if (rotation.eulerAngles.z == 0)
        {
            rotationBool = 0; // left to right
        }
        else if (rotation.eulerAngles.z == 90)
        {
            rotationBool = 1; // bottom to top
        }
        else if (rotation.eulerAngles.z == 180)
        {
            rotationBool = 2; // right to left
        }
        else
        {
            rotationBool = 3; // top to bottom
        }

    }

    // Update is called once per frame
    void Update()
    {
        //lol=velocityProperty.action.ReadValue<Vector3>();
        // Debug.Log(lol); // up +y down -y left -x right +x
        


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.gameObject==sword&&IsSword)
        {
            if (velocityProperty.action.ReadValue<Vector3>().x>-0.05&&rotationBool==0)
            {
                Debug.Log("goodge");
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().x < 0.05 && rotationBool == 2)
            {
                Debug.Log("goodge");
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().y > -0.05 && rotationBool == 1)
            {
                Debug.Log("goodge");
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().y < 0.05 && rotationBool == 3)
            {
                Debug.Log("goodge");
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("bedge");
                Destroy(this.gameObject);
            }

            //right direction
        }
        else if(other.gameObject.transform.parent.gameObject == hammer&&!IsSword)
        {
            if (velocityProperty.action.ReadValue<Vector3>().x > -0.05 && rotationBool == 0)
            {
                Debug.Log("goodge");
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().x < 0.05 && rotationBool == 2)
            {
                Debug.Log("goodge");
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().y > -0.05 && rotationBool == 1)
            {
                Debug.Log("goodge");
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().y < 0.05 && rotationBool == 3)
            {
                Debug.Log("goodge");
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("bedge");
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
