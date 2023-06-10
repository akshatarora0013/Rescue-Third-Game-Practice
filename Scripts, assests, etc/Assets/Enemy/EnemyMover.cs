using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoints> path = new List<WayPoints>();
    [SerializeField] [Range(0f, 5f)] float speed = 0.5f;

    Enemy enemy;

    void Start(){
        enemy = GetComponent<Enemy>();
    }
    
    void OnEnable()
    {
        FindPath();
        RetrunToStart();
        StartCoroutine(followPath());
    }

    void FindPath(){
        path.Clear();
        GameObject Parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in Parent.transform){
            WayPoints waypoint = child.GetComponent<WayPoints>();
            if(waypoint != null){
                path.Add(waypoint);
            }
            
        }
    }

    void RetrunToStart(){
        transform.position = path[0].transform.position;
    }

    void FinishPath(){
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator followPath(){
        foreach (WayPoints wayPoint in path){
            Vector3 startPosition = transform.position;
            Vector3 finalPosition = wayPoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(finalPosition);

            while(travelPercent < 1f){
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, finalPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
