using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Mutant : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = Vector3.zero;
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // 0 = Base Layer
        if (navMeshAgent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("isrunning", true);
        }
        else
        {
            animator.SetBool("isrunning", false);
        }
        if (stateInfo.IsName("EmptyEntry"))
        {
            StartCoroutine(HandleEmptyEntryOnce()); ;
        }
    }
    IEnumerator HandleEmptyEntryOnce()
    {

        // Optional: wait for a short moment after animation starts
        yield return null; // or: yield return new WaitForSeconds(0.1f);

        int random = Random.Range(1, 4);
        animator.SetInteger("idleValue", random);

        // Wait until animation exits before allowing again
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("EmptyEntry"))
        {
            yield return null;
        }

    }

}
