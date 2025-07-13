using UnityEngine;
using UnityEngine.SceneManagement; // Sahne y�netimi i�in gerekli
using TMPro; // TextMeshPro kullan�yorsak bu k�t�phane gerekli

public class DoorInteraction : MonoBehaviour
{
    // Inspector'dan s�r�kleyip b�rakaca��m�z UI Text objesi
    // TextMeshPro kulland���m�z i�in TMPro.TextMeshProUGUI tipinde
    public TextMeshProUGUI doorPromptText;

    // Hangi g�reve g�re sahne y�klenece�ini belirleyen basit bir de�i�ken
    // Ger�ek bir oyunda bu, GameManager gibi merkezi bir yerden gelmeli
    public int currentQuestID = 1; // Ba�lang��ta 1. g�revde oldu�umuzu varsayal�m

    // G�rev ID'lerine g�re y�klenecek sahne isimlerini tutan basit bir yap�
    // Daha karma��k g�rev sistemlerinde bu, ScriptableObject veya Dictionary olabilir
    [System.Serializable] // Bu s�n�f�n Inspector'da g�r�nmesini sa�lar
    public class QuestSceneMapping
    {
        public int questID;
        public string sceneName;
    }

    public QuestSceneMapping[] questSceneMappings; // Inspector'dan ayarlayaca��z

    // Karakterin collider i�inde olup olmad���n� takip eden de�i�ken
    private bool isPlayerInsideTrigger = false;

    void Start()
    {
        // Oyun ba�lad���nda UI yaz�s�n� gizle
        if (doorPromptText != null)
        {
            doorPromptText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // E�er oyuncu trigger'�n i�indeyse VE 'F' tu�una bas�ld�ysa
        if (isPlayerInsideTrigger && Input.GetKeyDown(KeyCode.F))
        {
            LoadQuestSpecificScene();
        }
    }

    // Karakter trigger'�n i�ine girdi�inde �al���r
    private void OnTriggerEnter(Collider other)
    {
        // Giren objenin "Player" tag'ine sahip olup olmad���n� kontrol et
        // Karakterinizin objesinde "Player" tag'i oldu�undan emin olun!
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = true;
            if (doorPromptText != null)
            {
                doorPromptText.gameObject.SetActive(true); // Yaz�y� g�ster
            }
            Debug.Log("Oyuncu kap� trigger'�na girdi!");
        }
    }

    // Karakter trigger'dan ��kt���nda �al���r
    private void OnTriggerExit(Collider other)
    {
        // ��kan objenin "Player" tag'ine sahip olup olmad���n� kontrol et
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = false;
            if (doorPromptText != null)
            {
                doorPromptText.gameObject.SetActive(false); // Yaz�y� gizle
            }
            Debug.Log("Oyuncu kap� trigger'�ndan ��kt�!");
        }
    }

    // G�reve �zel sahneyi y�kleyen metot
    private void LoadQuestSpecificScene()
    {
        string targetSceneName = "";

        // currentQuestID'ye g�re do�ru sahneyi bul
        foreach (var mapping in questSceneMappings)
        {
            if (mapping.questID == currentQuestID)
            {
                targetSceneName = mapping.sceneName;
                break; // E�le�en sahne bulundu, d�ng�den ��k
            }
        }

        if (!string.IsNullOrEmpty(targetSceneName))
        {
            // Sahneyi y�klemeden �nce UI yaz�s�n� gizle
            if (doorPromptText != null)
            {
                doorPromptText.gameObject.SetActive(false);
            }

            // Sahneyi y�kle
            SceneManager.LoadScene(targetSceneName);
            Debug.Log($"Sahne y�kleniyor: {targetSceneName} (G�rev ID: {currentQuestID})");
        }
        else
        {
            Debug.LogError($"Hata: G�rev ID {currentQuestID} i�in tan�mlanm�� bir sahne bulunamad�!");
        }
    }
}
