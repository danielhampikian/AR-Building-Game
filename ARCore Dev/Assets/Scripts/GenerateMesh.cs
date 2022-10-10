using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class GenerateMesh : MonoBehaviour
{

    Mesh mesh;
    public Material buildingMaterial;

    Vector3[] vertices;
    int[] triangles;

    public GameObject meshManager;

    private float y;
    private float x = 1f;
    private float z = 1f;

    private float randSizeFactor;
    private float scaleFactorY = 1f;

    private float tempMin;
    private float tempMax;

    // Start is called before the first frame update
    void Start()
    {
        randSizeFactor = Random.Range(1f, 1.2f);
        meshManager = GameObject.Find("Room");
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }



    void CreateShape () {
        vertices = new Vector3[] {
            new Vector3 (0,0,0),
            new Vector3 (0,0,z),
            new Vector3 (x,0,z),
            new Vector3 (x,0,0),
            new Vector3 (0, y * scaleFactorY ,0),
            new Vector3 (0, y * scaleFactorY ,z),
            new Vector3 (x, y * scaleFactorY ,z),
            new Vector3 (x, y * scaleFactorY ,0)  
        };

        triangles = new int[] {
            4,5,7, //Top
            7,5,6,
            1,2,6, //s1
            1,6,5,
            2,3,6, //s2
            6,3,7,
            3,0,4, //s3
            3,4,7,
            0,1,5, //s4
            0,5,4
        };
    }

    void UpdateMesh() {
        mesh.Clear();
        
        Material initalMaterial = GetComponent<Renderer>().material;
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        Vector2[] uvs = new Vector2[vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        mesh.uv = uvs;
        initalMaterial = buildingMaterial;
        
    }

    void Update() {
        y = meshManager.GetComponent<MeshManager>().meshHeight; 

        if(tempMin != meshManager.GetComponent<MeshManager>().meshScaleMin) {
            scaleFactorY = Random.Range(meshManager.GetComponent<MeshManager>().meshScaleMin, 1f);
            tempMin = meshManager.GetComponent<MeshManager>().meshScaleMin;
        }

        

        z = meshManager.GetComponent<MeshManager>().meshZScale * randSizeFactor;
        x = meshManager.GetComponent<MeshManager>().meshXScale * randSizeFactor;

        CreateShape();
        UpdateMesh();


    }

}



