using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Earth : MonoBehaviour
{

    public Transform world;
    public float rotetionspeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        world.GetComponent<Transform>();
       // SceneManager.LoadScene("main", LoadSceneMode.Additive);

    }

    // Update is called once per frame
    void Update()
    {
        world.Rotate(new Vector3(0, rotetionspeed*Time.deltaTime, 0), Space.World);
    }
}
