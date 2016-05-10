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
    public float percentStarTotal = 0.8f;
    public Text starTotal;
    GameObject putContainer;
    public GameObject fireButton;

    public Canvas UICanvas;
    public Canvas winCanvas;
    public Canvas lostCanvas;

    void Awake()
    {
        if (fireButton != null)
            fireButton.SetActive(true);
    }

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        winCanvas.enabled = false;
        lostCanvas.enabled = false;
        minRotate = transform.rotation.z - enterMinRotate;
        maxRotate = transform.rotation.z + enterMaxRotate;
        powerBar.minValue = minPower;
        powerBar.maxValue = maxPower;
        numberShots = maxShots;
        totalStars = GameObject.FindGameObjectsWithTag("Star").Length;
        numStars = 0;
        starTotal.text = numStars.ToString() + "/" + totalStars.ToString();
        putContainer = GameObject.Find("PutContainer");
        if (fireButton != null)
            fireButton.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        //reset fire button so player can fire new shot.
        if(fireButton.activeSelf == false)
        {
            if(putContainer.transform.childCount <= 0)
            {
                fireButton.SetActive(true);
            }
        }
        //set the power, cannon angle, and shots total meters.
        powerBar.value = power;
        angleBar.fillAmount = (maxRotate - cannonPoint) / (maxRotate - minRotate);
        shotsBar.fillAmount = (float)numberShots / (float)maxShots;

        //WASD and space bar controls
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

        //Call to see if all shots have been fired and no win has been called.
        FinalCurtain();
	}
    /// <summary>
    /// add to win score. if all are caught, win or next level.
    /// </summary>
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
        //if there are no children of the container holding shot puts
        if (putContainer.transform.childCount <= 0)
        {
            //deactivate the fire button
            fireButton.SetActive(false);
            //create, instantiate, & give velocity to a shot put.
            GameObject cannonballInstance;
            cannonballInstance =
                Instantiate(Resources.Load("PenguinPut"), transform.position, Quaternion.identity) as GameObject;
            cannonballInstance.transform.Rotate(0, 0, 54);
            cannonballInstance.GetComponent<Rigidbody2D>().velocity =
                new Vector2(power * Mathf.Cos((dir + currentRotate) * Mathf.PI / 180f),
                            power * Mathf.Sin((dir + currentRotate) * Mathf.PI / 180f));
            //make shot put a child of the put container
            cannonballInstance.transform.parent = putContainer.transform;
            //have camera follow the shot put.
            GameObject.Find("Main Camera").GetComponent<CameraFollowScript>().player =
                        cannonballInstance.transform;
            //decrement total shots available.
            numberShots--;
        }
    }

    /// <summary>
    /// increase power one step
    /// </summary>
    public void _IncreasePower()
    {
        //increase power
        if (power < maxPower)
        {
            power++;
        }
    }
    /// <summary>
    /// decrease power one step.
    /// </summary>
    public void _DecreasePower()
    {
        //decrease power
        if (power > minPower)
        {
            power--;
        }
    }
    /// <summary>
    /// increase angle by one rotationStep
    /// </summary>
    public void _IncreaseAngle()
    {
        //Increase rotation
        if (cannonPoint <= maxRotate)
        {
            transform.Rotate(Vector3.forward, rotationStep);
        }
    }
    /// <summary>
    /// decrease angle by one rotationStep
    /// </summary>
    public void _DecreaseAngle()
    {
        //Decrease rotation
        if (cannonPoint >= minRotate)
        {
            transform.Rotate(Vector3.forward, -rotationStep);
        }
    }

    /// <summary>
    /// call the cannonball function if shots are still available.
    /// </summary>
    public void _FirePut()
    {
        if (numberShots > 0)
        {
            Cannonballs(cannonPoint);
        }
    }
    /// <summary>
    /// if there are no more shots, then show appropriate canvas.
    /// </summary>
    public void FinalCurtain()
    {
        if(numberShots <= 0)
        {
            if(putContainer.transform.childCount <= 0)
            {
                Time.timeScale = 0;
                if (((float)numStars/(float)totalStars) >= percentStarTotal)
                {
                    //win condition
                    winCanvas.enabled = true;
                }
                else
                {
                    //loseCondition
                    lostCanvas.enabled = true;
                }
            }
        }
    }
}
