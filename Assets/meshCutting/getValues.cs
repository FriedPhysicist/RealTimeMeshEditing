using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class getValues : MonoBehaviour
{
    
    Mesh MF;

    public Vector3[] vertices_copy;
    public int[] triangles_copy;

    void Start()
    {
	MF = new Mesh();

	triangles_copy = new int[]
	{
	    0,2,1,
	    2,3,1,
	    4,6,5,
	    6,7,5
	};

	vertices_copy = new Vector3[]
	{
	    new Vector3(0,0,0), //left bottom
	    new Vector3(1,0,0), //right bottom
	    new Vector3(0,0,1), //legt top
	    new Vector3(1,0,1),  //right top
	    new Vector3(1,1,1),
	    new Vector3(1,1,1),
	    new Vector3(1,1,1),
	    new Vector3(1,1,1)
	};


	MF.vertices = vertices_copy;
	MF.triangles = triangles_copy;

	GetComponent<MeshFilter>().mesh = MF;
	GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }

    void Update()
    {
	MF.vertices = vertices_copy;
	MF.triangles = triangles_copy;
    }

    void OnDrawGizmos()
    {
    }
}
