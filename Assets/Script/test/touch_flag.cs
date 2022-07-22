using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_flag : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public string input;
    public GameObject ObjectB;

    void Start()
    {
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            if (flag == 0)
            {
                flag = 1;
                //script.input = script.input + input;
                //ObjectB.GetComponent<receiver>().input = input;
            }
            ThisRenderer.material.color = Color.red;
            //Debug.Log("fflag = " + script.flick_flag);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            if (flag == 1)
            {
                flag = 0;
                //Debug.Log("fflag_flag = " + script.flick_flag);
            }
            ThisRenderer.material.color = Color.white;
        }
    }
}
