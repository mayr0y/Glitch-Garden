﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 3f;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;


    private void Start() {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackersSpawned() {
        numberOfAttackers++;
    }

    public void AttackersKilled() {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished) {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition() {
        winLabel.SetActive(true);
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LoadScene>().LoadNextScene();
    }

    public void HandleLoseCondition() {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished() {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray) {
            spawner.StopSpawning();
        }
    }
}
