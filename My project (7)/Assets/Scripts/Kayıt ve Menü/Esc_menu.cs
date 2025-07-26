using UnityEngine;

public class Esc_menu : MonoBehaviour
{
    public GameObject menu;
    private bool acikMi = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (acikMi)
                Devam();
            else
                Durdur();
        }
    }

    public void Devam()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        acikMi = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Durdur()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        acikMi = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Kapat()
    {
        Debug.Log("Oyun kapatýldý");
        Application.Quit();
    }
}
