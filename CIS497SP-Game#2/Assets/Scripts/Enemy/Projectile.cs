/* (Ashton Lively) 
 * (Projectile) 
 * (Project 6) 
 * (Holds all the values of the projectile and makes it move and deal damage) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timeLimit = 4f;
    private float fadeTime = 3.2f;

    private float speed = 25f;

    private void Awake()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float currTime = 0;
        while (currTime <= timeLimit)
        {
            currTime += Time.deltaTime;
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (currTime >= fadeTime)
            {
                float alphaNew = sr.color.a - (Time.deltaTime * 255);
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alphaNew);
            }

            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<InGameUIManager>().UpdatePlayerHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<InGameUIManager>().UpdatePlayerHealth();
        }
    }
}
