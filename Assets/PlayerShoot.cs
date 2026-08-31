using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    Color hitColor;
    private int bullets;
    private int maxBullets;

    [SerializeField]
    private InputAction reloadkey;

    [SerializeField]
    private TMP_Text bulletText;
    [SerializeField]
    private ParticleSystem shootParticles;
    [SerializeField]
    private AudioSource shootAudio;

    private void OnEnable()
    {
        reloadkey.Enable();
    }
    private void OnDisable()
    {
        reloadkey.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullets = 10;
        maxBullets = 25;
        UpdateBulletText();
    }

    // Update is called once per frame
    void Update()
    {
        if(reloadkey.triggered)
        {
            if(maxBullets > 0)
            {
                if(maxBullets < 6)
                {
                    bullets += maxBullets;
                    maxBullets = 0;
                }
                else
                {
                    bullets += 6;
                    maxBullets -= 6;
                }
                UpdateBulletText();
            }
        }
        
        if (Mouse.current.leftButton.wasPressedThisFrame && bullets > 0)
        {
            RaycastHit hit;
            bullets--;
            shootAudio.Play();
            UpdateBulletText();
           
            shootParticles.Play();
            
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if(hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<EnemyScript>().TakeDamage(5);
                }
                //Debug.DrawRay(transform.position, transform.forward * hit.distance, hitColor);
                //Debug.Break();
            }
        }
    }

    void UpdateBulletText()
    {
        bulletText.text = bullets.ToString() + " / " + maxBullets.ToString();
    }

    public void AddBullets(int value)
    {
        maxBullets += value;
        UpdateBulletText();
    }
}
