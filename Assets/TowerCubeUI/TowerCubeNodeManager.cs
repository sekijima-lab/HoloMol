using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TowerCubeNodeManager : MonoBehaviour
{
    public GameObject node;
    public GameObject cubenode;
    public GameObject contents;

    void Start()
    {

        Enumerable.Range(1, 3).ToList().ForEach(x =>
        {
            var instance = Instantiate(node, new Vector3(1, (x-2)/2F , 2), Quaternion.identity);
            instance.transform.SetParent(contents.transform, false);

            //            var buttonNode = instance.GetComponent<CubeNode>();
            //            buttonNode.Initialize("Model" + x, detailText);

            var buttonName = instance.GetComponent<TowerCubeNode>();
            buttonName.name = "TowerCubeNode" + x;
        });
        Enumerable.Range(1, 4).ToList().ForEach(x =>
        {
            var instance = Instantiate(cubenode, new Vector3((x - 1/2F) / 2F, -1 / 2F, 3/2F), Quaternion.identity); //x軸負の方向に0.5F刻み 0.25 0.75 1.25 1.75
            instance.transform.SetParent(contents.transform, false);

            var buttonName = instance.GetComponent<CubeNode>();
            buttonName.name = "CubeNode" + x;
        });
    }

}