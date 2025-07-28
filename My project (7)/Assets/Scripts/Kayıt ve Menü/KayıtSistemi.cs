using UnityEngine;

public class KayıtSistemi : MonoBehaviour
{
    public Transform karakterKonumu;
    public GorevYonetici gorevYonetici;
    private int aktifGorevID;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Kaydet();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            Yukle();
        }
    }

    public void Kaydet()
    {
        KayıtVerileri state = new KayıtVerileri
        {
            konumX = karakterKonumu.position.x,
            konumY = karakterKonumu.position.y,
            konumZ = karakterKonumu.position.z,
            aktifGorevID = gorevYonetici.aktifGorevID
        };

        string json = JsonUtility.ToJson(state);
        PlayerPrefs.SetString("Kayıt", json);
        PlayerPrefs.Save();

        Debug.Log("Konum kaydedildi!");
    }

    public void Yukle()
    {
        if (PlayerPrefs.HasKey("Kayıt"))
        {
            string json = PlayerPrefs.GetString("Kayıt");
            KayıtVerileri state = JsonUtility.FromJson<KayıtVerileri>(json);

            Vector3 konum = new Vector3(state.konumX, state.konumY, state.konumZ);
            karakterKonumu.position = konum;

            gorevYonetici.aktifGorevID = aktifGorevID;

            Debug.Log("Kayıt yüklendi!");
        }
        else
        {
            Debug.LogWarning("Kayıt bulunamadı!");
        }
    }
}
