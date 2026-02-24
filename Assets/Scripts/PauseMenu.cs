using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuUI;
    [SerializeField] public Slider mouseXslider;
    [SerializeField] public Slider mouseYslider;
    public bool IsPaused;

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
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) || UnityEngine.Input.GetKeyDown(KeyCode.Q))
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

        if(IsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Debug.Log("Mouse X Sensitivity: " + mouseXslider.value);
        Debug.Log("Mouse Y Sensitivity: " + mouseYslider.value);
    }
}
