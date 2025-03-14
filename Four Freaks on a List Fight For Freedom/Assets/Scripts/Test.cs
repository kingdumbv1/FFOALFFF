using UnityEngine;

public class Test
{
    Player player;
    Animator animator;

    public Test(Player self)
    {
        player = self;
        animator = player.animator;
    }
    public void HeavyMiddle(Rigidbody2D rb)
    {
        player.xMovementPossible = false;
        player.canAttack = false;
        rb.AddForce(Vector2.right * 5 * Mathf.Clamp(-player.distance, -1, 1), ForceMode2D.Impulse);
        animator.SetTrigger("HeavyMiddle");
    }
   
}
