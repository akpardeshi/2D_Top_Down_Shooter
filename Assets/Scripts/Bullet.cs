using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range (10 , 100 ) ]
    [SerializeField] float g_FloatMoveSpeed ;

    Vector3 g_TargetPosition ;

    float g_FloatDeactivationDistance ;

    [SerializeField] GameObject g_Enemy ;

    void Start()
    {
        g_TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        g_FloatDeactivationDistance = 0.15f ;
    }

    // Update is called once per frame
    void Update()
    {
        m_DeactivateBullet() ;
    }

    void m_DeactivateBullet()
    {
        if ( Vector3.Distance( this.transform.position , g_TargetPosition ) < g_FloatDeactivationDistance )
        {
            Instantiate( g_Enemy , this.transform.position , Quaternion.identity ) ; 
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        m_MoveBullet () ;
    }

    void m_MoveBullet ()
    {
        this.transform.position = Vector3.MoveTowards( this.transform.position , g_TargetPosition , g_FloatMoveSpeed * Time.fixedDeltaTime );
    }
}
