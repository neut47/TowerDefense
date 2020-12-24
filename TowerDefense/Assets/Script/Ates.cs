using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ates : MonoBehaviour
{
    private Transform target;

    public float speed = 30f;

    public int damage = 50;

    public float rangeFireball = 0f;
    public void Seek(Transform _target)
    {
        target = _target;
    }
        
    
    void Update()
    {        
        //mermiyi yok etme
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        //hedef bulma
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        //hedefe carpma
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }
    //hedef vurma
    void HitTarget()
    {
        if(rangeFireball > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }        
        Destroy(gameObject);
    }

    //alan efekti
    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, rangeFireball);
        //Collider [] colliders = Physics.OverlapSphere(transform.position, rangeFireball);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Debug.Log(collider.tag);
                Damage(collider.transform);
            }
        }
    }
    //hasar verme
    void Damage(Transform enemy)
    {
        Dusman e = enemy.GetComponent<Dusman>();

        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeFireball);
        
    }


}
