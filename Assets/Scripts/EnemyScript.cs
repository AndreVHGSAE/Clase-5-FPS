using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float health = 10;

    private NavMeshAgent agent;

    private Transform player;

    [SerializeField]
    private GameObject knife;

    [SerializeField]
    private List<Transform> PatrolPoint = new List<Transform>();

    [SerializeField]
    private AudioSource ZombieAudio;

    [SerializeField]
    private GameObject RDrop;

    int currentPoint = 0;

    public float currentTimeS=0;
    public float MaxTimeS=0;

    GameManager UpdateInterface;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateInterface = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();

        player = GameObject.Find("Jugador").transform;
        agent.stoppingDistance = 2;
        MaxTimeS = Random.Range(1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= 10)
        {
            
            agent.destination = player.position;
        }
        else
        {
            if (Vector3.Distance(transform.position, PatrolPoint[currentPoint].position) >= 3)
            {
                agent.destination = PatrolPoint[currentPoint].position;
            }
            else
            {
                if (currentPoint < PatrolPoint.Count-1)
                {
                    currentPoint++;
                }
                else
                {
                    currentPoint = 0;
                }
            }
        }

        if(Vector2.Distance(transform.position,player.position) <= agent.stoppingDistance)
        {
            knife.SetActive(true);
        }
        else
        {
            knife.SetActive(false);
        }

        currentTimeS += Time.deltaTime;
        if (currentTimeS >= MaxTimeS)
        {
            ZombieAudio.Play();
            MaxTimeS = Random.Range(1f, 10f);
            currentTimeS = 0;
        }
    }

    public void TakeDamage(float value)
    {
        health -= value;
        GetComponent<MeshRenderer>().material.DOColor(Color.red, 1).From();
        GetComponent<MeshRenderer>().material.DOColor(Color.gray, 1);
        if(health <= 0)
        {
            int RandomDrop = Random.Range(1, 101);
            if (RandomDrop>30)
            {
                Instantiate(RDrop, this.transform.position, Quaternion.identity);
            }
            UpdateInterface.AddScore(2);
            Destroy(this.gameObject);
        }
    }
}
