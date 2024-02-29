using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SPHFluid;
// كلاس التحكم بالواجهة 
public class ControlPanel : MonoBehaviour
{
    public Toggle toggletsunami;
    public Toggle toggleBumb;
    public Text textBtnRun;

    public Canvas backgroud;
    public GameObject configuration;

    //public Text Title;

    public SliderValReader sliderParticleNum;
    public SliderValReader sliderTimeStep;
    public SliderValReader sliderKernelRadius;
    public SliderValReader sliderRestDensity;
    public SliderValReader sliderViscosity;
   
    

    public SliderValReader sliderWindX;
    public SliderValReader sliderGravityY;
    public SliderValReader sliderWindZ;

    public SliderValReader sliderMeshRes;

    public FluidController ctrl;
    public FluidController ctrll;
    public FluidController ctrlll;

    
    //public GameObject ball0, ball1;
    public GameObject ball0;
    public GameObject boat;


    public Button btnRun;
    public Text notSupport;

    private bool isRunning = false;
    private bool tsunami =false ;
    private bool bumb = false;
   




    public void OnRunTsunami()
    {
        tsunami =!tsunami;
    }



    public void OnRunBumb()
    {
        bumb = !bumb;
    }

    public void OnRunBtnHit()
    {
        isRunning = !isRunning;

        if (isRunning)
        {

            configuration.SetActive(false);
            backgroud.gameObject.SetActive(false);
           // Title.SetActive(false);
            textBtnRun.text = "Stop";
        
            ctrl.timeStep = sliderTimeStep.GetVal();
            ctrl.kernelRadius = sliderKernelRadius.GetVal();
             ctrl.restDensity = sliderRestDensity.GetVal();
            ctrl.externalAcc.y = sliderGravityY.GetVal();
              ctrl.externalAcc.x = sliderWindX.GetVal();
              ctrl.externalAcc.z = sliderWindZ.GetVal();

            ctrll.timeStep = sliderTimeStep.GetVal();
            ctrll.kernelRadius = sliderKernelRadius.GetVal();
            ctrll.restDensity = sliderRestDensity.GetVal();
            ctrll.externalAcc.y = sliderGravityY.GetVal();
            ctrll.externalAcc.x = sliderWindX.GetVal();
            ctrll.externalAcc.z = sliderWindZ.GetVal();


            ctrlll.timeStep = sliderTimeStep.GetVal();
            ctrlll.kernelRadius = sliderKernelRadius.GetVal();
            ctrlll.restDensity = sliderRestDensity.GetVal();
            ctrlll.externalAcc.y = sliderGravityY.GetVal();
            ctrlll.externalAcc.x = sliderWindX.GetVal();
            ctrlll.externalAcc.z = sliderWindZ.GetVal();



            Debug.Log("vvvvvvvvvvvvvvvvvv"+ (int)sliderParticleNum.GetVal()); 
            int particleNumLevel = (int)sliderParticleNum.GetVal() / (int)sliderParticleNum.scale;
            Debug.Log("wwww" + particleNumLevel);
            //int meshResLevel = (int)sliderMeshRes.GetVal();
            int meshResLevel = 4;
            ctrl.Init(particleNumLevel, meshResLevel);
            ctrll.Init(particleNumLevel, meshResLevel);
            ctrlll.Init(particleNumLevel, meshResLevel);

            var uis = configuration.GetComponentsInChildren<Selectable>();
            foreach (var ui in uis)
                ui.interactable = false;

            Vector3 simCenter = 0.5f * (float)ctrl.sphSolver.kernelRadius * new Vector3(ctrl.sphSolver.gridSize._x, ctrl.sphSolver.gridSize._y, ctrl.sphSolver.gridSize._z);
            Vector3 simRange = new Vector3(ctrl.sphSolver.gridSize._x, ctrl.sphSolver.gridSize._y, ctrl.sphSolver.gridSize._z) * (float)ctrl.sphSolver.kernelRadius;


           

            float radius = 1f;
            Vector3 velo = Vector3.zero;
            ctrl.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(simCenter, radius, velo, 0),
                                              new CSSphere(new Vector3(-2,-1,3), radius, velo, 0) };


            ctrll.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(simCenter, radius, velo, 0),
                                              new CSSphere(new Vector3(-2,-1,3), radius, velo, 0) };


            ctrlll.sphSolver._obstacles = new List<CSSphere>()
                                            { new CSSphere(simCenter, radius, velo, 0),
                                              new CSSphere(new Vector3(-2,-1,3), radius, velo, 0) };

            //   ball0.transform.position = new Vector3(100, 1, 100);

