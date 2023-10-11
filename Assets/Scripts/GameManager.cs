using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;
    
    public List<int> playerIndex = new List<int>();
    public List<GameObject> spawnPoints = new List<GameObject>();
   
    public List<GameObject> playerCars = new List<GameObject>();
    private void Start()
    {
        //you can change GamePad to KeyBoard if you wan to use WASD
        playerInputManager.JoinPlayer(controlScheme: "GamePad");
        playerInputManager.JoinPlayer(controlScheme: "Keyboard2", pairWithDevice: Keyboard.current);
    }

    public void PlayerJoined(PlayerInput input)
    {
       playerCars.Add(input.gameObject);
        input.gameObject.name = $"Car{input.playerIndex}";
        playerIndex.Add(input.playerIndex);
        input.gameObject.GetComponent<Car>().playerIndex = input.playerIndex;
        
        //set position and rotation to the spawn point
        Vector3 spawnPosition = spawnPoints[input.playerIndex].transform.position;
        Quaternion spawnRotation = spawnPoints[input.playerIndex].transform.rotation;
        
        Rigidbody rb = input.GetComponent<Rigidbody>();

        rb.MovePosition(spawnPosition);
        rb.MoveRotation(spawnRotation);
    }

}
