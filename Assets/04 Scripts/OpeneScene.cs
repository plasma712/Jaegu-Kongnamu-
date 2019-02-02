using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OpeneScene : MonoBehaviour
{
    public AudioSource MainCamAudio;
    public SpriteRenderer TitleSprite;
    private float Alpha;
    private bool Begin;
    public Camera MainCam;
    public AudioClip TreeUpsound;
    public AudioClip TreeUpsound2;
    public AudioClip OpenAudio;
    private AudioSource myAudio;
    public TextMeshPro Text;
    float shakeAmount = 0;

    private void Awake()
    {
        if (MainCam == null)
            MainCam = Camera.main;
    }
    // Use this for initialization
    void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Begin == true)
        {
            Alpha += Time.deltaTime;

            TitleSprite.color = new Color(255, 255, 255, Alpha);
            Text.color = new Color(255, 255, 255, Alpha);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("pro");
            }

        }
    }

    void TreeUp()
    {
        myAudio.PlayOneShot(TreeUpsound);
    }

    void TreeUp2()
    {
        myAudio.PlayOneShot(TreeUpsound2);
    }

    void StartOpen()
    {
        MainCamAudio.PlayOneShot(OpenAudio);
    }

    void StartTitle()
    {
        Begin = true;
    }

    // Update is called once per frame

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = MainCam.transform.position;
            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            MainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        MainCam.transform.localPosition = Vector3.zero;
    }

    void ShakeLogic()
    {
        Shake(0.1f, 0.4f);
    }
}
