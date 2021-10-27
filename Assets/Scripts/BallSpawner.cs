using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> balls;
    [SerializeField] private int levelNum = 0;
    [SerializeField] private uint secondsToWait;

    private void Update() {
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer() {
        SpawnBall();
        yield return new WaitForSecondsRealtime(secondsToWait);
    }

    private void SpawnBall() {
        Instantiate(balls[levelNum], spawnPoints[levelNum].transform);
    }
}