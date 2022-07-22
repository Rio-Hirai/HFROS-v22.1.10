using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_button : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public string input;
    public GameObject ObjectB;
    private receiver script;
    private float timeleft;

    //アクティブにするキー
    public GameObject keyboard_surface_R;
    public GameObject keyboard_surface_L;
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
    public GameObject key_del_L;
    public GameObject key_enter_L;
    public GameObject key_space_L;
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
            //if (flag == 1)
            //{
            //    flag = 0;
            //    script.flick_center_flag = 0; // 中央パネルとの接触フラグをオフにする
            //}
            if (ThisRenderer.material.color == Color.red)
            {
                ThisRenderer.material.color = Color.white; // パネルの色を白にする

                script.test_flag = 0;
                script.test_flag_L = 0;
                script.keyboard_active = 1;

                key_enter.SetActive(true);
                key_del.SetActive(true);
                key_space.SetActive(true);
                key_6.SetActive(true);
                key_7.SetActive(true);
                key_8.SetActive(true);
                key_9.SetActive(true);
                key_0.SetActive(true);
                key_y.SetActive(true);
                key_u.SetActive(true);
                key_i.SetActive(true);
                key_o.SetActive(true);
                key_p.SetActive(true);
                key_h.SetActive(true);
                key_j.SetActive(true);
                key_k.SetActive(true);
                key_l.SetActive(true);
                key_coron.SetActive(true);
                key_n.SetActive(true);
                key_m.SetActive(true);
                key_kanma.SetActive(true);
                key_priod.SetActive(true);
                key_slash.SetActive(true);
                script.Index_flag = 0;
                Debug.Log("OK:reset_R" + script.Index_flag);

                key_del_L.SetActive(true);
                key_space_L.SetActive(true);
                key_1.SetActive(true);
                key_2.SetActive(true);
                key_3.SetActive(true);
                key_4.SetActive(true);
                key_5.SetActive(true);
                key_q.SetActive(true);
                key_w.SetActive(true);
                key_e.SetActive(true);
                key_r.SetActive(true);
                key_t.SetActive(true);
                key_a.SetActive(true);
                key_s.SetActive(true);
                key_d.SetActive(true);
                key_f.SetActive(true);
                key_g.SetActive(true);
                key_z.SetActive(true);
                key_x.SetActive(true);
                key_c.SetActive(true);
                key_v.SetActive(true);
                key_b.SetActive(true);
                script.Index_flag_L = 0;
                Debug.Log("OK:reset_L");

                keyboard_surface_R.SetActive(true);
                keyboard_surface_L.SetActive(true);

                script.keyboard_active = 0;
            }
        }
    }
}