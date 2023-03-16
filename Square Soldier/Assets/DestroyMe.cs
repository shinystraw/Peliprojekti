using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public void DestroyOnDelay(float time)
    {
        Destroy(gameObject, time);
    }

    public void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
