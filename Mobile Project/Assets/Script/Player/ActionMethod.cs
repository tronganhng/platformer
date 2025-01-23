using UnityEngine;

public static class ActionMethod
{
    public static bool isGround(StateManager Player)
    {
        return Physics2D.OverlapBox(Player.transform.position, new Vector3(0.8f, 0.25f, 0f), 0f, Player.groundLayer);
    }

    public static void Flip(StateManager Player)
    {
        if(Player.rb.velocity.x < 0)
        {
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(Player.rb.velocity.x > 0)
        {
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public static void Jump(StateManager Player)
    {
        if(Player.jumpCharge > 0)
        {
            Player.jumpCharge --;
            if(Player.rb != null)
            {
                Player.rb.gravityScale = Player.gravityUp;
                float veloY = Mathf.Sqrt(-2 * Physics2D.gravity.y * Player.gravityUp * Player.jumpHeight);
                Player.rb.velocity = new Vector2(Player.rb.velocity.x, veloY);
            }
        }
    }

    public static bool stickToWall(StateManager Player)
    {
        if(InputManager.instance.inputDirect != 0)
            return Physics2D.OverlapBox(Player.checkWallPoint.position, new Vector3(0.2f, 0.35f, 0f), 0f, Player.sticky_wallLayer);
        else
            return false;
    }
}
