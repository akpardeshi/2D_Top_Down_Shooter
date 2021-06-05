using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        m_FollowMouse();
    }

    void m_FollowMouse()
    {
        Vector3 l_CursorPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        l_CursorPosition.z = 0.0f;
        this.transform.position = l_CursorPosition;
    }
}
