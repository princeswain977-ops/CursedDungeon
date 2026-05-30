using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject chest;

    void Update()
    {
        GameObject[] enemies =
            GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            chest.SetActive(true);
        }
    }
}