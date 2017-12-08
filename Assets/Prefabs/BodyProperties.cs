using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

public class BodyProperties : MonoBehaviour {

    public Boolean startGame = false;
    public Boolean InitializeObj = false;
    public int countinst = 0;
    int approximation = 0;
    public float leftarmLength = 0.0f;
    public float rightarmLength = 0.0f;
    int NoOfInitializationFrame = 100;
    public float rightFootHeight = Single.PositiveInfinity;
    public float leftFootHeight = Single.PositiveInfinity;
    double[] AnglesOfHand = { 0.0, 30.0, 60.0, 90.0, 120.0, 150.0, 180.0 };

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (startGame)
        {
            if (!InitializeObj)
            {
                float leftArm = FindHandLength("left");
                float rightArm = FindHandLength("right");
                if (leftArm != -1.0f && rightArm != -1.0f)
                {
                    FindLegHeightFromGround("left");
                    FindLegHeightFromGround("right");
                    leftarmLength += FindHandLength("left");
                    rightarmLength += FindHandLength("right");
                    approximation++;
                    if (approximation > NoOfInitializationFrame)
                    {
                        countinst++;
                        InitializeObj = true;
                        leftarmLength /= NoOfInitializationFrame;
                        rightarmLength /= NoOfInitializationFrame;
                        Button btn = GameObject.Find("SetInitial").GetComponent<Button>();
                        btn.interactable = true;
                        MainScript ms = GameObject.Find("MainScript").GetComponent<MainScript>();
                        ms.leftarmLength = leftarmLength;
                        ms.rightarmLength = rightarmLength;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("StartCircle")) {
            startGame = true;
            other.enabled = false;
        }
    }

    public double CalculateAngle(GameObject start, GameObject mid, GameObject end)
    {
        Vector3 a = start.transform.position - mid.transform.position;
        Vector3 b = end.transform.position - mid.transform.position;
        return Vector3.Angle(a, b);
    }

    public float CalculateDistance(GameObject g1, GameObject g2)
    {
        return Vector3.Distance(g2.transform.position, g1.transform.position);
    }

    public float CalculateDistance(Windows.Kinect.Joint g1, Windows.Kinect.Joint g2)
    {
        return Vector3.Distance(GetVector3FromJoint(g1), GetVector3FromJoint(g2));
    }

    public double CalculateDistanceByFormula(Windows.Kinect.Joint g1, Windows.Kinect.Joint g2)
    {
        Vector3 s = GetVector3FromJoint(g1);
        Vector3 t = GetVector3FromJoint(g2);

        return Math.Sqrt(Math.Pow(s.x - t.x, 2) + Math.Pow(s.y - t.y, 2) + Math.Pow(s.z - t.z, 2));

    }
    private static Vector3 GetVector3FromJoint(Windows.Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X, joint.Position.Y, joint.Position.Z);
    }

    public float FindHandLength(string hand)
    {
        switch (hand)
        {
            case "left":
            case "Left":
            case "LEFT":
                GameObject leftShoulder = transform.Find("ShoulderLeft").gameObject;
                GameObject leftElbow = transform.Find("ElbowLeft").gameObject;
                GameObject leftWrist = transform.Find("WristLeft").gameObject;
                return Vector3.Distance(leftShoulder.transform.position, leftElbow.transform.position) + Vector3.Distance(leftElbow.transform.position, leftWrist.transform.position);
                break;
            case "right":
            case "Right":
            case "RIGHT":
                GameObject rightShoulder = transform.Find("ShoulderRight").gameObject;
                GameObject rightElbow = transform.Find("ElbowRight").gameObject;
                GameObject rightWrist = transform.Find("WristRight").gameObject;
                return Vector3.Distance(rightShoulder.transform.position, rightElbow.transform.position) + Vector3.Distance(rightElbow.transform.position, rightWrist.transform.position);
                break;
            default:
                return -1.0f;
        }
        //return 0.0f;
    }

    public void FindLegHeightFromGround(string leg)
    {
        switch (leg)
        {
            case "left":
            case "Left":
            case "LEFT":
                GameObject leftFoot = transform.Find("FootLeft").gameObject;
                JointsProperties LFJP = leftFoot.GetComponent<JointsProperties>();
                leftFootHeight = leftFootHeight > (float)(LFJP.distanceFromGround) ? (float)LFJP.distanceFromGround : leftFootHeight;
                break;
            case "right":
            case "Right":
            case "RIGHT":
                GameObject rightFoot = transform.Find("FootRight").gameObject;
                JointsProperties RFJP = rightFoot.GetComponent<JointsProperties>();
                rightFootHeight = rightFootHeight > (float)(RFJP.distanceFromGround) ? (float)RFJP.distanceFromGround : rightFootHeight;
                break;
        }
    }

    public float ConvertDegreeToRadian(double degree)
    {
        return (float)(Math.PI * degree / 180.0);
    }

    public bool CheckLegAboveGround()
    {
        GameObject leftFoot = transform.Find("FootLeft").gameObject;
        JointsProperties LFJP = leftFoot.GetComponent<JointsProperties>();
        float leftLegHeight = (float)LFJP.distanceFromGround;

        GameObject rightFoot = transform.Find("FootRight").gameObject;
        JointsProperties RFJP = rightFoot.GetComponent<JointsProperties>();
        float rightLegHeight = (float)RFJP.distanceFromGround;

        float rightLegDiff = rightLegHeight - rightFootHeight;
        float leftLegDiff = leftLegHeight - leftFootHeight;
        
        if(rightLegDiff >= 0.02f && leftLegDiff >= 0.02f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float findDistanceBtwnFoots()
    {
        GameObject leftFoot = transform.Find("FootLeft").gameObject;
        GameObject rightFoot = transform.Find("FootRight").gameObject;

        return CalculateDistance(leftFoot, rightFoot);
    }
    public bool findAngleOfHand()
    {
        GameObject spineShoulder = transform.Find("SpineShoulder").gameObject;

        GameObject rightShoulder = transform.Find("ShoulderRight").gameObject;
        GameObject rightElbow = transform.Find("ElbowRight").gameObject;
        GameObject rightWrist = transform.Find("WristRight").gameObject;

        GameObject leftShoulder = transform.Find("ShoulderLeft").gameObject;
        GameObject leftElbow = transform.Find("ElbowLeft").gameObject;
        GameObject leftWrist = transform.Find("WristLeft").gameObject;

        double leftarmangle = CalculateAngle(leftShoulder, leftElbow, leftWrist);
        double leftarmshoulderangle = CalculateAngle(spineShoulder, leftShoulder, leftWrist);

        double rightarmangle = CalculateAngle(rightShoulder, rightElbow, rightWrist);
        double rightarmshoulderangle = CalculateAngle(spineShoulder, rightShoulder, rightWrist);

        //Debug.Log(leftarmangle);
        //Debug.Log(leftarmshoulderangle);

        bool lefthand = false;
        bool righthand = false;
        if ((leftarmangle > 150 && leftarmangle < 200) && (leftarmshoulderangle > 240 && leftarmshoulderangle < 300))
        {
             lefthand = true;
        }

        if ((rightarmangle > 150 && rightarmangle < 200) && (rightarmshoulderangle > 240 && rightarmshoulderangle < 300))
        {
             righthand = true;
        }

        return lefthand && righthand;

    } 

}