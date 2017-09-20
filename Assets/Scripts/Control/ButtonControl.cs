using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

    private GameObject left;
    private GameObject right;

    private Ship m_Ship;

	void Start () {
        left = GameObject.Find("left");
        right = GameObject.Find("right");

        m_Ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Ship>();

        UIEventListener.Get(left).onPress = LeftPress;
        UIEventListener.Get(right).onPress = RightPress;
	}

    private void LeftPress(GameObject go, bool isPress)
    {
        if (isPress)
        {
            m_Ship.IsLeft = true;
        }
        else
        {
            m_Ship.IsLeft = false;
        }
    }

    private void RightPress(GameObject go, bool isPress)
    {
        if (isPress)
        {
            m_Ship.IsRight = true;
        }
        else
        {
            m_Ship.IsRight = false;
        }
    }
}
