using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Object : MonoBehaviour
{
    //サーバー関係
    public GameObject ObjectB;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;
    public GameObject Object7;
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
        script.Thumb_position_t = Object1.transform.position;
        script.Index_position_t = Object2.transform.position;
        script.Middle_position_t = Object3.transform.position;
        script.Ring_position_t = Object4.transform.position;
        script.Pinky_position_t = Object5.transform.position;
        //Debug.Log("world_rot = " + Object7.transform.rotation);
        //Debug.Log("Thumb: " + script.Thumb_position_t);
        //Debug.Log("Index: " + script.Index_position_t);
        //Debug.Log("Middle: " + script.Middle_position_t);
        //Debug.Log("Ring: " + script.Ring_position_t);
        //Debug.Log("Pinky: " + script.Pinky_position_t);
    }
}
