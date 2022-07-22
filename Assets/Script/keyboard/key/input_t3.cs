using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class input_t3 : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public string input;
    public GameObject ObjectB;
    private receiver script;
    private float timeleft;
    public float interval = 0.4f;
    private DateTime presentTime;

    private bool thumb_R_flag = false;
    private bool thumb_L_flag = false;
    private float thumbs_time;
    public string tmp_input_keys;

    void Start()
    {
        script = ObjectB.GetComponent<receiver>();
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (timeleft == 0)
        {
            //ThisRenderer.material.color = Color.white;
        }
        timeleft += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (script.release_flag == 0)
        {
            ThisRenderer.material.color = Color.white; //キーを白色にする
            script.release_flag = 0;
        }

        if (collider.gameObject.name.StartsWith("Thumb_L"))
        {
            script.thumb_L_flag = true;
        }
        else if (collider.gameObject.name.StartsWith("Thumb_R"))
        {
            script.thumb_R_flag = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (script.input_ready > 0 && timeleft > script.newkey_interval)
        {
            if (collider.gameObject.name.StartsWith("Pinky_L"))
            {
                if (script.before_char == "_")
                {
                    script.input_keys = "";
                }
                //Debug.Log("1");
                input = "1";
                script.input_keys = script.input_keys + input; // 入力処理を行う
                script.input_Log = script.input_Log + input; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }
            else if (collider.gameObject.name.StartsWith("Ring_L"))
            {
                if (script.before_char == "_")
                {
                    script.input_keys = "";
                }
                //Debug.Log("2");
                input = "2";
                script.input_keys = script.input_keys + input; // 入力処理を行う
                script.input_Log = script.input_Log + input; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }
            else if (collider.gameObject.name.StartsWith("Middle_L"))
            {
                if (script.before_char == "_")
                {
                    script.input_keys = "";
                }
                //Debug.Log("3");
                input = "3";
                script.input_keys = script.input_keys + input; // 入力処理を行う
                script.input_Log = script.input_Log + input; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }
            else if (collider.gameObject.name.StartsWith("Index_L"))
            {
                if (script.before_char == "_")
                {
                    script.input_keys = "";
                }
                //Debug.Log("4");
                input = "4";
                script.input_keys = script.input_keys + input; // 入力処理を行う
                script.input_Log = script.input_Log + input; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }
            //else if (collider.gameObject.name.StartsWith("Thumb_R") || collider.gameObject.name.StartsWith("Thumb_L"))
            //{
            //    if (script.thumb_R_flag == true && script.thumb_L_flag == true)
            //    {
            //        script.delete_flag = true;
            //        script.thumb_R_flag = false;
            //        script.thumb_L_flag = false;
            //    } else if (script.delete_flag == true)
            //    {
            //        input = "9";
            //        script.before_char = input;
            //        script.delete_flag = false;
            //    } else
            //    {
            //        script.thumb_R_flag = false;
            //        Debug.Log("0");
            //        input = "0";
            //        script.input_Log = script.input_Log + "0"; // 入力処理を行う
            //        script.before_char = input; //入力した文字を記憶
            //        script.input_amount += 1; //入力数をカウントする
            //        script.thumb_R_flag = false;
            //        script.thumb_L_flag = false;
            //        script.delete_flag = false;
            //    }
            //}
            else if (collider.gameObject.name.StartsWith("Thumb_L"))
            {
                //Debug.Log("9");
                input = "9";
                script.input_Log = script.input_Log + "9"; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }
            else if (collider.gameObject.name.StartsWith("Thumb_R"))
            {
                //Debug.Log("0");
                input = "0";
                script.input_Log = script.input_Log + "0"; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }
            else if (collider.gameObject.name.StartsWith("Index_R"))
            {
                if (script.before_char == "_")
                {
                    script.input_keys = "";
                }
                //Debug.Log("5");
                input = "5";
                script.input_keys = script.input_keys + input; // 入力処理を行う
                script.input_Log = script.input_Log + input; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }
            else if (collider.gameObject.name.StartsWith("Middle_R"))
            {
                if (script.before_char == "_")
                {
                    script.input_keys = "";
                }
                //Debug.Log("6");
                input = "6";
                script.input_keys = script.input_keys + input; // 入力処理を行う
                script.input_Log = script.input_Log + input; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }
            else if (collider.gameObject.name.StartsWith("Ring_R"))
            {
                if (script.before_char == "_")
                {
                    script.input_keys = "";
                }
                //Debug.Log("7");
                input = "7";
                script.input_keys = script.input_keys + input; // 入力処理を行う
                script.input_Log = script.input_Log + input; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }
            else if (collider.gameObject.name.StartsWith("Pinky_R"))
            {
                if (script.before_char == "_")
                {
                    script.input_keys = "";
                }
                //Debug.Log("8");
                input = "8";
                script.input_keys = script.input_keys + input; // 入力処理を行う
                script.input_Log = script.input_Log + input; // 入力処理を行う
                script.before_char = input; //入力した文字を記憶
                script.input_amount += 1; //入力数をカウントする
            }

            ThisRenderer.material.color = Color.red;
            script.yosoku();
            timeleft = 0; //インターバルを初期化
        }
    }

    private static int space_num(string input_sentence)
    {
        string space_char = " ";
        int num = 0;
        int num_tmp = 0;

        if (input_sentence != null && input_sentence.Length > 0)
        {
            num = input_sentence.Substring(0, input_sentence.Length - 1).IndexOf("_");
        }

        while (num > 0)
        {
            num_tmp = num;
            if (input_sentence.Length > 0 && input_sentence.Length > num + 1)
            {
                num = input_sentence.Substring(0, input_sentence.Length - 1).IndexOf(space_char, num + 1);
            }
            else
            {
                num = -1;
            }
        }

        num = num_tmp;

        return num;
    }

}