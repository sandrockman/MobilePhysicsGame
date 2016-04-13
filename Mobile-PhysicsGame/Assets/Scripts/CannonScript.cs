using UnityEngine;
using System.Collections;

public class CannonScript : MonoBehaviour {

    public float minPower = 21f;
    public float maxPower = 40f;

    public float power = 30f;

    public float enterMinRotate = 20f;
    public float enterMaxRotate = 80f;

    public float minRotate;
    public float maxRotate;

    public float rotationStep = 5f;

    public float cannonPoint;
    public float currentRotate = 30f;

    // Use this for initialization
    void Start () {
        minRotate = transform.rotation.z - enterMinRotate;
        maxRotate = transform.rotation.z + enterMaxRotate;
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(power <= maxPower)
            {
                power++;
            }
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            if(power >= minPower)
            {
                power--;
            }
        }
        
        cannonPoint = transform.rotation.eulerAngles.z;
        if (cannonPoint > 180f)
            cannonPoint -= 360f;

        if(Input.GetKeyDown(KeyCode.A))
        {
            //Increase rotation
            if (cannonPoint <= maxRotate)
            {
                transform.Rotate(Vector3.forward, rotationStep);
            }
        }
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            //Decrease rotation
            if (cannonPoint >= minRotate)
            {
                transform.Rotate(Vector3.forward, -rotationStep);
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cannonballs(cannonPoint);
        }

	}

    //The x to be changed by power
    //The y to be changed by rotation
    void Cannonballs(float dir)
    {
        GameObject cannonballInstance;
        cannonballInstance = Instantiate(Resources.Load("CannonBall"), transform.position, Quaternion.identity) as GameObject;
        cannonballInstance.transform.Rotate(0, 0, 54);
        cannonballInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(power, dir + currentRotate);
    }
}
