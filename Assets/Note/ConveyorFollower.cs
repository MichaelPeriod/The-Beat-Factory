using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorFollower : MonoBehaviour
{
    public float noteSpeed = 3f;
    private Rigidbody2D rb;
    public float ConveyorProximity = 0.05f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, ConveyorProximity, Vector2.zero);

        rb.velocity = Vector2.zero;
        foreach(RaycastHit2D hit in hits)
        {
            if(hit.collider.gameObject.TryGetComponent(out NotePusher np))
            {
                rb.velocity = np.tileDirection * noteSpeed;
                break;
            }
        }
    }
}
