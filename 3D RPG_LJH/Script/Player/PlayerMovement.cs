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
        Cursor.visible = false;                 // ���콺 Ŀ���� ������ �ʰ�
        Cursor.lockState = CursorLockMode.Locked;	// ���콺 Ŀ�� ��ġ ����

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

        //isGround ������ ��� velocity.y ���Ǽ����Ͽ� gravity ���� ����
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (!GameManager.isPlayerDie)
        {
            //ī�޶� �����ִ� ������ �������� ����Ű�� ���� �̵�
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);

            // ȸ�� ���� (�׻� �ո� ������ ĳ������ ȸ���� ī�޶�� ���� ȸ�� ������ ����)
            transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        }

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) //�ȱ�
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) //�޸���
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

        velocity.y += gravity * Time.deltaTime; // gravity ���
        controller.Move(velocity * Time.deltaTime); // Charactor controller�� gravity ����
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
