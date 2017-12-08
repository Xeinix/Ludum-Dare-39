using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int sceneMainMenu = 0;
    public int sceneDeath = 2;

	void Start () {
        Debug.Log("GameManager Started");
	}

    public void EndGame(string reason, int score)
    {
        PlayerPrefs.SetString("reason", reason);
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene(sceneDeath);
    }
	

}
