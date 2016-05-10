using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Star")
        {
            
            Destroy(other.gameObject);
        }
    }
}
