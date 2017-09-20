using UnityEngine;
using System.Collections;

/// <summary>
/// 商城Item控制器
/// </summary>
public class ShopItemUI : MonoBehaviour {

    private Transform m_Transform;

    private UILabel ui_Speed;
    private UILabel ui_Rotate;
    private UILabel ui_Price;
    private GameObject shipParent;  //飞机模型的父物体

    private GameObject buyButton;

    //提前查找完毕
	void Awake () {
        m_Transform = gameObject.GetComponent<Transform>();

        ui_Speed = m_Transform.FindChild("speed/speedValue").GetComponent<UILabel>();
        ui_Rotate = m_Transform.FindChild("rotate/rotateValue").GetComponent<UILabel>();
        ui_Price = m_Transform.FindChild("buyButton/price").GetComponent<UILabel>();
        shipParent = m_Transform.FindChild("model").gameObject;

        buyButton = m_Transform.FindChild("buyButton/bg").gameObject;
        UIEventListener.Get(buyButton).onClick = BuyButtonClick;
    }

    /// <summary>
    /// 给商品UI赋值
    /// </summary>
    public void SetUIValue(string speed, string rotate, string price, GameObject shipModel)
    {
        //给UI元素赋值
        ui_Speed.text = speed;
        ui_Rotate.text = rotate;
        ui_Price.text = price;

        //实例化飞机模型，设置相关细节参数
        GameObject ship = NGUITools.AddChild(shipParent, shipModel);
        Transform ship_Transform = ship.GetComponent<Transform>();
        ship.layer = 8; //设置模型所属的层为NGUI层
        ship_Transform.FindChild("Mesh").gameObject.layer = 8;  //给子物体设置为NGUI层
        
        //设置飞机模型的缩放位置信息
        //缩放
        if (shipModel.name == "Ship_4")
        {
            ship_Transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);               //缩放
        }
        else
        {
            ship_Transform.localScale = new Vector3(5, 5, 5);           
        }
        ship_Transform.localPosition = new Vector3(23.2f, 45, 200);     //位置
        Vector3 shipRotate = new Vector3(-90, 0, 0);
        ship_Transform.localRotation = Quaternion.Euler(shipRotate);    //旋转
    }

    /// <summary>
    /// 购买按钮单击事件
    /// </summary>
    /// <param name="go"></param>
    private void BuyButtonClick(GameObject go)
    {
        Debug.Log("buy");
    }
}
