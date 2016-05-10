using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CannonScript : MonoBehaviour {

    public float minPower = 21f;
    public float maxPower = 40f;

    public float power = 30f;

    public float enterMinRotate = 20f;
    public float enterMaxRotate = 65f;

    public float minRotate;
    public float maxRotate;

    public float rotationStep = 5f;

    public float cannonPoint;
    public float currentRotate = 45f;

    public Slider powerBar;
    public Image angleBar;
    public Image shotsBar;

    public int numberShots = 10;
    public int maxShots = 10;

    public int numStars;
    public int totalStars;
    public Text starTotal;
    GameObject putContainer;

    // Use this for initialization
    void Start () {
        minRotate = transform.rotation.z - enterMinRotate;
        maxRotate = transform.rotation.z + enterMaxRotate;
        powerBar.minValue = minPower;
        powerBar.maxValue = maxPower;
        numberShots = maxShots;
        totalStars = GameObject.FindGameObjectsWithTag("Star").Length;
        numStars = 0;
        starTotal.text = numStars.ToString() + "/" + totalStars.ToString();
        putContainer = GameObject.Find("PutContainer");
	}
	
	// Update is called once per frame
	void Update () {

        powerBar.value = power;
        angleBar.fillAmount = (maxRotate - cannonPoint) / (maxRotate - minRotate);
        shotsBar.fillAmount = (float)numberShots / (float)maxShots;

        if(Input.GetKeyDown(KeyCode.W))
        {
            //increase power
            _IncreasePower();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            //decrease power
            _DecreasePower();
        }
        
        cannonPoint = transform.rotation.eulerAngles.z;
        if (cannonPoint > 180f)
            cannonPoint -= 360f;

        if(Input.GetKeyDown(KeyCode.A))
        {
            //Increase rotation
            _IncreaseAngle();
        }
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            //Decrease rotation
            _DecreaseAngle();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _FirePut();
        }

        FinalCurtain();
	}

    public void DestroyStar()
    {
        numStars++;
        starTotal.text = numStars.ToString() + "/" + totalStars.ToString();
        if (numStars == totalStars)
            Debug.Log("Game Won");
    }

    //The x to be changed by power
    //The y to be changed by rotation
    void Cannonballs(float dir)
    {
        GameObject cannonballInstance;
        cannonballInstance = 
            Instantiate(Resources.Load("PenguinPut"), transform.position, Quaternion.identity) as GameObject;
        cannonballInstance.transform.Rotate(0, 0, 54);
        cannonballInstance.GetComponent<Rigidbody2D>().velocity = 
            new Vector2(power * Mathf.Cos((dir + currentRotate) * Mathf.PI / 180f), 
                        power * Mathf.Sin((dir + currentRotate) * Mathf.PI / 180f));
        cannonballInstance.transform.parent = putContainer.transform;
    }

    public void _IncreasePower()
    {
        //increase power
        if (power < maxPower)
        {
            power++;
        }
    }

    public void _DecreasePower()
    {
        //decrease power
        if (power > minPower)
        {
            power--;
        }
    }

    public void _IncreaseAngle()
    {
        //Increase rotation
        if (cannonPoint <= maxRotate)
        {
            transform.Rotate(Vector3.forward, rotationStep);
        }
    }

    public void _DecreaseAngle()
    {
        //Decrease rotation
        if (cannonPoint >= minRotate)
        {
            transform.Rotate(Vector3.forward, -rotationStep);
        }
    }

    public void _FirePut()
    {
        if (numberShots > 0)
        {
            Cannonballs(cannonPoint);
            numberShots--;
        }
    }

    public void FinalCurtain()
    {
        if(numberShots <= 0)
        {
            if(putContainer.transform.childCount <= 0)
            {
                if(numStars == totalStars)
                {
                    Time.timeScale = 0;
                    
                }
            }
        }
    }
}
