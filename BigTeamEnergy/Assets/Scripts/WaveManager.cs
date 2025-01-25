using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] AnimationCurve waveCurve;
    [SerializeField] Transform spawnLocation;
    [SerializeField] Transform topSpawn;
    [SerializeField] float speed;
    int iterCount;
    void Start(){
        StartCoroutine(WaveSpawn());
    }
    IEnumerator WaveSpawn(){
        while(true){
            Spawn(spawnLocation);
            Spawn(topSpawn);
            yield return new WaitForSeconds(waveCurve.Evaluate(iterCount));
            iterCount++;
        }
    }
    void Spawn(Transform transform){
        var spawned = Instantiate(SpawnManager.Instance.smallBubblePrefab, transform.position, transform.rotation);
        var rig = spawned.GetComponent<Rigidbody2D>();
        rig.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }
}
