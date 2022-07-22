using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_pos_pinch_L : MonoBehaviour
{
    private OVRHand hand;
    private OVRSkeleton skeleton;
    private Renderer ThisRenderer;
    private int flag;
    public GameObject ObjectB;
    private receiver script;
    private float timeleft;
    private float interval = 3.0f;
    private bool hand_tracked;
    // Start is called before the first frame update
    void Start()
    {
        hand = this.gameObject.GetComponent<OVRHand>();
        skeleton = this.gameObject.GetComponent<OVRSkeleton>();
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
    }

    // Update is called once per frame
    void Update()
    {
        hand_tracked = skeleton.IsDataValid;
        interval -= Time.deltaTime;
        //var indexTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
        //Debug.Log("index = " + indexTipPos);
        if (interval <= 0 && hand_tracked)
        {
            script.L_Thumb_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
            script.L_Index_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
            script.L_Middle_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_MiddleTip].Transform.position;
            script.L_Ring_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_RingTip].Transform.position;
            script.L_Pinky_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_PinkyTip].Transform.position;
            script.Index_L.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
            script.Index_L.transform.rotation = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.rotation;

            script.Thumb_L.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
            //script.Thumb_L.transform.rotation = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_PinkyTip].Transform.rotation;
            script.Middle_L.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_MiddleTip].Transform.position;
            script.Ring_L.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_RingTip].Transform.position;
            script.Pinky_L.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_PinkyTip].Transform.position;
            //Debug.Log("index = " + script.Thumb_position);

            //Debug.Log("OK_update");
            if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                if (script.Index_flag_L == 0)
                {
                    script.Index_flag_L = 1;
                    script.Middle_flag_L = 0;
                }
            }

            if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
            {
                if (script.Middle_flag_L == 0)
                {
                    script.Middle_flag_L = 1;
                    script.Index_flag_L = 0;
                }
            }

            //Debug.Log("script.repos_flag = " + script.repos_flag);
        }
    }
}

