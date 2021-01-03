using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesh_ : MonoBehaviour
{ 
    public Mesh orginal_mesh; 
    public Vector3[] orginal_mesh_verticies;
    public GameObject sphere;



    void Start()
    { 
        orginal_mesh=gameObject.GetComponent<MeshFilter>().mesh; 
        System.Array.Resize(ref orginal_mesh_verticies, orginal_mesh.vertices.Length); 
        orginal_mesh_verticies=orginal_mesh.vertices; 

        foreach(Vector3 vert in orginal_mesh.vertices)
        { 
            //Instantiate(sphere,transform.TransformPoint(vert),Quaternion.identity);
        }
    }


    void Update()
    { 
        orginal_mesh.vertices=orginal_mesh_verticies; 

        foreach(Vector3 vert in orginal_mesh.vertices)
        {

        }
    }
    void OnTriggerStay(Collider other) 
    { 
        if(other.CompareTag("sphere"))
        { 
            for(int i=0;i<orginal_mesh_verticies.Length;i++)
            { 
                if(other.bounds.Contains(transform.TransformPoint(orginal_mesh_verticies[i])))
                { 
                    //orginal_mesh_verticies[i]-=new Vector3(0,0,2);
                    System.Array.Clear(orginal_mesh.vertices,i,i);
                }

            } 
        }
    }
}

