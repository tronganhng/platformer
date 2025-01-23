using UnityEngine;

public class StateManager : MonoBehaviour
{
    IState currentState;
    public string stateTxt;
    public Animator ani;
    public Rigidbody2D rb;
    public ParticleSystem runParticle, landParticle;
    public GameObject trail;
    public LayerMask groundLayer, sticky_wallLayer;
    public Transform checkWallPoint;
    public int jumpCharge;
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float fallLimit = -30f;
    public float accelerateTime = 0.2f;
    public float decelerateTime = 0.13f;
    public float gravityUp = 4;
    public float gravityFall = 7;
    void Start()
    {
        ChangeState(new Idle());
    }
    void Update()
    {
        if(currentState != null)
            currentState.UpdateState(this);
    }

    public void ChangeState(IState newState)
    {
        if(currentState != null) currentState.EndState(this);
        currentState = newState;
        currentState.StartState(this);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(0.8f, 0.25f, 0f));   
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(checkWallPoint.position, new Vector3(0.2f, 0.35f, 0f));
    }
}

public interface IState
{
    void StartState(StateManager properties);
    void UpdateState(StateManager properties);
    void EndState(StateManager properties);
}