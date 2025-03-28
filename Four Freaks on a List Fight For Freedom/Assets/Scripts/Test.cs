using UnityEngine;


public class Test
{
    Player player;
    string characterChoice;
    Animator animator;

    public Test(Player self, string chosenCharacter)
    {
        player = self;
        characterChoice = chosenCharacter;
        animator = player.animator;
    }
    // MAKE SURE ALL IDLE ANIMATIONS ARE NAMED "Idle"!
    public void LightHigh()
    {
        switch (characterChoice)
        {
            //Characters: prototype, raven, rockstar, dj, outlaw.
            case "prototype":
                player.isAttacking = true;
                player.canAttack = false;
                player.rb.AddForce(Vector2.up * player.jumpHeight, ForceMode2D.Impulse);
                animator.SetTrigger("HighPrimary");
                break;
            case "raven":
                animator.SetTrigger("HighPrimary");
                break;
            case "rockstar":
                player.isAttacking = true;
                player.canAttack = false;
                player.rb.AddForce(Vector2.up * player.jumpHeight, ForceMode2D.Impulse);
                player.rb.AddForce(Vector2.right * player.jumpHeight / 1.5f, ForceMode2D.Impulse);
                animator.SetTrigger("HighPrimary");
                break;
            case "dj":
                animator.SetTrigger("HighPrimary");
                break;
            case "outlaw":
                animator.SetTrigger("HighPrimary");
                break;
        }
    }
    public void LightMiddle()
    {
        switch (characterChoice)
        {
            //Characters: prototype, raven, rockstar, dj, outlaw.
            case "prototype":
                player.isAttacking = true;
                player.canAttack = false;
                animator.SetTrigger("MiddlePrimary");
                break;
            case "raven":
                animator.SetTrigger("MiddlePrimary");
                break;
            case "rockstar":
                player.isAttacking = true;
                player.canAttack = false;
                animator.SetTrigger("MiddlePrimary");
                break;
            case "dj":
                animator.SetTrigger("MiddlePrimary");
                break;
            case "outlaw":
                animator.SetTrigger("MiddlePrimary");
                break;
        }
    }
    public void LightLow()
    {
        switch (characterChoice)
        {
            //Characters: prototype, raven, rockstar, dj, outlaw.
            case "prototype":
                player.canAttack = false;
                player.isAttacking = true;
                animator.SetTrigger("LowPrimary");
                break;
            case "raven":
                animator.SetTrigger("LowPrimary");
                break;
            case "rockstar":
                animator.SetTrigger("LowPrimary");
                break;
            case "dj":
                animator.SetTrigger("LowPrimary");
                break;
            case "outlaw":
                animator.SetTrigger("LowPrimary");
                break;
        }
    }
    public void HeavyHigh()
    {
        switch (characterChoice)
        {
            //Characters: prototype, raven, rockstar, dj, outlaw.
            case "prototype":
                player.isAttacking = true;
                player.xMovementPossible = false;
                player.canAttack = false;
                animator.SetTrigger("HeavyHigh");
                break;
            case "raven":
                animator.SetTrigger("HeavyHigh");
                break;
            case "rockstar":
                player.isAttacking = true;
                player.xMovementPossible = false;
                player.canAttack = false;
                animator.SetTrigger("HeavyHigh");
                break;
            case "dj":
                animator.SetTrigger("HeavyHigh");
                break;
            case "outlaw":
                animator.SetTrigger("HeavyHigh");
                break;
        }
    }

    public void HeavyMiddle(Rigidbody2D rb)
    {
        switch (characterChoice)
        {
            //Characters: prototype, raven, rockstar, dj, outlaw.
            case "prototype":
                player.isHeavyAttacking = true;
                player.blockBreak = true;
                player.xMovementPossible = false;
                player.canAttack = false;
                rb.AddForce(Vector2.right * 5 * Mathf.Clamp(-player.distance, -1, 1), ForceMode2D.Impulse);
                animator.SetTrigger("HeavyMiddle");
                break;
            case "raven":
                animator.SetTrigger("HeavyMiddle");
                break;
            case "rockstar":
                animator.SetTrigger("HeavyMiddle");
                break;
            case "dj":
                animator.SetTrigger("HeavyMiddle");
                break;
            case "outlaw":
                animator.SetTrigger("HeavyMiddle");
                break;
        }
    }
   
    public void HeavyLow()
    {
        switch (characterChoice)
        {
            //Characters: prototype, raven, rockstar, dj, outlaw.
            case "prototype":
                player.isAttacking = true;
                player.xMovementPossible = false;
                player.canAttack = false;
                break;
            case "raven":

                break;
            case "rockstar":

                break;
            case "dj":

                break;
            case "outlaw":

                break;
        }

    }
}
