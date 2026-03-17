using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] protected Player player;
    [SerializeField] protected GameObject enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.Init(100, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
