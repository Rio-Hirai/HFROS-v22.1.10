using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_input : MonoBehaviour
{
    //private Renderer renderer;
    //private Renderer dwell_renderer;
    //private int flag = 0;
    public int min_ang = 260;
    public int max_ang = 360;
    private int ang;
    private int pinch_flag;
    public GameObject ObjectB;
    public Vector3 realobjpos;
    public Vector3 realobjrot;
    private receiver script;
    private OVRHand hand;
    private Vector3 oldpos;
    private float timeleft;

    // Start is called before the first frame update
    void Start()
    {
        // receiverを取得
        //renderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
        hand = this.gameObject.GetComponent<OVRHand>();
        // dwell用receiverを取得
        //dwell_renderer = this.gameObject.GetComponent<Renderer>();
        /*
        Transform myTransform = this.transform;
        realobjpos = myTransform.position;
        */
        Transform myTransform = this.transform;
        oldpos = myTransform.position;
        //oldrot = myTransform.eulerAngles;
        ang = (max_ang - min_ang) / 10;
    }

    // Update is called once per frame
    void Update()
    {
        // 位置取得
        Transform myTransform = this.transform;
        Vector3 objpos = myTransform.position;
        Vector3 objrot = myTransform.eulerAngles;

        timeleft -= Time.deltaTime;

        // 位置情報を更新
        //objpos.x = script.L_position.x + realobjpos.x;
        //objpos.y = script.L_position.y + realobjpos.y;
        //objpos.z = script.L_position.z + realobjpos.z;
        objrot.x = script.L_rotation.z + realobjrot.x;
        objrot.y = script.L_rotation.y + realobjrot.y;
        objrot.z = script.L_rotation.x + realobjrot.z;

        //Debug.Log("rot = " + objrot.y);

        if (pinch_flag == 0)
        {
            if (objrot.y < min_ang + ang * 1)
            {
                //Debug.Log("A = ");
                script.boin = "あ";
                if (hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle) >= 0.5f && hand.GetFingerPinchStrength(OVRHand.HandFinger.Index) >= 0.1f)
                {
                    Debug.Log("Index");
                    script.input = script.input + "あ";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
                {
                    Debug.Log("Index");
                    script.input = script.input + "い";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
                {
                    Debug.Log("Middle");
                    script.input = script.input + "う";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
                {
                    Debug.Log("Ring");
                    script.input = script.input + "え";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
                {
                    Debug.Log("Pinky");
                    script.input = script.input + "お";
                }
            }
            else if (objrot.y < min_ang + ang * 3)
            {
                //Debug.Log("B = ");
                script.boin = "か";
                if (hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle) >= 0.5f && hand.GetFingerPinchStrength(OVRHand.HandFinger.Index) >= 0.1f)
                {
                    Debug.Log("Index");
                    script.input = script.input + "あ";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
                {
                    Debug.Log("Index");
                    script.input = script.input + "き";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
                {
                    Debug.Log("Middle");
                    script.input = script.input + "く";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
                {
                    Debug.Log("Ring");
                    script.input = script.input + "け";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
                {
                    Debug.Log("Pinky");
                    script.input = script.input + "こ";
                }
            }
            else if (objrot.y < min_ang + ang * 5)
            {
                //Debug.Log("C = ");
                script.boin = "さ";
                if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
                {
                    Debug.Log("Index");
                    script.input = script.input + "し";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
                {
                    Debug.Log("Middle");
                    script.input = script.input + "す";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
                {
                    Debug.Log("Ring");
                    script.input = script.input + "せ";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
                {
                    Debug.Log("Pinky");
                    script.input = script.input + "そ";
                }
            }
            else if (objrot.y < min_ang + ang * 7)
            {
                //Debug.Log("D = ");
                script.boin = "た";
                if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
                {
                    Debug.Log("Index");
                    script.input = script.input + "ち";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
                {
                    Debug.Log("Middle");
                    script.input = script.input + "つ";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
                {
                    Debug.Log("Ring");
                    script.input = script.input + "て";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
                {
                    Debug.Log("Pinky");
                    script.input = script.input + "と";
                }
            }
            else if (objrot.y < min_ang + ang * 9)
            {
                //Debug.Log("E = ");
                script.boin = "な";
                if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
                {
                    Debug.Log("Index");
                    script.input = script.input + "に";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
                {
                    Debug.Log("Middle");
                    script.input = script.input + "ぬ";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
                {
                    Debug.Log("Ring");
                    script.input = script.input + "ね";
                }
                else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
                {
                    Debug.Log("Pinky");
                    script.input = script.input + "の";
                }
            }
            timeleft = 0.2f;
            pinch_flag = 1;
        }

        if (timeleft <= 0.0f)
        {
            pinch_flag = 0;
        } 
        
    }
}
