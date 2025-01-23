using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAir : IState
{
    Vector2 velo;
    public void StartState(StateManager Player)
    {
        Player.ani.SetInteger("State", (int)AnimState.InAir);
        Player.stateTxt = AnimState.InAir.ToString();
        GameEvents.instance.pressJump += AirJump;
        Player.jumpCharge = 0;
        Player.rb.gravityScale = Player.gravityUp;
        Player.trail.SetActive(true);
    }

    public void UpdateState(StateManager Player)
    {        
        velo.x = InputManager.instance.inputDirect * Player.speed;
        velo.y = Player.rb.velocity.y;
        Player.rb.velocity = velo;
        ActionMethod.Flip(Player);
        
        if(Player.rb.velocity.y < Player.fallLimit)
        {
            velo.y = Player.fallLimit;
            Player.rb.velocity = velo;
        }

        if(Player.rb.velocity.y < 0)
        {
            Player.ani.SetBool("fall", true);
            Player.rb.gravityScale = Player.gravityFall;
        }
        else
        {
            Player.ani.SetBool("fall", false);
            Player.rb.gravityScale = Player.gravityUp;
        }
        
        if(ActionMethod.isGround(Player))
        {
            Player.landParticle.Play();
            if(InputManager.instance.inputDirect == 0)
                Player.ChangeState(new Idle());
            else
                Player.ChangeState(new Run());
        }    

        if(ActionMethod.stickToWall(Player))
        {
            Player.ChangeState(new WallClimb());
        }
    }

    public void EndState(StateManager Player)
    {
        GameEvents.instance.pressJump -= AirJump;
        Player.ani.ResetTrigger("boost jump");
        Player.rb.gravityScale = Player.gravityUp;
        Player.trail.SetActive(false);
    }

    public void AirJump(StateManager Player)
    {
        if(Player.jumpCharge > 0)
        {
            Player.ani.SetTrigger("boost jump");
            ActionMethod.Jump(Player);
        }
    }
}
