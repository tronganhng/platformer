using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public Transform[] points;
    public float speed = 4f;
    public int index;
    [SerializeField] GameObject chainPref;
    [SerializeField] float chainDistance;

    void Start()
    {
        spawnChain();
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);
        SetIndex();
    }

    void SetIndex()
    {
        if (Vector2.Distance(transform.position, points[index].position) < .1f)
        {
            index++;
            if (index > points.Length - 1)
            {
                index = 0;
            }
        }
    }

    void spawnChain()
    {
        for(int i = 0; i < points.Length - 1; i++)
        {
            int chainAmount = (int) (Vector2.Distance(points[i].position, points[i+1].position)/chainDistance);
            Vector2 spawnPos = points[i].position;
            Vector2 direct = (points[i+1].position - points[i].position).normalized;
            for(int j=0; j<chainAmount; j++)
            {                
                GameObject chain = Instantiate(chainPref, gameObject.transform.parent);
                chain.transform.position = spawnPos;
                spawnPos += direct*chainDistance;
            }
        }
    }
}
