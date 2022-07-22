using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phrase_text : MonoBehaviour
{
    public string input;
    public GameObject ObjectB;
    public string StandByMessage = "Press detect to lock the keyboard";
    public string StandByMessage2 = "Press Enter-key when you're ready";
    private receiver script;
    // Start is called before the first frame update
    void Start()
    {
        script = ObjectB.GetComponent<receiver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.input_rest == 0)
        {
            if(script.input_ready == 0)
            {
                GetComponent<TextMesh>().text = StandByMessage;
            } else if(script.input_ready == 1)
            {
                GetComponent<TextMesh>().text = StandByMessage2;
            } else
            {
                GetComponent<TextMesh>().text = script.Test_phrase[script.input_text_num];
                if (!script.Test_phrase[script.input_text_num].Contains(script.input))
                {
                    GetComponent<TextMesh>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                }
                else
                {
                    GetComponent<TextMesh>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                }
            }
        } else
        {
            GetComponent<TextMesh>().text = "Next Phrase (Please Push Enter)";
        }

    }
}
