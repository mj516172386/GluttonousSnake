using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour
{
    public string tag = "Player";
    /// <summary>
    ///// ���ռ��ÿ�����ӵĲ�ֵ
    ///// </summary>
    //const int VALUE = 59;
    ///// <summary>
    ///// �������������������ʼ����Ϊ0��
    ///// </summary>
    //const int H_MAX = 17;
    ///// <summary>
    ///// ��������������������ʼ����Ϊ30
    ///// </summary>
    //const int V_MAX = 12;
    //const float timer = 0.5f;
    //float temptimer = 0;
    //bool isMove=false;
    //bool isDie = false;
    // Start is called before the first frame update
    void Start()
    {
        //transform.localPosition = new Vector3(0,30,0);
        //int random = Random.Range(0,4);
        //Config.e_Player = (E_PlayerTrans)random;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==tag)
        {
            GameManager.instance.isDie = true;
            print("die");
        }
        if (other.tag== "Effect")
        {
            Destroy(other.gameObject);
            GameManager.instance.CreatPlayer();
        }
    } 
    // Update is called once per frame
    void Update()
    {
        //if (!isDie) 
        //{
        //    temptimer += Time.deltaTime;
        //    if (temptimer >= timer)
        //    {
        //        temptimer = 0; isMove = true;
        //    }
        //    if (isMove)
        //    {
        //        Vector3 pos = Vector3.zero;
        //        ///+-472,X,+-324,Y>������ֵ�����
        //        isMove = false;
        //        if (Mathf.Abs(transform.localPosition.x)>= 472&&Config.e_Player==E_PlayerTrans.left||Config.e_Player==E_PlayerTrans.right)
        //        {

        //        }
        //        switch (Config.e_Player)
        //        {
        //            case E_PlayerTrans.up:
        //                if (transform.localPosition.y>=324)
        //                {
        //                    print("ײ��������");
        //                    isDie = true;
        //                }
        //                else
        //                {
        //                    pos= transform.localPosition;
        //                    transform.localPosition = new Vector3(pos.x, pos.y += VALUE, pos.z);
        //                }
                       
        //                break;
        //            case E_PlayerTrans.down:
        //                if (transform.localPosition.y <= -324)
        //                {
        //                    isDie = true;
        //                    print("ײ��xia����");
        //                }
        //                else
        //                {
        //                    pos = transform.localPosition;
        //                    transform.localPosition = new Vector3(pos.x, pos.y -= VALUE, pos.z);
        //                }
                     
        //                break;
        //            case E_PlayerTrans.left:
        //                if (transform.localPosition.x <= -472)
        //                {
        //                    isDie = true;
        //                    print("ײ��zuo����");
        //                }
        //                else
        //                {
        //                    pos = transform.localPosition;
        //                    transform.localPosition = new Vector3(pos.x -= VALUE, pos.y, pos.z);
        //                }
                       
        //                break;
        //            case E_PlayerTrans.right:
        //                if (transform.localPosition.x >= 472)
        //                {
        //                    isDie = true;
        //                    print("ײ��������");
        //                }
        //                else
        //                {
        //                    pos = transform.localPosition;
        //                    transform.localPosition = new Vector3(pos.x += VALUE, pos.y, pos.z);
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
        //else
        //{ 
        //    //die
        //}
        ////����
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    Config.e_Player = E_PlayerTrans.up;
        //}
        ////����
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    Config.e_Player = E_PlayerTrans.down;
        //}
        ////����
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    Config.e_Player = E_PlayerTrans.left;
        //}
        ////����
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    Config.e_Player = E_PlayerTrans.right;
        //}
    }
}
