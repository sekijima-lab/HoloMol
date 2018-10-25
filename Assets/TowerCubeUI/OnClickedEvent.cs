using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickedEvent : MonoBehaviour,IPointerClickHandler {

    public static string URL;
    public static bool DownloadFlag;
    public static int ProteinNumber = 0;
    public static bool LigandOn;  //true:Ligand ON false:Ligand OFF
    public static bool CartoonOn;  //true:cartoon false:surface
    public static bool LigandChosen = false;
    public static bool ModelChosen = false;

    public void Start()
    {

    }

    public void Update()
    {

    }

    public void ModelSelect()
    {
        if (ProteinNumber == 1)
        {
            if (ModelChosen == true && LigandChosen == true)
            {
                if (LigandOn == true && CartoonOn == true)
                {
                    URL = "https://moleculardisplay.blob.core.windows.net/images/1fkb.dae";
                    DownloadFlag = true;
                }
                else if (LigandOn == true && CartoonOn == false)
                {
                    URL = "https://moleculardisplay2.blob.core.windows.net/images/3a7e.dae";
                    DownloadFlag = true;
                }
                else if (LigandOn == false && CartoonOn == true)
                {
                    URL = "http://orbcreation.com/SimpleCollada/mushroom.dae";
                    DownloadFlag = true;
                }
                else if (LigandOn == false && CartoonOn == false)
                {
                    URL = "http://orbcreation.com/SimpleCollada/hat.dae";
                    DownloadFlag = true;
                }
            }
        }
        else if (ProteinNumber == 2)
        {
            if (ModelChosen == true && LigandChosen == true)
            {
                if (LigandOn == true && CartoonOn == true)
                {
                    URL = "https://moleculardisplay.blob.core.windows.net/images/1fkb.dae";
                    DownloadFlag = true;
                }
                else if (LigandOn == true && CartoonOn == false)
                {
                    URL = "https://moleculardisplay2.blob.core.windows.net/images/3a7e.dae";
                    DownloadFlag = true;
                }
                else if (LigandOn == false && CartoonOn == true)
                {
                    URL = "https://moleculardisplay3.blob.core.windows.net/images/3rze.dae";
                    DownloadFlag = true;
                }
                else if (LigandOn == false && CartoonOn == false)
                {
                    URL = "https://moleculardisplay4.blob.core.windows.net/images/5ggr_surface.dae";
                    DownloadFlag = true;
                }
            }
        }
        else if (ProteinNumber == 3)
        {
            if (ModelChosen == true && LigandChosen == true)
            {
                if (LigandOn == true && CartoonOn == true)
                {
                    URL = "https://moleculardisplay.blob.core.windows.net/images/1fkb.dae";
                    DownloadFlag = true;
                }
                else if (LigandOn == true && CartoonOn == false)
                {
                    URL = "https://moleculardisplay2.blob.core.windows.net/images/3a7e.dae";
                    DownloadFlag = true;
                }
                else if (LigandOn == false && CartoonOn == true)
                {
                    URL = "https://moleculardisplay3.blob.core.windows.net/images/3rze.dae";
                    DownloadFlag = true;
                }
                else if (LigandOn == false && CartoonOn == false)
                {
                    URL = "https://moleculardisplay4.blob.core.windows.net/images/5ggr_surface.dae";
                    DownloadFlag = true;
                }
            }
        }
        else
        {
            Debug.Log("Protein is not selected.");
        }
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (this.name == "CubeNode1")  //Protein
        {
            ProteinNumber = 1;
            GameObject.Find("CubeNode2").SetActive(false);
            GameObject.Find("CubeNode3").SetActive(false);
        }
        if (this.name == "CubeNode2")
        {
            ProteinNumber = 2;
            GameObject.Find("CubeNode1").SetActive(false);
            GameObject.Find("CubeNode3").SetActive(false);
        }
        if (this.name == "CubeNode3")
        {
            ProteinNumber = 3;
            GameObject.Find("CubeNode1").SetActive(false);
            GameObject.Find("CubeNode2").SetActive(false);
        }
        if (this.name == "CubeNode4")  //Reset
        {
            ProteinNumber = 0;
            Destroy(Collada_molecular.targetObject);
            Collada_molecular.targetObject = null;
            if (LigandChosen == true)
            {
                GameObject.Find("SmallLigandButtonNode1").GetComponent<Renderer>().material.color = Color.white;    //Reset Ligand
                GameObject.Find("SmallLigandButtonNode1").transform.localScale = new Vector3(1, 2 / 3F, 1 / 5F);
                GameObject.Find("SmallLigandButtonNode2").GetComponent<Renderer>().material.color = Color.white;
                GameObject.Find("SmallLigandButtonNode2").transform.localScale = new Vector3(1, 2 / 3F, 1 / 5F);
                LigandChosen = false;
            }
            if(ModelChosen == true)
            {
                GameObject.Find("SmallModelButtonNode1").GetComponent<Renderer>().material.color = Color.white;    //Reset Model
                GameObject.Find("SmallModelButtonNode1").transform.localScale = new Vector3(1, 2 / 3F, 1 / 5F);
                GameObject.Find("SmallModelButtonNode2").GetComponent<Renderer>().material.color = Color.white;
                GameObject.Find("SmallModelButtonNode2").transform.localScale = new Vector3(1, 2 / 3F, 1 / 5F);
                ModelChosen = false;
            }
            GameObject.Find("Contents").transform.Find("CubeNode1").gameObject.SetActive(true);    //Reset Protein
            GameObject.Find("Contents").transform.Find("CubeNode2").gameObject.SetActive(true);
            GameObject.Find("Contents").transform.Find("CubeNode3").gameObject.SetActive(true);
            ProteinNumber = 0;
        }

        if (this.name == "SmallLigandButtonNode1") //Ligand ON
        {
            LigandOn = true;
            LigandChosen = true;
            GameObject.Find("SmallLigandButtonNode2").GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("SmallLigandButtonNode2").transform.localScale = new Vector3(1, 2 / 3F, 1 / 5F);
            this.GetComponent<Renderer>().material.color = Color.yellow;
            this.transform.localScale = new Vector3(6 / 5F, 4 / 5F, 6 / 25F);
            ModelSelect();
        }
        if (this.name == "SmallLigandButtonNode2")  //Ligand OFF
        {
            LigandOn = false;
            LigandChosen = true;
            GameObject.Find("SmallLigandButtonNode1").GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("SmallLigandButtonNode1").transform.localScale = new Vector3(1, 2 / 3F, 1 / 5F);
            this.GetComponent<Renderer>().material.color = Color.yellow;
            this.transform.localScale = new Vector3(6 / 5F, 4 / 5F, 6 / 25F);
            ModelSelect();
        }

        if (this.name == "SmallModelButtonNode1")  //Cartoon model
        {
            CartoonOn = true;
            ModelChosen = true;
            GameObject.Find("SmallModelButtonNode2").GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("SmallModelButtonNode2").transform.localScale = new Vector3(1, 2 / 3F, 1 / 5F);
            this.GetComponent<Renderer>().material.color = Color.cyan;
            this.transform.localScale = new Vector3(6 / 5F, 4 / 5F, 6 / 25F);
            ModelSelect();
        }
        if (this.name == "SmallModelButtonNode2")  //Surface model
        {
            CartoonOn = false;
            ModelChosen = true;
            GameObject.Find("SmallModelButtonNode1").GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("SmallModelButtonNode1").transform.localScale = new Vector3(1, 2 / 3F, 1 / 5F);
            this.GetComponent<Renderer>().material.color = Color.cyan;
            this.transform.localScale = new Vector3(6 / 5F, 4 / 5F, 6 / 25F);
            ModelSelect();
        }
    }
}
