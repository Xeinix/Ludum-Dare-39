using UnityEngine.SceneManagement;
using UnityEngine;

public class ColliderController : MonoBehaviour {

    public int sceneBuildIndex = 1;
    public bool collisionCheck = true;
    public GameManager gm;
    [Space]
    public AudioClip soundBox;
    public AudioClip soundBattery;

    private AudioSource asou;
    private PlayerControllerRevamped pc;

	void Start () {
        Debug.Log("ColliderController Running.");
        pc = GetComponent<PlayerControllerRevamped>();
        asou = GetComponent<AudioSource>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Coin")
        {
            Debug.Log("Picked up a coin.");
            Destroy(collision.gameObject);
        }

        if (collisionCheck) {
            if (collision.transform.tag == "Box")
            {
                asou.PlayOneShot(soundBox);
                gm.EndGame("You hit your head a litle too hard.", pc.score);
                Debug.Log("You Hit A Box!");
            }
        }

        if (collision.transform.tag == "Battery")
        {
            asou.PlayOneShot(soundBattery);
            Destroy(collision.gameObject);
            pc.AddEnergy();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Somthing triggered me!");

        if (collision.transform.tag == "Counter") pc.score++;
        Destroy(collision.gameObject);

    }
}
