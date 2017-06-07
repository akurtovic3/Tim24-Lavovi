using Assets.Klase;
using UnityEngine;
using UnityEngine.UI;

public class PocetniScreenPodaciSkripta : MonoBehaviour {
    public Text podaciText;

    // Use this for initialization
    void Start () {
        podaciText = GetComponent<Text>();
        FactoryClass fC = new FactoryClass();
        Podaci podaci1 = fC.getPodatak("Scena1");
        podaciText.text = podaci1.Ime + " " + podaci1.Godina;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
