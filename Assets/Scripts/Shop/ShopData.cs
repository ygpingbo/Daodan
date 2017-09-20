using System.Collections;
using System.Collections.Generic;
using System.Xml;

/// <summary>
/// 商城功能模块数据操作
/// </summary>
public class ShopData {
    //存储xml数据实体集合
    public List<ShopItem> shopList = new List<ShopItem>();

    /// <summary>
    /// 通过路径读取xml文档
    /// </summary>
    /// <param name="path"></param>
    public void ReadXmlByPath(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("Shop");
        XmlNodeList nodeList = root.ChildNodes;
        foreach(XmlNode node in nodeList)
        {
            string speed = node.ChildNodes[0].InnerText;
            string rotate = node.ChildNodes[1].InnerText;
            string model = node.ChildNodes[2].InnerText;
            string price = node.ChildNodes[3].InnerText;

            //string info = string.Format("speed:{0},rotate:{1},model:{2},price:{3}", speed, rotate, model, price);
            //Debug.Log(info);

            //存储到List实体集合中
            ShopItem item = new ShopItem(speed, rotate, model, price);
            shopList.Add(item);
        }
    }
}
