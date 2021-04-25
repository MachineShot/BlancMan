using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1f;

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Platformer.Mechanics.PlayerController>();
        if (player != null) Interact();
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
