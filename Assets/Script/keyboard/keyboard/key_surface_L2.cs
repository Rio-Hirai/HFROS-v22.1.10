using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_surface_L2 : MonoBehaviour
{
    private int size; //���_��
    private float vertexDistance = 0.01f; //���_�Ԃ̋���
    //private float heightMultiplier = 0.01f;
    public Material material;
    public PhysicMaterial physicMaterial;

    //�L�[�ʒu
    public int high_point; //�L�[�̒i�i������P�j
    public int weight_point; //�L�[�̈ʒu�i������P
    private int key_size; //�L�[�̑傫��
    private int key_space; //�L�[�Ԃ̑傫��

    //�������W
    public float x_point;
    public float y_point;
    public float z_point;

    //��ԍ��W
    private float[] dx = new float[128];
    private float[] dy = new float[128];

    //�T�[�o�[�֌W
    public GameObject inputtext;
    private receiver script;

    //�w��
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

    //�T�C�Y�␳
    public int plus_x;
    public int plus_y;

    //���̑�
    private float yp;
    private const int N = 5;
    public Vector3 key_icon = new Vector3(0, 0, 0);
    public int objectNo;

    void Start()
    {
        script = inputtext.GetComponent<receiver>(); //�T�[�o�[�ɐڑ�

        size = script.keyboard_size;
        key_size = script.key_size;
        key_space = script.key_space;
        vertexDistance = script.key_heigh;
        objectNo = script.test_flag_L;

        if (script.test_flag_L < 3 && script.dwell_flag == 1)
        {

            //���̎p����ۑ�
            script.realobjrot_L = Object0.transform;
            Object7.transform.position = Object0.transform.position;
            script.L_keyboard.transform.position = Object0.transform.position;
            //�e�w��̍��W���X�V
            Object7.transform.rotation = hands.transform.rotation;
            Object1.transform.position = script.L_Thumb_position_t;
            Object2.transform.position = script.L_Index_position_t;
            Object3.transform.position = script.L_Middle_position_t;
            Object4.transform.position = script.L_Ring_position_t;
            Object5.transform.position = script.L_Pinky_position_t;
            Object6.transform.position = hands.transform.position;
            Object6.transform.rotation = hands.transform.rotation;
            //��]
            Object7.transform.localEulerAngles -= Object6.transform.localEulerAngles;
            ////�z�u�Ɏg�p����w��̍��W��ۑ�
            script.L_keyboard = hands;
            Object7.transform.rotation = basepose.transform.rotation;
            script.L_Thumb_position = Object1.transform.position - Object0.transform.position;
            script.L_Index_position = Object2.transform.position - Object0.transform.position;
            script.L_Middle_position = Object3.transform.position - Object0.transform.position;
            script.L_Ring_position = Object4.transform.position - Object0.transform.position;
            script.L_Pinky_position = Object5.transform.position - Object0.transform.position;

            // �菇
            // 1.��]��ł������āC�Ԃ���ɐ����ɂȂ�悤�ɂ���
            // 2.�K���Ȓ��S�ړ����s���Ȃ����]������
        }

        spoints();

        yp = script.L_Middle_position.y;

        Vector3[] vertices = new Vector3[size * size];
        for (int zp = 0; zp < size; zp++)
        {
            for (int xp = 0; xp < size; xp++)
            {
                vertices[zp * size + xp] = new Vector3(dx[xp], -zp * vertexDistance + yp, dy[xp]);
                if (float.IsNaN(vertices[zp * size + xp].z))
                {
                    vertices[zp * size + xp].z = 0.0f;
                }
            }
        }

        int triangleIndex = 0;
        int[] triangles = new int[(size - 1) * (size - 1) * 6];
        for (int zp = 0; zp < size - 1; zp++)
        {
            for (int xp = 0; xp < size - 1; xp++)
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

        //�Փ˔���̒ǉ�
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        if (!meshFilter) meshFilter = gameObject.AddComponent<MeshFilter>();

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (!meshRenderer) meshRenderer = gameObject.AddComponent<MeshRenderer>();

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        if (!meshCollider) meshCollider = gameObject.AddComponent<MeshCollider>();

        //meshFilter.mesh = mesh;
        //meshRenderer.sharedMaterial = material;
        meshCollider.sharedMesh = mesh;
        meshCollider.sharedMaterial = physicMaterial;
        meshCollider.convex = true;
        meshCollider.isTrigger = true;
        //Debug.Log("OKsurface");
    }
    void Update()
    {
        if (objectNo != 0)
        {
            if (objectNo != script.test_flag_L)
            {
                Destroy(this.gameObject);
                //this.gameObject.SetActive(false);
            }
        }

        //if (objectNo == 0)
        //{
        //    if (script.test_flag_L == 2)
        //    {
        //        this.gameObject.SetActive(false);
        //    }
        //}

        if (objectNo != 0)
        {
            if (script.keyboard_active == 1)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void spoints()
    {
        double[] x = new double[N];
        double[] y = new double[N];

        // 1.5���݂� -4.5�`4.5 �܂�, �V�_�����l���Z�b�g
        for (int i = 0; i < N; i++)
        {
            //double d1 = i * 1.5 - 4.5;
            //x[i] = d1;
            //y[i] = f(d1);
        }

        x[4] = script.L_Thumb_position.x;
        y[4] = script.L_Thumb_position.z;
        x[3] = script.L_Index_position.x;
        y[3] = script.L_Index_position.z;
        x[2] = script.L_Middle_position.x;
        y[2] = script.L_Middle_position.z;
        x[1] = script.L_Ring_position.x;
        y[1] = script.L_Ring_position.z;
        x[0] = script.L_Pinky_position.x;
        y[0] = script.L_Pinky_position.z;

        // �R���������̌W���̕\�����
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
        // �R�������������� (�g�|�}�X�@)
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

        // 0.5���݂� �^�����Ă��Ȃ��l����
        for (int i = 0; i <= size; i++)
        {
            //double d1 = i * 0.5 - 6.0;
            double d1 = (float)x[0] + (Mathf.Abs((float)(x[0] - x[4])) / size * i);
            double d3 = spline(d1, x, y, z);
            //Debug.Log(d1);

            dx[i] = (float)d1;
            dy[i] = (float)d3;


            // ���̊֐��Ɣ�r
            //Debug.Log("d1 = " + d1 + ", d2 = " + d2 + ", d3 = " + d3 + ", d4 = " + (d2 - d3));
            //Console.WriteLine(string.Format("{0,5:F2}\t{1,8:F5}\t{2,8:F5}\t{3,8:F5}", d1, d2, d3, d2 - d3));
        }
    }

    private static double f(double x)
    {
        return x - Mathf.Pow((float)x, 3) / (3 * 2) + Mathf.Pow((float)x, 5) / (5 * 4 * 3 * 2);
    }

    // Spline (�X�v���C��) ���
    private static double spline(double d, double[] x, double[] y, double[] z)
    {
        // ��Ԋ֐��l���ǂ̋�Ԃɂ��邩
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

    private void OnTriggerEnter(Collider collider)
    {
        //if (collider.gameObject.name == "Hand_Index3_CapsuleCollider") //�l�����w�ƐڐG�����ꍇ
        //{
        //    if (script.release_flag == 0) //������̃L�[��������Ă��Ȃ��ꍇ
        //    {
        //        //renderer = this.gameObject.GetComponent<Renderer>();
        //        //renderer.material.color = Color.red; //�L�[��ԐF�ɂ���
        //    }
        //    script.release_flag = 1; //�ڐG�t���O�𗧂Ă�
        //}
    }
    private void OnTriggerStay(Collider collider)
    {
        //if (!(collider.gameObject.name == "Index" || collider.gameObject.name == "Hand_Index3_CapsuleCollider"))
        //{
        //    script.release_flag = 1;
        //    script.key_white_flag = 0;
        //}
        //else if (collider.gameObject.name == "Index")
        //{
        //    script.key_white_flag = 1;
        //    script.release_flag_t = 0;
        //}
        //else
        //{

        //}
        //Debug.Log("stay_OK:" + collider.gameObject.name);

        if (collider.gameObject.name == "Hand_Index2_CapsuleCollider" || collider.gameObject.name == "Hand_Index1_CapsuleCollider" || collider.gameObject.name == "Hand_Index0_CapsuleCollider")
        {
            script.release_flag = 1;
            script.key_white_flag = 0;
        }
        else if (collider.gameObject.name == "Index")
        {
            script.key_white_flag = 1;
            script.release_flag_t = 0;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Index") //�l�����w�ƐڐG���������ꂽ�ꍇ
        {
            if (script.key_white_flag == 1)
            {
                script.colorrenderer.material.color = Color.white;
                script.key_white_flag = 0;
                script.release_flag = 0;
            }
            else
            {
                script.release_flag_t = 1;
            }
        }

        //if (collider.gameObject.name == "Hand_Index3_CapsuleCollider")
        //{
        //    if (script.release_flag_t == 1)
        //    {
        //        script.colorrenderer.material.color = Color.white;
        //        script.key_white_flag = 0;
        //        script.release_flag = 0;
        //        script.release_flag_t = 0 ;
        //    }
        //}
    }
}

