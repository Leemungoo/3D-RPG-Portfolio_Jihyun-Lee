using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private float moveSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] public static bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    private CharacterController controller;
    public static Animator playerAnimator;
    public static Animation playerAnimation;

    void Start()
    {
        Cursor.visible = false;                 // 마우스 커서를 보이지 않게
        Cursor.lockState = CursorLockMode.Locked;	// 마우스 커서 위치 고정

        controller = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (PlayerStatus.isControllable == true)
            Control();
    }
 
    private void Control()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask); 

        //isGround 상태인 경우 velocity.y 임의설정하여 gravity 적용 중지
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (!GameManager.isPlayerDie)
        {
            //카메라가 보고있는 방향을 기준으로 방향키에 따라 이동
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);

            // 회전 설정 (항상 앞만 보도록 캐릭터의 회전은 카메라와 같은 회전 값으로 설정)
            transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        }

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) //걷기
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) //달리기
            {
                Run();
            }
            else if (moveDirection == Vector3.zero) // Idle
            {
                Idle();
            }

            moveDirection *= moveSpeed;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; // gravity 계산
        controller.Move(velocity * Time.deltaTime); // Charactor controller에 gravity 적용
    }

    private void Idle()
    {
        playerAnimator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        playerAnimator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        playerAnimator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        playerAnimator.SetTrigger("Jump");
    }
}
