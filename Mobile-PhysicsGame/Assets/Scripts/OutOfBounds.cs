using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Star")
        {
            if (other.gameObject.tag == "Player")
                GameObject.Find("Main Camera").GetComponent<CameraFollowScript>().player =
                    GameObject.Find("Cannon").transform;
            Destroy(other.gameObject);
        }
    }
}
