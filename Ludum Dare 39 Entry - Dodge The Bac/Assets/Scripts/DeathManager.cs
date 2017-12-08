using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DeathManager : MonoBehaviour {

    public TextMeshProUGUI textReason;
    public TextMeshProUGUI textScore;

	// Use this for initialization
	void Start () {
        textReason.text = PlayerPrefs.GetString("reason");
        textScore.text = "You passed " + PlayerPrefs.GetInt("score") + " rows.";
	}
	    
    public void Tap()
    {
        SceneManager.LoadScene(1);
    }

}
