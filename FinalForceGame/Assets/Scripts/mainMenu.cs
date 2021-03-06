using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        EnemyController.enemykilledScore = 0;
        EnemyController.movenextlevel = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        EnemyController.enemykilledScore = 0;
        EnemyController.movenextlevel = false;
    }

    public void FullRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        EnemyController.enemykilledScore = 0;
        EnemyController.movenextlevel = false;
    }
}
