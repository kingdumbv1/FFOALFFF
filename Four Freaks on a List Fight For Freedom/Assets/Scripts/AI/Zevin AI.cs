using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ZevinAI : MonoBehaviour
{
    Player player;
    bool canAttack = true;
    Vector2[] movementTypes =
    {
        Vector2.zero, // 0
        new Vector2(0.65f, 0), // 1 
        new Vector2(0.65f, 1), // 2
        new Vector2(0, 1), // 3
        new Vector2(-0.65f, 0), // 4 
        new Vector2(-0.65f, -1), // 5
        new Vector2(0, -1) // 6
    };
    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!player.isAttacking)
        {
            if (player.distance < 0) player.currentDirection = movementTypes[1];
            if (player.distance > 0) player.currentDirection = movementTypes[4];
        }
        if (player.isHit) player.currentDirection = movementTypes[0];

        LayerMask pLayer = LayerMask.GetMask("Player1");
        RaycastHit2D checkLeft = Physics2D.Raycast(transform.position, Vector2.left, 10f, pLayer);
        RaycastHit2D checkRight = Physics2D.Raycast(transform.position, Vector2.right, 10f, pLayer);
        if (Mathf.Abs(player.distance) > 1.2f)
        {
            if (checkLeft)
            {
                Player enemy = checkLeft.transform.GetComponent<Player>();
                if (enemy.isBlocking == 0)
                {
                    if (canAttack) StartCoroutine(HeavyAttack());
                }
            }
            if (checkRight)
            {
                Player enemy = checkRight.transform.GetComponent<Player>();
                if (enemy.isBlocking == 0)
                {
                    if (canAttack) StartCoroutine(HeavyAttack());
                }
            }
        }
        if (Mathf.Abs(player.distance) < 1.2f)
        {
            if (checkLeft)
            {
                Player enemy = checkLeft.transform.GetComponent<Player>();
                if (enemy.isBlocking == 1)
                {
                    BlockBreak();
                    player.heavyAttackClickedFrame = 0;
                }
                else
                {
                    if (canAttack) StartCoroutine(Attack());
                    player.heavyAttackClickedFrame = 0;
                }
            }
            if (checkRight)
            {
                Player enemy = checkRight.transform.GetComponent<Player>();
                if (enemy.isBlocking == 1)
                {
                    BlockBreak();
                }
                else
                {
                    if (canAttack) StartCoroutine(Attack());
                    player.heavyAttackClickedFrame = 0;
                }
            }
        }
    }
    

    IEnumerator Attack()
    {
        Debug.Log("is attacking" + player.distance + " " + player.attackClickedFrame);
        int randomChoice = Random.Range(0, 3);
        Vector2[] attackTypes =
        {
            movementTypes[0],
            movementTypes[3],
            movementTypes[6],
        };
        player.currentDirection = attackTypes[randomChoice];
        player.attackClickedFrame = 1;
        canAttack = false;
        yield return new WaitForSeconds(2);
        player.attackClickedFrame = 0;
        canAttack = true;
    }
    IEnumerator HeavyAttack()
    {
        switch (player.chosenCharacter)
        {
            case "dj":
                int randomChoice = Random.Range(0, 3);
                Vector2[] attackTypes =
                {
                    movementTypes[1],
                    movementTypes[2],
                    movementTypes[5],
                };
                player.currentDirection = attackTypes[randomChoice];
                player.heavyAttackClickedFrame = 1;
                canAttack = false;
                yield return new WaitForSeconds(2);
                player.heavyAttackClickedFrame = 0;
                canAttack = true;
                break;
            case "rockstar":

                break;
            case "outlaw":

                break;
            case "raven":

                break;
        }
    }

    void BlockBreak()
    {
        switch (player.chosenCharacter)
        {
            case "dj":
                player.currentDirection = movementTypes[5];
                player.heavyAttackClickedFrame = 1;
                break;
            case "rockstar":
                player.currentDirection = movementTypes[0];
                player.heavyAttackClickedFrame = 1;
                break;
            case "outlaw":
                player.currentDirection = movementTypes[6];
                player.heavyAttackClickedFrame = 1;
                break;
            case "raven":
                player.currentDirection = movementTypes[5];
                player.heavyAttackClickedFrame = 1;
                break;
        }
    }

    void Combo()
    {
        switch (player.chosenCharacter)
        {
            case "dj":
                player.currentDirection = movementTypes[5];
                player.heavyAttackClickedFrame = 1;
                break;
            case "rockstar":

                break;
            case "outlaw":

                break;
            case "raven":

                break;
        }
    }
    void Block()
    {
        player.isBlocking = 1;
    }
}
