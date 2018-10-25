using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerCubeNode : MonoBehaviour, IPointerClickHandler
{
    public GameObject node;
    public GameObject smallclosenode;
    public GameObject cubenode;
    public static bool SmallButtonFlag = false;

    private bool LigandCubeClicked = false;
    private bool ModelCubeClicked = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }
    
    public void OnPointerClick(PointerEventData data)
    {
        if (this.name == "TowerCubeNode2" && LigandCubeClicked == false) //真ん中，リガンド
        {
            Enumerable.Range(1, 2).ToList().ForEach(x =>
            {
                var instance = Instantiate(node, new Vector3((x - 3/2F) * 3 / 2F, -1 / 5F, -1), Quaternion.Euler(30, 0, 0)); //x=1.5が相対座標x=0，
                instance.transform.SetParent(this.transform, false);

                var buttonName = instance.GetComponent<SmallButtonNode>();
                buttonName.name = "SmallLigandButtonNode" + x;
                /*
                if (x == 1 || x == 2)
                {
                    var instance = Instantiate(node, new Vector3((x - 2) * 3 / 2F, -1 / 5F, -1), Quaternion.Euler(30, 0, 0)); //x=2が相対座標x=0，
                    instance.transform.SetParent(this.transform, false);

                    var buttonName = instance.GetComponent<SmallButtonNode>();
                    buttonName.name = "SmallLigandButtonNode" + x;
                }
                else
                {
                    var instance = Instantiate(smallclosenode, new Vector3((x - 2) * 3 / 2F, -1 / 5F, -1), Quaternion.Euler(30, 0, 0)); //x=2が相対座標x=0，
                    instance.transform.SetParent(this.transform, false);

                    var buttonName = instance.GetComponent<SmallCloseButtonNode>();
                    buttonName.name = "SmallCloseButtonNode";
                }
                */
            });
            LigandCubeClicked = true;
            SmallButtonFlag = true;
        }

        if (this.name == "TowerCubeNode3" && ModelCubeClicked == false) //一番上，モデル種類
        {
            Enumerable.Range(1, 2).ToList().ForEach(x =>
            {
                var instance = Instantiate(node, new Vector3((x - 3/2F) * 3 / 2F, -1 / 5F, -1), Quaternion.Euler(30, 0, 0)); //x=1.5が相対座標x=0，
                instance.transform.SetParent(this.transform, false);

                var buttonName = instance.GetComponent<SmallButtonNode>();
                buttonName.name = "SmallModelButtonNode" + x;

                /*
                if (x == 1 || x == 2)
                {
                    var instance = Instantiate(node, new Vector3((x - 2) * 3 / 2F, -1 / 5F, -1), Quaternion.Euler(30, 0, 0)); //x=2が相対座標x=0，
                    instance.transform.SetParent(this.transform, false);

                    var buttonName = instance.GetComponent<SmallButtonNode>();
                    buttonName.name = "SmallModelButtonNode" + x;
                }
                else
                {
                    var instance = Instantiate(smallclosenode, new Vector3((x - 2) * 3 / 2F, -1 / 5F, -1), Quaternion.Euler(30, 0, 0)); //x=2が相対座標x=0，
                    instance.transform.SetParent(this.transform, false);

                    var buttonName = instance.GetComponent<SmallCloseButtonNode>();
                    buttonName.name = "SmallCloseButtonNode";
                }
                */
            });
            ModelCubeClicked = true;
            SmallButtonFlag = true;
        }
    }
}
