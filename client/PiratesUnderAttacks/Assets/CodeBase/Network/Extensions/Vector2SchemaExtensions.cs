using CodeBase.Generated;
using UnityEngine;

namespace CodeBase.Network.Extensions
{
    public static class Vector2SchemaExtensions
    {
        public static Vector3 ToVector3(this Vector2Schema schema) => 
            new(schema.x, 0f, schema.y);

        public static Vector2 ToVector2(this Vector3 value) => 
            new(value.x, value.z);
    }
}