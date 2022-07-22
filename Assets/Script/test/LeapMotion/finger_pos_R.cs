using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger_pos_R : MonoBehaviour
{
    private OVRHand hand;
    private OVRSkeleton skeleton;
    private int flag;
    public GameObject ObjectB;
    public GameObject Thumb;
    public GameObject Index;
    public GameObject Middle;
    public GameObject Ring;
    public GameObject Pinky;
    private receiver script;
    private float timeleft;
    // Start is called before the first frame update
    void Start()
    {
        script = ObjectB.GetComponent<receiver>();
    }

    // Update is called once per frame
    void Update()
    {
        //var indexTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
        //Debug.Log("index = " + indexTipPos);

        script.Thumb_position_t = Thumb.transform.position;
        script.Index_position_t = Index.transform.position;
        script.Middle_position_t = Middle.transform.position;
        script.Ring_position_t = Ring.transform.position;
        script.Pinky_position_t = Pinky.transform.position;
        script.Index_R.transform.position = Index.transform.position;
        script.Index_R.transform.rotation = Index.transform.rotation;
        //Debug.Log("index = " + script.Thumb_position);
    }
}
