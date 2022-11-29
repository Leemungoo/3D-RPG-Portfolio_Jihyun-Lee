using System.Collections;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private bool aiming = false;
    [SerializeField]
    private LayerMask collidingLayer;

    Transform bombSpawnPoint;
    [SerializeField] 
    private GameObject bombEffectPrefab;
    private GameObject bombEffect;
    [SerializeField]
    private GameObject targetingEffectPrefab;
    private GameObject targetingEffect;
    [SerializeField]
    private GameObject explosionEffectPrefab;
    private GameObject explosionEffect;
    Vector3 explosionSpawnPoint;

    private void Start()
    {
        bombSpawnPoint = GameObject.Find("Bomb").transform;
        bombEffect = Instantiate(bombEffectPrefab, bombSpawnPoint);
        bombEffect.SetActive(true);

        targetingEffect = Instantiate(targetingEffectPrefab) as GameObject;
        targetingEffect.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1)) // 마우스 우클릭시
        {
            Debug.Log("조준");
            aiming = true;
            bombEffect.SetActive(true);
            targetingEffect.SetActive(true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("조준해제");
            aiming = false;
            bombEffect.SetActive(false);
            targetingEffect.SetActive(false);
        }

        if (aiming)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, collidingLayer))
            {
                targetingEffect.SetActive(true);
                targetingEffect.transform.position = hit.point;
            }
            else
            {
                targetingEffect.SetActive(false);
            }


            if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭시
            {
                Debug.Log("투척");
                PlayerMovement.playerAnimator.Play("Throw");
                bombEffect.SetActive(false);
                targetingEffect.SetActive(false);

                explosionSpawnPoint = targetingEffect.transform.position;
                StartCoroutine(Explosion(2.0f));
            }
        }
    }

    IEnumerator Explosion(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        explosionEffect = Instantiate(explosionEffectPrefab, explosionSpawnPoint, Quaternion.identity) as GameObject;
        Destroy(explosionEffect, 5f);
    }
}
