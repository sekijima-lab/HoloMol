using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallButtonNameText : MonoBehaviour
{
    GameObject grandparent;
    GameObject parent;

    // Use this for initialization
    void Start()
    {
        grandparent = transform.parent.parent.parent.gameObject;
        parent = transform.parent.parent.gameObject;
        if(grandparent.name == "TowerCubeNode2")
        {
            if (parent.name == "SmallLigandButtonNode1")
            {
                this.GetComponent<Text>().text = "On";
            }
            if (parent.name == "SmallLigandButtonNode2")
            {
                this.GetComponent<Text>().text = "Off";
            }
        }
        if (grandparent.name == "TowerCubeNode3")
        {
            if (parent.name == "SmallModelButtonNode1")
            {
                this.GetComponent<Text>().text = "Cartoon";
            }
            if (parent.name == "SmallModelButtonNode2")
            {
                this.GetComponent<Text>().text = "Surface";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
