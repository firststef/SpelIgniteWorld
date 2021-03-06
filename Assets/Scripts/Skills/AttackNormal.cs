using UnityEngine;

public class AttackNormal : MonoBehaviour
{
    private StatsController st;

    private void Awake()
    {
        st = GetComponentInParent<StatsController>();
    }

    private void Update()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Hurtbox")
        {
            return;
        }

        var stats = collision.gameObject.GetComponentInParent<StatsController>();
        if (stats && st.allegiance != stats.allegiance && st.GetInstanceID() != stats.GetInstanceID())
        {
            stats.Damage(st.GetDamage(), "Attack");
        }
    }
}
