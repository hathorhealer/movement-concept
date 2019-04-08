using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public int lives = 3;
    bool gameOver = false;
    public float restartDelay = 1f;
    // Start is called before the first frame update

    public void CompleteLevel() {
        Debug.Log("level 01");
    }
    public void EndGame() {
        if (gameOver == false) {
            gameOver = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
