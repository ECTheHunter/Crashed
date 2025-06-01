using System.Collections;
using System.Collections.Generic;
using Ilumisoft.HealthSystem;
using UnityEngine;
using UnityEngine.AI;

public class Mutant : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public Transform player;
    public Light flashlight;
    public GameObject hitbox;
    public Transform[] runAwayCheckpoints; // Assign in inspector: random points to flee to when hit by light
    public float attackDistance = 1.5f;
    public float attackAngle = 60f;

    private Transform currentRunAwayTarget;
    private bool isRunningAway = false;

    // To track when we enter idle state
    private bool isIdle = false;
    private Coroutine idleCoroutine;

    void Start()
    {
        GameObject[] checkpointObjects = GameObject.FindGameObjectsWithTag("Checkpoint");
        runAwayCheckpoints = new Transform[checkpointObjects.Length];
        for (int i = 0; i < checkpointObjects.Length; i++)
        {
            runAwayCheckpoints[i] = checkpointObjects[i].transform;
        }
    }
    void Update()
    {
        bool flashlightOn = flashlight.gameObject.activeInHierarchy;
        bool litByFlashlight = flashlightOn && IsInFlashlight();

        if (isRunningAway)
        {
            // Run away until checkpoint is reached
            navMeshAgent.SetDestination(currentRunAwayTarget.position);

            if (ReachedDestination())
            {
                // Once checkpoint reached, stop running away and resume chasing player
                isRunningAway = false;
                currentRunAwayTarget = null;
            }
        }
        else
        {
            if (litByFlashlight)
            {
                // Start running away to a random checkpoint
                StartRunningAway();
            }
            else
            {
                // Chase the player
              
                if (IsDestinationReachable(player.position))
                    navMeshAgent.SetDestination(player.position);
                else
                    navMeshAgent.ResetPath(); // Stop movement if unreachable
            }

        }
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Prevent triggering a new attack if already in an attack animation
        if (!stateInfo.IsTag("Attack"))
            hitbox.SetActive(false);
        UpdateAnimator();
        CheckBackAttack();
    }
    bool IsDestinationReachable(Vector3 targetPosition)
    {
        NavMeshPath path = new NavMeshPath();
        navMeshAgent.CalculatePath(targetPosition, path);

        return path.status == NavMeshPathStatus.PathComplete;
    }

    bool IsInFlashlight()
    {
        Vector3 toEnemy = transform.position - flashlight.transform.position;
        float angle = Vector3.Angle(flashlight.transform.forward, toEnemy);
        float distance = toEnemy.magnitude;

        return angle < flashlight.spotAngle / 2f && distance < flashlight.range;
    }

    void StartRunningAway()
    {
        if (runAwayCheckpoints.Length == 0)
        {
            Debug.LogWarning("No runAwayCheckpoints assigned!");
            return;
        }
        currentRunAwayTarget = runAwayCheckpoints[Random.Range(0, runAwayCheckpoints.Length)];
        isRunningAway = true;
        if (IsDestinationReachable(currentRunAwayTarget.position))
        {
            navMeshAgent.SetDestination(currentRunAwayTarget.position);
        }
        else
        {
            navMeshAgent.ResetPath(); // Stop if checkpoint is not reachable
            isRunningAway = false;
            currentRunAwayTarget = null;
        }
    }

    bool ReachedDestination()
    {
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void UpdateAnimator()
    {
        float speed = navMeshAgent.velocity.magnitude;

        // Running animation
        if (speed > 0.1f)
        {
            animator.SetBool("isrunning", true);

            // If moving, not idle, stop idle coroutine if running
            if (isIdle)
            {
                isIdle = false;
                if (idleCoroutine != null)
                {
                    StopCoroutine(idleCoroutine);
                    idleCoroutine = null;
                }
            }
        }
        else
        {
            animator.SetBool("isrunning", false);

            // If just became idle, start idle randomizer coroutine
            if (!isIdle)
            {
                isIdle = true;
                idleCoroutine = StartCoroutine(HandleRandomIdle());
            }
        }
    }

    IEnumerator HandleRandomIdle()
    {
        while (true)
        {
            int randomIdleValue = Random.Range(1, 3);
            animator.SetInteger("idleValue", randomIdleValue);

            // Wait until leaving idle state (i.e., speed > 0.1f) or some time passes before changing again
            // We'll check every 1-3 seconds for variety
            float waitTime = Random.Range(1f, 3f);
            float timer = 0f;

            while (timer < waitTime)
            {
                if (navMeshAgent.velocity.magnitude > 0.1f)
                    yield break; // stop coroutine when moving

                timer += Time.deltaTime;
                yield return null;
            }
        }
    }

    void CheckBackAttack()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.position);

        if (distToPlayer < attackDistance)
        {
            AttackPlayer();
        }
    }


    void AttackPlayer()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Prevent triggering a new attack if already in an attack animation
        if (stateInfo.IsTag("Attack"))
            return;

        int random = Random.Range(1, 3);
        animator.SetInteger("attackValue", random);
        hitbox.SetActive(true);
    }

}
