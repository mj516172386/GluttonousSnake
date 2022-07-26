using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Map Instantiation And other
/// </summary>
public class PageGame : MonoBehaviour
{
    [SerializeField, Header("MapsCloneParentTransform")] 
    private Transform mapTrans;
    [Header("MapChildsList")]
    private List<GameObject> mapChilds = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
       // InitMap();
    }
    /// <summary>
    ///  InitMap
    /// </summary>
    private void InitMap() 
    {
        int with = Screen.width;
        int height = Screen.height; 
        for (int i = 0; i < with/100; i++)
        {
            GameObject item = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Map"), mapTrans);
            item.GetComponent<RectTransform>().sizeDelta=Vector2.one * 100;  
            item.transform.position = new Vector3(0,i * 100, 0);
        }

        #region Discard
        //Vector2 size = new Vector2(Screen.width, Screen.height);
        //int h_Cont = ((int)size.x - 2) / Config.MAP_SIZE;
        //for (int i = 0; i < h_Cont; i++)
        //{
        //    GameObject h_item = Instantiate(Resources.Load<GameObject>("Prefabs/Vertical"), mapTrans);
        //    h_item.GetComponent<RectTransform>().sizeDelta = new Vector2(1, size.y);
        //    h_item.transform.position = new Vector3((i + 1) * 20, size.y / 2, 0);
        //}
        //int v_Cont = ((int)size.y - 2) / Config.MAP_SIZE;
        //for (int i = 0; i < v_Cont; i++)
        //{
        //    GameObject v_item = Instantiate(Resources.Load<GameObject>("Prefabs/Horizontal"), mapTrans);
        //    v_item.GetComponent<RectTransform>().sizeDelta = new Vector2(size.x, 1);
        //    v_item.transform.position = new Vector3(size.x / 2, (i + 1) * 20, 0);
        //}
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
