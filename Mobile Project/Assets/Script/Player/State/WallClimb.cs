using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : IState
{
    float veloY = -1.8f;
    public void StartState(StateManager Player)
    {
        Player.ani.SetInteger("State", (int)AnimState.WallClimb);
        Player.stateTxt = AnimState.WallClimb.ToString();  
        Player.jumpCharge = 1;
        Player.rb.gravityScale = 0;
        GameEvents.instance.pressJump += WallJump;
    }

    public void UpdateState(StateManager Player)
    {
        Deceleration(Player);
        if(ActionMethod.isGround(Player))
        {
            Player.ChangeState(new Idle());
        }
        else
        {
            bool checkWall = Physics2D.OverlapBox(Player.checkWallPoint.position, new Vector3(0.2f, 0.35f, 0f), 0f, Player.sticky_wallLayer);
            if(!checkWall)
                Player.ChangeState(new InAir());
        }
    }

    public void EndState(StateManager Player)
    {
        Player.rb.gravityScale = Player.gravityUp;
        GameEvents.instance.pressJump -= WallJump;
    }

    void Deceleration(StateManager Player)
    {
        if(veloY >= 0) veloY = 0;
        else veloY += Time.deltaTime * 10;
        Player.rb.velocity = new Vector2(Player.transform.right.x * 3, veloY);
    }

    void WallJump(StateManager Player)
    {
        if(Player.jumpCharge > 0)
        {
            if(InputManager.instance.inputDirect * Player.transform.right.x <= 0)
            {
                ActionMethod.Jump(Player);
                Player.ChangeState(new InAir());
            }
        }
    }
}
