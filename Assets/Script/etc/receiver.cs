using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class receiver : MonoBehaviour
{
    //実験条件
    public string textfile_name = "c_set_original_880";
    public string user_ID = "0";
    public string user_name = "null";
    public enum test_type
    {
        mid_air,
        wall,
        wall_air,
        table,
        table_air,
        thigh,
        thigh_air
    }
    public test_type user_test_type = test_type.mid_air;
    public int input_text_size = 30;
    public int dataset_text_size = 700;
    //データ取得用
    public int input_amount;
    public int back_amount;
    public string[] Test_phrase = new string[128];
    public string[] Input_phrase = new string[128];
    public string[] Input_phrase_Log = new string[128];
    public string[] midstart_time = new string[128];
    public string[] midend_time = new string[128];
    public DateTime input_start_time;
    public DateTime[] input_midstart_time = new DateTime[128];
    public DateTime[] input_midend_time = new DateTime[128];
    public DateTime input_end_time;
    private TimeSpan[] timed;
    private TimeSpan totaltime;
    //キーボードステータス
    public int keyboard_size; //キーボード全体の大きさ
    public int key_size; //キーの大きさ
    public int key_space; //キー間の大きさ
    public float key_heigh; //キーの高さ
    public int keyboard_active;
    public int keyboard_set_active;
    // テスト文関係
    public int input_text_num = 0;
    //テスト用文字列
    public string input = "(Please input)";
    public string tmp_input_keys;
    public string input_keys;
    public string input_Log = "(input_Log)";
    public string boin = "あ";
    // フリック入力用フラグ
    public int flick_flag;
    public int flick_center_flag;
    public int flick_side_flag;
    public int flick_interval_flag;
    public int keypos_interval_flag;
    public int test_flag = 0;
    public int test_flag_L = 0;
    // ピンチ動作フラグ
    public int Index_flag;
    public int Middle_flag;
    public int Middle_pinch_states;
    public int Index_flag_L;
    public int Middle_flag_L;
    // 注視フラグ
    public int dwell_flag;
    // 手の座標関係
    public GameObject lefthand = null;
    public GameObject righthand = null;
    public Vector3 L_position;
    public Vector3 L_rotation;
    public Vector3 R_position;
    public Vector3 R_rotation;
    public int repos_flag = 0;
    public int keyboard_amount;
    public Vector3[] vertices_r = new Vector3[128 * 128];
    public Vector3[] vertices_l = new Vector3[128 * 128];
    // 右指の座標
    public Vector3 Thumb_position;
    public Vector3 Index_position;
    public Vector3 Middle_position;
    public Vector3 Ring_position;
    public Vector3 Pinky_position;
    public Vector3 Thumb_position_t;
    public Vector3 Index_position_t;
    public Vector3 Middle_position_t;
    public Vector3 Ring_position_t;
    public Vector3 Pinky_position_t;
    public Transform realobjrot_R;
    public GameObject R_keyboard;
    public GameObject Index_R;
    public GameObject Thumb_R;
    public GameObject Middle_R;
    public GameObject Ring_R;
    public GameObject Pinky_R;
    public GameObject Index_R_sub;
    // 左指の座標
    public Vector3 L_Thumb_position;
    public Vector3 L_Index_position;
    public Vector3 L_Middle_position;
    public Vector3 L_Ring_position;
    public Vector3 L_Pinky_position;
    public Vector3 L_Thumb_position_t;
    public Vector3 L_Index_position_t;
    public Vector3 L_Middle_position_t;
    public Vector3 L_Ring_position_t;
    public Vector3 L_Pinky_position_t;
    public Transform realobjrot_L;
    public GameObject L_keyboard;
    public GameObject Index_L;
    public GameObject Thumb_L;
    public GameObject Middle_L;
    public GameObject Ring_L;
    public GameObject Pinky_L;
    //入力フラグ
    public int input_start;
    public int input_rest; //1で休憩フラグ
    public int input_ready; //キーボードを固定したら1で入力開始可能状態にする
    public string before_char;
    public int release_flag;
    public int release_flag_t;
    public int key_white_flag;
    public Renderer colorrenderer;
    public int output_flag;

    // その他
    public int point_flag;
    public int points_cnt = 0;

    public bool thumb_R_flag;
    public bool thumb_L_flag;
    public bool delete_flag;

    // newpoints関係
    public bool R_point_on;
    public GameObject Index_R_point;
    public GameObject Thumb_R_point;
    public GameObject Middle_R_point;
    public GameObject Ring_R_point;
    public GameObject Pinky_R_point;
    public bool L_point_on;
    public GameObject Index_L_point;
    public GameObject Thumb_L_point;
    public GameObject Middle_L_point;
    public GameObject Ring_L_point;
    public GameObject Pinky_L_point;
    public float newkey_interval;

    //HMPW関係
    public float hmpw_right_hand;
    public float hmpw_right_finger;
    public float hmpw_left_hand;
    public float hmpw_left_finger;

    public Vector3 hmpw_right_hand_tmp;
    public Vector3 hmpw_right_finger_tmp;
    public Vector3 hmpw_left_hand_tmp;
    public Vector3 hmpw_left_finger_tmp;

    public GameObject rightfinger;
    public GameObject leftfinger;

    // コーパス関係
    private TextAsset csvFile;  // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 0; // CSVの行数
    public string filename = "unigram_freq";
    public string[] wordlist = new string[10];
    public int cont = 0;
    public int cursor = 0;
    public int space_pos;
    public bool firstflag = true;
    private int[] word_num = new int[40];

    public GameObject candidate;

    public string input_word;
    public string input_sentence_tmp;
    public string input_sentence;
    //public string input_numlog;

    public GameObject flickonj1;
    public GameObject flickonj2;
    public bool I_pinch_flag;

    void Start()
    {
        csvFile = Resources.Load("CSV/" + filename) as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(csvFile.text);
        int i = 0;

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる
            height++; // 行数加算

            if (i < csvDatas[height - 1][1].Length)
            {
                word_num[i] = height;
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        input = "speed" + Index_R.GetComponent<Valve.VR.InteractionSystem.VelocityEstimator>().GetVelocityEstimate();
        //if (I_pinch_flag == true && input_ready == 1)
        //{
        //    if (flickonj1.activeSelf == false)
        //    {
        //        flickonj1.SetActive(true);
        //        flickonj1.transform.position = Index_R.transform.position;
        //        flickonj1.transform.rotation = Index_R.transform.rotation;
        //        Vector3 worldAngle = flickonj1.transform.eulerAngles;
        //        worldAngle.y += 90;
        //        flickonj1.transform.eulerAngles = worldAngle;
        //    }
        //    flickonj1.SetActive(true);
        //    flickonj2.SetActive(true);
        //} else
        //{
        //    flickonj1.SetActive(false);
        //    flickonj2.SetActive(false);
        //}

        L_position = righthand.transform.position;
        L_rotation = righthand.transform.eulerAngles;
        //Index_R.transform.position = Index_position_t;
        /*
        Debug.Log("hand.pos = " + L_position);
        Debug.Log("hand.rot = " + L_rotation);
        */
        //Debug.Log("release_flag = " + release_flag);

        // HMPW取得
        Vector3 rh = righthand.transform.position - hmpw_right_hand_tmp;
        hmpw_right_hand += rh.magnitude;
        hmpw_right_hand_tmp = righthand.transform.position;

        Vector3 rf = rightfinger.transform.position - hmpw_right_finger_tmp;
        hmpw_right_finger += rf.magnitude;
        hmpw_right_finger_tmp = rightfinger.transform.position;

        //Debug.Log("rh = " + hmpw_right_hand);
        //Debug.Log("rf = " + hmpw_right_finger);

        Vector3 lh = lefthand.transform.position - hmpw_left_hand_tmp;
        hmpw_left_hand += lh.magnitude;
        hmpw_left_hand_tmp = lefthand.transform.position;

        Vector3 lf = leftfinger.transform.position - hmpw_left_finger_tmp;
        hmpw_left_finger += lf.magnitude;
        hmpw_left_finger_tmp = leftfinger.transform.position;
    }
    public void derayStart()
    {
        Debug.Log("deta_input!!");
        //ファイル名作成
        string filePath = Application.dataPath + "/Script/results/" + user_ID + "_" + user_name + "_" + user_test_type + "_" + input_start_time.Day + "." + input_start_time.Hour + "." + input_start_time.Minute + "." + input_start_time.Second + "." + input_start_time.Millisecond + ".txt";

        //ファイル生成
        StreamWriter streamWriter = File.AppendText(filePath);
        streamWriter.WriteLine("-----------------------------------------------------------------------------------------\n");
        streamWriter.WriteLine("test_text_" + input_text_size + ": \n");
        for (int i = 0; i < input_text_size; i++)
        {
            streamWriter.WriteLine(Test_phrase[i]);
        }
        streamWriter.WriteLine("------------\n");

        //入力文を追記
        streamWriter.WriteLine("\ntest_text : input_text\n");
        for (int i = 0; i < input_text_size; i++)
        {
            streamWriter.WriteLine(Test_phrase[i]);
            streamWriter.WriteLine(Input_phrase[i]);
            streamWriter.WriteLine(Input_phrase_Log[i]);
            streamWriter.WriteLine("input_start = " + input_midstart_time[i] + ":" + input_midstart_time[i].Millisecond);
            //Debug.Log("input_start " + i + " = " + input_midstart_time[i] + ":" + input_midstart_time[i].Millisecond);
            streamWriter.WriteLine("input_end = " + input_midend_time[i] + ":" + input_midend_time[i].Millisecond);
            //Debug.Log("input_end "+ i + " = " + input_midend_time[i] + ":" + input_midend_time[i].Millisecond);
            timed[i] = input_midend_time[i] - input_midstart_time[i];
            streamWriter.WriteLine("Time_Span = " + timed[i].ToString("g") + "\n");
            streamWriter.WriteLine("\n");
            totaltime += timed[i];
        }
        streamWriter.WriteLine("------------\n");
        //入力数を追記
        streamWriter.WriteLine("\ninput_chara = " + input_amount + "\n");
        //バックスペース回数を追記
        streamWriter.WriteLine("input_backspace = " + back_amount + "\n");
        //タイムスタンプ
        streamWriter.WriteLine("input_totalstart = " + input_start_time + ":" + input_start_time.Millisecond + "\n");
        input_end_time = DateTime.Now;
        streamWriter.WriteLine("input_totalend = " + input_end_time + ":" + input_end_time.Millisecond + "\n");
        streamWriter.WriteLine("input_totaltime = " + totaltime + "\n");
        //HMPWを追記
        streamWriter.WriteLine("\nhmpw_right_hand = " + hmpw_right_hand + "\n");
        streamWriter.WriteLine("hmpw_right_finger = " + hmpw_right_finger + "\n");
        streamWriter.WriteLine("hmpw_left_hand = " + hmpw_left_hand + "\n");
        streamWriter.WriteLine("hmpw_left_finger = " + hmpw_left_finger + "\n");
        //Debug.Log("input_timer_end");
        //Debug.Log("input_timer_end = " + input_end_time + ":" + input_end_time.Millisecond + "\n");
        //後処理
        streamWriter.Flush();
        streamWriter.Close();
        output_flag = 1;
    }

    public void yosoku()
    {
        if (before_char == "9")
        {
            if (input_keys.Length > 0)
            {
                input_keys = input_keys.Substring(0, input_keys.Length - 1);
            }
            else if (input_keys.Length == 0 && input_sentence_tmp.Length > 0)
            {
                input_sentence_tmp = input_sentence_tmp.Substring(0, space_pos + 1);
                if (input_sentence_tmp.Length == 1)
                {
                    input_sentence_tmp = "";
                    //firstflag = true;
                }
            }
            cursor = 0;
        }

        if (before_char == "0")
        {
            input_keys = "";
            input_sentence_tmp = input_sentence + "_";
            cursor = 0;
        }

        cont = 0;
        Array.Clear(wordlist, 0, wordlist.Length);
        int input_num = input_keys.Length;

        if (input_num != 0)
        {
            for (int i = word_num[input_num - 1] - 1; i < word_num[input_num]; i++)
            {
                if (csvDatas[i][1].StartsWith(input_keys))
                {
                    wordlist[cont] = csvDatas[i][0];
                    cont++;
                    if (cont > wordlist.Length - 1)
                    {
                        break;
                    }
                }
            }
        }

        if (cont == 0 && input_keys.Length != 0)
        {
            wordlist[cont] = input_word;
        }

        // 入力処理
        input_word = wordlist[cursor];
        input_sentence = input_sentence_tmp + input_word;

        // 削除用処理
        space_pos = space_num(input_sentence_tmp);

        // 出力
        input = input_sentence;
        candidate.GetComponent<TextMesh>().text = "";
        for (int i = 0; i < cont; i++)
        {
            candidate.GetComponent<TextMesh>().text += (i + 1) + ". " + wordlist[i] + "\n";
        }
    }

    // 削除処理用の関数
    private static int space_num(string input_sentence)
    {
        string space_char = " ";
        int num = 0;
        int num_tmp = 0;

        if (input_sentence != null && input_sentence.Length > 0)
        {
            num = input_sentence.Substring(0, input_sentence.Length - 1).IndexOf("_");
        }

        while (num > 0)
        {
            num_tmp = num;
            if (input_sentence.Length > 0 && input_sentence.Length > num + 1)
            {
                num = input_sentence.Substring(0, input_sentence.Length - 1).IndexOf(space_char, num + 1);
            }
            else
            {
                num = -1;
            }
        }

        num = num_tmp;

        return num;
    }
}
