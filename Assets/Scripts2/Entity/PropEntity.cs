﻿using UnityEngine;
using System.Collections.Generic;

using RTS2.Assets;
using RTS2.Entity.Behaviour;

namespace RTS2.Entity
{
    public class PropEntity : Entity
    {
        public override EAssetType GetAssetType() {
            return EAssetType.PROP;
        }

        public override string GetEntityName() {
            return "Generic Prop";
        }
    }
}