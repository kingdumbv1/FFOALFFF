using System.Collections;
using UnityEngine;

public class AnimatorReference : MonoBehaviour
{
    Rigidbody2D rb;
    Player player;
    public float cooldown;
    public float cooldown2;
    public float cooldown3;
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
        cooldown = 10;
        cooldown2 = 10;
        cooldown3 = 10;
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }
    private void Update()
    {
        cooldown += Time.deltaTime;
        cooldown2 += Time.deltaTime;
        cooldown3 += Time.deltaTime;
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
        if (player.tag == "Player") bomb.transform.GetChild(0).tag = "PlayerInstantiated";
        if (player.tag == "Enemy") bomb.transform.GetChild(0).tag = "EnemyInstantiated";
        bomb.transform.SetParent(gameObject.transform);
        bombrb.linearVelocityX = Mathf.Cos(35 * Mathf.Deg2Rad) * 4 * distanceCheck();
        bombrb.linearVelocityY = Mathf.Sin(35 * Mathf.Deg2Rad) * 4;
    }
    public void RFDash()
    {
        player.xMovementPossible = false;
        player.rb.linearVelocityX = 0;
        player.rb.AddForce(Vector2.right * 3 * distanceCheck(), ForceMode2D.Impulse);
    }
    public void RFHeavyHighCooldown()
    {
        if (cooldown >= 1)
        {
            cooldown = 0;
            player.animator.SetTrigger("HeavyHigh");
        }
    }
    public void RFHeavyMiddle()
    {
        player.xMovementPossible = false;
        gameObject.transform.Translate(Vector3.left * player.distance * distanceCheck());
        cooldown2 = 0;
    }
    public void RFHeavyLowCounter()
    {
        StartCoroutine(Counter(Time.deltaTime));
    }
    private IEnumerator Counter(float seconds)
    {
        while (player.invulnerable)
        {
            yield return new WaitForSeconds(0.1f);
            if (player.isHit || player.attackClickedFrame == 1)
            {
                Debug.Log("is hit = " + player.isHit + " is clicking = " + player.attackClickedFrame);
                Debug.Log("wow");
                player.heavyDamage = 5;
                player.rb.AddForce(Vector2.left * 2.5f * distanceCheck(), ForceMode2D.Impulse);
                player.animator.SetTrigger("Countered");
            }
        }
        
    }
}
