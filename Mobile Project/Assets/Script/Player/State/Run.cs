using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : IState
{
    float startVelo;
    float veloX;
    public void StartState(StateManager Player)
    {
        Player.ani.SetInteger("State", (int)AnimState.Run);        
        Player.stateTxt = AnimState.Run.ToString();
        Player.jumpCharge = 1;
        GameEvents.instance.pressJump += ActionMethod.Jump;
        Player.runParticle.Play();
        veloX = Player.speed * 2/3;
        startVelo = veloX;
    }

    public void UpdateState(StateManager Player)
    {
        // Acceleration
        veloX += Time.deltaTime * (Player.speed - startVelo)/Player.accelerateTime;
        if (veloX >= Player.speed) veloX = Player.speed;
        // Move
        Player.rb.velocity = new Vector2(InputManager.instance.inputDirect * veloX, Player.rb.velocity.y);
        ActionMethod.Flip(Player);

        // Change State
        if(InputManager.instance.inputDirect == 0)
        {
            Idle idle = new Idle();
            idle.deceleration = true;
            idle.veloX = veloX;
            Player.ChangeState(idle);
        }

        if(!ActionMethod.isGround(Player))
        {
            Player.ChangeState(new InAir());
        }
    }

    public void EndState(StateManager Player)
    {
        GameEvents.instance.pressJump -= ActionMethod.Jump;
        Player.runParticle.Stop();
    }
}
