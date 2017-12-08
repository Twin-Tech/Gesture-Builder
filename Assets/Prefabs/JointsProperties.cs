using System.Collections;
using System.Collections.Generic;

using Kinect = Windows.Kinect;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JointsProperties : MonoBehaviour {


    public string name;
    public double distanceFromGround;
    public Kinect.Vector4 floor;
    public Vector3 position;
    public HashSet<GameObject> adjacentJoints;
    public Dictionary<GameObject, float> distanceBtwnJoints;


    public ArrayList HandColliders = new ArrayList();
    int HandCollider_length = 0;	
	// Update is called once per frame
	void Update () {
        //UpdateDistanceFromGround();
	}

    public void UpdateDistanceFromGround()
    {
        double numerator = floor.X * transform.position.x + floor.Y * transform.position.y + floor.Z * transform.position.z + floor.W;
        double denominator = Math.Sqrt(floor.X * floor.X + floor.Y * floor.Y + floor.Z * floor.Z);

        distanceFromGround = numerator / denominator;
    }

    public void AddNeighbours(GameObject g)
    {
        adjacentJoints.Add(g);
        distanceBtwnJoints.Add(g, CalculateDistance(g));
    }

    public float CalculateDistance(GameObject g)
    {
        return Vector3.Distance(transform.position, g.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {

    }

}
