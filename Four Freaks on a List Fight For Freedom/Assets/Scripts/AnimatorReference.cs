using JetBrains.Annotations;
using UnityEngine;

public class AnimatorReference : MonoBehaviour
{
    Rigidbody2D rb;
    Player player;
    int distanceCheck()
    {
        if (player.distance < 0) return 1;
        if (player.distance > 0) return -1;
        return 1;
    }
    [SerializeField] GameObject[] objectsSpawn;
    [SerializeField] GameObject[] hitBoxes;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }
    public void LateUpdate()
    {
        
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void RAHeavyUpDash()
    {
        player.xMovementPossible = false;
        rb.AddForce(Vector2.left * 1.5f * Mathf.Clamp(player.distance, -5, 5), ForceMode2D.Impulse);
    }
    public void RAHeavyMiddleInstantiateWaves()
    {
        player.instantiatedDamage = 2;
        GameObject soundwave = Instantiate(objectsSpawn[0], player.transform.position, Quaternion.identity);
        soundwave.transform.SetParent(gameObject.transform);
        if (player.tag == "Player") soundwave.tag = "PlayerInstantiated";
        if (player.tag == "Enemy") soundwave.tag = "EnemyInstantiated";
        Destroy(soundwave, 1);
    }

    public void RAHeavyLowInstantiateRay()
    {
        player.instantiatedDamage = 8;
        player.xMovementPossible = false;
        player.rb.AddForce(Vector2.left * player.jumpHeight * Mathf.Clamp(-player.distance, -1, 1), ForceMode2D.Impulse);
        GameObject ray = Instantiate(objectsSpawn[1], hitBoxes[1].transform.position, Quaternion.identity);
        if (player.tag == "Player") ray.tag = "PlayerInstantiated";
        if (player.tag == "Enemy") ray.tag = "EnemyInstantiated";
        if (player.distance > 0) ray.transform.rotation = Quaternion.Euler(0, 180, 0);
        if (player.distance < 0) ray.transform.rotation = Quaternion.identity;
        ray.transform.SetParent(gameObject.transform);
        Destroy(ray, 0.3f);
    }
    public void DJHeavyHighInstantiateDisc()
    {
        player.instantiatedDamage = 15;
        GameObject bomb = Instantiate(objectsSpawn[0], hitBoxes[0].transform.position, Quaternion.identity);
        Rigidbody2D bombrb = bomb.GetComponent<Rigidbody2D>();
        if (player.tag == "Player") bomb.tag = "PlayerInstantiated";
        if (player.tag == "Enemy") bomb.tag = "EnemyInstantiated";
        bomb.transform.SetParent(gameObject.transform);
        Debug.Log(distanceCheck());
        bombrb.linearVelocityX = Mathf.Cos(35 * Mathf.Deg2Rad) * 4 * distanceCheck();
        bombrb.linearVelocityY = Mathf.Sin(35 * Mathf.Deg2Rad) * 4;
    }
    public void DJHeavyLowInstantiateLine()
    {
        LineRenderer line = player.GetComponent<LineRenderer>();
        line.enabled = true;
    }
}
