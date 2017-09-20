using UnityEngine;
using System.Collections;

/// <summary>
/// 管理奖励物品
/// </summary>
public class RewardManager : MonoBehaviour {

    private Transform m_Transform;
    private GameObject prefab_Reward;

    private int rewardCount = 0;
    private int rewardMaxCount = 3;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        prefab_Reward = Resources.Load<GameObject>("reward");
        InvokeRepeating("CreateReward", 3, 3);
    }

    /// <summary>
    /// 生成奖励物品
    /// </summary>
    private void CreateReward()
    {
        if (rewardCount < rewardMaxCount)
        {
            Vector3 pos = new Vector3(Random.Range(-400, 1000), 0, Random.Range(-300, 700));
            GameObject.Instantiate(prefab_Reward, pos, Quaternion.identity, m_Transform);
            rewardCount++;
        }
    }

    /// <summary>
    /// 停止奖励物品生成
    /// </summary>
    public void StopCreate()
    {
        CancelInvoke("CreateReward");
    }

    public void RewardCountDown()
    {
        rewardCount--;
    }

    public void Reset()
    {
        GameObject[] Rewards = GameObject.FindGameObjectsWithTag("Reward");

        for (int j = 0; j < Rewards.Length; j++)
        {
            GameObject.Destroy(Rewards[j]);
        }
        rewardCount = 0;
    }
}
