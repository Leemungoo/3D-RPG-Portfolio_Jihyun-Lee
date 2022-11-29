using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float minDistance = 3;  // target과의 최소 거리
	[SerializeField]
	private float maxDistance = 30; //target과의 최대 거리
	[SerializeField]
	private float wheelSpeed = 500; // 마우스 스크롤 속도
	[SerializeField]
	private float xMoveSpeed = 500; // 카메라의 y축 회전 속도
	[SerializeField]
	private float yMoveSpeed = 250; // 카메라의 x축 회전 속도
	private float yMinLimit = -20;        // 카메라 x축 회전 제한 최소 값
	private float yMaxLimit = 80;       // 카메라 x축 회전 제한 최대 값
	private float x, y;             // 마우스 이동 방향 값
	private float distance;         // 카메라와 target의 거리

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
	


