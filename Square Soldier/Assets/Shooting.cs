using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera cam;
    private Vector2 mousePos;
    [SerializeField] GameObject player;
    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 rotation = mousePos - (Vector2)transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void DisableWhileCrouch(bool isCrouching)
    {
        gameObject.SetActive(!isCrouching);
    } 
}
