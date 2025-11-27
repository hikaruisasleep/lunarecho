using UnityEngine;
using Unity.Cinemachine;

public class InitializeCinemachine : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player){
            assignFollowPoint() ;
        } else {
            player = GameObject.FindWithTag("Player");
        }
    }

    void assignFollowPoint() {
        CinemachineCamera virtualCamera = GetComponent<CinemachineCamera>();
        virtualCamera.Follow = player.transform;
    }
}
