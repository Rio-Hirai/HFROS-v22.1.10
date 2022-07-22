using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHand : MonoBehaviour
{
    private OVRHand hand;
    private Renderer renderer_cube;
    private int flag = 0;
    public string input;
    public GameObject ObjectB;
    private receiver script;

    void Start()
    {
        renderer_cube = GameObject.Find("Cube (1)").GetComponent<Renderer>();
        hand = this.gameObject.GetComponent<OVRHand>();
        script = ObjectB.GetComponent<receiver>();
    }

    void Update()
    {
        if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
        {
            renderer_cube.material.color = Color.blue;
            if (flag == 0)
            {
                flag = 1;
                script.input = script.input + input;
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
        }
        else if (renderer_cube.material.color == Color.green)
        {
            renderer_cube.material.color = Color.white;
        }

        Debug.Log("script.repos_flag = " + script.repos_flag);
    }
}
