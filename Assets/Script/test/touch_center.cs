using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_center : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public string input;
    public GameObject ObjectB;
    private receiver script;
    //フリックオブジェクト
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

    //private float seconds = 0;
    //private float deltatime = 0;

    void Start()
    {
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
        flick_off();
    }

    // 接触時
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider")
        {
            if (script.flick_center_flag == 0 && script.flick_interval_flag == 0)
            {
                if (flag == 0)
                {
                    flag = 1;
                    //script.input = script.input + input;
                    //ObjectB.GetComponent<receiver>().input = input;
                }
                if (script.flick_side_flag == 0)
                {
                    ThisRenderer.material.color = Color.red; // パネルの色を赤にする
                }
                script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
                flick_on(); // フリックパネルを開く
                panel_off();
            }
        }
    }

    // 接触している間
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider")
        {
            if (script.flick_side_flag == 0 && script.flick_interval_flag == 0)
            {
                if (flag == 0)
                {
                    flag = 1;
                    //script.input = script.input + input;
                    //ObjectB.GetComponent<receiver>().input = input;
                }
                ThisRenderer.material.color = Color.red; // パネルの色を赤にする
                script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
            }
        }
    }

    // 離れた瞬間時
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider")
        {
            if (flag == 1)
            {
                flag = 0;
                script.flick_center_flag = 0; // 中央パネルとの接触フラグをオフにする
            }
            ThisRenderer.material.color = Color.white; // パネルの色を白にする

            //いずれのパネルも接触フラグを立てていない時
            if (script.flick_interval_flag == 0)
            {
                Invoke("delaypanel", 0.2f);
            }
        }
    }

    private void flick_on()
    {
        up_object.SetActive(true);
        down_object.SetActive(true);
        right_object.SetActive(true);
        left_object.SetActive(true);
    }

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
        if (script.flick_center_flag == 0 && script.flick_side_flag == 0)
        {
            flick_off(); // フリックパネルを閉じる
            script.input = script.input + input; // 入力処理を行う
            panel_on(); // フリックパネル全体を再表示する
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
