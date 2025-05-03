using UnityEngine;

public class ParallaxSc : MonoBehaviour
{
    private float length, startpos; //Görselin genişliği ve başlangıç pozisyonunu tanımladım.
    public GameObject cam; //Kamerayı sahnede belirtmek için GameObject
    public float parallaxEffect; //Parallax hız katsayısını belirtmek için tanımladım. 0:hareketsiz 1:kamera ile aynı hızda (0-1 arası değer alınıyor).
    void Start()
    {
        startpos = transform.position.x; //Script'in bağlı olduğu görselin konumunu aldım.
        length = GetComponent<SpriteRenderer>().bounds.size.x; //Döngüsel kaydırma için görselin genişliğini aldım.
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect)); //Kameranın hareketine göre görselin kaydırılmasını sağlamak için kameranın pozisyonunu aldım.
        float dist = (cam.transform.position.x * parallaxEffect); //Parallax efekti uygulanmış pozisyon hesaplandı.
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z); //Görselin pozisyonunu hesapladım.

        //Görsel ekran dışına çıktığında yeniden konumlandırdım. Sonsuz kaydırma efekti için.
        if (temp > startpos + length) startpos += length; 
        else if (temp < startpos - length) startpos -= length;
    }
}

