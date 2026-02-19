using UnityEngine;

public class GravityAreaCenter : GravityArea {
    public override Vector3 GetGravityDirection(GravityBody gravityBody) => (transform.position - gravityBody.transform.position).normalized;
}