using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_rotate : MonoBehaviour
{
    //�T�[�o�[�֌W
    public GameObject inputtext;
    public GameObject Object0;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;
    private receiver script;
    // Start is called before the first frame update
    void Start()
    {
        script = inputtext.GetComponent<receiver>(); //�T�[�o�[�ɐڑ�
    }

    // Update is called once per frame
    void Update()
    {
        //���̎p����ۑ�
        script.realobjrot_R = Object0.transform;
        //�e�w��̍��W���X�V
        Object1.transform.position = script.Thumb_position_t;
        Object2.transform.position = script.Index_position_t;
        Object3.transform.position = script.Middle_position_t;
        Object4.transform.position = script.Ring_position_t;
        Object5.transform.position = script.Pinky_position_t;
        //�p����������
        //Transform myTransform = this.transform;
        //myTransform = Object6.transform;
        //Vector3 Angles = Object6.transform.eulerAngles;
        //Angles.y = 180.0f;
        this.transform.localEulerAngles = Object6.transform.localEulerAngles;
        //this.transform.eulerAngles = Angles;
        //�z�u�Ɏg�p����w��̍��W��ۑ�
        script.Thumb_position = Object1.transform.position;
        script.Index_position = Object2.transform.position;
        script.Middle_position = Object3.transform.position;
        script.Ring_position = Object4.transform.position;
        script.Pinky_position = Object5.transform.position;
    }
}
