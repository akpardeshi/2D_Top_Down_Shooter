using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject [] g_SpawnPoints ;

    float g_FloatWaitTime;

    [Range ( 0, 10.0f )]
    [SerializeField] float g_FloatTimeBetweenSpawn ;
    float g_FloatCurrentTimer ;

    float g_FloatMinWaitTime;

    [SerializeField] GameObject g_Enemy ;
    float g_FloatDecrementInTime;

    int g_IntSpawnPointCount ;

    void Awake()
    {
        g_SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    void Start()
    {
        g_FloatCurrentTimer = g_FloatTimeBetweenSpawn ;
        g_IntSpawnPointCount = g_SpawnPoints.Length - 1 ;
        g_FloatWaitTime = 90.0f;
        g_FloatMinWaitTime = 2.0f;
        g_FloatDecrementInTime = 0.5f;
        StartCoroutine( m_ManageSpawning() );
    }

    // Update is called once per frame
    void Update()
    {
        m_ManageTime () ;
    }

    void m_ManageTime ()
    {
        g_FloatCurrentTimer -= Time.deltaTime ;

        if ( g_FloatCurrentTimer <= 0 )
        {
            m_InstantiateEnemy () ;

            g_FloatCurrentTimer = g_FloatTimeBetweenSpawn ;
        }
    }

    void m_InstantiateEnemy ()
    {
        int l_IntRandom = Random.Range( 0 , g_IntSpawnPointCount );

        Instantiate (g_Enemy , g_SpawnPoints[ l_IntRandom].transform.position , Quaternion.identity ) ;
    }

    IEnumerator m_ManageSpawning()
    {
        yield return new WaitForSeconds(g_FloatWaitTime);

        if ( g_FloatCurrentTimer >= g_FloatMinWaitTime )
        {
            g_FloatCurrentTimer -= g_FloatDecrementInTime;
            StartCoroutine( m_ManageSpawning() );
        }
    }
}
