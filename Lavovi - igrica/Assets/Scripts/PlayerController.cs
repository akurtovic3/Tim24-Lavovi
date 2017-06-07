using Assets.Klase;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour { //Naslijedio MonoBehavior
    public float speed;
    public Text countText;
    public Text winText;
    
    private int count;
    private ConcreteSubject s = new ConcreteSubject();

    void Start () {
        count = 0;
        SetCountText();
       
        FactoryClass fC = new FactoryClass();
        Podaci podaci1 = fC.getPodatak("Scena2");
        winText.text = podaci1.Ime + " "+podaci1.Godina;


        s.Attach(new ConcreteObserver(s, "GlavniObserver"));
    } 
	
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        transform.Translate(movement * Time.deltaTime * speed);

        Facade f = new Facade();
        f.ispisiVrijemeIPoziciju();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.name)
        {
            case "NearBorder":
                s.SubjectState = "NearBorder";
                s.Notify();
                break;
            case "FarBorder":
                s.SubjectState = "FarBorder";
                s.Notify();
                break;
            case "RightBorder":
                s.SubjectState = "RightBorder";
                s.Notify();
                break;
            case "LeftBorder":
                s.SubjectState = "LeftBorder";
                s.Notify();
                break;
        }
    }


    void SetCountText()
    {
        countText.text = "Brojač: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "Čestitamo! Pobijedili ste";
        }
    }
}
