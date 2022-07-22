using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class inputmanage : MonoBehaviour
{
    public GameObject score_object = null;
    public GameObject textsource = null;
    public string input_text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        input_text = textsource.GetComponent<receiver>().input;
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = input_text;
    }
}
