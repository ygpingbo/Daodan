using UnityEngine;
using System.Collections;

/// <summary>
/// 导弹控制脚本
/// </summary>
public class Missile : MonoBehaviour {

    private Transform m_Transform;
    private Transform player_Transform;
    private GameObject prefab_Nuke;

    //private Vector3 normalForward = Vector3.forward;    //导弹默认前方

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        prefab_Nuke = Resources.Load<GameObject>("Multi");
        player_Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update () {
        m_Transform.Translate(Vector3.forward * 0.8f);
        m_Transform.LookAt(player_Transform.position);

        /*//导弹追击
        //导弹与飞机间的向量
        Vector3 dir = player_Transform.position - m_Transform.position;
        //插值获取导弹正前方
        normalForward = Vector3.Lerp(normalForward, dir, Time.deltaTime);
        //改变导弹正前方
        m_Transform.rotation = Quaternion.LookRotation(normalForward);*/
	}

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Missile")
        {
            GameObject.Instantiate(prefab_Nuke, m_Transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
