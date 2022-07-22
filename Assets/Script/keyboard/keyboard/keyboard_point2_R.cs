using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_point2_R : MonoBehaviour
{
    public GameObject sphere_obj;
    public GameObject surver;
    public GameObject righthand;
    public GameObject lefthand;
    public float timeleft_base = 1.0f;
    public float interval = 3.0f;
    public int amount;
    public int flag;
    public int interval_flag = 0;
    public int Index_pinch_states;
    public int Index_flag;
    private float timeleft;
    private receiver script;
    private OVRHand hand;
    private OVRHand hand_l;
    private OVRSkeleton skeleton;
    // Start is called before the first frame update
    void Start()
    {
        hand = righthand.GetComponent<OVRHand>();
        hand_l = lefthand.GetComponent<OVRHand>();
        skeleton = righthand.GetComponent<OVRSkeleton>();
        script = surver.GetComponent<receiver>();
        timeleft = timeleft_base;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (hand_l.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            interval_flag = 1;
            Index_pinch_states = 1;
        }
        if (!(hand_l.GetFingerIsPinching(OVRHand.HandFinger.Index)) && Index_pinch_states == 1)
        {
            if (Index_flag == 1)
            {
                Index_flag = 0;
                script.point_flag = 0;
                amount = 48;
            }
            else
            {
                Index_flag = 1;
                script.point_flag = 1;
            }
            Index_pinch_states = 0;
        }

        if (Index_flag == 1)
        {
            interval -= Time.deltaTime;
        } else
        {
            interval = 3.0f;
        }

        if (timeleft < 0.0f && interval < 0.0f && amount > 0 && flag == 1)
        {
            Instantiate(sphere_obj, skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position, skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.rotation);

            timeleft = timeleft_base;

            amount--;
        }

    }
}
