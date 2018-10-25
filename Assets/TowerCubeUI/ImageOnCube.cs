using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ImageOnCube : MonoBehaviour
{
    private GameObject imageObj;
    string url = "";
    bool flag = true;

    void Start()
    {
        StartCoroutine(ImageWWWStart());
    }

    void Update()
    {

    }

    IEnumerator ImageWWWStart()
    {
        //cubeObj.renderer.material.mainTexture=www.texture;
        for (int x = 1; x < 4; x++)
        {
            if (x == 1)
            {
                url = "https://cdn.rcsb.org/images/rutgers/fk/1fkb/1fkb.pdb1-500.jpg";
            }
            if (x == 2)
            {
                url = "https://cdn.rcsb.org/images/rutgers/xl/1xl2/1xl2.pdb1-500.jpg";
            }
            if (x == 3)
            {
                url = "https://cdn.rcsb.org/images/rutgers/gg/5ggr/5ggr.pdb1-500.jpg";
            }
            WWW www = new WWW(url);
            yield return www;
            imageObj = gameObject.transform.Find("CubeNode" + x).gameObject as GameObject;
            Renderer renderer = imageObj.GetComponent<Renderer>();
            renderer.material.mainTexture = www.texture;
        }
    }
}