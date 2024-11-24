using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] private SlimeManager slimeManager;
    public GameObject[] slimeCubes;
    public float leftBoundary;
    public float rightBoundary;
    public float topBoundary;
    public float bottomBoundary;
    
    public static bool canInput;

    private void Start()
    {
        canInput = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canInput)
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;
            
            if (clickPosition.x >= leftBoundary && clickPosition.x <= rightBoundary &&
                clickPosition.y >= bottomBoundary && clickPosition.y <= topBoundary)
            {
                GameObject newSlime = Instantiate(slimeCubes[Random.Range(0, slimeCubes.Length - 1)], clickPosition, Quaternion.identity);
                slimeManager.cubes.Add(newSlime);
            }
        }
    }
}
