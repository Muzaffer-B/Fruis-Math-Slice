using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMelon : MonoBehaviour
{

    public GameObject whole;
    public GameObject sliced;
    public AudioSource SliceAudio;
    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;
    private ParticleSystem juiceParticleEffect;
    public int point = 1;

    public GameObject Playtext;
    public GameObject scoretext;
    public GameObject timerText;

    private GameManager manager;
    private Spawner spawner;
    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        spawner = FindObjectOfType<Spawner>();

        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
        juiceParticleEffect = GetComponentInChildren<ParticleSystem>();
        SliceAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        manager.enabled = false;
        spawner.enabled = false;
    }
    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        if (!SliceAudio.isPlaying)
        {
            SliceAudio.Play();
        }

        Vibrator.Vibrate(20);
        FindObjectOfType<GameManager>().IncreaseScore(point);

        whole.SetActive(false);
        sliced.SetActive(true);

        fruitCollider.enabled = false;
        juiceParticleEffect.Play();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slices)
        {

            slice.velocity = fruitRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);

        }
        manager.enabled = true;
        spawner.enabled= true;
        Playtext.SetActive(false);
        scoretext.SetActive(true);
        timerText.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }
}
