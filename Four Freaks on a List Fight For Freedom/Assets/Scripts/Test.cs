using System;
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
    int distanceCheck()
    {
        if (player.distance < 0) return 1;
        if (player.distance > 0) return -1;
        return 1;
    }

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
                player.lightDamage = 1.5f;
                AudioManager.Instance.Play(4);
                animator.SetTrigger("HighPrimary");
                player.canAttack = false;
                break;
            case "rockstar":
                if (player.isGrounded)
                {
                    Passive passive = player.transform.GetComponent<Passive>();
                    player.knockback = 3.5f;
                    player.lightDamage = 2;
                    animator.SetTrigger("HighPrimary");
                    player.canAttack = false;
                    AudioManager.Instance.Play(6);
                    player.rb.AddForce(Vector2.up * player.jumpHeight, ForceMode2D.Impulse);
                    player.rb.AddForce(Vector2.right * player.jumpHeight / 1.5f, ForceMode2D.Impulse);
                    passive.input = 3;
                }
                break;
            case "dj":
                player.knockback = 3.5f;
                player.lightDamage = 1.5f;
                animator.SetTrigger("HighPrimary");
                player.canAttack = false;
                break;
            case "outlaw":
                player.knockback = 2;
                player.lightDamage = 2.5f;
                animator.SetTrigger("HighPrimary");
                player.canAttack = false;
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
                player.lightDamage = 1.5f;
                AudioManager.Instance.Play(4);
                animator.SetTrigger("MiddlePrimary");
                player.canAttack = false;
                break;
            case "rockstar":
                Passive passive = player.transform.GetComponent<Passive>();
                player.knockback = 3.5f;
                player.lightDamage = 2;
                AudioManager.Instance.Play(6);
                animator.SetTrigger("MiddlePrimary");
                player.canAttack = false;
                passive.input = 2;
                break;
            case "dj":
                player.knockback = 3.5f;
                player.lightDamage = 1.5f;
                animator.SetTrigger("MiddlePrimary");
                player.canAttack = false;
                break;
            case "outlaw":
                player.knockback = 1;
                player.lightDamage = 2;
                animator.SetTrigger("MiddlePrimary");
                player.canAttack = false;
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
                player.lightDamage = 1.5f;
                AudioManager.Instance.Play(4);
                animator.SetTrigger("LowPrimary");
                player.canAttack = false;
                break;
            case "rockstar":
                if (animReference.cooldown >= 1.5f)
                {
                    Passive passive = player.transform.GetComponent<Passive>();
                    player.lightDamage = 2;
                    player.knockback = 3.5f;
                    animator.SetTrigger("LowPrimary");
                    player.canAttack = false;
                    AudioManager.Instance.Play(6);
                    player.rb.AddForce(Vector2.left * player.jumpHeight * distanceCheck(), ForceMode2D.Impulse);
                    animReference.cooldown = 0;
                    passive.input = 1;
                }
                break;
            case "dj":
                player.knockback = 1.5f;
                player.lightDamage = 3;
                animator.SetTrigger("LowPrimary");
                player.canAttack = false;
                break;
            case "outlaw":
                player.knockback = 2;
                player.lightDamage = 2.5f;
                animator.SetTrigger("LowPrimary");
                player.canAttack = false;
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
                player.knockback = 2f;
                player.heavyDamage = 2.5f;
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
                player.knockback = 0;
                player.heavyDamage = 3.5f;
                animator.SetTrigger("HeavyHigh");
                player.canAttack = false;
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
                    player.heavyDamage = 8;
                    player.knockback = 7;
                    animator.SetTrigger("HeavyMiddle");
                    player.canAttack = false;
                }
                break;
            case "rockstar":
                if (animReference.cooldown2 >= 4)
                { 
                    player.heavyDamage = 4;
                    player.knockback = 3.5f;
                    AudioManager.Instance.Play(9);
                    animator.SetTrigger("HeavyMiddle");
                    player.canAttack = false;
                    player.blockBreak = true;
                    animReference.cooldown2 = 0;
                }
                break;
            case "dj":
                player.heavyDamage = 2;
                player.knockback = 2;
                AudioManager.Instance.Play(0);
                animator.SetTrigger("HeavyMiddle");
                player.canAttack = false;
                break;
            case "outlaw":
                if (animReference.cooldown >= 5)
                player.knockback = 0;
                player.instantiatedDamage = 0.35f;
                player.canAttack = false;
                AudioManager.Instance.Play(1);
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
                    AudioManager.Instance.Play(12);
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
                AudioManager.Instance.Play(11);
                animator.SetTrigger("HeavyLow");
                break;
            case "dj":
                if (animReference.cooldown >= 6)
                {
                    player.blockBreak = true;
                    player.knockback = 0;
                    player.heavyDamage = 0.5f;
                    AudioManager.Instance.Play(10);
                    animator.SetTrigger("HeavyLow");
                    player.canAttack = false;
                    animReference.cooldown = 0;
                }
                break;
            case "outlaw":
                if (animReference.cooldown2 >= 4)
                {
                    player.instantiatedDamage = 3f;
                    player.canAttack = false;
                    player.blockBreak = true;
                    AudioManager.Instance.Play(5);
                    animator.SetTrigger("HeavyLow");
                    animReference.cooldown2 = 0;
                }
                break;
        }

    }
}
