using UnityEngine;

public interface IPushTrap
{
    public void pushPlayer(float pushHeight, Rigidbody2D playerRb)
    {
        float veloY = Mathf.Sqrt(-2 * playerRb.GetComponent<StateManager>().gravityUp * Physics2D.gravity.y * pushHeight);
        playerRb.velocity = new Vector2(playerRb.velocity.x, veloY);
    }
}