using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesh_ : MonoBehaviour
{ 
    public Mesh orginal_mesh;

    GameObject bucket;
    Mesh bucket_mesh;
    public GameObject planee;

    public static Vector3 current_pos;


    public Vector3[] orginal_mesh_verticies;
    public Vector2[] orginal_mesh_uv;
    public int[] orginal_mesh_triangels; 

    void Start()
    { 
        orginal_mesh=gameObject.GetComponent<MeshFilter>().mesh; 
        bucket = GameObject.FindWithTag("bucket");
        bucket_mesh = bucket.GetComponent<MeshFilter>().mesh;

        Array.Resize(ref orginal_mesh_verticies, orginal_mesh.vertices.Length); 
        Array.Resize(ref orginal_mesh_uv, orginal_mesh.uv.Length); 
        Array.Resize(ref orginal_mesh_triangels, orginal_mesh.triangles.Length); 

        orginal_mesh_verticies=orginal_mesh.vertices; 
        orginal_mesh_uv=orginal_mesh.uv; 
        orginal_mesh_triangels=orginal_mesh.triangles;

        GameObject my_object = new GameObject();

        my_object.AddComponent<MeshFilter>().mesh.vertices = bucket_mesh.vertices; 
        my_object.AddComponent<MeshRenderer>().material.color=Color.blue; 
    }


    void Update()
    { 
        Debug.DrawRay(Camera.main.transform.position,Camera.main.transform.forward*5);
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 5);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        { 
            current_pos=planee.transform.InverseTransformPoint(hit.point);
            Debug.Log(hit.point);
        }
        
        orginal_mesh.vertices=orginal_mesh_verticies; 
        orginal_mesh.uv=orginal_mesh_uv; 
        orginal_mesh.triangles=orginal_mesh_triangels; 
    }


    void OnTriggerStay(Collider other) 
    { 
        if(other.CompareTag("sphere"))
        { 
            for(int i=0;i<orginal_mesh_verticies.Length;i++)
            { 
                if(other.bounds.Contains(transform.TransformPoint(orginal_mesh_verticies[i])))
                {
                    orginal_mesh_verticies[i]=new Vector3(orginal_mesh_verticies[i].x,orginal_mesh_verticies[i].y,-0.001f); 
                    orginal_mesh_uv[i]=new Vector2(0,0); 
                } 
            } 
        }
    }
} 