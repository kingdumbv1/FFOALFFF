using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ZevinAI : MonoBehaviour
{
    Player player;
    Player enemy;
    bool canAttack = true;
    int[] movementTypes =
    {
        1, // 0
        0, // 1 
        -1, // 2
    };
    private void Start()
    {
        player = GetComponent<Player>();
        StartCoroutine(GetEnemy());
    }

    private void Update()
    {
        if (!player.isAttacking)
        {
            if (player.distance < 0) player.currentDirection.x = movementTypes[0];
            if (player.distance > 0) player.currentDirection.x = movementTypes[2];
        }
        if (player.isHit) player.currentDirection.x = movementTypes[1];

        if (Mathf.Abs(player.distance) < 1.3f)
        {
            if (canAttack && enemy.isBlocking == 1)
            {
                player.currentDirection.x = movementTypes[1];
                BlockBreak();
            }
            if (canAttack && enemy.isBlocking == 0)
            {
                player.currentDirection.x = movementTypes[1];
                StartCoroutine(Attack());
            }
        }
    }
    

    IEnumerator Attack()
    {
        int randomChoice = Random.Range(0, 3);
        int[] attackTypes =
        {
            1,
            0,
            -1
        };
        player.currentDirection.y = attackTypes[randomChoice];
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
                int djRandomChoice = Random.Range(0, 3);
                player.currentDirection.y = movementTypes[djRandomChoice];
                player.heavyAttackClickedFrame = 1;
                canAttack = false;
                yield return new WaitForSeconds(2);
                player.heavyAttackClickedFrame = 0;
                canAttack = true;
                break;
            case "rockstar":
                int raRandomChoice = Random.Range(0, 3);
                player.currentDirection.y = movementTypes[raRandomChoice];
                player.heavyAttackClickedFrame = 1;
                canAttack = false;
                yield return new WaitForSeconds(2);
                player.heavyAttackClickedFrame = 0;
                canAttack = true;
                break;
            case "outlaw":
                int moRandomChoice = Random.Range(0, 3);
                player.currentDirection.y = movementTypes[moRandomChoice];
                player.heavyAttackClickedFrame = 1;
                canAttack = false;
                yield return new WaitForSeconds(2);
                player.heavyAttackClickedFrame = 0;
                canAttack = true;
                break;
            case "raven":
                int rfRandomChoice = Random.Range(0, 3);
                player.currentDirection.y = movementTypes[rfRandomChoice];
                player.heavyAttackClickedFrame = 1;
                canAttack = false;
                yield return new WaitForSeconds(2);
                player.heavyAttackClickedFrame = 0;
                canAttack = true;
                break;
        }
    }

    void BlockBreak()
    {
        switch (player.chosenCharacter)
        {
            case "dj":
                player.currentDirection.y = movementTypes[2];
                player.heavyAttackClickedFrame = 1;
                break;
            case "rockstar":
                player.currentDirection.y = movementTypes[1];
                player.heavyAttackClickedFrame = 1;
                break;
            case "outlaw":
                player.currentDirection.y = movementTypes[2];
                player.heavyAttackClickedFrame = 1;
                break;
            case "raven":
                StartCoroutine(CounterBreak());
                break;
        }
    }

    void Combo()
    {
        switch (player.chosenCharacter)
        {
            case "dj":
                //player.currentDirection = movementTypes[5];
                //player.heavyAttackClickedFrame = 1;
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
    IEnumerator GetEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        enemy = player.enemy.GetComponent<Player>();
    }

    IEnumerator CounterBreak()
    {
        player.currentDirection.y = movementTypes[0];
        player.heavyAttackClickedFrame = 1;
        yield return new WaitForSeconds(0.1f);
        player.heavyAttackClickedFrame = 0;
        yield return new WaitForSeconds(0.4f);
        player.heavyAttackClickedFrame = 1;
        yield return new WaitForSeconds(0.1f);
        player.heavyAttackClickedFrame = 0;
    }

    private void OnDestroy()
    {
        if (player.currentHealth <= 0)
        {
            DataSave data = GameObject.FindFirstObjectByType<DataSave>();
            if (data != null)
            {
                if (player.chosenCharacter == "dj") data.Stages.Remove(0);
                if (player.chosenCharacter == "rockstar") data.Stages.Remove(3);
                if (player.chosenCharacter == "raven") data.Stages.Remove(2);
                if (player.chosenCharacter == "outlaw") data.Stages.Remove(1);
                data.StartCoroutine("NextStage");
            }
        }
    }
}
