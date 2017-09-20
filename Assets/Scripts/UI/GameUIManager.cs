using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {

    private GameObject m_GamePanel;
    private GameObject m_OverPanel;
    private GameObject m_ButtonControl; //控制器

    private UILabel label_Score;
    private UILabel label_Time;

    private Ship m_Ship;

	void Start () {
        m_GamePanel = GameObject.Find("GamePanel");
        m_OverPanel = GameObject.Find("OverPanel");
        m_Ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Ship>();
        m_ButtonControl = GameObject.Find("ButtonControl");

        label_Score = GameObject.Find("starNum1").GetComponent<UILabel>();
        label_Time = GameObject.Find("time").GetComponent<UILabel>();
        label_Score.text = "0";
        label_Time.text = "0:00";

        m_OverPanel.SetActive(false);
	}

    public void GameOver()
    {
        m_ButtonControl.SetActive(false);
        m_OverPanel.SetActive(true);
        CancelInvoke("UpdateTimeLable");
    }

    public void ResetGame()
    { 
        SceneManager.LoadScene("Start");
        //m_ButtonControl.SetActive(true);
        //m_OverPanel.SetActive(false);
        //m_Ship.ResetAll();
    }

    /// <summary>
    /// 更新分数
    /// </summary>
    public void UpdateScoreLable(int score)
    {
        label_Score.text = score + "";
    }

    /// <summary>
    /// 更新时间
    /// </summary>
    public void UpdateTimeLable(int time_Minute, int time_Second)
    {
        string second;

        if (time_Second < 10)
        {
            second = ":0" + time_Second;
        }
        else
        {
            second = ":" + time_Second;
        }
        label_Time.text = time_Minute + second;
    }
}
