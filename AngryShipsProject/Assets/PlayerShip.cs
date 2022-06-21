using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShip : MonoBehaviour
{
    float force;
    [SerializeField] public float maxForce;
    Rigidbody2D myRB;
    public UnityEvent collidedWithTarget;

    public float getForce() 
    {
        return force;
    }
    private void Awake()
    {
        myRB = this.GetComponent<Rigidbody2D>();
    }
    public void launch(Vector2 mousePos)
    {

        Vector2 forceDirection = mousePos - new Vector2(this.transform.position.x, this.transform.position.y);
        myRB.AddForce(forceDirection.normalized * force, ForceMode2D.Impulse);
    }
    public void loadForce(float increase) 
    {
        if (force <= maxForce)
        {
            force += increase;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target")) 
        {
            collidedWithTarget.Invoke();
        }
    }
}
