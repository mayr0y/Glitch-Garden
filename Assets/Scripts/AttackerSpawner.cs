﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDellay = 1f;
    [SerializeField] float maxSpawnDellay = 5f;
    [SerializeField] Attacker attackerPrefabs;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDellay, maxSpawnDellay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(attackerPrefabs, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}