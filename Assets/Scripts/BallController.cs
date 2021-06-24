using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject GameBar;
    private bool isGameStart = false;
    private Vector3 ballAndBarDistance;
    private AudioSource jumpAudioSource;
    private AudioSource breakAudioSource;
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        jumpAudioSource = sources[0];
        breakAudioSource = sources[1];
        ballAndBarDistance = gameObject.transform.position - GameBar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart)
        {
            transform.position = GameBar.transform.position + ballAndBarDistance;
            if (Input.GetMouseButtonDown(0))
            {
                isGameStart = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10f, 10f), 12f);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bar"))
        {
            jumpAudioSource.Play();
            Vector3 barPosition = collision.gameObject.transform.position;
            if(barPosition.x < transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(3f, 0f);
            } else
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(-3f, 0f);
            }
        } else if(collision.gameObject.CompareTag("Block"))
        {
            if(collision.gameObject.GetComponent<BlockController>().power <= 1)
            {
                Debug.Log("Break Audio");
                breakAudioSource.Play();
            } else
            {
                Debug.Log("Jump Audio");
                jumpAudioSource.Play();
            }
            GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
    }
}
