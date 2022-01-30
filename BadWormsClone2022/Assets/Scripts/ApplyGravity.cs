///
///does grav stuff
///

using UnityEngine;




public class ApplyGravity : MonoBehaviour
{
	private Rigidbody rb;




	private void Start()
    {
		rb = transform.GetComponent<Rigidbody>();

	}

    private void Update()
    {
		Attract();
    }


    //calculates and applies planet based gravity
    public void Attract()
	{
		Vector3 gravityUp = (GlobalVariables.Instance.worldCenter - transform.position).normalized;

		rb.AddForce(gravityUp * GlobalVariables.Instance.gravityForce);

		Quaternion targetRotation = Quaternion.FromToRotation(transform.up, gravityUp) * transform.rotation;
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50 * Time.deltaTime);
	}
}