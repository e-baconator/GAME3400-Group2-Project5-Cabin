using UnityEngine;


public class OutsideAudio : MonoBehaviour
{
    public Collider Area; //area of sound
    public GameObject Player; //track this

    // Update is called once per frame
    void Update()
    {
        //Locate clostest point on collider to the player
        Vector3 closestPoint = Area.ClostestPoint(Player.transform.position);
        //set position to closest point to player
        transform.position = closestPoint;
    }
}
