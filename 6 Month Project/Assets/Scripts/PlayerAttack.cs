using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject attack1,attack2,attack3,ranged;
    public bool cancellable = false;
    public enum AttackState {
        idle,
        first,
        second,
        third,
        shoot
    }
    public Coroutine currentAttack;

    public bool attacking = false;

    private AttackState comboNum;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        ResetHitboxes();
        comboNum = AttackState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAttack(){
    }

    public IEnumerator attack(){
        attacking = true;
        GameObject hitbox = null;
        cancellable = false;
        ResetHitboxes();
        timer = 0;
        switch (comboNum){
            case AttackState.idle :{
                Debug.Log("First");
                hitbox = attack1;
                comboNum = AttackState.first;
                break;    
            }
            case AttackState.first :{
                Debug.Log("Second");
                hitbox = attack2;
                comboNum = AttackState.second;
                break;    
            }
            case AttackState.second :{
                Debug.Log("Third");
                hitbox = attack3;
                comboNum = AttackState.third;
                break;    
            }
        }
        AttackData attackData = hitbox.GetComponent<AttackHitbox>().attackData;
            Debug.Log("Startup"+comboNum);
            //Wind up your attack
        while(timer < attackData.windUp){
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
            Debug.Log(timer+ " " + comboNum);
        //Wind up is done; these are active frames
        Debug.Log("Attack"+comboNum);
        hitbox.SetActive(true);
        while(timer < attackData.attackDuration){
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
            Debug.Log(timer+ " " + comboNum);
        //Attack is done, you can cancel the endlag into the next attack
            Debug.Log("Cancel" + comboNum);
        hitbox.SetActive(false);
        cancellable = true;
        while(timer < attackData.lastCancellable){
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
            Debug.Log(timer+ " " + comboNum);
            Debug.Log("EndLag" + comboNum);
        //No longer cancellable, locked into endlag
        cancellable = false;
        while(timer < attackData.endLag){
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
            Debug.Log(timer+ " " + comboNum);
            Debug.Log("End");
        comboNum = AttackState.idle;
        attacking = false;
        timer = 0;
    }

    private void ResetHitboxes(){
        attack1.SetActive(false);
        attack2.SetActive(false);
        attack3.SetActive(false);
    }
}
