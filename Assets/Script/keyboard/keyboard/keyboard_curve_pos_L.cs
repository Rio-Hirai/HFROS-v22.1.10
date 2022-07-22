using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_curve_pos_L : MonoBehaviour
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
    public GameObject key_1;
    public GameObject key_2;
    public GameObject key_3;
    public GameObject key_4;
    public GameObject key_5;
    public GameObject key_q;
    public GameObject key_w;
    public GameObject key_e;
    public GameObject key_r;
    public GameObject key_t;
    public GameObject key_a;
    public GameObject key_s;
    public GameObject key_d;
    public GameObject key_f;
    public GameObject key_g;
    public GameObject key_z;
    public GameObject key_x;
    public GameObject key_c;
    public GameObject key_v;
    public GameObject key_b;


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
        if (script.Index_flag_L == 1 && script.dwell_flag == 1 && script.test_flag_L < 10)
        {
            script.Index_flag_L = 0;
            keyboard_flag = 1;
            //Debug.Log("OK_flag_start");
        }
        if (keyboard_flag == 1)
        {
            timeleft2 -= Time.deltaTime;
        }
        if (timeleft2 <= -3.0f)
        {
            timeleft2 = 0.0f;
            script.Index_flag_L = 0;
            script.Middle_flag_L = 0;
            keyboard_flag = 0;
            //Debug.Log("OK_flag_end");
            keyboard_flag2 = 1;
        }

        if (keyboard_flag2 == 1 && script.test_flag_L < 10 && script.dwell_flag == 1)
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
            myTransform.position = script.L_keyboard.transform.position;
            myTransform.rotation = script.L_keyboard.transform.rotation;
            //myTransform.rotation = script.righthand.transform.rotation;

            // キーボード生成
            //Debug.Log("mode5 : " + script.righthand.transform.eulerAngles);
            //Instantiate(ObjectC, myTransform.position, myTransform.rotation);
            //Instantiate(test_phrase, myTransform.position, myTransform.rotation);
            //Instantiate(input_phrase, myTransform.position, myTransform.rotation);
            Instantiate(key_del, myTransform.position, myTransform.rotation);
            Instantiate(key_space, myTransform.position, myTransform.rotation);
            Instantiate(key_1, myTransform.position, myTransform.rotation);
            Instantiate(key_2, myTransform.position, myTransform.rotation);
            Instantiate(key_3, myTransform.position, myTransform.rotation);
            Instantiate(key_4, myTransform.position, myTransform.rotation);
            Instantiate(key_5, myTransform.position, myTransform.rotation);
            Instantiate(key_q, myTransform.position, myTransform.rotation);
            Instantiate(key_w, myTransform.position, myTransform.rotation);
            Instantiate(key_e, myTransform.position, myTransform.rotation);
            Instantiate(key_r, myTransform.position, myTransform.rotation);
            Instantiate(key_t, myTransform.position, myTransform.rotation);
            Instantiate(key_a, myTransform.position, myTransform.rotation);
            Instantiate(key_s, myTransform.position, myTransform.rotation);
            Instantiate(key_d, myTransform.position, myTransform.rotation);
            Instantiate(key_f, myTransform.position, myTransform.rotation);
            Instantiate(key_g, myTransform.position, myTransform.rotation);
            Instantiate(key_z, myTransform.position, myTransform.rotation);
            Instantiate(key_x, myTransform.position, myTransform.rotation);
            Instantiate(key_c, myTransform.position, myTransform.rotation);
            Instantiate(key_v, myTransform.position, myTransform.rotation);
            Instantiate(key_b, myTransform.position, myTransform.rotation);
            Instantiate(keyboard_surface, myTransform.position, myTransform.rotation);
            script.keyboard_amount -= 1;
            // リセット
            //count = 0;
            timeleft = 2.0f;
            script.Index_flag_L = 0;
            script.Middle_flag_L = 0;
            script.test_flag_L += 1;
            keyboard_flag2 = 0;
            // インタ―バル
            script.flick_interval_flag = 1;
            script.repos_flag = 1;
            Invoke("input_interval", 0.8f);
        }
        if (timeleft <= -3.0f)
        {
            timeleft = 2.0f;
            script.Index_flag_L = 0;
            script.Middle_flag_L = 0;
        }

        if (script.keyboard_active == 1)
        {
            //key_enter.SetActive(true);
            //key_del.SetActive(true);
            //key_space.SetActive(true);
            //key_1.SetActive(true);
            //key_2.SetActive(true);
            //key_3.SetActive(true);
            //key_4.SetActive(true);
            //key_5.SetActive(true);
            //key_q.SetActive(true);
            //key_w.SetActive(true);
            //key_e.SetActive(true);
            //key_r.SetActive(true);
            //key_t.SetActive(true);
            //key_a.SetActive(true);
            //key_s.SetActive(true);
            //key_d.SetActive(true);
            //key_f.SetActive(true);
            //key_g.SetActive(true);
            //key_z.SetActive(true);
            //key_x.SetActive(true);
            //key_c.SetActive(true);
            //key_v.SetActive(true);
            //key_b.SetActive(true);
            //Debug.Log("OK:reset_L");
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
