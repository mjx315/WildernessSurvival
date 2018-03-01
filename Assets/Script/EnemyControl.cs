using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
	// Use this for initialization
	void Start () {
        //指定目标位置
        agent.SetDestination(target.position);
        agent.speed = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
