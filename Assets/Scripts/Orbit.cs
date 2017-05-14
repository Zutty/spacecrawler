using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public const float G = 6.673E-11f;

	public CelestialBody centerBody;
	public float semiMajorAxis;
	public float eccentricity = 1f;
	public float argumentOfPeriapsis;


	void OnValidate() {
		eccentricity = Mathf.Max(eccentricity, 0f);
	}

	void Update () {
		float k = G * centerBody.mass;

		if(Mathf.Approximately(eccentricity, 1f)) {
			// Parabolic
		} else if(eccentricity < 1f) {
			// Elliptic / circular
		} else {
			// Hyperbolic
		}

		float parameter = semiMajorAxis * (1f - eccentricity * eccentricity);
		float distance = parameter / (1f - eccentricity * Mathf.Cos(Time.time - argumentOfPeriapsis));

		float a3 = semiMajorAxis * semiMajorAxis * semiMajorAxis;
		float orbitalPeriod = 2f * Mathf.PI * Mathf.Sqrt(a3 / k);
			
		Vector3 newpos = centerBody.transform.position;

		newpos.x += distance * Mathf.Cos(Time.time);
		newpos.z += distance * Mathf.Sin(Time.time);

		transform.position = newpos;
	}
}
