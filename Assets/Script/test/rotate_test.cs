using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_test : MonoBehaviour
{
    //サーバー関係
    public GameObject inputtext;
    public GameObject Object0;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;
    public GameObject ObjectA;
    public GameObject ObjectB;
    public GameObject ObjectC;
    public GameObject ObjectD;
    public GameObject ObjectE;
    private receiver script;
    // Start is called before the first frame update
    void Start()
    {
        script = inputtext.GetComponent<receiver>(); //サーバーに接続
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = Object0.transform;
        script.realobjrot_R = Object0.transform;
        //script.realobjrot_R = Object0.transform.localEulerAngles;
        Object1.transform.position = script.Thumb_position_t;
        Object2.transform.position = script.Index_position_t;
        Object3.transform.position = script.Middle_position_t;
        Object4.transform.position = script.Ring_position_t;
        Object5.transform.position = script.Pinky_position_t;
        //this.transform.localEulerAngles = Object0.transform.localEulerAngles;
        this.transform.localEulerAngles = Object6.transform.localEulerAngles;
        script.Thumb_position = Object1.transform.position;
        script.Index_position = Object2.transform.position;
        script.Middle_position = Object3.transform.position;
        script.Ring_position = Object4.transform.position;
        script.Pinky_position = Object5.transform.position;
        //Object1.transform.position = script.Thumb_position;
        //Object2.transform.position = script.Index_position;
        //Object3.transform.position = script.Middle_position;
        //Object4.transform.position = script.Ring_position;
        //Object5.transform.position = script.Pinky_position;
    }
}
