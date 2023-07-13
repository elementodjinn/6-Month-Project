using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject AttackHitBox;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        AttackHitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator attack(){
        while(timer < 0.5){
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        AttackHitBox.SetActive(true);
        while(timer < 1){
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        AttackHitBox.SetActive(false);
        while(timer < 2){
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        timer = 0;
    }

    
}
