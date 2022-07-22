using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_icon_pos : MonoBehaviour
{
    //サーバー関係
    public GameObject inputkey;
    private key_surface script;
    private Vector3 tmp_pos;
    private Vector3 pos;
    public int objectNo;

    void Start()
    {
        script = inputkey.GetComponent<key_surface>();
        tmp_pos = this.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition = tmp_pos;
        //Debug.Log("script.key_icon = " + script.key_icon.ToString("F6") + float.IsNaN(script.key_icon.z));
        //Debug.Log("transform.localPosition = " + this.gameObject.transform.localPosition.ToString("F6"));
        if(!float.IsNaN(script.key_icon.z))
        {
            //script.key_icon.z = 0.0f;
            this.gameObject.transform.localPosition += script.key_icon;
            pos = this.gameObject.transform.position;
        }
        //this.gameObject.transform.localPosition += script.key_icon;
        //pos = this.gameObject.transform.position;
        if (objectNo != 0)
        {
            //if (objectNo != script.test_flag)
            //{
            //    this.gameObject.SetActive(false);
            //}
        }
        //Debug.Log("real = " + this.gameObject.transform.position.ToString("F6") + ", icon = " + script.key_icon.ToString("F6"));
    }
}
