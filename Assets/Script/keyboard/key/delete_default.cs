using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_default : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public string input;
    public GameObject ObjectB;
    private receiver script;
    private float timeleft;
    public float interval = 0.2f;

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
                script.input = script.input.Substring(0, script.input.Length - 1); // 削除処理を行う
                script.input_Log = script.input_Log + "[bs]"; // 入力ログを取る
                script.before_char = "null";
                script.back_amount += 1;
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
    //    if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider") {
    //        if (script.flick_center_flag == 0 && script.flick_interval_flag == 0)
    //        {
    //            if (flag == 0)
    //            {
    //                flag = 1;
    //            }
    //            if (script.flick_side_flag == 0)
    //            {
    //                renderer.material.color = Color.red; // パネルの色を赤にする
    //                Invoke("delaypanel", 0.05f);
    //            }
    //            script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
    //        }
    //    }
    //}

    //// 接触している間
    //private void OnTriggerStay(Collider collider)
    //{
    //    if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider")
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
    //    if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider")
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
    //        script.input = script.input.Substring(0, script.input.Length - 1); // 削除処理を行う
    //        script.input_Log = script.input_Log + "[bs]"; // 入力処理を行う
    //        script.before_char = "null";
    //        script.back_amount += 1;
    //        script.flick_interval_flag = 1;
    //        script.keypos_interval_flag = 1;
    //        script.repos_flag = 1;
    //        Invoke("input_interval", 0.05f);
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