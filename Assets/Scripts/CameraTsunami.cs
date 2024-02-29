
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SPHFluid;
using UnityEngine.SceneManagement;
public class CameraTsunami : MonoBehaviour
{
    public Transform center;
    public Vector3 offest;
    private const float kDirectionSwitchTime = 20.0f;
    private const float kDirectionSwitchTime1 = 75.0f;// Switch direction every five seconds.
    private float timeSinceLastSwitch = 1.0f;
    public FluidController ctrl;
    public FluidController ctrll;
    public FluidController ctrlll;
    public float cc=1;
    public float cc1 = 0;

    public GameObject wave;
    // Start is called before the first frame update
    void Start()
    {
        ctrl.Init(3, 5);
        ctrll.Init(3, 5);
        ctrlll.Init(3, 5);


        float radius = 1f;
        Vector3 velo = Vector3.zero;

        //ctrl.transform.localScale = new Vector3(500, 1, 100);
        //ctrl.enabled = true;

        ctrll.transform.localScale = new Vector3(500, 1, 100);
        ctrll.enabled = true;




        ctrlll.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(new Vector3(-2,2,6), 1, Vector3.zero, 0) };

       // ctrl.sphSolver._obstacles = new List<CSSphere>()      { new CSSphere(new Vector3(-2,2,6), 1, Vector3.zero, 0) };

        ctrll.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(new Vector3(-2,2,6), 1, Vector3.zero, 0) };
        /* var s0 = ctrlll.sphSolver._obstacles[0];
         s0.active = System.Convert.ToInt32(true);
         ctrlll.sphSolver._obstacles[0] = s0;*/


        ctrlll.transform.localScale = new Vector3(500, 1, 100);
        ctrlll.enabled = true;
        if (Time.time == 0)
        { cc1 = 1; }
    }

    // Update is called once per frame
    void Update()
    {
        if (cc1 == 1)
        {

            Debug.Log(Time.deltaTime);
            if (Time.time - timeSinceLastSwitch < kDirectionSwitchTime)
            {
                //   ctrl.transform.position = new Vector3(-2184, -4, -100* Time.deltaTime);
                transform.Rotate(new Vector3(0, 5 * Time.deltaTime, 0), Space.World);

                //wave.transform.position = new Vector3(-2156, -4, 350 * Time.deltaTime);
                //  ctrl.transform.position = new Vector3(-2184, -4, -100 * Time.deltaTime);
            }



            if (Time.time - timeSinceLastSwitch >= 20 && 25 > Time.time - timeSinceLastSwitch)
            {
                //  transform.position = new Vector3(-1293 , 36, 286);
                //  transform.localScale = new Vector3(0, 100, 0);
                //cc = 5;

                ctrl.transform.localScale = new Vector3(500, 1, 100);
                ctrl.enabled = true;
                ctrl.sphSolver._obstacles = new List<CSSphere>() { new CSSphere(new Vector3(-2, 2, 6), 1, Vector3.zero, 0) };

                wave.transform.position = new Vector3(-2156, -8, 87 * Time.deltaTime);


                ctrll.transform.localScale = new Vector3(500, 1, 100);
                //   ctrll.transform.position = new Vector3(-2156, -8, 87 * Time.deltaTime);
                ctrll.enabled = true;
                ctrll.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(new Vector3(-2,2,6), 1, Vector3.zero, 0) };





                //ctrll.transform.position = new Vector3(-2184, -27, 612-( 2* Time.deltaTime));//////////////////////////
            }



            if (Time.time - timeSinceLastSwitch >= 26)
            {
                wave.transform.position = new Vector3(-2156, -59, 511);
                ctrll.enabled = false;

                SceneManager.LoadScene("main");
            }
        }

















        else if (cc1 == 0)
        {
            
            Debug.Log(Time.deltaTime);
            if (Time.time - timeSinceLastSwitch < kDirectionSwitchTime1)
            {
                //   ctrl.transform.position = new Vector3(-2184, -4, -100* Time.deltaTime);
                transform.Rotate(new Vector3(0, 5 * Time.deltaTime, 0), Space.World);

                //wave.transform.position = new Vector3(-2156, -4, 350 * Time.deltaTime);
                //  ctrl.transform.position = new Vector3(-2184, -4, -100 * Time.deltaTime);
            }



            if (Time.time - timeSinceLastSwitch >= 75 && 80 > Time.time - timeSinceLastSwitch)
            {
                //  transform.position = new Vector3(-1293 , 36, 286);
                //  transform.localScale = new Vector3(0, 100, 0);
                //cc = 5;

                ctrl.transform.localScale = new Vector3(500, 1, 100);
                ctrl.enabled = true;
                ctrl.sphSolver._obstacles = new List<CSSphere>() { new CSSphere(new Vector3(-2, 2, 6), 1, Vector3.zero, 0) };

                wave.transform.position = new Vector3(-2156, -8, 87 * Time.deltaTime);


                ctrll.transform.localScale = new Vector3(500, 1, 100);
                ctrll.enabled = true;
                ctrll.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(new Vector3(-2,2,6), 1, Vector3.zero, 0) };





                // wave.transform.position = new Vector3(-2156, -4, 350 * Time.deltaTime);
            }



            if (Time.time - timeSinceLastSwitch >= 83)
            {
                wave.transform.position = new Vector3(-2156, -59, 511);
                ctrll.enabled = false;

                SceneManager.LoadScene("main");
            }
        }
    }
}
