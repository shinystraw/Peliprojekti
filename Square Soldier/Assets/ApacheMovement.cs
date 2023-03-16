using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ApacheMovement : MonoBehaviour
{
    Transform targetLeft;
    Transform targetRight;
    Transform heli;
    Transform currentTarget;
    Transform nextTarget;
    [SerializeField] float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        targetLeft = GameObject.FindGameObjectWithTag("LeftPost").transform; 
        targetRight = GameObject.FindGameObjectWithTag("RightPost").transform;
        heli = gameObject.transform;

        ChooseFirstTraget();
    }

    // Update is called once per frame
    void Update()
    {

        CheckDistanceToTarget();
        MoveTowardTargetPost(currentTarget.position);
    }


    void ChooseFirstTraget()
    {
        if(Random.Range(1,3) == 1)
        {
            currentTarget = targetRight;
            nextTarget = targetLeft;
            Flip();
        }
        else
        {
            currentTarget = targetLeft;
            nextTarget = targetRight;
        }
    }

    void MoveTowardTargetPost(Vector2 target)
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(heli.position, target, step);
    }

    void CheckDistanceToTarget()
    {
        float distance = Vector3.Distance(heli.position, currentTarget.position);
        if (distance < 1f)
        {
            Debug.Log(distance);
            Flip();
            SetNewTarget(nextTarget);
        }
    }

    void SetNewTarget(Transform newTarget)
    {
        nextTarget = currentTarget;
        currentTarget = newTarget;
    }

    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        // Flip the child object along with the parent.
        Transform child = transform.GetChild(0); // assuming the child object is the first child
        Vector3 childScale = child.localScale;
        childScale.x *= -1;
        child.localScale = childScale;
    }

}
