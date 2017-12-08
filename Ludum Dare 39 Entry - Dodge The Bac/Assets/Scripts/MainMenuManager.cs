using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{

    public int sceneBuildIndex;
    private AudioSource source;
    public Animator anim;
    private bool isLoading = false;

    void Start()
    {
        Debug.Log("MainMenuManager Loaded.");
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isLoading == false)
        {
            isLoading = true;
            anim.SetBool("isLoading", true);
            StartCoroutine(Enter());
        }
    }

    IEnumerator Enter()
    {
        source.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void OnTap()
    {
        if (isLoading == false)
        {
            isLoading = true;
            anim.SetBool("isLoading", true);
            StartCoroutine(Enter());
        }   
    }

}
