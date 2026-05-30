using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Transform player;

    public Vector2 nextRoomPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.position = nextRoomPosition;
        }
    }
}