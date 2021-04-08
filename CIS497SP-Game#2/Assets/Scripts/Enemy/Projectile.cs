using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timeLimit = 4f;
    private float fadeTime = 3.2f;

    private float speed = 2f;

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
}
