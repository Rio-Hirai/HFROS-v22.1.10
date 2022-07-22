using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_center2 : MonoBehaviour
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

    //private float seconds = 0;
    //private float deltatime = 0;
    //private Vector3 hitPos;

    // Start is called before the first frame update
    void Start()
    {
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
        flick_off();
    }

    // 接触時
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" && script.flick_center_flag == 0)
        {
            if (flag == 0)
            {
                flag = 1;
            }
            if (script.flick_side_flag == 0)
            {
                ThisRenderer.material.color = Color.red; // パネルの色を赤にする
            }
            script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
            flick_on(); // フリックパネルを開く
            //hitPos = collider.ClosestPointOnBounds(this.transform.position);
        }
    }

    // 接触している間
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider" && script.flick_side_flag == 0)
        {
            if (flag == 0)
            {
                flag = 1;
            }
            ThisRenderer.material.color = Color.red; // パネルの色を赤にする
            script.flick_center_flag = 1; // 中央パネルとの接触フラグをオンにする
        }
    }

    // 離れた瞬間時
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            if (flag == 1)
            {
                flag = 0;
                script.flick_center_flag = 0; // 中央パネルとの接触フラグをオフにする
            }
            ThisRenderer.material.color = Color.white; // パネルの色を白にする

            //いずれのパネルも接触フラグを立てていない時
            Invoke("delaypanel", 0.1f);
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
}
