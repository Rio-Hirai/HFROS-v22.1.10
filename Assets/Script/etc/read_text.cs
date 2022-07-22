using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class read_text : MonoBehaviour
{
    public string[] textMessage; //テキストの加工前の一行を入れる変数
    public string[,] textWords; //テキストの複数列を入れる2次元は配列

    //private int rowLength; //テキスト内の行数を取得する変数
    private int columnLength; //テキスト内の列数を取得する変数
    private int start = 1;
    private int cnt = 0;
    //private int[] text_amount = new int[50];

    //サーバー関係
    public GameObject ObjectB;
    private receiver script;

    List<int> numbers = new List<int>();

    private void Start()
    {
        script = ObjectB.GetComponent<receiver>(); //サーバーに接続
        int[] text_amount = new int[script.input_text_size];

        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load(script.textfile_name, typeof(TextAsset)) as TextAsset; //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる

        //Splitで一行づつを代入した1次配列を作成
        textMessage = TextLines.Split('\n'); //

        //行数と列数を取得
        columnLength = textMessage[0].Split('\t').Length;

        //2次配列を定義
        textWords = new string[script.input_text_size, columnLength];
        script.Test_phrase = new string[script.input_text_size];
        script.Input_phrase = new string[script.input_text_size];

        //乱数を生成１（範囲内の数値をリストに入れる）
        for (int i = start; i <= script.dataset_text_size; i++)
        {
            numbers.Add(i);
            //Debug.Log("script.dataset_text_size");
        }
        //Debug.Log("script.dataset_text_size = " + script.dataset_text_size);
        //Debug.Log("numbers.Count = " + numbers.Count);
        //乱数を生成２（リストからランダムで数値を取り出し、取り出した数値は削除する）
        while (numbers.Count > 0 && cnt < script.input_text_size)
        {
            int index = Random.Range(0, numbers.Count);

            //int ransu = numbers[index];
            text_amount[cnt++] = numbers[index];
            //Debug.Log(cnt+"text_amount[cnt] = " + text_amount[cnt-1]);

            numbers.RemoveAt(index);
        }

        for (int i = 0; i < script.input_text_size; i++)
        {

            string[] tempWords = textMessage[text_amount[i]].Split('\t'); //textMessageをカンマごとに分けたものを一時的にtempWordsに代入
            //Debug.Log(i+"text_amount = " + text_amount[i]);

            for (int n = 0; n < columnLength; n++)
            {
                textWords[i, n] = tempWords[n]; //2次配列textWordsにカンマごとに分けたtempWordsを代入していく
                script.Test_phrase[i] = tempWords[n];
                //Debug.Log(script.Test_phrase[i]);
            }
        }

        //script.derayStart();
    }
}
