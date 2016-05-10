using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    //Dist in the x axis the player moves vefore being followed by camera
    public float xMargin = 1.5f;

    //Dist in teh y axis the player moves before being followed by the camera
    public float yMargin = 1.5f;

    //how smooth the camera catches its target(x axis)
    public float xSmooth = 1.5f;

    //how smooth the camera catches its target(x axis)
    public float ySmooth = 1.5f;

    //max x & y coord.s the cam can have
    private Vector2 maxXandY;

    //min x & y coord.s the cam can have
    private Vector2 minXandY;

    //references the player's transform
    public Transform player;

    void Awake()
    {
        //Gather player
        player = GameObject.FindWithTag("Cannon").transform;

        if (player == null)
            Debug.LogError("Player object not found.");

        //Getting the bounds for the bgt in WORLD size
        if(GameObject.Find("Background").GetComponent<SpriteRenderer>())
        {
            Debug.Log("BG Render check.");
            Component[] allComp = GameObject.Find("Background").GetComponents(typeof(Component));
            foreach (Component item in allComp)
                Debug.Log(item);
        }
        var backgroundBounds = GameObject.Find("Background").GetComponent<SpriteRenderer>().bounds;

        //Get the viewable bounds of the camera in WORLD size
        var cameraTopLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        var cameraBottomRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        //Set the min and max X for the Camera
        minXandY.x = backgroundBounds.min.x - cameraTopLeft.x;
        maxXandY.x = backgroundBounds.max.x - cameraBottomRight.x;
    }

    void LateUpdate()
    {
        //check if the player is close to the edge and update the camera's position
        //Also, check it the camera bounds have reached the edge of the screen and
        //don't move beyond it
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        //If the player has moved beyond the x margin
        if(CheckXMargin())
        {
            //Lerp btwn the cur. pos. and the player pos., using xSmooth
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        }

        //If the player has moved beyond the y margin
        if (CheckYMargin())
        {
            //Lerp btwn the cur. pos. and the player pos., using xSmooth
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);
        targetY = Mathf.Clamp(targetY, minXandY.y, maxXandY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }


    /// <summary>
    /// Check if the player has moved near the edge of the camera bounds.
    /// </summary>
    /// <returns>If the player has moved near the X edge of the camera bounds</returns>
    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    /// <summary>
    /// Check if the player has moved near the edge of the camera bounds.
    /// </summary>
    /// <returns>If the player has moved near the Y edge of the camera bounds</returns>
    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }
}
