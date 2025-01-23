using UnityEngine;

public class RockHeadDamage : MonoBehaviour
{
    public RockHead rockHead;
    public LayerMask groundLayer;
    public float rayDistance = 2f;

    Vector2 direct;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tag.Player))
        {            
            SetDirect(other);
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direct, rayDistance, groundLayer);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject != gameObject)
                {
                    GameEvents.instance.playerDeath?.Invoke(true);
                }
            }
            Debug.DrawRay(transform.position, direct * rayDistance, Color.red);
        }
    }

    void SetDirect(Collision2D other)
    {
        Vector2 dir1 = rockHead.points[rockHead.index].position - transform.position;
        dir1 = dir1.normalized;
        
        Vector3 playerPos = new Vector3(other.transform.position.x, other.transform.position.y + 1, 0);
        Vector2 dir2 = playerPos - transform.position;
        dir2 = RoundVector(dir2);
        dir1 = RoundVector(dir1);

        if(dir1 == dir2) direct = dir1;
        else direct = Vector2.zero;
    }

    Vector2 RoundVector(Vector2 input)
    {
        if(Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            return new Vector2(Mathf.Sign(input.x), 0);
        }
        else
        {
            return new Vector2(0, Mathf.Sign(input.y));
        }
    }
}
