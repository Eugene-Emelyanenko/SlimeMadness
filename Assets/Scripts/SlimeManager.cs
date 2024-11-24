using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    public float mergeDistance = 0.1f;
    public List<GameObject> cubes = new List<GameObject>();
    public float maxSize = 3f;
    [SerializeField] private Score score;
    public int maxSlimes = 40;
    [SerializeField] private GameObject leaderBoard;
    private void Update()
    {
        if (cubes.Count > 1)
        {
            for (int i = 0; i < cubes.Count; i++)
            {
                for (int j = i + 1; j < cubes.Count; j++)
                {
                    GameObject cubeA = cubes[i];
                    GameObject cubeB = cubes[j];
                    
                    float radiusA = cubeA.transform.localScale.x / 4;
                    float radiusB = cubeB.transform.localScale.x / 4;

                    if (Vector3.Distance(cubeA.transform.position, cubeB.transform.position) < (radiusA + radiusB) + mergeDistance &&
                        cubeA.GetComponent<Slime>().color == cubeB.GetComponent<Slime>().color)
                    {
                        cubeA.transform.localScale += cubeB.transform.localScale / 2f;

                        cubes.RemoveAt(j);
                        Destroy(cubeB);
                    }
                }
            }
        }
        
        for (int i = 0; i < cubes.Count; i++)
        {
            if (cubes[i] != null && cubes[i].transform.localScale.x >= maxSize)
            {
                Destroy(cubes[i], 0.3f);
                cubes.RemoveAt(i);
                score.IncreaseScore();
            }
        }

        if (cubes.Count > maxSlimes)
        {
            leaderBoard.SetActive(true);
            SlimeSpawner.canInput = false;
        }
            
    }
    
}
