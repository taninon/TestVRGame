using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchingEnemy : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] float fireInterval;

    [SerializeField] GameObject spherePrefab;
    [SerializeField] GameObject target;

    [SerializeField] Vector2 shakeRenge;

    float pastTime;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;

        if (pastTime > fireInterval) {
           var sphere = Instantiate<GameObject>(spherePrefab);
            sphere.transform.position = this.transform.position;
            var rigid = sphere.GetComponent<Rigidbody>();
            rigid.AddForce(this.transform.forward * power,ForceMode.Impulse);

            var shake = Random.Range(shakeRenge.x, shakeRenge.y);
            rigid.AddForce(new Vector3(shake, shake, shake), ForceMode.Impulse);

            pastTime = 0;
        }
    }
}
