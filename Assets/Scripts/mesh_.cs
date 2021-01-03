using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesh_ : MonoBehaviour
{ 
    public Mesh orginal_mesh; 
    public GameObject sphere;


    public Vector3[] orginal_mesh_verticies;
    public Vector2[] orginal_mesh_uv;
    public int[] orginal_mesh_triangels;

    public RenderTexture RT;





    void Start()
    { 
        orginal_mesh=gameObject.GetComponent<MeshFilter>().mesh; 

        System.Array.Resize(ref orginal_mesh_verticies, orginal_mesh.vertices.Length); 
        System.Array.Resize(ref orginal_mesh_uv, orginal_mesh.uv.Length); 
        System.Array.Resize(ref orginal_mesh_triangels, orginal_mesh.triangles.Length); 

        orginal_mesh_verticies=orginal_mesh.vertices; 
        orginal_mesh_uv=orginal_mesh.uv; 
        orginal_mesh_triangels=orginal_mesh.triangles; 
    }


    void Update()
    { 
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

