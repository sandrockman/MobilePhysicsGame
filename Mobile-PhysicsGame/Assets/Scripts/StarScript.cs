using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            GameObject.Find("Cannon").GetComponent<CannonScript>().DestroyStar();
            Destroy(gameObject);
        }
    }
}
