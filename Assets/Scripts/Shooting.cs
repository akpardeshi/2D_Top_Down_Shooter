using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject g_Bullet ;

    Transform g_PlayerTransform ;

    // Start is called before the first frame update
    void Awake()
    {
        g_PlayerTransform = this.transform ;
    }

    // Update is called once per frame
    void Update()
    {
        m_Shoot () ;
    }

    void m_Shoot ()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            Instantiate ( g_Bullet , g_PlayerTransform.position , Quaternion.identity ) ;
        }
    }
}
