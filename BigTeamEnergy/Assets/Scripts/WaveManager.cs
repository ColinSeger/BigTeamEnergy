using System.Collections;
using UnityEngine;
using FMODUnity;
enum SpawnSpots : byte {
    Top,
    Bottom,
    Both,
    Alternate
}


public class Spawner : MonoBehaviour
{
    [SerializeField] AnimationCurve waveCurve;
    [SerializeField] Transform bottomSpawn;
    [SerializeField] Transform topSpawn;
    [SerializeField] float speed;
    [SerializeField] SpawnSpots spawnSpots = SpawnSpots.Both;
    int iterCount;
    bool alt = false;

    [SerializeField] private EventReference spawnSound;
    void Start(){
        StartCoroutine(WaveSpawn());
    }
    IEnumerator WaveSpawn(){
        while(true){
            if(spawnSpots == SpawnSpots.Both){
                //AudioManager.instance.PlayOneShot(spawnSound);
                Spawn(bottomSpawn);
                Spawn(topSpawn);
            }else if (spawnSpots == SpawnSpots.Top){
                //AudioManager.instance.PlayOneShot(spawnSound);
                Spawn(topSpawn);
            }else if(spawnSpots == SpawnSpots.Bottom){
                Spawn(bottomSpawn);
            }else if(spawnSpots == SpawnSpots.Alternate){
                if(alt){
                    alt = false;
                    Spawn(topSpawn);
                }else{
                    alt = true;
                    Spawn(bottomSpawn);
                }
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
