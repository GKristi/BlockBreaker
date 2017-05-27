using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
	}	
	
	void Update () {
        if (!hasStarted)
        {   // Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for a mouse press to launch
            if (Input.GetMouseButtonDown(0))
            {  hasStarted = true;
                Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
                rigidbody2D.velocity = new Vector2(2f, 10f);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);

        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            playSound(collision);
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity += tweak;
        }
    }

    private void playSound(Collision2D collision)
    {
        string name = collision.gameObject.name;
        if (name != "Paddle" && !name.Contains("Wall"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
