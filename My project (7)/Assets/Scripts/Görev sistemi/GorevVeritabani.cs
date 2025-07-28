using System.Collections.Generic;
using UnityEngine;

public class GorevVeritabani : MonoBehaviour
{
    private Dictionary<int, Gorev> gorevler = new Dictionary<int, Gorev>();

    void Awake()
    {
        GorevleriYukle();
    }

    private void GorevleriYukle()
    {
        gorevler.Add(1, new Gorev
        {
            id = 1,
            ad = "Barış Mesajı",
            tanim = "Azeran, seni Durnheim’e barış görüşmeleri için gönderir.",
            mesaj = "Azeran Krallığı'nın saygıdeğer Durnheim Kralı’na,\n\nHuzur dolu kalbimle selamlarımı iletiyorum. Zamanın getirdiği zorluklar karşısında, düşmanlarımızla başa çıkabilmemiz için aramızda kalıcı bir barışın tesis edilmesi elzemdir. Birlikte hareket ettiğimizde, güçlerimizin bir araya gelmesi, her iki krallığın da geleceğini güvence altına alacaktır. Bu teklifi değerlendirmenizi temenni ederim. Huzurumuzun, ancak kardeşlik içinde sağlanabileceğini unutmayalım.\n\nSaygılarımla,\nAzeran Kralı",
            konusma = "Azeran Kralı: Elçim, bu değerli mesajı Durnheim’a iletmek senin görevin. Barış, iki krallığın huzuru için şart. Unutma ki, düşmanlarımızın her an pusu kurduğu bir ortamdayız.\nElçi: Majesteleri, Durnheim liderinin bu teklife nasıl yaklaşacağını bilemiyorum. Belki de geçmişteki çatışmalar, onu temkinli olmaya itecektir.\nAzeran Kralı: Sadece gerçeği aktar. Birlikte güçlenmenin önemini vurgula. Eğer bu fırsatı değerlendirebilirsek, hem bizim hem de onların geleceği güvence altına alınmış olur.",
            hedefKrallik = "Azeran",
        });

        gorevler.Add(2, new Gorev
        {
            id = 2,
            ad = "Tehdit Uyarısı",
            tanim = "Velmora, Durnheim’de bir tehdit olduğuna inanıyor ve bu bilgiyi iletmeni istiyor.",
            mesaj = "Değerli Durnheim Kralı,\n\nVelmora Krallığı'ndan gelen haberler, iç huzursuzlukların büyük bir çatışmaya dönüşme potansiyeli taşıdığını göstermektedir. Durnheim'in güvenliği, bu belirsizlikler altında tehdit altındadır. Bu durumu dikkate almanızı ve gerekli önlemleri almanızı tavsiye ederim. Bu tür durumlar, geçmişte birçok krallığın yıkımına yol açmıştır; dikkatli olmakta fayda var.\n\nSaygılarımla,\nVelmora Kralı",
            konusma = "Velmora Kralı: Elçim, bu uyarıyı Durnheim liderine iletmekte acele etmelisin. İçteki huzursuzluk tehlikeli ve zamanla daha da büyüyebilir.\nElçi: Majesteleri, bu durumu nasıl açıklamalıyım? Durnheim lideri bu tür bir habere nasıl bir tepki verebilir?\nVelmora Kralı: Gerçekleri aktar. Onların güvenliği için hazırlıklı olmaları gerektiğini belirt. Unutma ki, krallıklar arasındaki dayanışma, bu tür tehditleri bertaraf edebilir.",
            hedefKrallik = "Durnheim",
        });

        gorevler.Add(3, new Gorev
        {
            id = 3,
            ad = "Mühürlerin Bilgisi",
            tanim = "Durnheim Krallığı, Azeran’dan mühürlerin nerede bulunduğuna dair bilgi talep ediyor.",
            mesaj = "Saygıdeğer Durnheim Kralı,\n\nAzeran Krallığı, sizden gelen talep doğrultusunda, kayıp mühürlerin konumlarına dair bilgileri sunmaktan mutluluk duyar. Bu mühürler, geçmişin bilgeliğini ve gücünü taşımaktadır. Onların doğru ellerde kullanılması, her iki krallığın da yararına olacaktır. Bu bilgiyi değerlendirmenizi rica ederim; çünkü bu mühürlerin bir araya gelmesi, eski barışı yeniden tesis edebilir.\n\nSaygılarımla,\nAzeran Kralı",
            konusma = "Durnheim Kralı: Elçi, Azeran’dan bu mühürlerin konumunu öğrenmemiz gerekiyor. Bilgi çok kıymetli ve bu güç, dengemizi sağlayabilir.\nElçi: Majesteleri, Azeran Kralı bilgiyi paylaşmaya hazır. Ancak bu bilgi, güç dengesini değiştirebilir. Bunu göz önünde bulundurmalıyız.\nDurnheim Kralı: Bunu dikkate al. Ancak bilgiye ihtiyacımız var. Geçmişteki hataları tekrarlamamak için güçlü adımlar atmalıyız.",
            hedefKrallik = "Durnheim",
        });

        gorevler.Add(4, new Gorev
        {
            id = 4,
            ad = "Gizemli İttifak",
            tanim = "Azeran, Velmora'nın Durnheim ile gizli bir ittifak kurduğu hakkında endişelerini dile getiriyor.",
            mesaj = "Değerli Durnheim Kralı,\n\nAzeran Krallığı olarak, Velmora'nın Durnheim ile gizli bir ittifak kurma niyetinde olduğuna dair endişelerimiz bulunmaktadır. Bu durum, her iki krallığın da geleceğini tehdit edebilir. Bu bilgiyi dikkate almanızı ve gerekli önlemleri almanızı öneririm. Unutmayın ki, düşmanların en büyük zaafı, içteki bölünmelerdir.\n\nSaygılarımla,\nAzeran Kralı",
            konusma = "Azeran Kralı: Elçim, bu bilgiyi Durnheim liderine iletmekte gecikme olmamalı. Velmora'nın niyetleri belirsiz ve bu durum tehlikelidir.\nElçi: Majesteleri, bu bilgiyle Durnheim’ın tepkisi ne olur? Gizli bir ittifak, karşılıklı güveni sarsabilir.\nAzeran Kralı: Bu onları uyandırabilir. Dikkatli ve hızlı olmalısın. Unutma ki, biz bir arada durursak, bu tür tehditler karşısında daha güçlü oluruz.",
            hedefKrallik = "Durnheim",
        });

        gorevler.Add(5, new Gorev
        {
            id = 5,
            ad = "Son Barış Teklifi",
            tanim = "Tüm krallıklar, senin aracılığınla bir araya gelmek istiyor. Son barış teklifini iletmek üzere Durnheim’e gitmelisin.",
            mesaj = "Saygıdeğer Durnheim Kralı,\n\nTüm krallıkların bir araya gelerek ortak bir gelecek inşa etme arzusunu ifade etmekten mutluluk duyarım. Barışın sağlanması, her bir krallığın katkısını gerektiren hayati bir meseledir. Krallıkların birliği, sadece düşmanlarımıza karşı değil, aynı zamanda kendi iç huzurumuz için de elzemdir. Bu toplantıda, birlikte hareket etmenin yollarını aramalıyız. Size en içten selamlarımı sunuyorum.\n\nSaygılarımla,\nVelmora Kralı",
            konusma = "Durnheim Kralı: Elçi, bu son barış teklifini iletmek için hazır mısın? Tüm krallıklarla bir araya gelmek büyük bir fırsat. Bizim için önemli bir adım olacak.\nElçi: Majesteleri, bu toplantının sonuçları çok önemli. Herkesin beklentisi büyük ve bu konuda dikkatli olmalıyız.\nDurnheim Kralı: Bu toplantı, geleceğimizi etkileyecek. Elinden geleni yap ve bu fırsatı iyi değerlendirdiğimizden emin ol.",
            hedefKrallik = "Durnheim",
        });
    }

    public Gorev GetirGorev(int id)
    {
        if (gorevler.ContainsKey(id))
            return gorevler[id];
        else
            return null;
    }
}
