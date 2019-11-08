﻿using System;
using System.Collections.Generic;
using ABS.RoboticBuilderABS;
using Grasshopper.Kernel;
using ICD.AbmFramework.Core.Agent;
using ICD.AbmFramework.Core.AgentSystem;
using Rhino.Geometry;

namespace ABS
{
    public class RBTrajectoryBehavior : GH_Component
    {
        public RBTrajectoryBehavior()
          : base("RB-Trajectory-Behavavior", "RB-Traj",
              "Causes agents to follow goal trajectories",
              "Thesis", "ABS")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Weight", "Weight", "Weight", GH_ParamAccess.item, 1);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("RandDirBehavior", "Behav", "RandDirBehavior", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            double placeholder = 1;
            DA.GetData(0, ref placeholder);
            DA.SetData("Separation Behavior", null);

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
            get { return new Guid("a38943df-e362-4707-a5a8-48d517255927"); }
        }
    }
}
