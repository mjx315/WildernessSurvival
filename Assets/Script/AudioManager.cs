using UnityEngine;
using System.Collections;
//[System.Serializable]
//public class AudioData
//{
    //public int Id;
    //public string Name;
    //public AudioSource AudioSource;
//}
public class AudioManager : MonoBehaviour {
    //public AudioData[] Audioes;
    public GameObject LoginSystem;
    public AudioSource AudioSource;
    //public AudioClip ButtonEffect;
    public bool Effect = true;
    public float Volume;
	// Use this for initialization
	void Start () {
        Volume = 1;
	}
	public void Play(string AudioPath)
    {
        AudioSource.clip = (AudioClip)Resources.Load(AudioPath,typeof(AudioClip));
        AudioSource.Play();
    }
	// Update is called once per frame
	void Update () {
        AudioSource.volume = Volume;

    }
}
