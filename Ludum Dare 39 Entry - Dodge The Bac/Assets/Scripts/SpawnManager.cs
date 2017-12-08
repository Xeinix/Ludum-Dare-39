using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public float repeatingTime = 5;
    public float timeLimit = 100;
    [Space]
    public GameObject prefabBox;
    public GameObject prefabBattery;
    public GameObject prefabCounter;
    [Space]
    public GameObject[] spawnPoints;
    [Space]
    public GameObject[] prefabClouds;
    public GameObject[] spawnClouds;

    private GameObject newCloud;

	void Start () {
        Debug.Log("BoxManager Started");
        InvokeRepeating("MakeItHarder", 0, timeLimit);
        StartGame();
	}

    void SpawnBoxes()
    {
        int missingNumber = Random.Range(0, 4);
        Debug.Log("IEnumerator SpawnBoxes() Running");
        // Debug.Log(missingNumber.ToString());
        #region Spawn Boxes
        if (missingNumber != 0)
        {
            Instantiate(prefabBox, spawnPoints[0].transform.position, spawnPoints[0].transform.rotation);
        }
        if (missingNumber != 1)
        {
            Instantiate(prefabBox, spawnPoints[1].transform.position, spawnPoints[1].transform.rotation);
        }
        if (missingNumber != 2)
        {
            Instantiate(prefabBox, spawnPoints[2].transform.position, spawnPoints[3].transform.rotation);
        }
        if (missingNumber != 3)
        {
            Instantiate(prefabBox, spawnPoints[3].transform.position, spawnPoints[3].transform.rotation);
        }
        if (missingNumber != 4)
        {
            Instantiate(prefabBox, spawnPoints[4].transform.position, spawnPoints[4].transform.rotation);
        }
        #endregion

        #region Spwan Counter
        if (missingNumber == 0)
        {
            Instantiate(prefabCounter, spawnPoints[0].transform.position, spawnPoints[0].transform.rotation);
        }
        if (missingNumber == 1)
        {
            Instantiate(prefabCounter, spawnPoints[1].transform.position, spawnPoints[1].transform.rotation);
        }
        if (missingNumber == 2)
        {
            Instantiate(prefabCounter, spawnPoints[2].transform.position, spawnPoints[3].transform.rotation);
        }
        if (missingNumber == 3)
        {
            Instantiate(prefabCounter, spawnPoints[3].transform.position, spawnPoints[3].transform.rotation);
        }
        if (missingNumber == 4)
        {
            Instantiate(prefabCounter, spawnPoints[4].transform.position, spawnPoints[4].transform.rotation);
        }
        #endregion
    }

    void SpawnBattery()
    {
        int number1 = Random.Range(0, 2);
        int number2 = Random.Range(0, 2);
        int spawnNumber = Random.Range(0,4);
        Debug.Log("I'm being called!");

        if (number1 == number2) {

            Debug.Log("Spawning at " + spawnNumber.ToString());

            if (spawnNumber == 0)
            {
                Instantiate(prefabBattery, spawnPoints[0].transform.position, spawnPoints[0].transform.rotation);
            }
            if (spawnNumber == 1)
            {
                Instantiate(prefabBattery, spawnPoints[1].transform.position, spawnPoints[1].transform.rotation);
            }
            if (spawnNumber == 2)
            {
                Instantiate(prefabBattery, spawnPoints[2].transform.position, spawnPoints[3].transform.rotation);
            }
            if (spawnNumber == 3)
            {
                Instantiate(prefabBattery, spawnPoints[3].transform.position, spawnPoints[3].transform.rotation);
            }
            if (spawnNumber == 4)
            {
                Instantiate(prefabBattery, spawnPoints[4].transform.position, spawnPoints[4].transform.rotation);
            }

        }
    }
	
    void SpawnClouds()
    {
        int rand1 = Random.Range(0, 1);
        int rand2 = Random.Range(0, 1);

        int spawnNumber = Random.Range(0, 8);
        int cloudNumber = Random.Range(0, 2);

        if (rand1 == rand2)
        {

            newCloud = Instantiate(prefabClouds[cloudNumber], spawnClouds[spawnNumber].transform.position, spawnClouds[spawnNumber].transform.rotation);
            // StartCoroutine(CheckRender(newCloud));

        }
    }

    void MakeItHarder()
    {
        repeatingTime -= .5f;
        if (repeatingTime < 1)
        {
            repeatingTime = 1;
        }
        CancelInvoke("SpawnBoxes");
        CancelInvoke("SpawnBattery");
        CancelInvoke("SpawnClouds");
        StartGame();

    }

    private void StartGame()
    {
        InvokeRepeating("SpawnBoxes", 2, repeatingTime);
        InvokeRepeating("SpawnBattery", 4.5f, repeatingTime);
        InvokeRepeating("SpawnClouds", 0, .5f);

    }


}
