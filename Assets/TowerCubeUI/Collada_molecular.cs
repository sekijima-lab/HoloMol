/* SimpleCollada 1.4                    */
/* By Orbcreation BV                    */
/* Richard Knol                         */
/* info@orbcreation.com                 */
/* Mar 11, 2016                         */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class Collada_molecular : MonoBehaviour{
    public GameObject cameraGameObject;
    public Texture2D defaultTexture;
    public GameObject rulerIndicatorPrototype;
    public Color[] demoColors;
    public GameObject HologramCollection;
    public Shader _shader;

    private string url;
//	Use this when you want to use your own local files
//	private string url = "file:///ontwikkel/AssetStore/SimpleCollada/colladafiles/heli_dae.dae";
//  private string url = "file:///ontwikkel/AssetStore/SimpleCollada 5.2/colladafiles/cube.dae";

    private string downloadedPath = "";
    private float importScale = 1f;
    private float importedScale = 1f;
    private Vector3 importTranslation = new Vector3(0, 0, 0);
    private Vector3 importedTranslation = new Vector3(0, 0, 0);
    private Vector3 importRotation = new Vector3(0, 0, 0);
    private Vector3 importedRotation = new Vector3(0, 0, 0);
    private bool importEmptyNodes = true;
    private bool importedEmptyNodes = false;

    private string logMsgs = "";
    private string fileContentString;

    public static GameObject targetObject;
    private Bounds overallBounds;

    public static string modelInfo = "";


    void Start()
    {

    }

    void Update()
    {

        if (OnClickedEvent.DownloadFlag == true)
        {
            url = OnClickedEvent.URL;
            if (downloadedPath != url || importedTranslation != importTranslation || importedScale != importScale || importedRotation != importRotation || importedEmptyNodes != importEmptyNodes)
            {
                downloadedPath = url;
                importedTranslation = importTranslation;
                importedScale = importScale;
                importedRotation = importRotation;
                importedEmptyNodes = importEmptyNodes;
                StartCoroutine(DownloadAndImportFile(url, Quaternion.Euler(importRotation), new Vector3(importScale, importScale, importScale), importTranslation));
            }
            OnClickedEvent.DownloadFlag = false;
        }
    }

    //OnClickedEvent と SampleButtonController と SmallButtonNode


    /* ------------------------------------------------------------------------------------- */
    /* ------------------------------- Downloading files  ---------------------------------- */

    private IEnumerator DownloadAndImportFile(string url, Quaternion rotate, Vector3 scale, Vector3 translate)
    {
        fileContentString = null;
        if (targetObject)
        {
            Destroy(targetObject);
            targetObject = null;
        }
        //		ResetCameraPosition();
        modelInfo = "";

        yield return StartCoroutine(DownloadFile(url, fileContents => fileContentString = fileContents));
        if (fileContentString != null && fileContentString.Length > 0)
        {
            targetObject = ColladaImporter.Import(fileContentString, rotate, scale, translate, importEmptyNodes);
            yield return StartCoroutine(DownloadTextures(targetObject, url));

            // place the bottom on the floor
            overallBounds = GetBounds(targetObject);
            targetObject.transform.parent = HologramCollection.transform;
            targetObject.transform.position = new Vector3(0, 0, 3);
            targetObject.transform.localScale = new Vector3(0.01F, 0.01F, 0.01f);
   //         targetObject.gameObject.AddComponent<BoundingBoxTarget>;


            List<GameObject> list = GetAllChildren.GetAll(targetObject);
            foreach (GameObject obj in list)
            {
                MeshRenderer rd = obj.transform.GetComponent<MeshRenderer>();
                if (rd != null)
                {
                    //renderer.material.shader = proteinShader;
                    obj.GetComponent<Renderer>().material.shader = _shader;
                }

            }

            overallBounds = GetBounds(targetObject);

            modelInfo = GetModelInfo(targetObject, overallBounds);


            //			ResetCameraPosition();
        }
    }

    private IEnumerator DownloadFile(string url, System.Action<string> result)
    {
        AddToLog("Downloading " + url);
        WWW www = new WWW(url);
        yield return www;
        if (www.error != null)
        {
            AddToLog(www.error);
        }
        else
        {
            AddToLog("Downloaded " + www.bytesDownloaded + " bytes");
        }
        result(www.text);
    }
    private IEnumerator DownloadTexture(string url, System.Action<Texture2D> result)
    {
        AddToLog("Downloading " + url);
        WWW www = new WWW(url);
        yield return www;
        if (www.error != null)
        {
            AddToLog(www.error);
        }
        else
        {
            AddToLog("Downloaded " + www.bytesDownloaded + " bytes");
        }
        result(www.texture);
    }

    private IEnumerator DownloadTextures(GameObject go, string originalUrl)
    {
        string path = originalUrl;
        int lastSlash = path.LastIndexOf('/', path.Length - 1);
        if (lastSlash >= 0) path = path.Substring(0, lastSlash + 1);
        Renderer[] renderers = go.GetComponentsInChildren<Renderer>(true);
        foreach (Renderer r in renderers)
        {
            foreach (Material m in r.materials)
            {
                if (m.mainTexture != null)
                {
                    Texture2D texture = null;
                    string texUrl = path + m.mainTexture.name;
                    yield return StartCoroutine(DownloadTexture(texUrl, retval => texture = retval));
                    if (texture != null)
                    {
                        m.mainTexture = texture;
                    }
                }
            }
        }
    }

    private void SetTextureInAllMaterials(GameObject go, Texture2D texture)
    {
        Renderer[] renderers = go.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            foreach (Material m in r.materials)
            {
                m.mainTexture = texture;
            }
        }
    }

    private void SetColorInAllMaterials(GameObject go, Texture2D texture)
    {
        int i = 0;
        Renderer[] renderers = go.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            foreach (Material m in r.materials)
            {
                m.color = demoColors[i++ % demoColors.Length];
            }
        }
    }

    private string GetModelInfo(GameObject go, Bounds bounds)
    {
        string infoString = "";
        int meshCount = 0;
        int subMeshCount = 0;
        int vertexCount = 0;
        int triangleCount = 0;

        MeshFilter[] meshFilters = go.GetComponentsInChildren<MeshFilter>();
        if (meshFilters != null) meshCount = meshFilters.Length;
        foreach (MeshFilter mf in meshFilters)
        {
            Mesh mesh = mf.mesh;
            subMeshCount += mesh.subMeshCount;
            vertexCount += mesh.vertices.Length;
            triangleCount += mesh.triangles.Length / 3;
        }
        infoString = infoString + meshCount + " mesh(es)\n";
        infoString = infoString + subMeshCount + " sub meshes\n";
        infoString = infoString + vertexCount + " vertices\n";
        infoString = infoString + triangleCount + " triangles\n";
        infoString = infoString + bounds.size + " meters";
        return infoString;
    }
    /* ------------------------------------------------------------------------------------- */


    /* ------------------------------------------------------------------------------------- */
    /* --------------------- Position camera to include entire model ----------------------- */
    private Bounds GetBounds(GameObject go)
    {
        Bounds goBounds = new Bounds(go.transform.position, Vector3.zero);
        Renderer[] renderers = go.GetComponentsInChildren<Renderer>(true);
        if (renderers != null && renderers.Length > 0) goBounds = renderers[0].bounds;
        foreach (Renderer r in renderers)
        {
            Bounds bounds = r.bounds;
            goBounds.Encapsulate(bounds);
        }
        return goBounds;
    }


    /* ------------------------------------------------------------------------------------- */
    /* ------------------------------- Logging functions  ---------------------------------- */

    private void AddToLog(string msg)
    {
        Debug.Log(msg + "\n" + DateTime.Now.ToString("yyy/MM/dd hh:mm:ss.fff"));

        // for some silly reason the Editor will generate errors if the string is too long
        int lenNeeded = msg.Length + 1;
        if (logMsgs.Length + lenNeeded > 4096) logMsgs = logMsgs.Substring(0, 4096 - lenNeeded);

        logMsgs = logMsgs + "\n" + msg;
    }

    private string TruncateStringForEditor(string str)
    {
        // for some silly reason the Editor will generate errors if the string is too long
        if (str.Length > 4096) str = str.Substring(0, 4000) + "\n .... display truncated ....\n";
        return str;
    }
    /* ------------------------------------------------------------------------------------- */



}

