using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class default_enter : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    private string input;
    public GameObject ObjectB;
    private receiver script;
    private float timeleft;
    public float interval = 0.4f;
    private DateTime presentTime;

    void Start()
    {
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
    }
    private void Update()
    {
        timeleft += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider") //人差し指と接触した場合
        {
            if (script.release_flag == 0 && timeleft > interval) //いずれのキーも押されていない場合
            {
                ThisRenderer.material.color = Color.red; //キーを赤色にする
                if(script.input_ready == 1)
                {
                    script.input_ready = 2;
                    script.input = input; // 削除処理を行う
                    script.input_Log = input; // 削除処理を行う
                    script.release_flag = 0;

                    script.hmpw_right_hand = 0;
                    script.hmpw_right_finger = 0;
                    script.hmpw_left_hand = 0;
                    script.hmpw_left_finger = 0;

                    Debug.Log("START!!");
                }
                if (script.input_rest == 0 && script.Test_phrase[script.input_text_num].Length == script.input.Length) //課題文入力時
                {
                    script.input_midend_time[script.input_text_num] = DateTime.Now; //現在時刻（入力終了時刻）を取得
                    script.input_rest = 1;
                    script.Input_phrase[script.input_text_num] = script.input;
                    script.Input_phrase_Log[script.input_text_num] = script.input_Log;
                    script.input = input; // 削除処理を行う
                    script.input_Log = input; // 削除処理を行う
                    script.input_amount += 1;
                    script.input_text_num += 1;
                }
                else if (script.input_rest == 1)//休憩文時
                {
                    script.input_midstart_time[script.input_text_num] = DateTime.Now; //現在時刻（入力開始時刻）を取得
                    script.input_rest = 0;
                    script.input = input; // 削除処理を行う
                    script.input_Log = input; // 削除処理を行う
                }
                if (script.input_text_num >= script.input_text_size && script.output_flag == 0)
                {
                    script.derayStart();
                    script.input = "END";
                }
                if ((script.input_rest == 0 && script.Test_phrase[script.input_text_num].Length == script.input.Length) || script.input_rest == 1)
                {
                    script.flick_interval_flag = 1;
                    script.keypos_interval_flag = 1;
                    script.repos_flag = 1;
                    Invoke("input_interval", 0.1f);
                }
            }
            script.release_flag = 1; //接触フラグを立てる
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider") //人差し指と接触したが離れた場合
        {
            ThisRenderer.material.color = Color.white; //キーを赤色にする
        }
    }

    //// 接触時
    //private void OnTriggerEnter(Collider collider)
    //{
    //    // || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider"
    //    if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
    //    {
    //        if (script.flick_center_flag == 0 && script.flick_interval_flag == 0)
    //        {
    //            if (flag == 0)
    //            {
    //                flag = 1;
    //            }
    //            if (script.flick_side_flag == 0)
    //            {
    //                renderer.material.color = Color.red; // パネルの色を赤にする
    //                Invoke("delaypanel", 0.1f);
    //            }
    //            script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
    //        }
    //    }
    //}

    //// 接触している間
    //private void OnTriggerStay(Collider collider)
    //{
    //    if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
    //    {
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
    //    if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
    //    {
    //        if (flag == 1)
    //        {
    //            flag = 0;
    //            script.flick_center_flag = 0; // 中央パネルとの接触フラグをオフにする
    //        }
    //        renderer.material.color = Color.white; // パネルの色を白にする

    //        //いずれのパネルも接触フラグを立てていない時
    //    }
    //}

    //private void delaypanel()
    //{
    //    if (script.flick_center_flag == 1 && script.flick_side_flag == 0)
    //    {
    //        if(script.input_rest == 0 && script.Test_phrase[script.input_text_num].Length == script.input.Length) //課題文入力時
    //        {
    //            script.input_midend_time[script.input_text_num] = DateTime.Now; //現在時刻（入力終了時刻）を取得
    //            //Debug.Log(script.Test_phrase[script.input_text_num] + ":input_midend " + script.input_text_num + " = " + script.input_midend_time[script.input_text_num] + ":" + script.input_midend_time[script.input_text_num].Millisecond);
    //            script.input_rest = 1;
    //            script.Input_phrase[script.input_text_num] = script.input;
    //            script.Input_phrase_Log[script.input_text_num] = script.input_Log;
    //            script.input = input; // 削除処理を行う
    //            script.input_Log = input; // 削除処理を行う
    //            script.input_amount += 1;
    //            script.input_text_num += 1;
    //        } else if(script.input_rest == 1)//休憩文時
    //        {
    //            script.input_midstart_time[script.input_text_num] = DateTime.Now; //現在時刻（入力開始時刻）を取得
    //            //Debug.Log(script.Test_phrase[script.input_text_num] + ":input_midstart " + script.input_text_num + " = " + script.input_midstart_time[script.input_text_num] + ":" + script.input_midstart_time[script.input_text_num].Millisecond);
    //            script.input_rest = 0;
    //            script.input = input; // 削除処理を行う
    //            script.input_Log = input; // 削除処理を行う
    //        }
    //        if (script.input_text_num >= script.input_text_size && script.output_flag == 0)
    //        {
    //            script.derayStart();
    //            script.input = "END";
    //        }
    //        if((script.input_rest == 0 && script.Test_phrase[script.input_text_num].Length == script.input.Length) || script.input_rest == 1)
    //        {
    //            script.flick_interval_flag = 1;
    //            script.keypos_interval_flag = 1;
    //            script.repos_flag = 1;
    //            Invoke("input_interval", 0.1f);
    //        }
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
