using UnityEngine;
using Unity.VisualScripting;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject gameUI;
    public GameObject gameOverUI;
    public GameObject tryHaderUI;
    private bool isGameOver = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DamagedPlayer();

        GameEnd();
    }

    private void DamagedPlayer()
    {
    if (playerHealth.healthText.text == "Health: 90")
    {
        gameUI.SetActive(true);
    }
    else if (playerHealth.healthText.text == "Health: 100")
        {
            gameUI.SetActive(false);
        }

    if (playerHealth.healthText.text == "Health: 0")
        {
            GameEnd();
        }
    }
    void GameEnd()
    {
        if (playerHealth.health <= 0 && isGameOver == false)
        {
            isGameOver = true;
            StartCoroutine(BeforeEnd());
        }
    }

    IEnumerator BeforeEnd()
    {
        playerHealth.healthText.text = "Health: 0";
        player.SetActive(false);
        gameUI.SetActive(false);
        tryHaderUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        tryHaderUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

}
