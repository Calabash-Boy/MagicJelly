using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatMesh : MonoBehaviour
{
    private MeshFilter filter;
    private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;

        InitMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitMesh()
    {
        mesh.name = "MyMesh";
        Vector3[] vertices = {
            new Vector3(1, 1, 0),
            new Vector3(-1, 1, 0),
            new Vector3(1, -1, 0),
            new Vector3(-1, -1, 0)
        };

        mesh.vertices = vertices;

        //有了这些顶点 还必须设置顶点连接的顺序 创建成为三角形
        int[] triangles = { 0, 3, 1, 0, 2, 3 };
        mesh.triangles = triangles;

        Vector2[] uv = {
            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0)
        };

        mesh.uv = uv;
    }
}
