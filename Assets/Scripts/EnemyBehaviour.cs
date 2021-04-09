using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(StatsController))]
public class EnemyBehaviour : MonoBehaviour
{
    public PlayerController player;
    public Transform goldPrefab;
    private Animator animator;
    private StatsController stats;

    private System.DateTime lastAttack;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        lastAttack = System.DateTime.Now;
        stats = GetComponent<StatsController>();

        stats.onDeath.AddListener(Die);
    }

    private void Update()
    {
        bool isClose = Vector3.Distance(transform.position, player.transform.position) < 1.5f;
        animator.SetBool("Attacking", isClose);
        if (isClose && (System.DateTime.Now - lastAttack).TotalSeconds > 0.5f)
        {
            player.GetComponent<StatsController>().Damage(0.5f);
            lastAttack = System.DateTime.Now;
        }
    }

    private void Die()
    {
        Instantiate(goldPrefab, transform.parent.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
