using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_test : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public string input;
    public GameObject ObjectB;
    private receiver script;
    public GameObject up_object;
    public GameObject down_object;
    public GameObject right_object;
    public GameObject left_object;
    // 他のパネル
    public GameObject panel_abc;
    public GameObject panel_def;
    public GameObject panel_ghi;
    public GameObject panel_jkl;
    public GameObject panel_mno;
    public GameObject panel_pqrs;
    public GameObject panel_tuv;
    public GameObject panel_wxyz;
    public GameObject panel_etc;

    void Start()
    {
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
    }

    // 接触時
    private void OnTriggerEnter(Collider collider)
    {
        // 接触時に中央パネルの接触フラグがオフになっていた場合
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider")
        {
            if (flag == 0)
            {
                flag = 1;
                //script.input = script.input + input;
                //ObjectB.GetComponent<receiver>().input = input;
            }
            script.flick_side_flag = 1; // サイドパネルとの接触フラグをオンにする

            if(script.flick_center_flag == 0)
            {
                ThisRenderer.material.color = Color.red; // パネルの色を赤にする
            }
            //Debug.Log("fflag = " + script.flick_flag);
        }
    }

    // 接触している間
    private void OnTriggerStay(Collider collider)
    {
        // 接触している間に中央パネルの接触フラグがオフになった場合
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider")
        {
            if (script.flick_center_flag == 0)
            {
                if (flag == 0)
                {
                    flag = 1;
                    //script.input = script.input + input;
                    //ObjectB.GetComponent<receiver>().input = input;
                }
                ThisRenderer.material.color = Color.red; // パネルの色を赤にする
                script.flick_side_flag = 1; // サイドパネルとの接触フラグをオンにする
                                            //Debug.Log("fflag = " + script.flick_flag);
            }
        }
    }

    // 離れた瞬間
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider")
        {
            if(flag == 1)
            {
                flag = 0;
                script.flick_side_flag = 0; // サイドパネルとの接触フラグをオフにする
                //Debug.Log("fflag_flag = " + script.flick_flag);
            }
            ThisRenderer.material.color = Color.white; // パネルの色を白にする

            //いずれのパネルも接触フラグを立てていない時
            if (script.flick_center_flag == 0 && script.flick_side_flag == 0)
            {
                Invoke("delaypanel", 0.2f);
            }
        }
    }

    // フリックパネル展開
    private void flick_on()
    {
        up_object.SetActive(true);
        down_object.SetActive(true);
        right_object.SetActive(true);
        left_object.SetActive(true);
    }

    // フリックパネル消滅
    private void flick_off()
    {
        up_object.SetActive(false);
        down_object.SetActive(false);
        right_object.SetActive(false);
        left_object.SetActive(false);
    }

    private void panel_on()
    {
        panel_abc.SetActive(true);
        panel_def.SetActive(true);
        panel_ghi.SetActive(true);
        panel_jkl.SetActive(true);
        panel_mno.SetActive(true);
        panel_pqrs.SetActive(true);
        panel_tuv.SetActive(true);
        panel_wxyz.SetActive(true);
        panel_etc.SetActive(true);
    }

    private void panel_off()
    {
        panel_abc.SetActive(false);
        panel_def.SetActive(false);
        panel_ghi.SetActive(false);
        panel_jkl.SetActive(false);
        panel_mno.SetActive(false);
        panel_pqrs.SetActive(false);
        panel_tuv.SetActive(false);
        panel_wxyz.SetActive(false);
        panel_etc.SetActive(false);
    }

    private void delaypanel()
    {
        if (script.flick_center_flag == 0 && script.flick_side_flag == 0 && script.flick_interval_flag == 0)
        {
            flick_off(); // フリックパネルを閉じる
            panel_on();
            script.input = script.input + input; // 入力処理
            script.flick_interval_flag = 1;
            script.keypos_interval_flag = 1;
            script.repos_flag = 1;
            Invoke("input_interval", 0.2f);
            Invoke("keypos_interval", 3.0f);
        }
    }

    private void input_interval()
    {
        //Debug.Log("flagoff");
        script.flick_interval_flag = 0;
    }

    private void keypos_interval()
    {
        script.keypos_interval_flag = 0;
    }
}