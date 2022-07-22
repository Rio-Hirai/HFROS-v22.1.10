using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_pos_pinch : MonoBehaviour
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
            script.Thumb_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
            script.Index_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
            script.Middle_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_MiddleTip].Transform.position;
            script.Ring_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_RingTip].Transform.position;
            script.Pinky_position_t = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_PinkyTip].Transform.position;
            script.Index_R.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
            script.Index_R.transform.rotation = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.rotation;

            script.Thumb_R.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
            script.Middle_R.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_MiddleTip].Transform.position;
            script.Ring_R.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_RingTip].Transform.position;
            script.Pinky_R.transform.position = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_PinkyTip].Transform.position;

            //Debug.Log("OK_update");
            if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index) && script.keyboard_set_active == 0)
            {
                if (script.Index_flag == 0)
                {
                    script.Index_flag = 1;
                    //script.Middle_flag = 0;
                }
                //Debug.Log("pinch_OK : " + script.Index_flag);
            }

            if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                if (script.I_pinch_flag == false)
                {
                    script.I_pinch_flag =true;
                }
            } else
            {
                script.I_pinch_flag = false;
            }

            if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
            {
                // ピンチフラグをオンにする
                script.Middle_pinch_states = 1;
                //script.Index_flag = 0;
            }
            if (!(hand.GetFingerIsPinching(OVRHand.HandFinger.Middle)) && script.Middle_pinch_states == 1)
            {
                if (script.Middle_flag == 1)
                {
                    script.Middle_flag = 0;
                }
                else
                {
                    script.Middle_flag = 1;
                }
                script.Middle_pinch_states = 0;
            }

            //Debug.Log("script.repos_flag = " + script.repos_flag);
        }

    }
}

