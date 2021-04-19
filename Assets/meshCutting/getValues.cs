using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getValues : MonoBehaviour
{
    public Vector3[] vertices_copy;
    public int[] triangles_copy;
    
    Mesh MF;
    Mesh someMesh;

    public int xSize;
    public int zSize;

    public Transform holder;

    void Start()
    {
	someMesh = GetComponent<MeshFilter>().mesh;

	vertices_copy  = GetComponent<MeshFilter>().mesh.vertices;
	triangles_copy = GetComponent<MeshFilter>().mesh.triangles;
	
    }

    void Update()
    {
	Debug.Log(transform.TransformPoint(someMesh.bounds.ClosestPoint(holder.position)));
    }

    int some = 0;
    void createShapeArray()
    {
	MF = new Mesh();

	vertices_copy = new Vector3[(xSize+1)*(zSize+1)];
	triangles_copy = new int[xSize*zSize*6];


	for(int i = 0, z = 0; z<= zSize; z++)
	{
	    for(int x = 0; x<= xSize; x++)
	    {
		vertices_copy[i] = new Vector3(x,0,z);
		i++;
	    }
	}

	int vert = 0;
	int tris = 0;

	for(int i = 0; i< zSize; i++)
	{
	    for(int x = 0; x< xSize; x++)
	    {
		triangles_copy[tris+0] = vert + 0;
		triangles_copy[tris+1] = vert + xSize + 1;
		triangles_copy[tris+2] = vert + 1;
		triangles_copy[tris+3] = vert + 1;
		triangles_copy[tris+4] = vert + xSize + 1;
		triangles_copy[tris+5] = vert + xSize + 2;

		vert++;
		tris+=6;
	    }
	}

	MF.vertices = vertices_copy;
	MF.triangles = triangles_copy;

	GetComponent<MeshFilter>().mesh = MF;
	GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }

    void OnDrawGizmos()
    {
	for(int i = 0; i<vertices_copy.Length; i++)
	{
	    //Gizmos.DrawSphere(MF.vertices[i], 0.1f);
	}
    }
}
