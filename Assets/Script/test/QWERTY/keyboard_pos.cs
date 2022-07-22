using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_pos : MonoBehaviour
{
    //private Renderer renderer;
    //private Renderer dwell_renderer;
    //private int flag = 0;
    private int count = 0;
    private int touch_timecount = 0; //壁接触検知用のカウント
    //private int touch_timecount2 = 0; //壁接触検知用のカウント2
    //private int leave_timecount = 0; //壁離脱検知用のカウント
    //private int keyset_interval = 0;
    public int keyboard_amount;
    public GameObject ObjectB;
    public GameObject ObjectC;
    public GameObject ObjectD;
    public GameObject ObjectE;
    public GameObject SightObject;
    public Vector3 realobjpos;
    public Vector3 realobjrot;
    private receiver script;
    private sight dwell_script;
    private float timeleft;
    private int pinch_flag;
    private Vector3 oldpos;
    //private Vector3 oldrot;
    private Vector3 firsttouch;
    private Vector3 firsttouchrot;
    // Start is called before the first frame update
    void Start()
    {
        // receiverを取得
        //renderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
        // dwell用receiverを取得
        //dwell_renderer = this.gameObject.GetComponent<Renderer>();
        dwell_script = SightObject.GetComponent<sight>();
        /*
        Transform myTransform = this.transform;
        realobjpos = myTransform.position;
        */
        Transform myTransform = this.transform;
        oldpos = myTransform.position;
        //script.keyboard_amount = keyboard_amount;
        Debug.Log(script.keyboard_amount);
        //oldrot = myTransform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        // 位置取得
        Transform myTransform = this.transform;
        Vector3 objpos = myTransform.position;
        Vector3 objrot = myTransform.eulerAngles;

        // 経過時間を計測
        timeleft -= Time.deltaTime;
        //Debug.Log("script.Index_flag = " + script.Middle_flag + " pinch_flag = " + pinch_flag + " " + script.Index_flag);

        // ログ
        //Debug.Log("pos = " + objpos);
        //Debug.Log("time = " + timeleft);
        /*
        if (timeleft <= 0.0)
        {
            timeleft = 0.5f;
            objpos.x = script.L_position.x + realobjpos.x;
            objpos.y = script.L_position.y + realobjpos.y;
            objpos.z = script.L_position.z + realobjpos.z;
            Debug.Log("move = " + (objpos - oldpos).magnitude);
            oldpos = objpos;
        }
        */

        // 位置情報を更新
        objpos.x = script.L_position.x + realobjpos.x;
        objpos.y = script.L_position.y + realobjpos.y;
        objpos.z = script.L_position.z + realobjpos.z;
        objrot.x = script.L_rotation.z + realobjrot.x;
        objrot.y = script.L_rotation.y + realobjrot.y;
        objrot.z = script.L_rotation.x + realobjrot.z;
        //
        if ((objpos - oldpos).magnitude < 0.002f)
        {
            touch_timecount += 1;
        } else
        {
            if ((objpos - oldpos).magnitude < 0.006f)
            {
                if (touch_timecount > 0)
                {
                    //Debug.Log("count = " + touch_timecount);
                    //Debug.Log("touch_count = " + touch_timecount + ", time = " + timeleft + ", count = " + count + ", pos = " + (objpos - oldpos).magnitude);
                    touch_timecount = 0;
                    count += 1;
                    if (count == 1)
                    {
                        //Debug.Log("OK first");
                        firsttouch = objpos;
                        firsttouchrot = objrot;
                    }
                }
                //Debug.Log("pos = " + (objpos - oldpos).magnitude + ", rot = " + objpos);
                timeleft = 0.5f; //静止していなければ時間をリセット

            }
        }

        if (script.Index_flag == 1 && dwell_script.dwell_flag == 1 && script.flick_interval_flag == 0)
        {
            pinch_flag = 1;
            //Debug.Log("script.Index_flag = " + script.Middle_flag + " pinch_flag = " + pinch_flag + " " + script.Index_flag);
        } else if(script.Middle_flag == 1 && dwell_script.dwell_flag == 1 && script.flick_interval_flag == 0)
        {
            pinch_flag = 1;
            //Debug.Log("script.Index_flag = " + script.Middle_flag + " pinch_flag = " + pinch_flag + " " + script.Index_flag);
        }


        //Debug.Log("OK0 touch_count = " + touch_timecount + ", time = " + timeleft + ", count = " + count + ", pos = " + (objpos - oldpos).magnitude);
        if (count >= 2 && count <= 6 && dwell_script.dwell_flag == 1 && script.flick_center_flag == 0 && script.flick_side_flag == 0 && script.keypos_interval_flag == 0) //カウントが3以上かつその場に1秒以上静止
        {
            //Debug.Log("OK1 keyset1" + ", time = " + timeleft + ", dwell = " + (firsttouchrot - objrot).magnitude);
            if ((firsttouchrot - objrot).magnitude > 345.0f || (firsttouchrot - objrot).magnitude < 15.0f)
            {
                //Debug.Log("OK2 keyset1" + ", time = " + timeleft + ", dwell = " + (firsttouchrot - objrot).magnitude);
                //&& (firsttouch - objpos).magnitude < 0.04f && (firsttouch - objpos).magnitude > 0.005f
                //Debug.Log("mode1");
                if (timeleft <= 0.0f && (firsttouch - objpos).magnitude < 0.04f && (firsttouch - objpos).magnitude > 0.005f)
                {
                    //Debug.Log("keyset2" + ", pos = " + (firsttouch - objpos).magnitude);
                    // オブジェクトの位置を変更
                    objpos.x = script.L_position.x + realobjpos.x;
                    objpos.y = script.L_position.y + realobjpos.y;
                    objpos.z = script.L_position.z + realobjpos.z;
                    Vector3 subpos = myTransform.position;
                    myTransform.position = objpos;
                    // オブジェクトの姿勢を変更
                    objrot.x = script.L_rotation.z + realobjrot.x;
                    objrot.y = script.L_rotation.y + realobjrot.y;
                    objrot.z = script.L_rotation.x + realobjrot.z;
                    Quaternion subrot = myTransform.rotation;
                    myTransform.eulerAngles = objrot;
                    // キーボード生成
                    Instantiate(ObjectE, myTransform.position, myTransform.rotation);
                    myTransform.position = subpos;
                    myTransform.rotation = subrot;
                    script.keyboard_amount -= 1;
                    // リセット
                    count = 0;
                    timeleft = 2.0f;
                    script.Index_flag = 0;
                    script.Middle_flag = 0;
                    pinch_flag = 0;
                    // インタ―バル
                    script.flick_interval_flag = 1;
                    script.repos_flag = 1;
                    Invoke("input_interval", 0.8f);
                }
            }
        } else if (count >= 7 && count <= 10 && dwell_script.dwell_flag == 1 && script.flick_center_flag == 0 && script.flick_side_flag == 0 && script.keypos_interval_flag == 0)
        {

            if ((firsttouchrot - objrot).magnitude > 345.0f || (firsttouchrot - objrot).magnitude < 15.0f)
            {
                //Debug.Log("mode2");
                if (timeleft <= 0.0f && (firsttouch - objpos).magnitude < 0.04f && (firsttouch - objpos).magnitude > 0.005f)
                {
                    // オブジェクトの位置を変更
                    objpos.x = script.L_position.x + realobjpos.x;
                    objpos.y = script.L_position.y + realobjpos.y;
                    objpos.z = script.L_position.z + realobjpos.z;
                    Vector3 subpos = myTransform.position;
                    myTransform.position = objpos;
                    // オブジェクトの姿勢を変更
                    objrot.x = script.L_rotation.z + realobjrot.x;
                    objrot.y = script.L_rotation.y + realobjrot.y;
                    objrot.z = script.L_rotation.x + realobjrot.z;
                    Quaternion subrot = myTransform.rotation;
                    myTransform.eulerAngles = objrot;
                    // キーボード生成
                    Instantiate(ObjectE, myTransform.position, myTransform.rotation);
                    myTransform.position = subpos;
                    myTransform.rotation = subrot;
                    script.keyboard_amount -= 1;
                    // リセット
                    count = 0;
                    timeleft = 2.0f;
                    script.Index_flag = 0;
                    script.Middle_flag = 0;
                    pinch_flag = 0;
                    // インタ―バル
                    script.flick_interval_flag = 1;
                    script.repos_flag = 1;
                    Invoke("input_interval", 0.8f);
                }
            }
        } else if (pinch_flag == 1)
        {
            if ((firsttouchrot - objrot).magnitude > 340.0f || (firsttouchrot - objrot).magnitude < 20.0f)
            {
                if (timeleft <= -1.0f)
                {
                    // オブジェクトの位置を変更
                    objpos.x = script.L_position.x + realobjpos.x;
                    objpos.y = script.L_position.y + realobjpos.y;
                    objpos.z = script.L_position.z + realobjpos.z;
                    Vector3 subpos = myTransform.position;
                    myTransform.position = objpos;
                    // オブジェクトの姿勢を変更
                    objrot.x = script.L_rotation.z + realobjrot.x;
                    objrot.y = script.L_rotation.y + realobjrot.y;
                    objrot.z = script.L_rotation.x + realobjrot.z;
                    Quaternion subrot = myTransform.rotation;
                    myTransform.eulerAngles = objrot;
                    // キーボード生成
                    if (script.Index_flag == 1)
                    {
                        Debug.Log("mode3 : " + script.keyboard_amount);
                        Instantiate(ObjectC, myTransform.position, myTransform.rotation);
                    } else if (script.Middle_flag == 1)
                    {
                        Debug.Log("mode4 : " + script.keyboard_amount);
                        Instantiate(ObjectD, myTransform.position, myTransform.rotation);
                    }
                    myTransform.position = subpos;
                    myTransform.rotation = subrot;
                    script.keyboard_amount -= 1;
                    // リセット
                    count = 0;
                    timeleft = 2.0f;
                    script.Index_flag = 0;
                    script.Middle_flag = 0;
                    pinch_flag = 0;
                    // インタ―バル
                    script.flick_interval_flag = 1;
                    script.repos_flag = 1;
                    Invoke("input_interval", 0.8f);
                }
            }
        } else if (count > 10 || timeleft <= 0.0f)
        {
            count = 0;
            pinch_flag = 0;
        }

        oldpos = objpos;

    }

    private void input_interval()
    {
        //Debug.Log("flagoff");
        script.flick_interval_flag = 0;
    }
}
