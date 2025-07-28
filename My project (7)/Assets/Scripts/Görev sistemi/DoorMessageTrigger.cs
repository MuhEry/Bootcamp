using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DoorMessageTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI doorMessageText; // Inspector'dan baðlayacaðýmýz UI metni
    [SerializeField] private string messageToShow = "F'ye basarak kapýyý kontrol et"; // Gösterilecek mesaj
    [SerializeField] private GorevYonetici gorevYonetici;
    [SerializeField] private KayýtSistemi kayýtSistemi;

    private bool Kapýda = false;

    void Start()
    {
        // Oyun baþladýðýnda metni  gizle
        if (doorMessageText != null)
        {
            doorMessageText.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Kapýda && Input.GetKeyDown(KeyCode.F))
        {
            if (kayýtSistemi != null)
                kayýtSistemi.Kaydet();

            SceneManager.LoadScene(gorevYonetici.aktifGorevID.ToString());

            if (gorevYonetici != null)
                gorevYonetici.GoreviTamamlaVeSonrakineGec();

            if (kayýtSistemi != null)
                kayýtSistemi.Yukle();
        }
    }

    // Oyuncu tetikleyiciye girdiðinde çaðrýlýr
    private void OnTriggerEnter(Collider other)
    {
        // Oyuncu karakterinizin bir "Player" Tag'i olduðundan emin olun
        if (other.CompareTag("Player"))
        {
            Kapýda = true;
            if (doorMessageText != null)
            {
                doorMessageText.text = messageToShow; // Mesajý ayarla
                doorMessageText.gameObject.SetActive(true); // Metni görünür yap
            }
        }
    }

    // Oyuncu tetikleyiciden çýktýðýnda çaðrýlýr
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Kapýda = false;
            if (doorMessageText != null)
            {
                doorMessageText.gameObject.SetActive(false); // Metni gizle
            }
        }
    }
}