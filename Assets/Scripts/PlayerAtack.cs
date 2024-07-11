using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    private PlayerAtackTypesSO playerAtackType;
    private BoxCollider2D boxCollider;
    private int damage;
    public static PlayerAtack Create(Vector3 position, float lookDirection, PlayerAtackTypesSO atackType)
    {
        Transform pfAtack = atackType.prefab;
        Transform atackTransform = Instantiate(pfAtack, position, Quaternion.identity);

        atackTransform.localScale = new Vector2(lookDirection, 1);
        atackTransform.GetComponent<PlayerAtack>().SetParametrs(Player.Instance.GetLookDirection());
        PlayerAtack playerAtack = atackTransform.GetComponent<PlayerAtack>();

        return playerAtack;
    }

    private void SetParametrs(float lookDirection)
    {
        boxCollider = GetComponent<BoxCollider2D>();

        playerAtackType = GetComponent<PlayerAtackTypeHolder>().atackType;

        damage = playerAtackType.damageAmount;

        Destroy(gameObject, .2f);
        Strike(lookDirection);
    }
    private void Strike(float lookDirection)
    {
        // Changes offset of collision box depending on player lookDirection
        Vector3 punchSpawnPosition = transform.position + new Vector3(boxCollider.offset.x * lookDirection, boxCollider.offset.y);
        // Creates boxcollider to check if punch hit someone
        Collider2D[] collider2DArray = Physics2D.OverlapBoxAll(punchSpawnPosition, boxCollider.size, (lookDirection - 1) * 90);
        foreach (Collider2D colider2D in collider2DArray)
        {
            if(colider2D.CompareTag("Enemy"))
            {
                Debug.Log("Hit " + playerAtackType.typeOfPunch.ToString() + " with " + damage + " damage!");
                colider2D.GetComponent<HealthSystem>().Damage(damage);
                CinemachineShake.Instance.ShakeCamera(2, 0.2f);
            }
        }
    }
}
