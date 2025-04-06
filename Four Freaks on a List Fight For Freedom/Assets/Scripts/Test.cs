using System.Collections;
using UnityEngine;


public class Test
{
    Player player;
    string characterChoice;
    Animator animator;
    AnimatorReference animReferance;

    public Test(Player self, string chosenCharacter, AnimatorReference animatorReference)
    {

        player = self;
        characterChoice = chosenCharacter;
        animator = player.animator;
        animReferance = animatorReference;
        // finish in player
    }
    // MAKE SURE ALL IDLE ANIMATIONS ARE NAMED "Idle"!
    // TURN "isAttacking" ON DURING ALL ATTACK ANIMATIONS IN ANIM
    // KEEP TRIGGERS AT START OF CODE (except for damage variables)
    public void LightHigh()
    {
        switch (characterChoice)
        {
            //Characters: prototype, raven, rockstar, dj, outlaw.
            case "prototype":
                animator.SetTrigger("HighPrimary");
                player.canAttack = false;
                player.rb.AddForce(Vector2.up * player.jumpHeight, ForceMode2D.Impulse);
               
                break;
            case "raven":
                animator.SetTrigger("HighPrimary");
                break;
            case "rockstar":
                player.lightDamage = 3;
                animator.SetTrigger("HighPrimary");
                player.canAttack = false;
                player.rb.AddForce(Vector2.up * player.jumpHeight, ForceMode2D.Impulse);
                player.rb.AddForce(Vector2.right * player.jumpHeight / 1.5f, ForceMode2D.Impulse);
                break;
            case "dj":
                player.lightDamage = 3;
                animator.SetTrigger("HighPrimary");
                player.canAttack = false;
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
                player.canAttack = false;
                animator.SetTrigger("MiddlePrimary");
                break;
            case "raven":
                animator.SetTrigger("MiddlePrimary");
                break;
            case "rockstar":
                player.lightDamage = 3;
                animator.SetTrigger("MiddlePrimary");
                player.canAttack = false;
                break;
            case "dj":
                player.lightDamage = 3;
                animator.SetTrigger("MiddlePrimary");
                player.canAttack = false;
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
                animator.SetTrigger("LowPrimary");
                player.canAttack = false;
                break;
            case "raven":
                animator.SetTrigger("LowPrimary");
                break;
            case "rockstar":
                player.lightDamage = 3;
                animator.SetTrigger("LowPrimary");
                player.canAttack = false;
                player.xMovementPossible = false;
                player.rb.AddForce(Vector2.left * player.jumpHeight * Mathf.Clamp(-player.distance, -1, 1), ForceMode2D.Impulse); 
                break;
            case "dj":
                player.lightDamage = 3;
                animator.SetTrigger("LowPrimary");
                player.canAttack = false;
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
                animator.SetTrigger("HeavyHigh");
                player.xMovementPossible = false;
                player.canAttack = false;
                break;
            case "raven":
                animator.SetTrigger("HeavyHigh");
                break;
            case "rockstar":
                player.heavyDamage = 6;
                animator.SetTrigger("HeavyHigh");
                player.xMovementPossible = false;
                player.canAttack = false;
                
                break;
            case "dj":
                animator.SetTrigger("HeavyHigh");
                player.canAttack= false;
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
                animator.SetTrigger("HeavyMiddle");
                player.isHeavyAttacking = true;
                player.blockBreak = true;
                player.xMovementPossible = false;
                player.canAttack = false;
                rb.AddForce(Vector2.right * 5 * Mathf.Clamp(-player.distance, -1, 1), ForceMode2D.Impulse);
                break;
            case "raven":
                animator.SetTrigger("HeavyMiddle");
                break;
            case "rockstar":
                player.heavyDamage = 7;
                animator.SetTrigger("HeavyMiddle");
                player.canAttack = false;
                player.blockBreak = true;

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
                player.xMovementPossible = false;
                player.canAttack = false;
                break;
            case "raven":

                break;
            case "rockstar":
                player.canAttack = false;
                animator.SetTrigger("HeavyLow");
                break;
            case "dj":

                break;
            case "outlaw":

                break;
        }

    }

    public void Update(float deltaTime)
    {
        
    }
}
