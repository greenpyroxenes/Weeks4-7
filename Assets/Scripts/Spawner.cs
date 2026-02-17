using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    //variable declaration
    public RollButton dieScript;
    public GameObject chipPrefab;
    public GameObject spawnedChip;
    public List<GameObject> chips;
    public int check;
    public int stored;
    public bool spawn;
    Vector2 spawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //initally gets a chip to spawn and make the list. chips are based on a streak of how many wins in a row
    void Start()
    {
        spawnPos = transform.position;
        spawnedChip = Instantiate(chipPrefab, spawnPos, Quaternion.identity);
        chips.Add(spawnedChip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks if die script win is true or false, and adds or takes away based on boolean
    public void spawning()
    {
        if (dieScript.wins == true)
        {
            spawnPos.x += 1;
            spawnedChip = Instantiate(chipPrefab, spawnPos, Quaternion.identity);
            chips.Add(spawnedChip);
        }
        else if (dieScript.lose == true && chips.Count > 1)
        {
            for (int i = 0; i <= chips.Count; i++)
            {
                GameObject chip = chips[i];
                chips.Remove(chip);
                Destroy(chip);
            }
            spawnPos.x = 0;
        }
    }
}
