using TMPro;
using UnityEngine;

public class GorevYonetici : MonoBehaviour
{
    public GorevVeritabani gorevVeritabani;
    public int aktifGorevID = 1;
    public TextMeshProUGUI gorevGosterge;

    public BoxCollider Azeran;
    public BoxCollider Durnheim;
    public BoxCollider Velmora;

    void Start()
    {
        Gorev aktifGorev = gorevVeritabani.GetirGorev(aktifGorevID);
        GoreviGoster(aktifGorev);
    }

    public void GoreviTamamlaVeSonrakineGec()
    {
        aktifGorevID++;
        Gorev yeniGorev = gorevVeritabani.GetirGorev(aktifGorevID);
        if (yeniGorev != null)
            GoreviGoster(yeniGorev);
        else
            Debug.Log("Tüm görevler tamamlandı.");
    }

    void GoreviGoster(Gorev gorev)
    {
        Debug.Log("Görev: " + gorev.ad);
        gorevGosterge.text = gorev.tanim;
        Debug.Log("Mesaj:\n" + gorev.mesaj);

        Durnheim.enabled = false;
        Azeran.enabled = false;
        Velmora.enabled = false;

        // Sadece hedef krallığın collider'ını aç
        switch (gorev.hedefKrallik.ToLower())
        {
            case "durnheim":
                Durnheim.enabled = true;
                break;
            case "azeran":
                Azeran.enabled = true;
                break;
            case "velmora":
                Velmora.enabled = true;
                break;
        }
    }
}