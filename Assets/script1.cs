using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class script1 : MonoBehaviour {

    /*
    XmlDocument xmldoc;
    XmlElement rootnode;
    public float leftarmLength = 0.0f;
    public float rightarmLength = 0.0f;
    public List<string> selectedjoints;
    // Use this for initialization
    void Start()
    {
        /*MainScript ms = GameObject.Find("MainScript").GetComponent<MainScript>();
        selectedjoints = ms.selectedJoints;
        SceneManager.UnloadSceneAsync("gui");
        Scene jj = SceneManager.GetSceneByName("Jumping Jack");
        SceneManager.SetActiveScene(jj);
    }
    */
    // Update is called once per frame
    void Update()
    {

    }
    /*
    public void getInitialData()
    {
        xmldoc.Load("C:\\Users\\Public\\Documents\\Unity Projects\\rajan\\final\\pb\\BuilderUI\\info.xml");
        rootnode = xmldoc.DocumentElement;
        XmlNode joint, child;
        XmlAttribute att;
        float realhandlength = 0.0f;
        float realheight = 0.0f;
        float realshoulder = 0.0f;
        float realfootlevel = 0.0f;
        float angle = 0;
        GameObject head = transform.Find("Head").gameObject;
        GameObject shoulderLeft = transform.Find("ShoulderLeft").gameObject;
        GameObject shoulderRight = transform.Find("ShoulderRight").gameObject;
        GameObject foot = transform.Find("FootLeft").gameObject;
        JointsProperties jphead = head.GetComponent<JointsProperties>();
        JointsProperties jpshoulderl = shoulderLeft.GetComponent<JointsProperties>();
        JointsProperties jpshoulderr = shoulderRight.GetComponent<JointsProperties>();
        JointsProperties jpfoot = foot.GetComponent<JointsProperties>();
        realheight = jphead.position.y;
        realshoulder = Vector3.Distance(jpshoulderl.position, jpshoulderr.position);
        realhandlength = (rightarmLength + leftarmLength) / 2;
        realfootlevel = jpfoot.position.y;

        joint = xmldoc.CreateElement("joint");
        att = xmldoc.CreateAttribute("name");
        att.Value = "HandLength";
        joint.Attributes.Append(att);
        child = xmldoc.CreateElement("length");
        child.InnerText = realhandlength.ToString();
        joint.AppendChild(child);
        rootnode.AppendChild(joint);

        joint = xmldoc.CreateElement("joint");
        att = xmldoc.CreateAttribute("name");
        att.Value = "ShoulderWidth";
        joint.Attributes.Append(att);
        child = xmldoc.CreateElement("length");
        child.InnerText = realshoulder.ToString();
        joint.AppendChild(child);
        rootnode.AppendChild(joint);

        joint = xmldoc.CreateElement("joint");
        att = xmldoc.CreateAttribute("name");
        att.Value = "HeadPos";
        joint.Attributes.Append(att);
        child = xmldoc.CreateElement("length");
        child.InnerText = realheight.ToString();
        joint.AppendChild(child);
        rootnode.AppendChild(joint);

        joint = xmldoc.CreateElement("joint");
        att = xmldoc.CreateAttribute("name");
        att.Value = "AngleAdjust";
        joint.Attributes.Append(att);
        child = xmldoc.CreateElement("length");
        child.InnerText = realfootlevel.ToString();
        joint.AppendChild(child);
        rootnode.AppendChild(joint);
        
        foreach (string j in selectedjoints)
        {
            JointsProperties thisjoint = GameObject.Find(j).GetComponent<JointsProperties>();
            joint = xmldoc.CreateElement("joint");
            att = xmldoc.CreateAttribute("name");
            att.Value = j + "Initial";
            joint.Attributes.Append(att);
            child = xmldoc.CreateElement("x");
            child.InnerText = thisjoint.position.x.ToString();
            joint.AppendChild(child);
            child = xmldoc.CreateElement("y");
            child.InnerText = thisjoint.position.y.ToString();
            joint.AppendChild(child);
            child = xmldoc.CreateElement("z");
            child.InnerText = thisjoint.position.z.ToString();
            joint.AppendChild(child);
            if (j.Contains("Hand") || j.Contains("Elbow") || j.Contains("Wrist"))
            {
                Vector3 a, b;
                if (j.Contains("Left"))
                {
                    a = thisjoint.position - jpshoulderl.position;
                    b = new Vector3(jpshoulderl.position.x, 0, jpshoulderl.position.z) - jpshoulderl.position;
                    angle = Math.Abs(Vector3.Angle(a, b));
                }
                else if (j.Contains("Right"))
                {
                    a = thisjoint.position - jpshoulderr.position;
                    b = new Vector3(jpshoulderr.position.x, 0, jpshoulderr.position.z) - jpshoulderr.position;
                    angle = Math.Abs(Vector3.Angle(a, b));
                }
                child = xmldoc.CreateElement("angle");
                child.InnerText = angle.ToString();
                joint.AppendChild(child);
            }
            xmldoc.Save("info.xml");
        }
    }*/

}
