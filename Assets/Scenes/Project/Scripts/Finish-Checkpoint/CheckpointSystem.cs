using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointSystem : MonoBehaviour
{
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float playerDead;
    [SerializeField] TMP_Text checkpointText;
    public AudioClip checkpointSound;

    private int checkpointCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -playerDead)
        {
            transform.position = vectorPoint;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = transform.position;
        Destroy(other.gameObject);

        checkpointCount++;
        checkpointText.text = "Checkpoints: " + checkpointCount + " / 10";

        // Play checkpoint sound
        AudioSource.PlayClipAtPoint(checkpointSound, transform.position);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Zombie"))
        {
            transform.position = vectorPoint;
        }
    }
}
