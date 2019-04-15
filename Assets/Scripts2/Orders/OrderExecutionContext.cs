using UnityEngine;
using System.Collections;

using RTS2.Entities;
namespace RTS2.Orders
{
    public struct OrderExecutionContext
    {
        bool isEntity;
        Entity entity;
        Vector3 point;
    }
}