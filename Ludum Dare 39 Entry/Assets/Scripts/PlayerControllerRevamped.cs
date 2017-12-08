using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRevamped : MonoBehaviour {

    public float energy = 100;
    public GameObject[] positionPoints;
    public int currPositionPoint = 2;
    public GameManager gm;

    public int score;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("RemoveEnergy", 2, .5f);
    }


    private void Update()
    {
        CheckInput();
        MovePlayer();
        CheckEnergy();

        if (energy > 50)
        {
            energy = 50;
        }

    }

    void RemoveEnergy()
    {
        energy -= 1f;
    }

    public void AddEnergy()
    {
        energy += 15;
    }

    void CheckEnergy()
    {
        if (energy < 1)
        {
            Debug.Log("GameOver");
            gm.EndGame("You ran out of battery, should have picked up a charge.", score);
        }
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currPositionPoint -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currPositionPoint += 1;
        }

        if (currPositionPoint < 0) { currPositionPoint = 0; }
        if (currPositionPoint > 4) { currPositionPoint = 4; }

        Debug.Log(currPositionPoint.ToString());
    }

    public void TapLeft()
    {
        currPositionPoint -= 1;
        if (currPositionPoint < 0) { currPositionPoint = 0; }
        if (currPositionPoint > 4) { currPositionPoint = 4; }
    }

    public void TapRight()
    {
        currPositionPoint += 1;
        if (currPositionPoint < 0) { currPositionPoint = 0; }
        if (currPositionPoint > 4) { currPositionPoint = 4; }
    }

    void MovePlayer()
    {
        transform.position = positionPoints[currPositionPoint].transform.position;
    }
}
