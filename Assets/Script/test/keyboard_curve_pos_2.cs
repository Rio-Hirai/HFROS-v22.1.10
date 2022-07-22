using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_curve_pos_2 : MonoBehaviour
{
    //private Renderer renderer;
    //private Renderer dwell_renderer;
    //private int flag = 0;
    private int count;
    //private int touch_timecount = 0; //�ǐڐG���m�p�̃J�E���g
    //private int touch_timecount2 = 0; //�ǐڐG���m�p�̃J�E���g2
    //private int leave_timecount = 0; //�Ǘ��E���m�p�̃J�E���g
    //private int keyset_interval = 0;
    public int keyboard_amount;
    public GameObject ObjectB;
    public GameObject ObjectC;
    public GameObject SightObject;
    public Vector3 realobjpos;
    public Vector3 realobjrot;
    private sight dwell_script;
    private float timeleft;
    private int pinch_flag;
    private Vector3 oldpos;
    //private Vector3 oldrot;
    private Vector3 firsttouch;
    private Vector3 firsttouchrot;

    [Range(1, 255)]
    public int size; //���_��
    public float vertexDistance = 1f; //���_�Ԃ̋���
    public float heightMultiplier = 1f;
    public Material material;
    public PhysicMaterial physicMaterial;

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

    //���̑�
    private float yp = 0.04f;
    private const int N = 5;
    // Start is called before the first frame update
    void Start()
    {
        // receiver���擾
        //renderer = this.gameObject.GetComponent<Renderer>();
        script = ObjectB.GetComponent<receiver>();
        // dwell�preceiver���擾
        //dwell_renderer = this.gameObject.GetComponent<Renderer>();
        dwell_script = SightObject.GetComponent<sight>();
        /*
        Transform myTransform = this.transform;
        realobjpos = myTransform.position;
        */
        Transform myTransform = this.transform;
        oldpos = myTransform.position;
        //script.keyboard_amount = keyboard_amount;
        Debug.Log(script.keyboard_amount);
        //oldrot = myTransform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        // �ʒu�擾
        Transform myTransform = this.transform;
        Vector3 objpos = myTransform.position;
        Vector3 objrot = myTransform.eulerAngles;

        // �o�ߎ��Ԃ��v��
        timeleft -= Time.deltaTime;

        if (timeleft <= -3.0f && script.test_flag < 3)
        {
            Curve();

            myTransform.position = script.R_keyboard.transform.position;
            myTransform.rotation = script.R_keyboard.transform.rotation;

            // �L�[�{�[�h����
            Debug.Log("mode5 : " + script.righthand.transform.eulerAngles);
            Instantiate(ObjectC, myTransform.position, myTransform.rotation);
            script.keyboard_amount -= 1;
            // ���Z�b�g
            //count = 0;
            timeleft = 2.0f;
            script.Index_flag = 0;
            script.Middle_flag = 0;
            script.test_flag += 1;
            // �C���^�\�o��
            script.flick_interval_flag = 1;
            script.repos_flag = 1;
            Invoke("input_interval", 0.8f);
        }
    }

    private void input_interval()
    {
        //Debug.Log("flagoff");
        script.flick_interval_flag = 0;
    }

    void Curve()
    {
        script = inputtext.GetComponent<receiver>(); //�T�[�o�[�ɐڑ�

        if (script.test_flag < 3)
        {
            //���̎p����ۑ�
            script.realobjrot_R = Object0.transform;
            Object7.transform.position = Object0.transform.position;
            script.R_keyboard.transform.position = Object0.transform.position;
            //�e�w��̍��W���X�V
            Object7.transform.rotation = hands.transform.rotation;
            Object1.transform.position = script.Thumb_position_t;
            Object2.transform.position = script.Index_position_t;
            Object3.transform.position = script.Middle_position_t;
            Object4.transform.position = script.Ring_position_t;
            Object5.transform.position = script.Pinky_position_t;
            Object6.transform.position = hands.transform.position;
            Object6.transform.rotation = hands.transform.rotation;
            ////�z�u�Ɏg�p����w��̍��W��ۑ�
            script.R_rotation = Object7.transform.eulerAngles;
            script.R_keyboard = hands;
            Object7.transform.rotation = basepose.transform.rotation;
            script.Thumb_position = Object1.transform.position - Object0.transform.position;
            script.Index_position = Object2.transform.position - Object0.transform.position;
            script.Middle_position = Object3.transform.position - Object0.transform.position;
            script.Ring_position = Object4.transform.position - Object0.transform.position;
            script.Pinky_position = Object5.transform.position - Object0.transform.position;
        }

        spoints();

        yp = script.Middle_position.y;

        for (int zp = 0; zp < size; zp++)
        {
            for (int xp = 0; xp < size; xp++)
            {
                script.vertices_r[zp * size + xp] = new Vector3(dx[xp], -zp * vertexDistance + yp, dy[xp]);
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