            //boat.transform.position = simCenter;
            //ball0.transform.localScale = Vector3.one * radius;
            //ball0.transform.rotation = Quaternion.identity;
            /*ball1.transform.position = simCenter;
            ball1.transform.localScale = Vector3.one * radius * 2;
            ball1.transform.rotation = Quaternion.identity;*/

            // ctrl.transform.localScale = new Vector3(100, 1, 100);

            if(bumb)
            { ctrl.enabled = true;
                OnToggleObs1(true);
                OnToggleObs2(true);

            }
           
            
           
          


        if(tsunami)
            {
                ctrll.transform.localScale = new Vector3(100, 1, 100);
                ctrll.enabled = true;
                ctrlll.transform.localScale = new Vector3(100, 1, 100);
                ctrlll.enabled = true;
            }

        }
        else
        {
            backgroud.gameObject.SetActive(false);
            textBtnRun.text = "Start";
            tsunami = false;
            bumb = false;
            //toggle.isOn = true;


            ctrl.enabled = false;
             ctrl.Free();

            ctrll.enabled = false;
            ctrll.Free();

            ctrlll.enabled = false;
            ctrlll.Free();

           

            var uis = configuration.GetComponentsInChildren<Selectable>();
            foreach (var ui in uis)
               ui.interactable = true;



           
            OnToggleObs1(false);
            ball0.SetActive(false);
            boat.SetActive(false);
            OnToggleObs2(false);

           
        }
    }

    public void OnToggleObs1(bool value)
    {
        ball0.SetActive(value);
        var s0 = ctrl.sphSolver._obstacles[0];
        s0.active = System.Convert.ToInt32(value);
        ctrl.sphSolver._obstacles[0] = s0;
        ctrll.sphSolver._obstacles[0] = s0;
        ctrlll.sphSolver._obstacles[0] = s0;
    }

    public void OnToggleObs2(bool value)
    {
        boat.SetActive(value);
        var s1 = ctrl.sphSolver._obstacles[1];
        s1.active = System.Convert.ToInt32(value);
        ctrl.sphSolver._obstacles[1] = s1;
        ctrll.sphSolver._obstacles[1] = s1;
        ctrlll.sphSolver._obstacles[1] = s1;
    }

    private void FixedUpdate()
    {
        if (!isRunning)
            return;
        if (ctrl.sphSolver._obstacles[0].active != 0)
        {
            CSSphere s0 = ctrl.sphSolver._obstacles[0];
            s0.velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                s0.center.z += 0.1f;
                s0.velocity.z += 0.1f / Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                s0.center.z -= 0.1f;
                s0.velocity.z -= 0.1f / Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                s0.center.x -= 0.1f;
                s0.velocity.x -= 0.1f / Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                s0.center.x += 0.1f;
                s0.velocity.x += 0.1f / Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                s0.center.y += 0.1f;
                s0.velocity.y += 0.1f / Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                s0.center.y -= 0.1f;
                s0.velocity.y -= 0.1f / Time.fixedDeltaTime;
            }

            ctrl.sphSolver._obstacles[0] = s0;
            ctrll.sphSolver._obstacles[0] = s0;
            ctrlll.sphSolver._obstacles[0] = s0;
            ball0.transform.position = s0.center;
        }

        if (ctrl.sphSolver._obstacles[1].active != 0)
        {
            CSSphere s1 = ctrl.sphSolver._obstacles[1];
            s1.velocity = Vector3.zero;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                s1.center.z += 0.1f;
                s1.velocity.z += 0.1f / Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                s1.center.z -= 0.1f;
                s1.velocity.z -= 0.1f / Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                s1.center.x -= 0.1f;
                s1.velocity.x -= 0.1f / Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                s1.center.x += 0.1f;
                s1.velocity.x += 0.1f / Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.L))
            {
                s1.center.y += 0.1f;
                s1.velocity.y += 0.1f / Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.O))
            {
                s1.center.y -= 0.1f;
                s1.velocity.y -= 0.1f / Time.fixedDeltaTime;
            }

            ctrl.sphSolver._obstacles[1] = s1;
            ctrll.sphSolver._obstacles[1] = s1;
            ctrlll.sphSolver._obstacles[1] = s1;
            boat.transform.position = s1.center;
        }





    }

    private void Update()
    {
       
    }



    private void Start()
    {
        if (SystemInfo.supportsComputeShaders && SystemInfo.graphicsShaderLevel < 50)
        {
            notSupport.gameObject.SetActive(true);
            configuration.SetActive(false);
            btnRun.gameObject.SetActive(false);
            toggletsunami.gameObject.SetActive(false);
            toggleBumb.gameObject.SetActive(false);


}
    }
}
