using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Test
{
    Player player;
    string characterChoice;
    Animator animator;
    AnimatorReference animReference;

    public Test(Player self, string chosenCharacter, AnimatorReference animatorReference)
    {

        player = self;
        characterChoice = chosenCharacter;
        animator = player.animator;
        animReference = animatorReference;
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
                player.knockback = 3.5f;
                player.lightDamage = 3;
                animator.SetTrigger("HighPrimary");
                player.canAttack = false;
                break;
            case "rockstar":
                if (player.isGrounded)
                {
                    player.knockback = 3.5f;
                    player.lightDamage = 3;
                    animator.SetTrigger("HighPrimary");
                    player.canAttack = false;
                    player.rb.AddForce(Vector2.up * player.jumpHeight, ForceMode2D.Impulse);
                    player.rb.AddForce(Vector2.right * player.jumpHeight / 1.5f, ForceMode2D.Impulse);
                }
                break;
            case "dj":
                player.knockback = 3.5f;
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
                player.knockback = 3.5f;
                player.lightDamage = 3;
                animator.SetTrigger("MiddlePrimary");
                player.canAttack = false;
                break;
            case "rockstar":
                player.knockback = 3.5f;
                player.lightDamage = 3;
                animator.SetTrigger("MiddlePrimary");
                player.canAttack = false;
                break;
            case "dj":
                player.knockback = 3.5f;
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
                player.knockback = 3.5f;
                player.lightDamage = 3;
                animator.SetTrigger("LowPrimary");
                player.canAttack = false;
                break;
            case "rockstar":
                if (animReference.cooldown >= 1.5f)
                {
                    player.lightDamage = 3;
                    player.knockback = 3.5f;
                    animator.SetTrigger("LowPrimary");
                    player.canAttack = false;
                    player.xMovementPossible = false;
                    player.rb.AddForce(Vector2.left * player.jumpHeight * Mathf.Clamp(-player.distance, -1, 1), ForceMode2D.Impulse);
                    animReference.cooldown = 0;
                }
                break;
            case "dj":
                player.knockback = 3.5f;
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
                player.knockback = 1.5f;
                player.heavyDamage = 2;
                animReference.RFHeavyHighCooldown();
                player.canAttack = false;
                break;
            case "rockstar":
                player.knockback = 3.5f;
                player.heavyDamage = 6;
                animator.SetTrigger("HeavyHigh");
                player.xMovementPossible = false;
                player.canAttack = false;
                break;
            case "dj":
                player.knockback = 4f;
                animator.SetTrigger("HeavyHigh");
                player.canAttack = false;
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
                if (animReference.cooldown2 >= 5)
                {
                    player.heavyDamage = 15;
                    player.knockback = 10;
                    animator.SetTrigger("HeavyMiddle");
                    player.canAttack = false;
                }
                break;
            case "rockstar":
                player.heavyDamage = 7;
                player.knockback = 3.5f;
                animator.SetTrigger("HeavyMiddle");
                player.canAttack = false;
                player.blockBreak = true;

                break;
            case "dj":
                player.heavyDamage = 2;
                player.knockback = 2;
                animator.SetTrigger("HeavyMiddle");
                player.canAttack = false;
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
                if (animReference.cooldown3 >= 6)
                {
                    animator.SetTrigger("HeavyLow");
                    player.blockBreak = true;
                    player.canAttack = false;
                    player.invulnerable = true;
                    player.xMovementPossible = false;
                    animReference.cooldown3 = 0;
                }
                break;
            case "rockstar":
                player.canAttack = false;
                animator.SetTrigger("HeavyLow");
                break;
            case "dj":
                if (animReference.cooldown >= 6)
                {
                    player.blockBreak = true;
                    player.knockback = 0;
                    player.heavyDamage = 1;
                    animator.SetTrigger("HeavyLow");
                    player.canAttack = false;
                    animReference.cooldown = 0;
                }
                break;
            case "outlaw":

                break;
        }

    }
}
