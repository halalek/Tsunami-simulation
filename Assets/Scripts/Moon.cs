using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform center;
    public float radius;
    public float radiusSpeed;
    public float rotetionspeed;

    private Vector3 axis;
    private Vector3 desiredPosition;
    public float time=0;
   // private const float kDirectionSwitchTime = 30.0f; // Switch direction every five seconds.
   // private float timeSinceLastSwitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = (transform.position - center.position).normalized * radius + center.position;
        axis = Vector3.up;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position, axis, rotetionspeed * Time.deltaTime);
        desiredPosition= (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);


       /* if (Time.time - timeSinceLastSwitch >= kDirectionSwitchTime)
        {
           
            timeSinceLastSwitch = Time.time;
            SceneManager.LoadScene("main", LoadSceneMode.Additive);
        }*/

      
        


    }
}
