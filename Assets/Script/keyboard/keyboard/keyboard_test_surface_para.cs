using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_test_surface_para : MonoBehaviour
{
    public GameObject target_surface;
    public GameObject surver;
    private receiver script;
    private float timeleft;
    // Start is called before the first frame update
    void Start()
    {
        script = surver.GetComponent<receiver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.Middle_flag == 0)
        {
            target_surface.SetActive(true);
        } else if (script.Middle_flag == 1)
        {
            target_surface.SetActive(false);
        }
    }
}
