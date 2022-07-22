using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_surface_test : MonoBehaviour
{
    public int size = 4; //���_��
    public float vertexDistance = 0.333f; //���_�Ԃ̋���
    public float heightMultiplier = 0.333f;
    public Material material;
    public PhysicMaterial physicMaterial;

    //�L�[�ʒu
    public int high_point; //�L�[�̒i�i������P�j
    public int weight_point; //�L�[�̈ʒu�i������P
    public int key_size; //�L�[�̑傫��
    public int key_space; //�L�[�Ԃ̑傫��

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

    //�������_
    public int left_x;
    public int left_y;

    //���̑�
    private float yp;
    private const int N = 5;

    void Start()
    {
        script = inputtext.GetComponent<receiver>(); //�T�[�o�[�ɐڑ�


        spoints();

        Vector3[] vertices = new Vector3[size * size];
        int xp3 = ((weight_point - 1) * key_size + (weight_point - 1) * key_space) + (key_size - 1);
        int zp3 = ((high_point - 1) * key_size + (high_point - 1) * key_space) + (key_size - 1);

        for (int zp = 0; zp < size; zp++)
        {
            for (int xp = 0; xp < size; xp++)
            {
                vertices[zp * size + xp] = new Vector3(xp3 * vertexDistance, yp + Mathf.Sin(((180 / size) * xp3) * Mathf.Deg2Rad) * 0.06f, -zp3 * vertexDistance);
            }
        }

        for (int zp = ((high_point - 1) * key_size + (high_point - 1) * key_space); zp < (high_point * key_size + (high_point - 1) * key_space); zp++) //for (int zp = 0; zp < size - 1; zp++)
        {
            for (int xp = ((weight_point - 1) * key_size + (weight_point - 1) * key_space); xp < (weight_point * key_size + (weight_point - 1) * key_space); xp++) //for (int xp = 0; xp < size - 1; xp++)
            {
                vertices[zp * size + xp] = new Vector3(xp * vertexDistance, yp + Mathf.Sin(((180 / size) * xp) * Mathf.Deg2Rad) * 0.06f, -zp * vertexDistance);
            }
        }

        int triangleIndex = 0;
        int[] triangles = new int[(size - 1) * (size - 1) * 6];

        for (int zp = ((high_point - 1) * key_size + (high_point - 1) * key_space); zp < (high_point * key_size + (high_point - 1) * key_space); zp++) //for (int zp = 0; zp < size - 1; zp++)
        {
            for (int xp = ((weight_point - 1) * key_size + (weight_point - 1) * key_space); xp < (weight_point * key_size + (weight_point - 1) * key_space); xp++) //for (int xp = 0; xp < size - 1; xp++)
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

        meshFilter.mesh = mesh;
        meshRenderer.sharedMaterial = material;
        meshCollider.sharedMesh = mesh;
        meshCollider.sharedMaterial = physicMaterial;
        meshCollider.convex = true;
        meshCollider.isTrigger = true;
        Debug.Log("OKsurface");
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

        x[0] = script.Thumb_position.x;
        y[0] = script.Thumb_position.y;
        x[1] = script.Index_position.x;
        y[1] = script.Index_position.y;
        x[2] = script.Middle_position.x;
        y[2] = script.Middle_position.y;
        x[3] = script.Ring_position.x;
        y[3] = script.Ring_position.y;
        x[4] = script.Pinky_position.x;
        y[4] = script.Pinky_position.y;

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
}

