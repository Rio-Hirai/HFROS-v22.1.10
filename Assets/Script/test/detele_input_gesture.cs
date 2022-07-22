using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detele_input_gesture : MonoBehaviour
{
    private OVRHand hand;
    private Renderer renderer_cube;
    private int flag = 0;
    //public string input;
    public GameObject ObjectB;
    private receiver script;
    // Start is called before the first frame update
    void Start()
    {
        renderer_cube = GameObject.Find("Cube").GetComponent<Renderer>();
        hand = this.gameObject.GetComponent<OVRHand>();
        script = ObjectB.GetComponent<receiver>();
        //Debug.Log("OK_start");
    }

    // Update is called once per frame
    void Update()
    {
        if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
        {
            renderer_cube.material.color = Color.blue;
            if (flag == 0)
            {
                Debug.Log("OK");
                flag = 1;
                script.input = script.input.Substring(0, script.input.Length - 1);
                Debug.Log("delete = " + script.input + ", flag = "+ flag);
            }
        }
        else if (renderer_cube.material.color == Color.blue)
        {
            renderer_cube.material.color = Color.white;
            if (flag == 1)
            {
                flag = 0;
            }
        }

        if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            renderer_cube.material.color = Color.green;
            script.repos_flag = 0;
        }
        else if (renderer_cube.material.color == Color.green)
        {
            renderer_cube.material.color = Color.white;
        }
    }
}
