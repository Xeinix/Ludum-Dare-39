using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CountdownManager : MonoBehaviour {

    public int gameScene;
    public TextMeshProUGUI countdown;
    public AudioClip main;
    public AudioClip fin;

    private AudioSource asou;
    private int secconds = 3;

	void Start () {
        Debug.Log("CountdownManager Started.");
        asou = GetComponent<AudioSource>();
        InvokeRepeating("Countdown", 0, 1);
	}


    void Countdown()
    {
        if (secconds != -1) {
            countdown.text = secconds.ToString();
            asou.PlayOneShot(main);
            secconds--;
        }
        else
        {
            asou.PlayOneShot(fin);
            SceneManager.LoadScene(gameScene);
        }
    }
}
