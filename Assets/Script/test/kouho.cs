using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kouho : MonoBehaviour
{
    private Renderer ThisRenderer;
    private int flag;
    public string input;
    public GameObject ObjectB;
    private receiver script;
    // Start is called before the first frame update
    void Start()
    {
        ThisRenderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = "";
        for (int i = 0; i < 10; i++)
        {
            GetComponent<TextMesh>().text += script.wordlist[i] + "\n";
        }
    }
}

