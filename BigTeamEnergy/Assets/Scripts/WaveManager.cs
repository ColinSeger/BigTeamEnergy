using System.Collections;
using UnityEngine;
using FMODUnity;
enum SpawnSpots : byte {
    Top,
    Bottom,
    Both
}


public class Spawner : MonoBehaviour
{
    [SerializeField] AnimationCurve waveCurve;
    [SerializeField] Transform bottomSpawn;
    [SerializeField] Transform topSpawn;
    [SerializeField] float speed;
    [SerializeField] SpawnSpots spawnSpots = SpawnSpots.Both;
    int iterCount;

    [SerializeField] private EventReference spawnSound;
    void Start(){
        StartCoroutine(WaveSpawn());
    }
    IEnumerator WaveSpawn(){
        while(true){
            if(spawnSpots == SpawnSpots.Both){
                Spawn(bottomSpawn);
                Spawn(topSpawn);
            }else if (spawnSpots == SpawnSpots.Top){
                Spawn(topSpawn);
            }else if(spawnSpots == SpawnSpots.Bottom){
                Spawn(bottomSpawn);
            }

            yield return new WaitForSeconds(waveCurve.Evaluate(iterCount));
            iterCount++;
        }
    }
    void Spawn(Transform transform){
        var spawned = Instantiate(SpawnManager.Instance.smallBubblePrefab, transform.position, transform.rotation);
        AudioManager.instance.PlayOneShot(spawnSound);
        var rig = spawned.GetComponent<Rigidbody2D>();
        rig.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }
}
