using UnityEngine;

public class HeroEnemyAttractory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.NoticePlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.LoosePlayer();
        }
    }
}
