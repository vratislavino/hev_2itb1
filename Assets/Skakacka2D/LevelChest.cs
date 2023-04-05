using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChest : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite openedChest;
    [SerializeField]
    private Sprite closedChest;

    bool isPlayerIn = false;

    [SerializeField]
    private string levelToLoad;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var player = collision.GetComponent<PlayerCoins>();
        if(player != null) {
            OpenChest();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        var player = collision.GetComponent<PlayerCoins>();
        if (player != null) {
            CloseChest();
        }
    }

    private void OpenChest() {
        spriteRenderer.sprite = openedChest;
        isPlayerIn = true;
    }

    private void CloseChest() {
        spriteRenderer.sprite = closedChest;
        isPlayerIn = false;
    }

    private void Update() {
        if(isPlayerIn) {
            if(Input.GetKeyDown(KeyCode.E)) {
                LoadLevel(levelToLoad);
            }
        }
    }

    private void LoadLevel(string level) {
        // TODO LOAD LEVEL
        SceneManager.LoadScene(level);
    }
}
