using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoretxt;

    int score;
    void Updatescoretxt(int scoretoAdd = 0)
    {
        score += scoretoAdd;
        scoretxt.text = "Score : " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Target hittarget = collision.collider.gameObject.GetComponent<Target>();
        Updatescoretxt(hittarget.pointvalue);
        Instantiate(hittarget.explosionpar, collision.transform.position, hittarget.explosionpar.transform.rotation);
        Destroy(collision.collider.gameObject);
    }
}
