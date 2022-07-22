using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_posR_t3 : MonoBehaviour
{
    private int count;
    public int keyboard_amount;
    public GameObject ObjectB;
    public GameObject keyboard_surface;
    public GameObject SightObject;
    public Vector3 realobjpos;
    public Vector3 realobjrot;
    private receiver script;
    private sight dwell_script;
    private float timeleft;
    private int pinch_flag;
    private Vector3 oldpos;
    private Vector3 firsttouch;
    private Vector3 firsttouchrot;

    private int keyboard_flag; //�L�[�{�[�h�\���p�̃t���O�i�^�C�}�[�X�^�[�g�j
    private int keyboard_flag2; //�L�[�{�[�h�\���p�̃t���O2
    private float timeleft2; //�L�[�{�[�h�\���t���O���������ォ��v��


    // Start is called before the first frame update
    void Start()
    {
        // receiver���擾
        script = ObjectB.GetComponent<receiver>();
        // dwell�preceiver���擾
        dwell_script = SightObject.GetComponent<sight>();
        Transform myTransform = this.transform;
        oldpos = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �ʒu�擾
        Transform myTransform = this.transform;
        Vector3 objpos = myTransform.position;
        Vector3 objrot = myTransform.eulerAngles;

        // �o�ߎ��Ԃ��v��
        timeleft -= Time.deltaTime;

        // �ʒu�����X�V
        if (script.Index_flag == 1 && script.dwell_flag == 1 && script.test_flag < 10)
        {
            script.Index_flag = 0;
            keyboard_flag = 1;
        }
        if (keyboard_flag == 1)
        {
            timeleft2 -= Time.deltaTime;
        }
        if (timeleft2 <= -3.0f)
        {
            timeleft2 = 0.0f;
            script.Index_flag = 0;
            keyboard_flag = 0;
            keyboard_flag2 = 1;
        }

        if (keyboard_flag2 == 1 && script.test_flag < 10 && script.dwell_flag == 1)
        {
            //�ʒu�p���̕␳
            myTransform.position = script.R_keyboard.transform.position;
            myTransform.rotation = script.R_keyboard.transform.rotation;

            // �L�[�{�[�h����
            Instantiate(keyboard_surface, myTransform.position, myTransform.rotation);
            script.keyboard_amount -= 1;

            // ���Z�b�g
            timeleft = 2.0f;
            script.Index_flag = 0;
            script.test_flag += 1;
            keyboard_flag2 = 0;

            // �C���^�\�o��
            script.flick_interval_flag = 1;
            script.repos_flag = 1;
            Invoke("input_interval", 0.8f);
        }
        if (timeleft <= -3.0f)
        {
            timeleft = 2.0f;
            script.Index_flag = 0;
        }

        if (script.keyboard_active == 1)
        {
        }
    }

    private void input_interval()
    {
        script.flick_interval_flag = 0;
    }
}
