using UnityEngine;
using UnityEngine.AI; 

public class Boss : MonoBehaviour
{
    public Transform transform;
    public Transform target;
    public Animator animator;
    public Collider collider;
    public NavMeshAgent navMeshAgent;

    public GameObject hpBarPos;

    private IState currentState;

    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float landingDistance = 12f; // 착지 시작거리
    public float attackDistance = 8f; // 공격 사정거리
    public float backDistance = 4f; // 후진 시작 거리

    public static bool isFlying = false; // 비행여부 판별

    private void Awake()
    {
        ChangeState(new FlyIdleState());
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        collider = GetComponent<BoxCollider>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        hpBarPos = GameObject.FindWithTag("HPbarPos_boss");
        hpBarPos.SetActive(false);
    }

    void Update()
    {
        currentState.Update();
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
     
        currentState = newState;

        currentState.Enter(this);
    }

    private void OnEnable() 
    {
        PlayerStatus.OnPlayerDie += this.OnPlayerDie;
    }

    private void OnDisable()
    {
        PlayerStatus.OnPlayerDie -= this.OnPlayerDie;
    }

    private void OnPlayerDie()
    {
        navMeshAgent.isStopped = true; 
        ChangeState(new FlyIdleState());
    }
}

