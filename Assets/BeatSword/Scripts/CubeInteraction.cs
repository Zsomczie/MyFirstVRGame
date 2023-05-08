using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class CubeInteraction : MonoBehaviour
{
    [SerializeField] GameObject sword, hammer, gun;
    [SerializeField] bool IsSword, IsGun;
    public InputActionProperty velocityProperty;
    [SerializeField] Quaternion rotation;
    [SerializeField] int rotationBool;
    ScoreManager scoreMan;
    //public Vector3 lol;
    // Start is called before the first frame update
    void Start()
    {
        //using this to modify score later
        scoreMan = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); 
        //getting rotation to check which way the cube is facing later
        rotation = this.transform.rotation;
        //getting the 3 weapons
        sword = GameObject.FindObjectsOfType<FindMe>(true).Select(x=>x.gameObject).Where(x=>x.gameObject.name.Contains("Sword")).First();
        hammer = GameObject.FindObjectsOfType<FindMe>(true).Select(x => x.gameObject).Where(x => x.gameObject.name.Contains("Hammer")).First();
        gun = GameObject.FindObjectsOfType<FindMe>(true).Select(x => x.gameObject).Where(x => x.gameObject.name.Contains("Gun")).First();
        //is it a sword cube, or a hammer cube?
        if (gameObject.name.Contains("Sword")) 
        {
            IsSword = true;
            IsGun = false;
        }
        else if(gameObject.name.Contains("Gun"))
        {
            IsGun = true;
            IsSword = false;
        }
        else
        {
            IsGun = false;
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
        //lol = velocityProperty.action.ReadValue<Vector3>();
        //Debug.Log(lol); // up +y down -y left -x right +x
    }
    private void OnTriggerEnter(Collider other)
    {
        //if a bullet or the gun hits the cube, and the cube is a gun cube, increase score
        if (other.gameObject.name.Contains("Bullet") && IsGun || other.gameObject.name.Contains("Gun") && IsGun)
        {
            if (other.gameObject.name.Contains("Gun"))
            {
                scoreMan.score += 100 * scoreMan.multiplier; //increasing score depending on combo
                if (scoreMan.multiplier < 8) //multiplier can't be more than 8
                {
                    scoreMan.multiplier += 1;
                }
                Destroy(this.gameObject);
            }
            //if it's a bullet, destroy the bullet as well
            else
            {
                scoreMan.score += 100 * scoreMan.multiplier; //increasing score depending on combo
                if (scoreMan.multiplier < 8) //multiplier can't be more than 8
                {
                    scoreMan.multiplier += 1;
                }
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
            

        }
        //if a bullet hits the cube but it's not a gun cube, it's a fail
        else if (other.gameObject.name.Contains("Bullet") && !IsGun)
        {
            scoreMan.multiplier = 1;
            scoreMan.fails++;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        //checking if sword cube is hit from right direction 
        else if (other.gameObject.transform.parent.gameObject==sword&&IsSword) //if the used weapon is correct 
        {
            //if the weapon is right, but it's still
            if (velocityProperty.action.ReadValue<Vector3>().x < 0.015&& velocityProperty.action.ReadValue<Vector3>().x > -0.015)
            {
                Debug.Log("bedge");
                scoreMan.multiplier = 1;
                scoreMan.fails++;
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().x>-0.05&&rotationBool==0) //reading the value of the velocity input //right 
            {
                Debug.Log("goodge");
                scoreMan.score += 100*scoreMan.multiplier; //increasing score depending on combo
                if (scoreMan.multiplier<8) //multiplier can't be more than 8
                {
                    scoreMan.multiplier += 1;
                }
                
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().x < 0.05 && rotationBool == 2) //left
            {
                Debug.Log("goodge");
                scoreMan.score += 100 * scoreMan.multiplier; 
                if (scoreMan.multiplier < 8) 
                {
                    scoreMan.multiplier += 1;
                }
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().y > -0.05 && rotationBool == 1) //up
            {
                Debug.Log("goodge");
                scoreMan.score += 100 * scoreMan.multiplier;
                if (scoreMan.multiplier < 8)
                {
                    scoreMan.multiplier += 1;
                }
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().y < 0.05 && rotationBool == 3) //down
            {
                Debug.Log("goodge");
                scoreMan.score += 100 * scoreMan.multiplier;
                if (scoreMan.multiplier < 8)
                {
                    scoreMan.multiplier += 1;
                }
                Destroy(this.gameObject);
            }
            else //wrong direction
            {
                Debug.Log("bedge");
                scoreMan.multiplier =1;
                scoreMan.fails++;
                Destroy(this.gameObject);
            }

        }
        //chechking the same for hammer
        else if(other.gameObject.transform.parent.gameObject == hammer&&!IsSword&&!IsGun)
        {
            if (velocityProperty.action.ReadValue<Vector3>().x < 0.015 && velocityProperty.action.ReadValue<Vector3>().x > -0.015)
            {
                Debug.Log("bedge");
                scoreMan.multiplier = 1;
                scoreMan.fails++;
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().x > -0.05 && rotationBool == 0) //right
            {
                Debug.Log("goodge");
                scoreMan.score += 100 * scoreMan.multiplier;
                if (scoreMan.multiplier < 8)
                {
                    scoreMan.multiplier += 1;
                }
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().x < 0.05 && rotationBool == 2) //left
            {
                Debug.Log("goodge");
                scoreMan.score += 100 * scoreMan.multiplier; 
                if (scoreMan.multiplier < 8) 
                {
                    scoreMan.multiplier += 1;
                }
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().y > -0.05 && rotationBool == 1) //up
            {
                Debug.Log("goodge");
                scoreMan.score += 100 * scoreMan.multiplier;
                if (scoreMan.multiplier < 8)
                {
                    scoreMan.multiplier += 1;
                }
                Destroy(this.gameObject);
            }
            else if (velocityProperty.action.ReadValue<Vector3>().y < 0.05 && rotationBool == 3) //down
            {
                Debug.Log("goodge");
                scoreMan.score += 100 * scoreMan.multiplier;
                if (scoreMan.multiplier < 8)
                {
                    scoreMan.multiplier += 1;
                }
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("bedge");
                scoreMan.multiplier =1;
                scoreMan.fails++;
                Destroy(this.gameObject);
            }
        }
        //if the wall hits the cube
        else
        {
            scoreMan.multiplier = 1;
            scoreMan.fails++;
            Destroy(this.gameObject);
        }
    }
}
