using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 商城模块总控制器
/// </summary>
public class ShopManager : MonoBehaviour {

    private string xmlPath = "Assets/Datas/ShopData.xml";

    private int index = 0;

    private GameObject leftButton;
    private GameObject rightButton;

    private List<GameObject> shopUI = new List<GameObject>();

    //商城数据对象
    private ShopData shopData;

    //商城商品模板
    private GameObject ui_ShopItem;

	void Start () {
        ui_ShopItem = Resources.Load<GameObject>("UI/ShopItem");
        
        //按钮事件绑定
        leftButton = GameObject.Find("LeftButton");
        rightButton = GameObject.Find("RightButton");
        UIEventListener.Get(leftButton).onClick = LeftButtonClick;
        UIEventListener.Get(rightButton).onClick = RightButtonClick;

        //实例化商城数据对象
        shopData = new ShopData();
        //加载xml
        shopData.ReadXmlByPath(xmlPath);

        CreateAllShopUI();
	}

    /// <summary>
    /// 创建商城模块中所有的商品
    /// </summary>
    private void CreateAllShopUI()
    {
        for (int i = 0; i < shopData.shopList.Count; i++)
        {
            //实例化单个商品UI
            GameObject item = NGUITools.AddChild(gameObject, ui_ShopItem);

            //加载对应模型
            GameObject ship = Resources.Load<GameObject>(shopData.shopList[i].Model);

            item.GetComponent<ShopItemUI>().SetUIValue(shopData.shopList[i].Speed,
                shopData.shopList[i].Rotate, shopData.shopList[i].Price, ship);

            //将生成的UI添加到列表中，方便管理
            shopUI.Add(item);

            //只显示第一个飞机
            ShopUIHideAndShow();
        }
    }

    private void LeftButtonClick(GameObject go)
    {
        index = --index;
        if (index < 0)
        {
            index = 3;
        }
        ShopUIHideAndShow();
    }

    private void RightButtonClick(GameObject go)
    {
        index = ++index % shopUI.Count;
        ShopUIHideAndShow();
    }

    /// <summary>
    /// 只显示角标为index的飞机
    /// </summary>
    private void ShopUIHideAndShow()
    {
        for (int i = 0; i < shopUI.Count; i++)
        {
            shopUI[i].SetActive(false);
        }
        shopUI[index].SetActive(true);
    }
}
