using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public string input;
    public GameObject ObjectB;
    public GameObject keyboard_R;
    public GameObject keyboard_L;
    private receiver script;
    private float timeleft;

    void Start()
    {
        script = ObjectB.GetComponent<receiver>();
    }

    private void Update()
    {
        timeleft += Time.deltaTime;
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
    }

    // 接触時
    private void OnTriggerEnter(Collider collider)
    {
        // || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider"
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            ThisRenderer.material.color = Color.red; // パネルの色を赤にする
            //if (script.flick_center_flag == 0 && script.flick_interval_flag == 0)
            //{
            //    if (flag == 0)
            //    {
            //        flag = 1;
            //    }
            //    if (script.flick_side_flag == 0)
            //    {
            //        renderer.material.color = Color.red; // パネルの色を赤にする
            //        timeleft = 0;
            //    }
            //    script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
            //}
        }
    }

    // 接触している間
    private void OnTriggerStay(Collider collider)
    {
        // || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider"
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            //if (script.flick_center_flag == 0 && script.flick_interval_flag == 0)
            //{
            //    if (flag == 0)
            //    {
            //        flag = 1;
            //    }
            //    //renderer.material.color = Color.red; // パネルの色を赤にする
            //    script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
            //}
        }
    }

    // 離れた瞬間時
    private void OnTriggerExit(Collider collider)
    {
        // || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider"
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            if (flag == 1)
            {
                flag = 0;
                //script.flick_center_flag = 0; // 中央パネルとの接触フラグをオフにする
            }
            if (ThisRenderer.material.color == Color.red)
            {
                ThisRenderer.material.color = Color.white; // パネルの色を白にする
                //Debug.Log("time = " + timeleft);
                script.release_flag = 0;

                if (script.keyboard_set_active == 0)
                {
                    script.keyboard_set_active = 1;
                    script.input_ready = 1; //多分統合できる
                    Debug.Log("set_active = " + script.keyboard_set_active);
                    keyboard_L.SetActive(false);
                    keyboard_R.SetActive(false);
                }
                else if (script.keyboard_set_active == 1)
                {
                    script.keyboard_set_active = 0;
                    script.input_ready = 0; //多分統合できる
                    Debug.Log("set_active = " + script.keyboard_set_active);
                    keyboard_L.SetActive(true);
                    keyboard_R.SetActive(true);
                }
                script.release_flag = 0;

                //Invoke("delaypanel", 0.5f);

            }
        }
    }

    private void delaypanel()
    {
    }

    private void input_interval()
    {
        script.flick_interval_flag = 0;
    }

    private void keypos_interval()
    {
        script.keypos_interval_flag = 0;
    }
}