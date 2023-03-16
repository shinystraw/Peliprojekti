using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 target;

    void Start()
    {
        SetTarget();        
    }

    // Update is called once per frame
    void Update()
    {

        float step = Random.Range(1f, 3f) * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);

        float distance = Vector2.Distance(transform.position, target);

        if (transform.position.y == target.y) 
        {
            Debug.Log(distance);
            SetTarget();
        }

    }

    void SetTarget()
    {
        target = new Vector2(transform.position.x, Random.Range(3, 6));
    }
}
