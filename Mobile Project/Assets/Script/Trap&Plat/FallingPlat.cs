using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    public ParticleSystem particle;
    public float fallingSpeed = 5f;
    public float fallingTime = 2.5f;
    public float delayTime = 1.5f;
    public bool active = true;
    float currentSpeed;

    void OnEnable() 
    {
        particle.Play();
        currentSpeed = fallingSpeed;
    }
    void Update()
    {
        if(!active)
        {
            currentSpeed += Time.deltaTime * 9.8f * 5f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * currentSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            StartCoroutine(SetFalling());
        }
    }

    IEnumerator SetFalling()
    {
        yield return new WaitForSeconds(delayTime);
        active = false;
        GetComponent<Animator>().SetBool("off", true);
        particle.Stop();
        yield return new WaitForSeconds(fallingTime);
        active = true;
        GetComponent<Animator>().SetBool("off", false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.localPosition = Vector2.zero;
        currentSpeed = fallingSpeed;
        gameObject.SetActive(false);
    }
}
