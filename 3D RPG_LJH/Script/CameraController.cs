using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float minDistance = 3;  // target���� �ּ� �Ÿ�
	[SerializeField]
	private float maxDistance = 30; //target���� �ִ� �Ÿ�
	[SerializeField]
	private float wheelSpeed = 500; // ���콺 ��ũ�� �ӵ�
	[SerializeField]
	private float xMoveSpeed = 500; // ī�޶��� y�� ȸ�� �ӵ�
	[SerializeField]
	private float yMoveSpeed = 250; // ī�޶��� x�� ȸ�� �ӵ�
	private float yMinLimit = -20;        // ī�޶� x�� ȸ�� ���� �ּ� ��
	private float yMaxLimit = 80;       // ī�޶� x�� ȸ�� ���� �ִ� ��
	private float x, y;             // ���콺 �̵� ���� ��
	private float distance;         // ī�޶�� target�� �Ÿ�

	private void Awake()
	{
		distance = Vector3.Distance(transform.position, target.position);

		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}

	private void Update()
	{
		if (target == null) 
			return;

	    x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
		y -= Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;

		y = ClampAngle(y, yMinLimit, yMaxLimit);
		transform.rotation = Quaternion.Euler(y, x, 0);

		if (!Input.GetKey(KeyCode.LeftControl))
		{
			distance -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;
		}

		distance = Mathf.Clamp(distance, minDistance, maxDistance);
	}

	private void LateUpdate()
	{
		if (target == null) 
			return;

		transform.position = transform.rotation * new Vector3(0, 0, -distance) + target.position;
	}

	private float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360) angle += 360;
		if (angle > 360) angle -= 360;

		return Mathf.Clamp(angle, min, max);

	}
}
	

