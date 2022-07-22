using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_icon_pos_L : MonoBehaviour
{
    //サーバー関係
    public GameObject inputkey;
    private key_surface_L script;
    private Vector3 tmp_pos;

    void Start()
    {
        script = inputkey.GetComponent<key_surface_L>();
        tmp_pos = this.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition = tmp_pos;
        //Debug.Log(script.key_icon.ToString("F6"));
        if (!float.IsNaN(script.key_icon.z))
        {
            this.gameObject.transform.localPosition += script.key_icon;
        }
        //Debug.Log("real = " + this.gameObject.transform.position.ToString("F6") + ", icon = " + script.key_icon.ToString("F6"));
    }
}
