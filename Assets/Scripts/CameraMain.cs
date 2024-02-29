using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMain : MonoBehaviour
{
    public Transform center;
    public Vector3 offest;

    private const float kDirectionSwitchTime = 15.0f;
    private const float kDirectionSwitchTime1 = 10.0f;// Switch direction every five seconds.
    private float timeSinceLastSwitch = 0.0f;
    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(-5, 3, -10);
      
        // transform.position = new Vector3(0, 0, -20 + Time.time);
        if (Time.time - timeSinceLastSwitch <= kDirectionSwitchTime)
        {
            transform.Rotate(new Vector3(0, 3 * Time.deltaTime, 0), Space.World);
            Debug.Log(transform.position);
           

        }
    }


}
