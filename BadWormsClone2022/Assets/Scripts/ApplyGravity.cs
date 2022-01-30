///
///does grav stuff
///

using UnityEngine;




public class ApplyGravity : MonoBehaviour
{
	private Rigidbody rb;

	public float planetRotationSpeed = 50;


	private void Start()
    {
		rb = transform.GetComponent<Rigidbody>();

	}


    //calculates and applies planet based gravity
    public void Attract()
	{
		Vector3 gravityUp = (GlobalVariables.Instance.worldCenter - transform.position).normalized;

		rb.AddForce(gravityUp * GlobalVariables.Instance.gravityForce);

		//Quaternion targetRotation = Quaternion.FromToRotation(transform.up, gravityUp) * transform.rotation;
		//transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, planetRotationSpeed * Time.deltaTime);

		transform.rotation = Quaternion.LookRotation(rb.velocity);
	}
}