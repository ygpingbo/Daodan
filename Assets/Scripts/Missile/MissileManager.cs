using UnityEngine;
using System.Collections;

/// <summary>
/// 导弹生成器
/// </summary>
public class MissileManager : MonoBehaviour {

    private Transform m_Transform;
    private Transform[] createPoints;
    private GameObject missile_Prefab;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        createPoints = GameObject.Find("CreatePoints").GetComponent<Transform>().GetComponentsInChildren<Transform>();
        missile_Prefab = Resources.Load<GameObject>("Missile_3");
        
        //调用生成导弹
        InvokeRepeating("CreateMissile", 3, 5);
    }
	
	void Update () {
	    
	}

    /// <summary>
    /// 导弹生成
    /// </summary>
    private void CreateMissile()
    {
        int index = Random.Range(0, createPoints.Length);
        GameObject.Instantiate(missile_Prefab, createPoints[index].position, Quaternion.identity, m_Transform);
    }

    /// <summary>
    /// 停止导弹生成
    /// </summary>
    public void StopCreate()
    {
        CancelInvoke();
    }

    public void Reset()
    {
        GameObject[] Missiles = GameObject.FindGameObjectsWithTag("Missile");
        for (int i = 0; i < Missiles.Length; i++)
        {
            GameObject.Destroy(Missiles[i]);
        }
    }
}
