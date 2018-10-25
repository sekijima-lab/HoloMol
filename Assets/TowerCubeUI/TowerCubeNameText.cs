using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerCubeNameText : MonoBehaviour
{
    GameObject parent;

    // Use this for initialization
    void Start()
    {
        parent = transform.parent.parent.gameObject;
        if (parent.name == "TowerCubeNode1")
        {
            this.GetComponent<Text>().text = "Protein";
        }
        if (parent.name == "TowerCubeNode2")
        {
            this.GetComponent<Text>().text = "Ligand";
        }
        if (parent.name == "TowerCubeNode3")
        {
            this.GetComponent<Text>().text = "Model";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
