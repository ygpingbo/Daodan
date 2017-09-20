using UnityEngine;
using System.Collections;
using System.Xml;

/// <summary>
/// XML操作演示
/// </summary>
public class XMLDemo : MonoBehaviour {

    //xml路径
    private string xmlPath = "Assets/Datas/web.xml"; 

	void Start () {
        ReadXMLByPath(xmlPath);
	}
	
	void Update () {
	
	}

    /// <summary>
    /// 通过路径读取XML中的数据
    /// </summary>
    /// <param name="path"></param>
    private void ReadXMLByPath(string path)
    {
        //1.实例化XML文档操作对象
        XmlDocument doc = new XmlDocument();
       
        //2.使用XML对象加载XML
        doc.Load(path);

        //3.获取根节点
        XmlNode root = doc.SelectSingleNode("Web");

        //4.获取根节点下所有子节点
        XmlNodeList nodeList = root.ChildNodes;

        //5.遍历输出
        foreach(XmlNode node in nodeList)
        {
            int id = int.Parse(node.Attributes["id"].Value);
            string name = node.ChildNodes[0].InnerText;
            string url = node.ChildNodes[1].InnerText;

            Debug.Log(id + "--" + name + "--" + url);
        }
    }
}
