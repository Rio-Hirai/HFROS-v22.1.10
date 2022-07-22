using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_curve_pos : MonoBehaviour
{
    //private Renderer renderer;
    //private Renderer dwell_renderer;
    //private int flag = 0;
    private int count;
    //private int touch_timecount = 0; //壁接触検知用のカウント
    //private int touch_timecount2 = 0; //壁接触検知用のカウント2
    //private int leave_timecount = 0; //壁離脱検知用のカウント
    //private int keyset_interval = 0;
    public int keyboard_amount;
    public GameObject ObjectB;
    public GameObject keyboard_surface;
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

    private int keyboard_flag; //キーボード表示用のフラグ（タイマースタート）
    private int keyboard_flag2; //キーボード表示用のフラグ2
    private float timeleft2; //キーボード表示フラグが立った後から計測

    //表示文章
    public GameObject test_phrase;
    public GameObject input_phrase;

    //表示キー
    public GameObject key_del;
    public GameObject key_enter;
    public GameObject key_space;
    public GameObject key_6;
    public GameObject key_7;
    public GameObject key_8;
    public GameObject key_9;
    public GameObject key_0;
    public GameObject key_y;
    public GameObject key_u;
    public GameObject key_i;
    public GameObject key_o;
    public GameObject key_p;
    public GameObject key_h;
    public GameObject key_j;
    public GameObject key_k;
    public GameObject key_l;
    public GameObject key_coron;
    public GameObject key_n;
    public GameObject key_m;
    public GameObject key_kanma;
    public GameObject key_priod;
    public GameObject key_slash;


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
        //Debug.Log(script.keyboard_amount);
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

        // 位置情報を更新
        //objpos.x = script.L_position.x + realobjpos.x;
        //objpos.y = script.L_position.y + realobjpos.y;
        //objpos.z = script.L_position.z + realobjpos.z;
        //objrot.x = script.L_rotation.z + realobjrot.x;
        //objrot.y = script.L_rotation.y + realobjrot.y;
        //objrot.z = script.L_rotation.x + realobjrot.z;
        if(script.Index_flag == 1 && script.dwell_flag == 1 && script.test_flag < 10)
        {
            script.Index_flag = 0;
            keyboard_flag = 1;
            //Debug.Log("OK_flag_start");
        }
        if(keyboard_flag == 1)
        {
            timeleft2 -= Time.deltaTime;
        }
        if (timeleft2 <= -3.0f)
        {
            timeleft2 = 0.0f;
            script.Index_flag = 0;
            //script.Middle_flag = 0;
            keyboard_flag = 0;
            //Debug.Log("OK_flag_end");
            keyboard_flag2 = 1;
        }

        if (keyboard_flag2 == 1 && script.test_flag < 10 && script.dwell_flag == 1)
        {
            //objpos += realobjpos;
            //objrot = script.realobjrot_R;
            //myTransform.position = script.realobjrot_R.position;
            //Angles.y = 0.0f;
            //myTransform.eulerAngles = script.realobjrot_R.eulerAngles - script.R_rotation;
            //myTransform.eulerAngles = script.realobjrot_R.eulerAngles;
            //myTransform.eulerAngles -= realobjrot;

            //位置姿勢の補正
            //myTransform.eulerAngles += script.realobjrot_R.eulerAngles;
            //myTransform.eulerAngles += script.R_rotation;
            //myTransform.position = script.R_keyboard.transform.position;
            //myTransform.position = script.righthand.transform.position;
            myTransform.position = script.R_keyboard.transform.position;
            myTransform.rotation = script.R_keyboard.transform.rotation;
            //myTransform.rotation = script.righthand.transform.rotation;

            // キーボード生成
            //Debug.Log("mode5 : " + script.righthand.transform.eulerAngles);

            //Instantiate(ObjectC, myTransform.position, myTransform.rotation);
            //Instantiate(test_phrase, myTransform.position, myTransform.rotation);
            //Instantiate(input_phrase, myTransform.position, myTransform.rotation);
            Instantiate(key_enter, myTransform.position, myTransform.rotation);
            Instantiate(key_del, myTransform.position, myTransform.rotation);
            Instantiate(key_space, myTransform.position, myTransform.rotation);
            Instantiate(key_6, myTransform.position, myTransform.rotation);
            Instantiate(key_7, myTransform.position, myTransform.rotation);
            Instantiate(key_8, myTransform.position, myTransform.rotation);
            Instantiate(key_9, myTransform.position, myTransform.rotation);
            Instantiate(key_0, myTransform.position, myTransform.rotation);
            Instantiate(key_y, myTransform.position, myTransform.rotation);
            Instantiate(key_u, myTransform.position, myTransform.rotation);
            Instantiate(key_i, myTransform.position, myTransform.rotation);
            Instantiate(key_o, myTransform.position, myTransform.rotation);
            Instantiate(key_p, myTransform.position, myTransform.rotation);
            Instantiate(key_h, myTransform.position, myTransform.rotation);
            Instantiate(key_j, myTransform.position, myTransform.rotation);
            Instantiate(key_k, myTransform.position, myTransform.rotation);
            Instantiate(key_l, myTransform.position, myTransform.rotation);
            Instantiate(key_coron, myTransform.position, myTransform.rotation);
            Instantiate(key_n, myTransform.position, myTransform.rotation);
            Instantiate(key_m, myTransform.position, myTransform.rotation);
            Instantiate(key_kanma, myTransform.position, myTransform.rotation);
            Instantiate(key_priod, myTransform.position, myTransform.rotation);
            Instantiate(key_slash, myTransform.position, myTransform.rotation);
            Instantiate(keyboard_surface, myTransform.position, myTransform.rotation);

            script.keyboard_amount -= 1;
            // リセット
            //count = 0;
            timeleft = 2.0f;
            script.Index_flag = 0;
            //script.Middle_flag = 0;
            script.test_flag += 1;
            keyboard_flag2 = 0;
            // インタ―バル
            script.flick_interval_flag = 1;
            script.repos_flag = 1;
            Invoke("input_interval", 0.8f);
        }
        if (timeleft <= -3.0f)
        {
            timeleft = 2.0f;
            script.Index_flag = 0;
            //script.Middle_flag = 0;
        }

        if(script.keyboard_active == 1)
        {
            //key_enter.SetActive(true);
            //key_del.SetActive(true);
            //key_space.SetActive(true);
            //key_6.SetActive(true);
            //key_7.SetActive(true);
            //key_8.SetActive(true);
            //key_9.SetActive(true);
            //key_0.SetActive(true);
            //key_y.SetActive(true);
            //key_u.SetActive(true);
            //key_i.SetActive(true);
            //key_o.SetActive(true);
            //key_p.SetActive(true);
            //key_h.SetActive(true);
            //key_j.SetActive(true);
            //key_k.SetActive(true);
            //key_l.SetActive(true);
            //key_coron.SetActive(true);
            //key_n.SetActive(true);
            //key_m.SetActive(true);
            //key_kanma.SetActive(true);
            //key_priod.SetActive(true);
            //key_slash.SetActive(true);
            //Debug.Log("OK:reset_R");
        }


       // if ((objpos - oldpos).magnitude < 0.002f)
       // {
       //     touch_timecount += 1;
       // }
       // else
       // {
       //     if ((objpos - oldpos).magnitude < 0.006f)
       //     {
       //         if (touch_timecount > 0)
       //         {
       //             //Debug.Log("count = " + touch_timecount);
       //             //Debug.Log("touch_count = " + touch_timecount + ", time = " + timeleft + ", count = " + count + ", pos = " + (objpos - oldpos).magnitude);
       //             touch_timecount = 0;
       //             count += 1;
       //             if (count == 1)
       //             {
       //                 firsttouch = objpos;
       //                 firsttouchrot = objrot;
       //             }
       //         }
       //         timeleft = 0.5f; //静止していなければ時間をリセット
       //         Debug.Log("reset");

       //     }
       // }

       // if (script.Index_flag == 1 && dwell_script.dwell_flag == 1 && script.flick_interval_flag == 0)
       // {
       //     pinch_flag = 1;
       //     Debug.Log("script.Index_flag = " + script.Middle_flag + " pinch_flag = " + pinch_flag + " " + script.Index_flag);
       // }


       // //Debug.Log("OK0 touch_count = " + touch_timecount + ", time = " + timeleft + ", count = " + count + ", pos = " + (objpos - oldpos).magnitude);
       //if (pinch_flag == 1)
       // {
       //     if ((firsttouchrot - objrot).magnitude > 340.0f || (firsttouchrot - objrot).magnitude < 20.0f)
       //     {
       //         if (timeleft <= -1.0f)
       //         {
       //             // オブジェクトの位置を変更
       //             objpos.x = script.L_position.x + realobjpos.x;
       //             objpos.y = script.L_position.y + realobjpos.y;
       //             objpos.z = script.L_position.z + realobjpos.z;
       //             Vector3 subpos = myTransform.position;
       //             myTransform.position = objpos;
       //             // オブジェクトの姿勢を変更
       //             objrot.x = script.L_rotation.z + realobjrot.x;
       //             objrot.y = script.L_rotation.y + realobjrot.y;
       //             objrot.z = script.L_rotation.x + realobjrot.z;
       //             Quaternion subrot = myTransform.rotation;
       //             myTransform.eulerAngles = objrot;
       //             // キーボード生成
       //             if (script.Index_flag == 1)
       //             {
       //                 Debug.Log("mode3 : " + script.keyboard_amount);
       //                 Instantiate(ObjectC, myTransform.position, myTransform.rotation);
       //             }
       //             myTransform.position = subpos;
       //             myTransform.rotation = subrot;
       //             script.keyboard_amount -= 1;
       //             // リセット
       //             count = 0;
       //             timeleft = 2.0f;
       //             script.Index_flag = 0;
       //             script.Middle_flag = 0;
       //             pinch_flag = 0;
       //             // インタ―バル
       //             script.flick_interval_flag = 1;
       //             script.repos_flag = 1;
       //             Invoke("input_interval", 0.8f);
       //         }
       //     }
       // }
       // else if (count > 10 || timeleft <= 0.0f)
       // {
       //     count = 0;
       //     pinch_flag = 0;
       // }

       // oldpos = objpos;

    }

    private void input_interval()
    {
        //Debug.Log("flagoff");
        script.flick_interval_flag = 0;
    }
}
