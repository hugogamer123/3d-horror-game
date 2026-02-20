using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuUI;
    bool IsPaused;

    void Awake()
    {
        MenuUI.SetActive(false);
    }
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            MenuUI.SetActive(!MenuUI.activeSelf);
            IsPaused = MenuUI.activeSelf;
        }
        if (IsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
