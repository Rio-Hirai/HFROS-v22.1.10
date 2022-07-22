using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_input_pos : MonoBehaviour
{
    //サーバー関係
    public GameObject inputkey;
    private key_icon_pos script;
    private Vector3 tmp_pos;
    void Start()
    {
        script = inputkey.GetComponent<key_icon_pos>();
        tmp_pos = this.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition = tmp_pos;
        //Debug.Log(script.key_icon.ToString("F6"));
        //this.gameObject.transform.localPosition += script.pos;
        //Debug.Log("real = " + this.gameObject.transform.position.ToString("F6") + ", icon = " + script.key_icon.ToString("F6"));
    }
}