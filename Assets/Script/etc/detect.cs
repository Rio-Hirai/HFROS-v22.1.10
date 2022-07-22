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

    // �ڐG��
    private void OnTriggerEnter(Collider collider)
    {
        // || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider"
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            ThisRenderer.material.color = Color.red; // �p�l���̐F��Ԃɂ���
            //if (script.flick_center_flag == 0 && script.flick_interval_flag == 0)
            //{
            //    if (flag == 0)
            //    {
            //        flag = 1;
            //    }
            //    if (script.flick_side_flag == 0)
            //    {
            //        renderer.material.color = Color.red; // �p�l���̐F��Ԃɂ���
            //        timeleft = 0;
            //    }
            //    script.flick_center_flag = 1; // �����p�l���Ƃ̐ڐG�t���O���I���ɂ���
            //}
        }
    }

    // �ڐG���Ă����
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
            //    //renderer.material.color = Color.red; // �p�l���̐F��Ԃɂ���
            //    script.flick_center_flag = 1; // �����p�l���Ƃ̐ڐG�t���O���I���ɂ���
            //}
        }
    }

    // ���ꂽ�u�Ԏ�
    private void OnTriggerExit(Collider collider)
    {
        // || collider.gameObject.name == "Hand_Thumb3_CapsuleCollider" || collider.gameObject.name == "Hand_Middle3_CapsuleCollider" || collider.gameObject.name == "Hand_Ring3_CapsuleCollider" || collider.gameObject.name == "Hand_Pinky3_CapsuleCollider"
        if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        {
            if (flag == 1)
            {
                flag = 0;
                //script.flick_center_flag = 0; // �����p�l���Ƃ̐ڐG�t���O���I�t�ɂ���
            }
            if (ThisRenderer.material.color == Color.red)
            {
                ThisRenderer.material.color = Color.white; // �p�l���̐F�𔒂ɂ���
                //Debug.Log("time = " + timeleft);
                script.release_flag = 0;

                if (script.keyboard_set_active == 0)
                {
                    script.keyboard_set_active = 1;
                    script.input_ready = 1; //���������ł���
                    Debug.Log("set_active = " + script.keyboard_set_active);
                    keyboard_L.SetActive(false);
                    keyboard_R.SetActive(false);
                }
                else if (script.keyboard_set_active == 1)
                {
                    script.keyboard_set_active = 0;
                    script.input_ready = 0; //���������ł���
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