using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Slicer : MonoBehaviour 
{
    public GameObject[] tryholdvertices;
    public Vector3[] vertices;

    public GameObject try_;

    Vector3 _in;
    Vector3 _out;

    public GameObject plane;

    void Start()
    {
	vertices = plane.GetComponent<MeshFilter>().mesh.vertices;
    }

    void Update()
    {
    }


    void OnCollisionEnter(Collision other)
    {
    }

    void OnTriggerEnter(Collider other)
    {
	if(other.CompareTag("Slicable"))
	{
	    Mesh oMesh=other.GetComponent<MeshFilter>().mesh;
	    _in=transform.position;
	}
    }

    void OnTriggerExit(Collider other)
    {
	if(other.CompareTag("Slicable"))
	{
	    Mesh oMesh=other.GetComponent<MeshFilter>().mesh;
	    Material oMaterial=other.GetComponent<MeshRenderer>().material;
	    _out=transform.position;

	    GameObject go0 = new GameObject();
	    Mesh go0Mesh = new Mesh();

	    go0Mesh.vertices = new Vector3[]
	    {
		//other.transform.TransformPoint(
		oMesh.vertices[120],
		oMesh.vertices[40],
		_out,
		_in 
	    };

	    go0Mesh.triangles = new int[]
	    {
		0,1,2,
		1,3,2
	    };

	    go0Mesh.RecalculateBounds();
	    go0Mesh.RecalculateNormals();
	    go0Mesh.RecalculateTangents();


	    go0.AddComponent<MeshRenderer>().material= oMaterial;
	    go0.AddComponent<MeshFilter>().mesh= go0Mesh;
	    go0.AddComponent<MeshCollider>().convex= true;

	    Destroy(other.gameObject, 0f);


	    GameObject go1 = new GameObject();
	}
    }










    void meshCreation()
    {
	tryholdvertices = GameObject.FindGameObjectsWithTag("bucket");
	System.Array.Resize(ref vertices, tryholdvertices.Length);

	for(int i = 0; i<10 ; i++)
	{
	    vertices[i] = tryholdvertices[i].transform.position;
	}

	try_ = new GameObject();
	try_.transform.position = new Vector3(10,2.5f,0.4f);

	Mesh tryMesh = new Mesh();
	tryMesh.vertices = vertices;

	tryMesh.triangles = new int[]
	{
	    0,1,6,
	    1,2,7,
	    2,3,8,
	    3,4,9,
	    4,5,0,
	    5,6,1,
	    6,7,2,
	    7,8,3,
	    8,9,4,
	    9,0,5
	};

	try_.AddComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
	try_.AddComponent<MeshFilter>().mesh= tryMesh;
	try_.AddComponent<MeshCollider>().convex= true;

	tryMesh.RecalculateBounds();
	tryMesh.RecalculateNormals();
	tryMesh.RecalculateTangents();
    }
}
