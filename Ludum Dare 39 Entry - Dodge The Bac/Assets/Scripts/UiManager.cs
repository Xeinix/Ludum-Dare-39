using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour {

    public Slider powerBar;
    public TextMeshProUGUI boxesPassed;
    public PlayerControllerRevamped player;

	void Start () {
        Debug.Log("UiManager Running");
	}
	
	// Update is called once per frame
	void Update () {
        powerBar.value = player.energy;
        boxesPassed.text = "Rows Survived: " + player.score;
	}
}
