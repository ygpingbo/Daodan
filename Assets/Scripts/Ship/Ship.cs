using UnityEngine;
using System.Collections;

/// <summary>
/// 飞机控制器脚本
/// </summary>
public class Ship : MonoBehaviour {

    private Transform m_transform;
    private GameObject prefab_Nuke;

    private MissileManager m_MissileManager;
    private RewardManager m_RewardManager;
    private GameUIManager m_GameUIManager;

    private bool isLeft = false;
    private bool isRight = false;

    private int speed = 1;
    private int rotateSpeed = 1;
    private bool isDeath = false;

    private int rewardNum = 0;      //本局获得奖励物品数量
    private int time_Minute = 0;    //本局游戏时间（分钟）
    private int time_Second = 0;    //本局游戏时间（秒）

	void Start () {
        m_transform = gameObject.GetComponent<Transform>();
        prefab_Nuke = Resources.Load<GameObject>("Multi");

        m_MissileManager = GameObject.Find("MissileManager").GetComponent<MissileManager>();
        m_RewardManager = GameObject.Find("RewardManager").GetComponent<RewardManager>();
        m_GameUIManager = GameObject.Find("UI Root").GetComponent<GameUIManager>();

        InvokeRepeating("UpdateTime", 1, 1);
    }
	
	void Update () {
        if (isDeath == false)
        {
            ShipRotate();
            m_transform.Translate(Vector3.forward * speed);
            m_GameUIManager.UpdateScoreLable(rewardNum);
        }
        else
        {
            m_MissileManager.Reset();
            m_RewardManager.Reset();
            CancelInvoke("UpdateTime");
        }
	}

    /// <summary>
    /// 飞机旋转
    /// </summary>
    private void ShipRotate()
    {
        if (isLeft)
        {
            m_transform.Rotate(Vector3.up * -rotateSpeed);
        }

        if (isRight)
        {
            m_transform.Rotate(Vector3.up * rotateSpeed);
        }
    }

    public bool IsLeft
    {
        get { return isLeft; }
        set { isLeft = value; }
    }

    public bool IsRight
    {
        get { return isRight; }
        set { isRight = value; }
    }

    /// <summary>
    /// 碰撞
    /// </summary>
    /// <param name="coll"></param>
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Border")
        {
            isDeath = true;
            m_MissileManager.StopCreate();
            GameObject.Instantiate(prefab_Nuke, m_transform.position, Quaternion.identity);
            m_GameUIManager.GameOver();
        }

        if (coll.tag == "Missile")
        {
            isDeath = true;
            m_MissileManager.StopCreate();
            m_RewardManager.StopCreate();
            GameObject.Instantiate(prefab_Nuke, m_transform.position, Quaternion.identity);
            GameObject.Destroy(coll.gameObject);
            m_GameUIManager.GameOver();
        }

        if (coll.tag == "Reward")
        {
            rewardNum += 10;
            m_RewardManager.RewardCountDown();
            GameObject.Destroy(coll.gameObject);
        }
    }

    /// <summary>
    /// 重置游戏
    /// </summary>
    public void ResetAll()
    {
        m_transform.position = Vector3.zero;
        m_transform.rotation = Quaternion.LookRotation(Vector3.zero);
        isDeath = false; 
        rewardNum = 0;
    }

    /// <summary>
    /// 更新时间
    /// </summary>
    private void UpdateTime()
    {
        if (time_Minute <= 59)
        {
            time_Second += 1;
            if (time_Second >= 60)
            {
                time_Minute++;
                time_Second = 0;
            }
        }
        m_GameUIManager.UpdateTimeLable(time_Minute, time_Second);
    }
}
