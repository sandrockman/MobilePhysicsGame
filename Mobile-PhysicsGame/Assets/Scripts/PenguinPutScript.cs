using UnityEngine;
using System.Collections;

public class PenguinPutScript : MonoBehaviour {

    public float implode = 1.7f;
    public float velocity;

    void Update()
    {
        Poof();
        velocity = GetComponent<Rigidbody2D>().velocity.x;

    }


    void Poof()
    {

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) < 1f)
        {
            implode -= Time.deltaTime;
            velocity = GetComponent<Rigidbody2D>().velocity.x;
        }
        if (implode < 0)
        {
            GameObject.Find("Main Camera").GetComponent<CameraFollowScript>().player =
                    GameObject.Find("Cannon").transform;
            Destroy(gameObject);
        }
    }
}
