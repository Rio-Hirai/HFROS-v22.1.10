using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public int dwell_flag = 0;
    public string input;
    public GameObject ObjectB;
    private receiver script;
    // Start is called before the first frame update
    void Start()
    {
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
    }

    // 接触している間
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            if (flag == 0)
            {
                flag = 1;
                dwell_flag = 1;
                script.dwell_flag = dwell_flag;
                //Debug.Log("dwell:on");
            }
        }
    }

    // 離れた瞬間時
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            if (flag == 1)
            {
                flag = 0;
                dwell_flag = 0;
                //Debug.Log("dwell:off");
            }
        }
    }
}
