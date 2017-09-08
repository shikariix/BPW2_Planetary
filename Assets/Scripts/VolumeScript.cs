using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeScript : MonoBehaviour {
	
    public Slider volumeSlider;
    public AudioSource volumeAudio;

	//Align slider value and audio volume
    public void VolumeController() {
        volumeSlider.value = volumeAudio.volume;
    }
}