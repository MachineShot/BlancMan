using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Range to pickup item
    public float radius = 1f;
    //Transform player;
    //bool hasInteracted = false;
    //Platformer.Mechanics.PlayerController positionOfPlayer;

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    //public void playerTransform()
    //{
    //    player = positionOfPlayer.setPlayerPosition();
    //    Debug.Log(player.position);
    //}
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
    private void Update()
    {
        ////playerTransform();
        //if (!hasInteracted)
        //{
            //float distance = Vector2.Distance(player.position, transform.position);
            //if (0.1 <= radius)
            //{
            //    Interact();
            //    //hasInteracted = true;
            //}
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //only exectue OnPlayerEnter if the player collides with this token.
        var player = other.gameObject.GetComponent<Platformer.Mechanics.PlayerController>();
        if (player != null) Interact();
    }
}
