﻿using Perpetuum.ExportedTypes;
using Perpetuum.Items;

namespace Perpetuum.Services.TechTree
{
    public class Kernel : Item
    {
        public TechTreePointType PointType
        {
            get { return ED.Options.KernelPointType; }
        }
    }
}