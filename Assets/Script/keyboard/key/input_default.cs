using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class input_default : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public string input;
    public GameObject ObjectB;
    private receiver script;
    private float timeleft;
    public float interval = 0.4f;
    private DateTime presentTime;

    void Start()
    {
        script = ObjectB.GetComponent<receiver>();
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        timeleft += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Index") //人差し指と接触した場合
        {
            if (input.Equals(script.before_char))
            {
                interval = 0.8f;
            } else
            {
                interval = 0.4f;
            }

            if(script.release_flag == 0 && timeleft > interval) //いずれのキーも押されていない場合
            {
                ThisRenderer.material.color = Color.red; //キーを赤色にする
                script.colorrenderer = this.gameObject.GetComponent<Renderer>();

                if (script.input_start == 0 && script.input_ready == 2)
                {
                    script.input_start = 1;
                    script.input_start_time = DateTime.Now;
                    script.input_midstart_time[script.input_text_num] = DateTime.Now;
                    Debug.Log("input_timer_start = " + script.input_start_time + ":" + script.input_start_time.Millisecond + "\n");
                    script.input_Log = "";
                }

                script.input = script.input + input; // 入力処理を行う
                script.input_Log = script.input_Log + input; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
                //Debug.Log("time = " + timeleft);
                timeleft = 0; //インターバルを初期化
            }
            script.release_flag = 1; //接触フラグを立てる
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(script.release_flag == 0)
        {
            ThisRenderer.material.color = Color.white; //キーを白色にする
            script.release_flag = 0;
        }
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider") //人差し指と接触したが離れた場合
        {
            ThisRenderer.material.color = Color.white;
            //if (ThisRenderer.material.color == Color.red)
            //{

            //}
            //ThisRenderer.material.color = Color.white; //キーを白色にする
            //script.release_flag = 0; //接触フラグを折る
        }
    }

    //// 接触時
    //private void OnTriggerEnter(Collider collider)
    //{
    //    //collider.gameObject.name == "Hand_Index3_CapsuleCollider"　|| collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider"
    //    if (collider.gameObject.name == "Index_R" || collider.gameObject.name == "Index_L")
    //    {
    //        if (script.flick_center_flag == 0 && script.flick_interval_flag == 0)
    //        {
    //            if (flag == 0)
    //            {
    //                flag = 1;
    //            }
    //            if (script.flick_side_flag == 0 && script.release_flag == 1)
    //            {
    //                renderer.material.color = Color.red; // パネルの色を赤にする
    //                //timeleft = 0;
    //            }
    //            script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
    //        }
    //    }
    //}

    //// 接触している間
    //private void OnTriggerStay(Collider collider)
    //{
    //    //いずれかのキーが接触していれば0にする
    //    if(script.release_flag == 1)
    //    {
    //        script.release_flag = 0;
    //    }

    //    if (collider.gameObject.name == "Index_R" || collider.gameObject.name == "Index_L") {
    //        if (script.flick_center_flag == 0 && script.flick_interval_flag == 0)
    //        {
    //            if (flag == 0)
    //            {
    //                flag = 1;
    //            }
    //            //renderer.material.color = Color.red; // パネルの色を赤にする
    //            script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
    //        }
    //    }
    //}

    //// 離れた瞬間時
    //private void OnTriggerExit(Collider collider)
    //{
    //    if (collider.gameObject.name == "Index_R" || collider.gameObject.name == "Index_L")
    //    {
    //        collider.isTrigger = true;
    //        if (flag == 1)
    //        {
    //            flag = 0;
    //            script.flick_center_flag = 0; // 中央パネルとの接触フラグをオフにする
    //        }
    //        if (renderer.material.color == Color.red) //オブジェクトが赤色＆そのオブジェクトが他のキーに触れていなければ
    //        {
    //            renderer.material.color = Color.white; // パネルの色を白にする
    //            if (script.release_flag == 1)
    //            {
    //                delaypanel();
    //            }
    //            //if (timeleft > 0.03f)
    //            //{
    //            //    //Invoke("delaypanel", 0.03f);
    //            //    delaypanel();
    //            //}
    //        }
    //    }

    //    //いずれかのキーが接触していれば0にする
    //    if (script.release_flag == 0)
    //    {
    //        script.release_flag = 1;
    //    }
    //}

    //private void delaypanel()
    //{
    //    if (script.flick_center_flag == 0 && script.flick_side_flag == 0 && !input.Equals(script.before_char))
    //    {
    //        script.input = script.input + input; // 入力処理を行う
    //        Debug.Log("input = " + script.input);
    //        script.input_amount += 1;
    //        script.flick_interval_flag = 1;
    //        script.keypos_interval_flag = 1;
    //        script.repos_flag = 1;
    //        script.before_char = input;
    //        if(script.input_start == 0 && script.input_ready == 1)
    //        {
    //            script.input_start = 1;
    //            script.input_start_time = DateTime.Now;
    //            script.input_midstart_time[script.input_text_num] = DateTime.Now;
    //            //Debug.Log("input_timer_start");
    //            Debug.Log("input_timer_start = " + script.input_start_time + ":" + script.input_start_time.Millisecond + "\n");
    //        }
    //        Invoke("input_interval", 0.1f);
    //        //input_interval();
    //        //Invoke("keypos_interval", 3.0f);
    //    }
    //}

    //private void input_interval()
    //{
    //    script.flick_interval_flag = 0;
    //}

    //private void keypos_interval()
    //{
    //    script.keypos_interval_flag = 0;
    //}
}