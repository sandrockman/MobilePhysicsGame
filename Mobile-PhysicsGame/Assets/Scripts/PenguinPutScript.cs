using UnityEngine;
using System.Collections;

public class PenguinPutScript : MonoBehaviour {

    float implode = 3f;
    public float velocity;

    void Update()
    {
        Poof();
    }


    void Poof()
    {

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) < 0.1f)
        {
            implode -= Time.deltaTime;
            velocity = GetComponent<Rigidbody2D>().velocity.x;
        }
        if (implode < 0)
        {
            Destroy(gameObject);
        }
    }
}
