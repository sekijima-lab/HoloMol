using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameText : MonoBehaviour {

    GameObject grandparent;
    GameObject parent;

    // Use this for initialization
    void Start() {
        parent = transform.parent.parent.gameObject;
        if (parent.name == "CubeNode1")
        {
            this.GetComponent<Text>().text = "1FKB / FKBP";
        }
        if (parent.name == "CubeNode2")
        {
            this.GetComponent<Text>().text = "1XL2 / HIV-Protease";
        }
        if (parent.name == "CubeNode3")
        {
            this.GetComponent<Text>().text = "5GGR / PD-1";
        }
        if (parent.name == "CubeNode4")
        {
            this.GetComponent<Text>().text = "Reselect Protein";
        }
    }

	// Update is called once per frame
	void Update () {

    }
}
