using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int power;
    public GameObject effect;

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            power--;
            if(power <= 0)
            {
                GameObject createdEffect = Instantiate(effect, transform.position, Quaternion.identity);
                createdEffect.GetComponent<ParticleSystem>().startColor = transform.GetComponent<SpriteRenderer>().color;
                Destroy(gameObject);
            }
        }
    }
}
