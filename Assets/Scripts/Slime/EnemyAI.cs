using UnityEngine;
using UnityEngine.AI;
using KnightAdventure.Utils;

public class EnemyAI : MonoBehaviour {

    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamimgDistanceMin = 3f;
    [SerializeField] private float roamimgTimerMax = 2f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamPosition;
    private Vector3 startingPosition;


    private enum State {
        Idle,
        Roaming
    }

    private void Start() {
        startingPosition = transform.position;
    }

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startingState;
    }


    private void Update() {
        switch (state) {
            default:
            case State.Idle:
                break;
            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime < 0) {
                    Roaming();
                    roamingTime = roamimgTimerMax;
                }

                break;
        }
    }

    private void Roaming() {
        roamPosition = GetRoamingPosition();
        navMeshAgent.SetDestination(roamPosition);
    }

    private Vector3 GetRoamingPosition() {
        return startingPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamimgDistanceMin, roamingDistanceMax);
    }

}
