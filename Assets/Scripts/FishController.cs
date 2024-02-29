using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;

// ﬂ·«” «· Õﬂ„ »Õ—ﬂ… «·√”„«ﬂ 
public class FishController : MonoBehaviour
{

    public Rigidbody rb;


    float ZONE_ONE_DIST = 2f;
    public float ZONE_TWO_DIST = 10f;
    public float ZONE_THREE_DIST = 20f;

    public float swimSpeed = 4f;
    public float turnSpeed = 9f;


    float xRot = 0;
    float yRot = 0;

    public GameObject leaderFish;
    GameObject tank;
    Vector3 tankCenter;
    float tankSphereDistance;
    float cornerScale = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //{ fish.transform.position = new Vector3(5 * Time.deltaTime, 11, 8); }




        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        MoveRandom();
    }


    


    void MoveRandom()
    {
        if (tankSphereDistance < Vector3.Distance(transform.position, tankCenter))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(tankCenter - transform.position), Time.deltaTime / turnSpeed);
        }
        else
        {
            RaycastHit hitLeft;
            RaycastHit hitRight;
            RaycastHit hitUp;
            RaycastHit hitDown;
            Vector3 direction = transform.forward;
            Vector3 left = Quaternion.AngleAxis(-5, transform.up) * direction;
            Vector3 right = Quaternion.AngleAxis(5, transform.up) * direction;
            Vector3 up = Quaternion.AngleAxis(-5, transform.right) * direction;
            Vector3 down = Quaternion.AngleAxis(5, transform.right) * direction;
            Debug.DrawRay(transform.position, left * 5 * tank.transform.localScale.x, Color.yellow);
            Debug.DrawRay(transform.position, right * 5 * tank.transform.localScale.x, Color.yellow);
            Debug.DrawRay(transform.position, up * 5 * tank.transform.localScale.x, Color.blue);
            Debug.DrawRay(transform.position, down * 5 * tank.transform.localScale.x, Color.red);
            bool hit1 = Physics.Raycast(transform.position, left, out hitLeft, 5 * tank.transform.localScale.x);
            bool hit2 = Physics.Raycast(transform.position, right, out hitRight, 5 * tank.transform.localScale.x);
            bool hit3 = Physics.Raycast(transform.position, up, out hitUp, 5 * tank.transform.localScale.x);
            bool hit4 = Physics.Raycast(transform.position, down, out hitDown, 5 * tank.transform.localScale.x);
            if (hit1 || hit2)
            {
                float angleLeft = Mathf.Rad2Deg * (Mathf.Acos(Vector3.Dot(left, hitLeft.normal)));
                float angleRight = Mathf.Rad2Deg * (Mathf.Acos(Vector3.Dot(right, hitRight.normal)));
                //Debug.Log ("left="+angleLeft+", right="+angleRight);
                if (angleLeft > angleRight)
                {
                    yRot = 2;
                }
                else if (hitLeft.collider != hitRight.collider)
                {
                    yRot = 0;
                }
                else
                {
                    yRot = -2;
                }
            }
            else
            {
                yRot = 0;
            }
            if (hit3 || hit4)
            {
                float angleUp = Mathf.Rad2Deg * (Mathf.Acos(Vector3.Dot(up, hitUp.normal)));
                float angleDown = Mathf.Rad2Deg * (Mathf.Acos(Vector3.Dot(down, hitDown.normal)));
                //Debug.Log ("left="+angleLeft+", right="+angleRight);
                if (angleUp > angleDown)
                {
                    xRot = 2;
                }
                else if (hitUp.collider != hitDown.collider)
                {
                    xRot = 0;
                }
                else
                {
                    xRot = -2;
                }
            }
            else
            {
                if (transform.rotation.eulerAngles.x > 40 && transform.rotation.eulerAngles.x <= 180)
                {
                    xRot = -1;
                }
                else if (transform.rotation.eulerAngles.x < 320 && transform.rotation.eulerAngles.x > 180)
                {
                    xRot = 1;
                }
            }

            transform.Rotate(new Vector3(xRot, yRot, 0) * Time.deltaTime * turnSpeed, Space.Self);
            //transform.RotateAround (transform.position, Vector3.up, Time.deltaTime * turnSpeed * yRot);
        }
        transform.Translate(Vector3.forward * swimSpeed * Time.deltaTime);
    }

   

  
}
