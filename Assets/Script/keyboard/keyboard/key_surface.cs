using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_surface : MonoBehaviour
{
    private int size; //頂点数
    private float vertexDistance = 0.01f; //頂点間の距離
    //private float heightMultiplier = 0.01f;
    public Material material;
    public PhysicMaterial physicMaterial;

    //キー位置
    public int high_point; //キーの段（下から１）
    public int weight_point; //キーの位置（左から１
    private int key_size; //キーの大きさ
    private int key_space; //キー間の大きさ

    //初期座標
    public float x_point;
    public float y_point;
    public float z_point;

    //補間座標
    private float[] dx = new float[128];
    private float[] dy = new float[128];

    //サーバー関係
    public GameObject inputtext;
    private receiver script;

    //指先
    public GameObject Object0;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;
    public GameObject Object7;
    public GameObject basepose;
    public GameObject hands;

    //サイズ補正
    public int plus_x;
    public int plus_y;

    //その他
    private float yp;
    private const int N = 5;
    public Vector3 key_icon = new Vector3(0, 0, 0);
    public int objectNo;

    void Start()
    {
        script = inputtext.GetComponent<receiver>(); //サーバーに接続

        size = script.keyboard_size;
        key_size = script.key_size;
        key_space = script.key_space;
        vertexDistance = script.key_heigh;
        objectNo = script.test_flag;

        if (script.test_flag < 3 && script.dwell_flag == 1)
        {

            //元の姿勢を保存
            script.realobjrot_R = Object0.transform;
            Object7.transform.position = Object0.transform.position;
            //Vector3 rotation180;
            //rotation180.x = 0;
            //rotation180.y = 180;
            //rotation180.z = 0;
            //Object7.transform.localEulerAngles += rotation180;
            script.R_keyboard.transform.position = Object0.transform.position;
            //script.R_keyboard.transform.rotation = Object0.transform.rotation;
            //this.transform.rotation = hands.transform.rotation;
            //Debug.Log("world_rot6-1 = " + Object6.transform.eulerAngles);
            //Debug.Log("world_rot7-1 = " + Object7.transform.eulerAngles);
            //各指先の座標を更新
            Object7.transform.rotation = hands.transform.rotation;
            Object1.transform.position = script.Thumb_position_t;
            Object2.transform.position = script.Index_position_t;
            Object3.transform.position = script.Middle_position_t;
            Object4.transform.position = script.Ring_position_t;
            Object5.transform.position = script.Pinky_position_t;
            Object6.transform.position = hands.transform.position;
            Object6.transform.rotation = hands.transform.rotation;
            //回転
            //Object7.transform.localEulerAngles -= Object6.transform.localEulerAngles;
            //Object7.transform.localEulerAngles += rotation180;
            //Debug.Log("world_rot6-2 = " + Object6.transform.eulerAngles);
            //Debug.Log("world_rot7-2 = " + Object7.transform.eulerAngles);
            //Debug.Log("world_pos1-2 = " + Object1.transform.position);
            ////配置に使用する指先の座標を保存
            script.R_rotation = Object7.transform.eulerAngles;
            script.R_keyboard = hands;
            //Object7.transform.position = Object5.transform.position;
            Object7.transform.rotation = basepose.transform.rotation;
            script.Thumb_position = Object1.transform.position - Object0.transform.position;
            script.Index_position = Object2.transform.position - Object0.transform.position;
            script.Middle_position = Object3.transform.position - Object0.transform.position;
            script.Ring_position = Object4.transform.position - Object0.transform.position;
            script.Pinky_position = Object5.transform.position - Object0.transform.position;
            //Debug.Log("world_rot7-3 = " + Object7.transform.eulerAngles);
            //Debug.Log("world_pos1-3 = " + Object1.transform.position);
            //Debug.Log("world_posbase = " + script.realobjrot_R.position);
            //Debug.Log("world_poshand = " + hands.transform.position);
            //Debug.Log("world_rotbase = " + script.realobjrot_R.eulerAngles);
            //Debug.Log("world_rothand = " + hands.transform.eulerAngles);
            //script.Thumb_position = Object1.transform.position;
            //script.Index_position = Object2.transform.position;
            //script.Middle_position = Object3.transform.position;
            //script.Ring_position = Object4.transform.position;
            //script.Pinky_position = Object5.transform.position;

            // 手順
            // 1.回転を打ち消して，赤が常に垂直になるようにする
            // 2.適当な中心移動を行いながら回転させる
        }

        spoints();

        yp = script.Middle_position.y;

        Vector3[] vertices = new Vector3[size * size];
        int xp3 = ((weight_point - 1) * key_size + (weight_point - 1) * key_space) + (high_point - 1);
        int zp3 = ((high_point - 1) * key_size + (high_point - 1) * key_space);
        key_icon = new Vector3(dx[xp3], -zp3 * vertexDistance + yp, dy[xp3]);

        for (int zp = 0; zp < size; zp++)
        {
            for (int xp = 0; xp < size; xp++)
            {
                vertices[zp * size + xp] = new Vector3(dx[xp3], -zp3 * vertexDistance + yp, dy[xp3]);
                if (float.IsNaN(vertices[zp * size + xp].z))
                {
                    //Debug.Log("Index 0 = " + vertices[zp * size + xp]);
                    vertices[zp * size + xp].z = 0.0f;
                    //Debug.Log("Index 0_fix = " + vertices[zp * size + xp]);
                }
            }
        }

        for (int zp = ((high_point - 1) * key_size + (high_point - 1) * key_space); zp < (high_point * key_size + (high_point - 1) * key_space); zp++) //for (int zp = 0; zp < size - 1; zp++)
        {
            for (int xp = ((weight_point - 1) * key_size + (weight_point - 1) * key_space) + (high_point - 1); xp < (weight_point * key_size + (weight_point - 1) * key_space) + (high_point - 1) + plus_x; xp++) //for (int xp = 0; xp < size - 1; xp++)
            {
                //vertices[zp * size + xp] = new Vector3(xp * vertexDistance, yp + Mathf.Sin(((180 / size) * xp) * Mathf.Deg2Rad) * 0.06f, -zp * vertexDistance);
                //vertices[zp * size + xp] = new Vector3(xp * vertexDistance, 0, -zp * vertexDistance);
                vertices[zp * size + xp] = new Vector3(dx[xp], -zp * vertexDistance + yp, dy[xp]);
                if (float.IsNaN(vertices[zp * size + xp].z))
                {
                    //Debug.Log("Index 0 = " + vertices[zp * size + xp]);
                    vertices[zp * size + xp].z = 0.0f;
                    //Debug.Log("Index 0_fix = " + vertices[zp * size + xp]);
                }
            }
        }

        int triangleIndex = 0;
        int[] triangles = new int[(size - 1) * (size - 1) * 6];
        for (int zp = ((high_point - 1) * key_size + (high_point - 1) * key_space); zp < (high_point * key_size + (high_point - 1) * key_space); zp++) //for (int zp = 0; zp < size - 1; zp++)
        {
            for (int xp = ((weight_point - 1) * key_size + (weight_point - 1) * key_space) + (high_point - 1); xp < (weight_point * key_size + (weight_point - 1) * key_space) + (high_point - 1) + plus_x; xp++) //for (int xp = 0; xp < size - 1; xp++)
            {
                int ap = zp * size + xp;
                int bp = ap + 1;
                int cp = ap + size;
                int dp = cp + 1;

                triangles[triangleIndex] = ap;
                triangles[triangleIndex + 1] = bp;
                triangles[triangleIndex + 2] = cp;

                triangles[triangleIndex + 3] = cp;
                triangles[triangleIndex + 4] = bp;
                triangles[triangleIndex + 5] = dp;

                triangleIndex += 6;
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        //衝突判定の追加
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        if (!meshFilter) meshFilter = gameObject.AddComponent<MeshFilter>();

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (!meshRenderer) meshRenderer = gameObject.AddComponent<MeshRenderer>();

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        if (!meshCollider) meshCollider = gameObject.AddComponent<MeshCollider>();

        meshFilter.mesh = mesh;
        meshRenderer.sharedMaterial = material;
        meshCollider.sharedMesh = mesh;
        meshCollider.sharedMaterial = physicMaterial;
        meshCollider.convex = true;
        meshCollider.isTrigger = true;
        //Debug.Log("OKsurface");
    }
    void Update()
    {
        if(objectNo != 0)
        {
            if(objectNo != script.test_flag)
            {
                Destroy(this.gameObject);
                //this.gameObject.SetActive(false);
            }
        }

        //if(objectNo == 0)
        //{
        //    if(script.test_flag == 2)
        //    {
        //        this.gameObject.SetActive(false);
        //    }
        //}

        if (objectNo != 0)
        {
            if(script.keyboard_active == 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
        private void spoints()
    {
        double[] x = new double[N];
        double[] y = new double[N];

        // 1.5刻みで -4.5～4.5 まで, ７点だけ値をセット
        for (int i = 0; i < N; i++)
        {
            //double d1 = i * 1.5 - 4.5;
            //x[i] = d1;
            //y[i] = f(d1);
        }

        x[0] = script.Thumb_position.x;
        y[0] = script.Thumb_position.z;
        x[1] = script.Index_position.x;
        y[1] = script.Index_position.z;
        x[2] = script.Middle_position.x;
        y[2] = script.Middle_position.z;
        x[3] = script.Ring_position.x;
        y[3] = script.Ring_position.z;
        x[4] = script.Pinky_position.x;
        y[4] = script.Pinky_position.z;

        // ３項方程式の係数の表を作る
        double[] a = new double[N];
        double[] b = new double[N];
        double[] c = new double[N];
        double[] d = new double[N];
        for (int i = 1; i < N - 1; i++)
        {
            a[i] = x[i] - x[i - 1];
            b[i] = 2.0 * (x[i + 1] - x[i - 1]);
            c[i] = x[i + 1] - x[i];
            d[i] = 6.0 * ((y[i + 1] - y[i]) / (x[i + 1] - x[i]) - (y[i] - y[i - 1]) / (x[i] - x[i - 1]));
        }
        // ３項方程式を解く (ト－マス法)
        double[] g = new double[N];
        double[] s = new double[N];
        g[1] = b[1];
        s[1] = d[1];
        for (int i = 2; i < N - 1; i++)
        {
            g[i] = b[i] - a[i] * c[i - 1] / g[i - 1];
            s[i] = d[i] - a[i] * s[i - 1] / g[i - 1];
        }
        double[] z = new double[N];
        z[0] = 0;
        z[N - 1] = 0;
        z[N - 2] = s[N - 2] / g[N - 2];
        for (int i = N - 3; i >= 1; i--)
        {
            z[i] = (s[i] - c[i] * z[i + 1]) / g[i];
        }

        // 0.5刻みで 与えられていない値を補間
        for (int i = 0; i <= size; i++)
        {
            //double d1 = i * 0.5 - 6.0;
            double d1 = (float)x[0] + (Mathf.Abs((float)(x[0] - x[4])) / size * i);
            double d3 = spline(d1, x, y, z);
            //Debug.Log(d1);

            dx[i] = (float)d1;
            dy[i] = (float)d3;


            // 元の関数と比較
            //Debug.Log("d1 = " + d1 + ", d2 = " + d2 + ", d3 = " + d3 + ", d4 = " + (d2 - d3));
            //Console.WriteLine(string.Format("{0,5:F2}\t{1,8:F5}\t{2,8:F5}\t{3,8:F5}", d1, d2, d3, d2 - d3));
        }
    }

    private static double f(double x)
    {
        return x - Mathf.Pow((float)x, 3) / (3 * 2) + Mathf.Pow((float)x, 5) / (5 * 4 * 3 * 2);
    }

    // Spline (スプライン) 補間
    private static double spline(double d, double[] x, double[] y, double[] z)
    {
        // 補間関数値がどの区間にあるか
        int k = -1;
        for (int i = 1; i < N; i++)
        {
            if (d <= x[i])
            {
                k = i - 1;
                break;
            }
        }
        if (k < 0) k = N - 1;

        double d1 = x[k + 1] - d;
        double d2 = d - x[k];
        double d3 = x[k + 1] - x[k];
        return (z[k] * Mathf.Pow((float)d1, 3) + z[k + 1] * Mathf.Pow((float)d2, 3)) / (6.0 * d3)
                  + (y[k] / d3 - z[k] * d3 / 6.0) * d1
                  + (y[k + 1] / d3 - z[k + 1] * d3 / 6.0) * d2;
    }
}

