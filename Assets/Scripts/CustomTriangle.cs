using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CustomTriangle : MonoBehaviour
{
    public float sideLength = 2f;
    public float angleDegress = 100f;
    private static readonly int ANGLE_DEGREE_PRECISION = 1000;
    private static readonly int SIDE_LENGTH_PRECISION = 1000;
    private MeshFilter meshFilter;
    private TriangleMeshCreator creator = new TriangleMeshCreator();

    // Start is called before the first frame update
    void Start()
    {
        TriangleWithoutTexture();
        //TriangleWithTexture();
    }

    private void TriangleWithoutTexture()
    {
        MeshFilter meshfilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, 0, 1);
        vertices[2] = new Vector3(1, 0, 0);
        int[] tris = new int[3];
        tris[0] = 0; tris[1] = 1; tris[2] = 2;
        Vector2[] uvs = new Vector2[vertices.Length];
        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = Vector2.zero;
        }
        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.uv = uvs;
        meshfilter.mesh = mesh;

    }
    private void TriangleWithTexture()
    {
        meshFilter = GetComponent<MeshFilter>();

    }

    private class TriangleMeshCreator
    {
        
    }


   



}
