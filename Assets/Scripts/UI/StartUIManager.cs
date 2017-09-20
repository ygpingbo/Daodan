using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 开始界面UI
/// </summary>
public class StartUIManager : MonoBehaviour {

    private GameObject m_StartPanel;
    private GameObject m_SettingPanel;

	void Start () {
        m_StartPanel = GameObject.Find("StartPanel");
        m_SettingPanel = GameObject.Find("SettingPanel");

        m_SettingPanel.SetActive(false);
	}
	
	void Update () {
	
	}

    public void OpenSettingPanel()
    {
        if (m_SettingPanel.activeSelf == false)
        {
            m_SettingPanel.SetActive(true);
        }
    }

    public void CloseSettingPanel()
    {
        m_SettingPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
