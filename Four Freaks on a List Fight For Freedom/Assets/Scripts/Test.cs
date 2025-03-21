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

                break;
            case "rockstar":

                break;
            case "dj":

                break;
            case "outlaw":

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

                break;
            case "rockstar":

                break;
            case "dj":

                break;
            case "outlaw":

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

                break;
            case "rockstar":

                break;
            case "dj":

                break;
            case "outlaw":

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

    public void HeavyMiddle(Rigidbody2D rb)
    {
        switch (characterChoice)
        {
            //Characters: prototype, raven, rockstar, dj, outlaw.
            case "prototype":
                player.isAttacking = true;
                player.blockBreak = true;
                player.xMovementPossible = false;
                player.canAttack = false;
                rb.AddForce(Vector2.right * 5 * Mathf.Clamp(-player.distance, -1, 1), ForceMode2D.Impulse);
                animator.SetTrigger("HeavyMiddle");
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
