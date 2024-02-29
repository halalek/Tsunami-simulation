using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraEarth : MonoBehaviour
{
    public Transform center;
    public Vector3 offest;

    private const float kDirectionSwitchTime = 17.0f;
    private const float kDirectionSwitchTime1 = 10.0f;// Switch direction every five seconds.
    private float timeSinceLastSwitch = 0.0f;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(6, 0, -10);
        Debug.Log(center.position);
        transform.Rotate(new Vector3(0, -2 * Time.deltaTime,0), Space.World);
        transform.position = new Vector3(0, 0, -20 + Time.time);
        if (Time.time - timeSinceLastSwitch >= kDirectionSwitchTime)
        {

            timeSinceLastSwitch = Time.time;
           
             SceneManager.LoadScene("water");
        }
    }
}
