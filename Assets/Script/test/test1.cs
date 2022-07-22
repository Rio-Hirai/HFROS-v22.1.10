using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    //サーバー関係
    public GameObject ObjectB;
    private receiver script;
    // Start is called before the first frame update
    void Start()
    {
        script = ObjectB.GetComponent<receiver>(); //サーバーに接続
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = script.Index_position;
        script.Index_position = this.transform.position;
    }
}
