using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance;
    private void Awake()
    {
            instance = this;
    }
    public List<GameObject>players = new List<GameObject>();
    /// <summary>
    /// 玩家占据每个格子的差值
    /// </summary>
    const int VALUE = 59;
    /// <summary>
    /// 最大横向网格格子数，初始坐标为0；
    /// </summary>
    const int H_MAX = 17;
    /// <summary>
    /// 最大纵向网格格子数，初始坐标为30
    /// </summary>
    const int V_MAX = 12;
    const float timer = 1; //0.5f;
    float temptimer = 0;
    bool isMove = false;
    public bool isDie = false;
    [Header("初始玩家蛇头")]
    GameObject item = null;
    public List<GameObject> effectPools = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //transform.localPosition = new Vector3(0, 30, 0);
        int random = Random.Range(0, 4);
        Config.e_Player =  (E_PlayerTrans)random;
        if (item==null)
        {
            item = Instantiate(Resources.Load<GameObject>("Prefabs/Player"),GameObject.Find("Canvas").transform);
            item.transform.localPosition = new Vector3(0,30,0);
            item.transform.tag = "Player";
            players.Add(item);
        }
    }
    public void CreatEffect() 
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject item = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), GameObject.Find("Canvas").transform);
            item.transform.tag = "Effect";
            int h_Random = Random.Range(0, H_MAX);
            int v_Random = Random.Range(0, V_MAX);
            //[-324,324] [-472,472] leftDown[-472,-324] leftUp[-472,324]  rightUp[472,324],rigthDown[472,-324]
            item.transform.localPosition = new Vector3(h_Random, v_Random, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {   

        if (!isDie&&players.Count>0)
        {
            temptimer += Time.deltaTime;
            if (temptimer >= timer)
            {
                temptimer = 0; isMove = true;
            }
            if (isMove)
            { 
                Vector3 pos = Vector3.zero;
                ///+-472,X,+-324,Y>这两个值则出界
                isMove = false; 
                switch (Config.e_Player)
                {
                    case E_PlayerTrans.up:
                        if (players[0].transform.localPosition.y >= 324)
                        {
                            print("撞到上面了");
                            isDie = true;
                        }
                        else
                        {
                            pos = players[0].transform.localPosition;
                            if (players.Count>=2)
                            {
                                for (int i = players.Count-1; i >= 1; i--)
                                {
                                    //0
                                    var temp = players[i - 1].transform.localPosition;
                                    players[i].transform.localPosition = temp;
                                }
                            }
                            //蛇头
                            
                            players[0].transform.localPosition = new Vector3(pos.x, pos.y += VALUE, pos.z);
                        }

                        break;
                    case E_PlayerTrans.down:
                        if (players[0].transform.localPosition.y <= -324)
                        {
                            isDie = true;
                            print("撞到xia面了");
                        }
                        else
                        { 
                            pos = players[0].transform.localPosition;
                            if (players.Count >= 2)
                            {
                                for (int i = players.Count - 1; i >= 1; i--)
                                {
                                    //0
                                    var temp = players[i - 1].transform.localPosition;
                                    players[i].transform.localPosition = temp;
                                }
                            }
                            //蛇头

                            players[0].transform.localPosition = new Vector3(pos.x, pos.y -= VALUE, pos.z);
                        }

                        break;
                    case E_PlayerTrans.left:
                        if (players[0].transform.localPosition.x <= -472)
                        {
                            isDie = true;
                            print("撞到zuo面了");
                        }
                        else
                        {

                            pos = players[0].transform.localPosition;
                            if (players.Count >= 2)
                            {
                                for (int i = players.Count - 1; i >= 1; i--)
                                {
                                    //0
                                    var temp = players[i - 1].transform.localPosition;
                                    players[i].transform.localPosition = temp;
                                }
                            }
                            //蛇头

                            players[0].transform.localPosition = new Vector3(pos.x -= VALUE, pos.y, pos.z); 
                           
                        }

                        break;
                    case E_PlayerTrans.right:
                        if (players[0].transform.localPosition.x >= 472)
                        {
                            isDie = true;
                            print("撞到右面了");
                        }
                        else
                        {
                            pos = players[0].transform.localPosition;
                            if (players.Count >= 2)
                            {
                                for (int i = players.Count - 1; i >= 1; i--)
                                {
                                    //0
                                    var temp = players[i - 1].transform.localPosition;
                                    players[i].transform.localPosition = temp;
                                }
                            }
                            //蛇头

                            players[0].transform.localPosition = new Vector3(pos.x += VALUE, pos.y, pos.z); 
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            //die
        }
        //向上
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Config.e_Player == E_PlayerTrans.down)
                isDie = true;
            Config.e_Player = E_PlayerTrans.up;
        }
        //向下
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Config.e_Player==E_PlayerTrans.up)
                isDie = true;
            Config.e_Player = E_PlayerTrans.down;
        }
        //向左
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        
        {if (Config.e_Player == E_PlayerTrans.right)
                isDie = true;
            Config.e_Player = E_PlayerTrans.left;
        }
        //向右
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Config.e_Player == E_PlayerTrans.left)
                isDie = true;
            Config.e_Player = E_PlayerTrans.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatPlayer();
        }
        //die
        
    }
    public void CreatPlayer() 
    {
        Vector3 tempPos = tempPos = players[players.Count - 1].transform.localPosition;
        Vector3 stemppos = Vector3.zero;
        var e_p = E_PlayerTrans.up;
        if (players.Count <= 1)
        {
            e_p = Config.e_Player;
        }
        else
        {
            e_p = E_PlayerTrans.up;
            stemppos = players[players.Count - 2].transform.localPosition;
            //纵向
            if (tempPos.x == stemppos.x)
            {
                if (tempPos.y > stemppos.y)
                {
                    e_p = E_PlayerTrans.down;
                }
                else
                {
                    e_p = E_PlayerTrans.up;
                }
            }
            //横向
            if (tempPos.y == stemppos.y)
            {
                if (tempPos.x > stemppos.x)
                {
                    e_p = E_PlayerTrans.left;
                }
                else
                {
                    e_p = E_PlayerTrans.right;
                }
            }
        }

        switch (e_p)
        {
            case E_PlayerTrans.up:
                tempPos = new Vector3(tempPos.x, players[players.Count - 1].transform.localPosition.y - VALUE, tempPos.z);
                break;
            case E_PlayerTrans.down:
                tempPos = new Vector3(tempPos.x, players[players.Count - 1].transform.localPosition.y + VALUE, tempPos.z);
                break;
            case E_PlayerTrans.left:
                tempPos = new Vector3(players[players.Count - 1].transform.localPosition.x + VALUE, tempPos.y, tempPos.z);
                break;
            case E_PlayerTrans.right:
                tempPos = new Vector3(players[players.Count - 1].transform.localPosition.x - VALUE, tempPos.y, tempPos.z);
                break;
            default:
                break;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), GameObject.Find("Canvas").transform);
            obj.transform.localPosition = tempPos;
            obj.transform.tag = "Player";
            players.Add(obj);
        }
    }
}
