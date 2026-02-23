using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private Slider mouseXslider;
    [SerializeField] private Slider mouseYslider;
    bool IsPaused;

    void Awake()
    {
        MenuUI.SetActive(false);
        mouseXslider.minValue = 0f;
        mouseXslider.maxValue = 10f;
        mouseYslider.minValue = 0f;
        mouseYslider.maxValue = 10f;

        mouseXslider.value = 3f;
        mouseYslider.value = 3f;
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
