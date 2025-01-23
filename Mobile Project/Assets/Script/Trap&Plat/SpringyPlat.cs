using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpringyPlat : MonoBehaviour
{
    [SerializeField] float springDistance = 0.2f;
    [SerializeField] float springTime = 0.3f;
    [SerializeField] Vector2 initialPos;

    void Start()
    {
        initialPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            StartCoroutine(springEffect());
        }
    }

    IEnumerator springEffect()
    {
        Vector2 targetPos = initialPos - new Vector2(0, springDistance);
        float speed = 2 * springDistance/springTime;

        while(transform.position.y > targetPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
            yield return null;
        }
        
        yield return new WaitForSeconds(0.05f);

        while(transform.position.y < initialPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPos, Time.deltaTime * speed);
            yield return null;
        }
    }
}
