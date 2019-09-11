using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_camera : MonoBehaviour
{

    public GameObject Player;

    Vector3 distanceVector;

    bool isFollowing;

    void Awake()
    {

        resetCamera();
        
    }


    //
    // public void followPlayer() 
    //
    // Camera may not follow the player when
    // he is bouncing in
    //

    public void followPlayer()
    {
        isFollowing = true;
    }



    // 
    // void LateUpdate() 
    //
    // let the camera follow the player
    //

    void LateUpdate()
    {
        if (isFollowing)
        {
            transform.position = Player.transform.position + distanceVector;
            transform.LookAt(Player.transform.position);

        }
            
            
    }



    //
    // public void resetCamera() 
    //
    // Reset the camera to start position
    //

    public void resetCamera()
    {
        
        GetComponent<Camera>().fieldOfView = 60;
        //isFollowing = false;
        distanceVector = transform.position - Player.transform.position;
        followPlayer();
    }
}
