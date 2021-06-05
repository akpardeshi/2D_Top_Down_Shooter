using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text g_ScoreMessage;

    void Awake() 
    {
        g_ScoreMessage.text = "Your Score is : " + PlayerPrefs.GetInt("PlayerScore").ToString();
    }

    public void m_RestartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void m_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
