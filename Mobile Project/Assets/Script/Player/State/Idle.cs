using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle: IState
{
    public bool deceleration;
    public float veloX;
    float startVelo;
    public void StartState(StateManager Player)
    {
        Player.ani.SetInteger("State", (int)AnimState.Idle);
        Player.stateTxt = AnimState.Idle.ToString();
        Player.jumpCharge = 1;
        GameEvents.instance.pressJump += ActionMethod.Jump;
        startVelo = veloX;
        if(!deceleration) Player.rb.velocity = new Vector2(0, Player.rb.velocity.y);
    }

    public void UpdateState(StateManager Player)
    {
        // Deceleration
        if(deceleration) 
        {
            veloX -= Time.deltaTime * startVelo/Player.decelerateTime;
            if(veloX <= 0) veloX = 0;
            Player.rb.velocity = new Vector2(veloX * Player.transform.right.x, Player.rb.velocity.y);
        }
        // Change State       
        if(InputManager.instance.inputDirect != 0)
        {
            Player.ChangeState(new Run());
        }

        if(!ActionMethod.isGround(Player))
        {
            Player.ChangeState(new InAir());
        }
    }

    public void EndState(StateManager Player)
    {
        GameEvents.instance.pressJump -= ActionMethod.Jump;
    }
}
