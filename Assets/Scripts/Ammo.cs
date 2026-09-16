using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private int amountAmmo = 5;
    [SerializeField]
    private int amountLife = 3;
    [SerializeField]
    private int amountTime = 10;
    public enum pickupSelection
    {
        Life,
        ammo,
        time
    }

    void Start()
    {
        int value = UnityEngine.Random.Range(1, 4);
        if(value > 2)
        {
            currentSelection = pickupSelection.time;
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else if(value > 1)
        {
            currentSelection = pickupSelection.Life;
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            currentSelection = pickupSelection.ammo;
            GetComponent<MeshRenderer>().material.color = Color.aquamarine;
        }
    }

    public pickupSelection currentSelection;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 45, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch(currentSelection)
            {
                case pickupSelection.Life:
                    other.GetComponent<PlayerHealth>().TakeDamage(-amountLife);
                    break;
                case pickupSelection.ammo:
                    other.transform.GetChild(0).GetComponent<PlayerShoot>().AddBullets(amountAmmo);
                    break;
                case pickupSelection.time:
                    GameManager.instance.AddTime(amountTime);
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
