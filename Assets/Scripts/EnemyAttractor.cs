using UnityEngine;

public class EnemyAttractor : MonoBehaviour
{
    [SerializeField] private float _attractionRadius;

    public void AttractEnemies()
    {
        var collidersInZone = Physics.OverlapSphere(transform.position, _attractionRadius);

        foreach (var collider in collidersInZone)
        {
            var enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Attract(transform.position);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 255, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, _attractionRadius);
    }
}
