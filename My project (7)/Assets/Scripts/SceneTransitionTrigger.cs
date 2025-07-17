using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro kullan�yorsan�z bu sat�r� ekleyin

public class SceneTransitionTrigger : MonoBehaviour
{
    public string targetSceneName; // Ge�i� yap�lacak sahnenin ad�
    public TextMeshProUGUI interactionText; // UI Text objesi
    public KeyCode interactionKey = KeyCode.F; // Etkile�im tu�u

    private bool playerInRange = false;

    void Start()
    {
        // Ba�lang��ta metni gizle
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Oyuncu menzil i�indeyse ve etkile�im tu�una bas�ld�ysa sahne de�i�tir
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.LogWarning("Ge�i� yap�lacak sahne ad� belirtilmemi�! L�tfen Inspector'dan atay�n.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Oyuncu collider'a girdi�inde
        if (other.CompareTag("Player")) // Oyuncunuzun "Player" tag'ine sahip oldu�undan emin olun
        {
            playerInRange = true;
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(true); // Metni g�ster
            }
            Debug.Log("Oyuncu kap� menziline girdi.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Oyuncu collider'dan ��kt���nda
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(false); // Metni gizle
            }
            Debug.Log("Oyuncu kap� menzilinden ��kt�.");
        }
    }
}