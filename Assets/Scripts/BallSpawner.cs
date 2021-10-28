using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> balls;
    [SerializeField] private int levelNum = 1;
    [SerializeField] private float secondsToWait = 10.0f;
    private int spotNum;
    private int numberOfSpawnPoints;

    private void Start() {
        numberOfSpawnPoints = spawnPoints.Count();
        StartCoroutine(SpawnTimer());
    }

    private void Update() {
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        levelNum++;
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer() {
        SpawnBall();
        yield return new WaitForSecondsRealtime(secondsToWait);
    }

    private void SpawnBall() {
        spotNum = PickASpawner();
        Instantiate(balls[spotNum], spawnPoints[spotNum].transform);
    }

    private int PickASpawner() {
        return UnityEngine.Random.Range(0, numberOfSpawnPoints);
    }
}