using UnityEngine;
using Unity.Cinemachine;

public class PlayerSpawnSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector3 spawnPosition;
    public Vector3 spawnRotation;

    private GameObject player;
    private GameObject cinemachineCamera;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cinemachineCamera = GameObject.FindWithTag("Cinemachine");

        if(!player) {
            if(SceneMemory.lastOutdoorPosition != Vector3.zero && SceneMemory.outdoor) {
                player = Instantiate(playerPrefab, SceneMemory.lastOutdoorPosition, Quaternion.Euler(spawnRotation));    
            } else {
                player = Instantiate(playerPrefab, spawnPosition, Quaternion.Euler(spawnRotation));    
            }
        }

        CinemachineCamera c = cinemachineCamera.GetComponent<CinemachineCamera>();

        Debug.Log(player);
        Debug.Log(cinemachineCamera);
        Debug.Log(c);

        c.Follow = player.transform;
        c.LookAt = player.transform;
        
    }   
}
