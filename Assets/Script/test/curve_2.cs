using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curve_2 : MonoBehaviour
{
    [Range(1, 255)]
    public int size; //頂点数
    public float vertexDistance = 1f; //頂点間の距離
    public float heightMultiplier = 1f;
    public Material material;
    public PhysicMaterial physicMaterial;

    //補間座標
    private float[] dx = new float[128];
    private float[] dy = new float[128];

    //サーバー関係
    public GameObject inputtext;
    private receiver script;

    //その他
    //private float yp = 0.04f;
    //private const int N = 5;

    void Start()
    {
        script = inputtext.GetComponent<receiver>(); //サーバーに接続

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
        mesh.vertices = script.vertices_r;
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
    }
}
