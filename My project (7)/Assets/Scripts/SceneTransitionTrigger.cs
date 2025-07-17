using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro kullanýyorsanýz bu satýrý ekleyin

public class SceneTransitionTrigger : MonoBehaviour
{
    public string targetSceneName; // Geçiþ yapýlacak sahnenin adý
    public TextMeshProUGUI interactionText; // UI Text objesi
    public KeyCode interactionKey = KeyCode.F; // Etkileþim tuþu

    private bool playerInRange = false;

    void Start()
    {
        // Baþlangýçta metni gizle
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Oyuncu menzil içindeyse ve etkileþim tuþuna basýldýysa sahne deðiþtir
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.LogWarning("Geçiþ yapýlacak sahne adý belirtilmemiþ! Lütfen Inspector'dan atayýn.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Oyuncu collider'a girdiðinde
        if (other.CompareTag("Player")) // Oyuncunuzun "Player" tag'ine sahip olduðundan emin olun
        {
            playerInRange = true;
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(true); // Metni göster
            }
            Debug.Log("Oyuncu kapý menziline girdi.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Oyuncu collider'dan çýktýðýnda
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(false); // Metni gizle
            }
            Debug.Log("Oyuncu kapý menzilinden çýktý.");
        }
    }
}