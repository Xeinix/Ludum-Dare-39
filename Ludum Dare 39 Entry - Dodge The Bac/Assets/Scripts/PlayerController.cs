using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 5;
    public float energy = 100;

    private Rigidbody2D rb;
    private float movementH = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("PlayerController Running");
        InvokeRepeating("RemoveEnergy", 2, .5f);
    }

    private void FixedUpdate()
    {
        MovePlayer();
        
        if (energy > 100)
        {
            energy = 100;
        }

    }

    void RemoveEnergy()
    {
        energy -= 1f;
    }

    public void AddEnergy()
    {
        energy += 50;
    }

    private void MovePlayer()
    {
        movementH = 0;

        if (Input.GetAxis("Horizontal") >= 0.5 || Input.GetAxis("Horizontal") <= -0.5)
        {
            movementH = Input.GetAxis("Horizontal") * speed;
            // Debug.Log("Attempting to move player horizontally." + movementH.ToString() );            
        }

        /* Debug Purposes Only! Remove when releasing!
        if (Input.GetButtonDown("Fire1"))
        {
            energy += 10;
        }
        */
        rb.velocity = new Vector2(movementH, 0);
    }

}
