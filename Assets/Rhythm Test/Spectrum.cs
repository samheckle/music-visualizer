using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour
{

	// C#
	// Instantiates a prefab in a circle
	
	public GameObject prefab;
	public int numberOfObjects = 20;
	public float radius = 5f;
	public GameObject[] bass;
	public GameObject[] harmony;
	public GameObject[] melody;
	
	void Start ()
	{
		// creates the circle of cubes
		for (int i = 0; i < numberOfObjects; i++) {
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3 (Mathf.Cos (angle), 0, Mathf.Sin (angle)) * radius;
			Instantiate (prefab, pos, Quaternion.identity);
		}

		// instantiates each GameObject
		bass = GameObject.FindGameObjectsWithTag ("Bass");
		harmony = GameObject.FindGameObjectsWithTag ("Harmony");
		melody = GameObject.FindGameObjectsWithTag ("Melody");
	}
	
	// Update is called once per frame
	void Update ()
	{

		// creates an array holding each frequency (in Hz) value
		// bass
		float[] spectrum = AudioListener.GetSpectrumData (2048, 0, FFTWindow.BlackmanHarris);
		
		// loop that goes through each GameObject and assigns the frequency value, then adjusts the size of 
		// each cube according to the frequency value at that point

		for (int i=0; i<numberOfObjects; i++) {

			Vector3 previousScale = bass [i].transform.localScale;
			previousScale.y = spectrum [i] * 200;
			bass [i].transform.localScale = previousScale;
				
		}


		// repeated for each part of the song
		// harmony

		//float[] hSpectrum = AudioListener.GetSpectrumData (512, 0, FFTWindow.Hamming);
		
		for (int i=0; i<numberOfObjects; i++) {
			Vector3 previousScale = harmony [i].transform.localScale;
			previousScale.y = spectrum [i] * 200;
			harmony [i].transform.localScale = previousScale;
		}


		// melody
		//float[] mSpectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);

		for (int i=0; i<numberOfObjects; i++) {
			Vector3 previousScale = melody [i].transform.localScale;
			previousScale.y = spectrum [i] * 200;
			melody [i].transform.localScale = previousScale;
		}


	}
}
