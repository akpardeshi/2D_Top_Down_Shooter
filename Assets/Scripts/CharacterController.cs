using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
using UnityEngine.UI ;

public class CharacterController : MonoBehaviour
{
    [Range ( 10 , 100 )]
    [SerializeField] float g_FloatMoveSpeed ;
    Rigidbody2D g_Rigidbody ;

    [SerializeField] Text g_HealthText ;
    [SerializeField] Text g_ScoreText;

    Vector3 g_PlayerMovement ;

    [SerializeField] int g_IntHealth ;
    int g_IntPlayerScore;

    void Awake ()
    {
        g_Rigidbody = this.GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("PlayerScore", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        g_IntHealth = 10 ;
        g_HealthText.text = "HEALTH : " + g_IntHealth.ToString();
        g_ScoreText.text = "SCORE : " + g_IntPlayerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        m_GetInput () ;

        m_ReloadScene() ;
    }

    void m_GetInput ()
    {
        g_PlayerMovement.x = Input.GetAxis("Horizontal");
        g_PlayerMovement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        m_MovePlayer() ;
    }

    void m_MovePlayer()
    {
        g_Rigidbody.MovePosition ( this.transform.position + g_PlayerMovement * Time.fixedDeltaTime * g_FloatMoveSpeed ) ;
    }

    public void m_ReduceHealth ()
    {
        --g_IntHealth;
        g_HealthText.text = "HEALTH : " + g_IntHealth.ToString();
    }

    public void m_IncreaseScore()
    {
        g_IntPlayerScore++;
        PlayerPrefs.SetInt("PlayerScore", g_IntPlayerScore);
        g_ScoreText.text = "SCORE : " + g_IntPlayerScore.ToString();
    }

    void m_ReloadScene()
    {
        if ( g_IntHealth <= 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
