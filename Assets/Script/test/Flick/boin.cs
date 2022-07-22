using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boin : MonoBehaviour
{
    private Renderer obj_renderer;
    private int flag;
    public string input;
    public GameObject ObjectB;
    private receiver script;
    // Start is called before the first frame update
    void Start()
    {
        obj_renderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = script.boin;
    }
}
