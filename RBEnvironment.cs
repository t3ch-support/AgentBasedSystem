﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;


namespace ABS
{
    public class RBEnvironment : GH_Component
    {
        public RBEnvironment()
          : base("RoboticBuilderEnvironment", "RB-Env",
              "Environment for RB-Agents",
              "Thesis", "ABS")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }
        public override Guid ComponentGuid
        {
            get { return new Guid("a38943df-e362-4707-a5a8-48d517255925"); }
        }
    }
}
