using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform spawnPoint;

    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.selectedCharacter != null)
        {
            Instantiate(GameManager.Instance.selectedCharacter.playerPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
