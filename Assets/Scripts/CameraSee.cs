using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SPHFluid;
using UnityEngine.SceneManagement;
public class CameraSee : MonoBehaviour
{
    public Transform center;
    public Vector3 offest;
    private const float kDirectionSwitchTime = 40.0f;//45
    private const float kDirectionSwitchTime1 = 30.0f;// Switch direction every five seconds.
    private float timeSinceLastSwitch = 1.0f;
    public FluidController ctrl;
    public FluidController ctrll;
    public FluidController ctrlll;
    public GameObject ball0;
    public GameObject ball1;
    public GameObject ball2;
    public GameObject fish, fish1, fish2, fish3, fish4, fish5, fish6, fish7;
    // Start is called before the first frame update
    void Start()
    {
        ctrl.Init(3, 5);
        ctrll.Init(3, 5);
        ctrlll.Init(3, 5);


        float radius = 1f;
        Vector3 velo = Vector3.zero;

        ctrl.transform.localScale = new Vector3(500, 1, 100);
        ctrl.enabled = true;

        ctrll.transform.localScale = new Vector3(500, 1, 100);
        ctrll.enabled = true;

       


        ctrlll.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(new Vector3(-2,2,6), 1, Vector3.zero, 0) };

        ctrl.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(new Vector3(-2,2,6), 1, Vector3.zero, 0) };

        ctrll.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(new Vector3(-2,2,6), 1, Vector3.zero, 0) };
        /* var s0 = ctrlll.sphSolver._obstacles[0];
         s0.active = System.Convert.ToInt32(true);
         ctrlll.sphSolver._obstacles[0] = s0;*/


        ctrlll.transform.localScale = new Vector3(500, 1, 100);
        ctrlll.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(27, 17, -10);
        /* Debug.Log(center.position);
         transform.Rotate(new Vector3(0, 10 * Time.deltaTime, 0), Space.World);
         transform.position = new Vector3(-30,60-(Time.time*2), -20 + Time.time);
         if (Time.time - timeSinceLastSwitch >= kDirectionSwitchTime)
         {

            // timeSinceLastSwitch = Time.time;

             //SceneManager.LoadScene("see");
         }*/




        Debug.Log(center.position);


        if (Time.time - timeSinceLastSwitch < kDirectionSwitchTime)
        {
            transform.Rotate(new Vector3(0, 1 * Time.deltaTime, 0), Space.World);
        }
         if (Time.time - timeSinceLastSwitch >= kDirectionSwitchTime && timeSinceLastSwitch==1.0)
         {
            ball0.SetActive(true);
            ball1.SetActive(true);
            ball2.SetActive(true);
            transform.position = new Vector3(0, -50, 0);
            timeSinceLastSwitch = 5;
            fish.transform.position = new Vector3(0, -50, 24);
            fish1.transform.position = new Vector3(0, -50, 12);
            fish2.transform.position = new Vector3(0, -50, 29);
            fish3.transform.position = new Vector3(0, -50, 17);
            fish4.transform.position = new Vector3(1, -50, 17);
            fish5.transform.position = new Vector3(20, -50, 3);
            fish6.transform.position = new Vector3(31, -50, 32);
            fish7.transform.position = new Vector3(41, -50, 20);
            //   transform.position = new Vector3(-30, (Time.time * 1), -20);
            // timeSinceLastSwitch = Time.time;
            // transform.position = new Vector3(-30, (Time.time * 1), -20);
            // SceneManager.LoadScene("main");
        }

        if (timeSinceLastSwitch == 5 && Time.time - timeSinceLastSwitch <50)
        { transform.Rotate(new Vector3(0, 1 * Time.deltaTime, 0), Space.World);



        }


        if (Time.time - timeSinceLastSwitch > 50) {
          //  timeSinceLastSwitch = Time.time;

            SceneManager.LoadScene("tsunami");
        }


    }
}
