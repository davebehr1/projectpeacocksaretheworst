using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class DogController : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent pathfinder;
    Vector3 velocity;
    Rigidbody myRigidbody;
    float myCollisionRadius;
    float targetCollisionRadius;
    public float rotationSpeed = 10f;

    GameObject targetEntity;
    FieldOfView fow;

    Transform target;
    float attackDistanceThreshold = .5f;
    bool hasTarget;

    private void Awake()
    {
        fow = GetComponent<FieldOfView>();
        
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();

        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;



        if (GameObject.FindGameObjectWithTag("Duck") != null)
        {
            print("found target");
            hasTarget = true;

            target = GameObject.FindGameObjectWithTag("Duck").transform;
            targetEntity = target.GetComponent<GameObject>();

            myCollisionRadius = GetComponent<CapsuleCollider>().radius;
            targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
        }
    }
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        StartCoroutine(UpdatePath());

    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        

        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
     
 

    }

    IEnumerator UpdatePath()
    {

        float refreshRate = .25f;

        while (hasTarget)
        {
            print(fow.visibleTargets.Count);
            //if (currentState == State.Chasing)
            //{
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position - dirToTarget * (myCollisionRadius + targetCollisionRadius + attackDistanceThreshold / 2);
            if (fow.visibleTargets.Count > 0)
            {
                gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                pathfinder.SetDestination(targetPosition);
                
                //Vector3 direction = (target.position - transform.position).normalized;
                //Quaternion lookRotation = Quaternion.LookRotation(direction);
                
                //Quaternion rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
               
            }
               
            //}
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
