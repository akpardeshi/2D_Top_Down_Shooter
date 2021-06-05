using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range ( 0 , 100 )]
    [SerializeField] float g_FloatMoveSpeed ;
    Rigidbody2D g_Rigidbody ;

    Transform g_PlayerTransform ;

    CharacterController g_Player ;

    [SerializeField] GameObject g_ParticleSystem ;

    // Start is called before the first frame update
    void Awake()
    {
        g_Rigidbody = this.GetComponent<Rigidbody2D>();    
        g_PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        g_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards( this.transform.position , g_PlayerTransform.position, g_FloatMoveSpeed * Time.deltaTime );    
    }

    void OnTriggerEnter2D( Collider2D collider )
    {
        switch ( collider.gameObject.tag )
        {
            case "Player" :
                g_Player.m_ReduceHealth () ;
                break ;

            case "Bullet" :
                g_Player.m_IncreaseScore();
                Destroy(collider.gameObject);
                Destroy(this.gameObject);
                break ;
        }

        Instantiate( g_ParticleSystem , this.transform.position , Quaternion.identity );
    }
}
