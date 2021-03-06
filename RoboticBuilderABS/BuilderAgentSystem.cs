﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICD.AbmFramework.Core;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using ICD.AbmFramework.Core.Agent;
using ICD.AbmFramework.Core.AgentSystem;


namespace ABS.RoboticBuilderABS
{
    public class BuilderAgentSystem : AgentSystemBase
    {
        public int TimeStep = 2000;
        public double MaxSpeed = 2.0;
        public double MaxForce = 3.0;
        public double DisplacementThreshold = -1.0;
        public double TotalDisplacement = double.MaxValue;
        public BuilderMeshEnvironment BuilderEnvironment;

        private static System.Timers.Timer executeTimer;

        protected BuilderAgentSystem()
        {
        }

        public BuilderAgentSystem(List<BuilderAgent> agents, BuilderMeshEnvironment env)
        {
            this.BuilderEnvironment = env;
            this.Agents = new List<AgentBase>();
            foreach (AgentBase agent in agents)
            {
                this.Agents.Add(agent);
                agent.AgentSystem = (AgentSystemBase)this;
                ((BuilderAgent)agent).FindStartingPosition();
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.TotalDisplacement = double.MaxValue;
            this.BuilderEnvironment.Reset();
        }
        public override void Execute()
        {
            this.TotalDisplacement = 0.0;
            foreach (AgentBase agent in this.Agents)
                agent.Execute();
            this.BuilderEnvironment.FadePheromonesArrays();
        }

        public override List<object> GetDisplayGeometries()
        {
            List<object> objectList = new List<object>();
            foreach (BuilderAgent agent in this.Agents)
                objectList.AddRange((IEnumerable<object>)agent.GetDisplayGeometries());
            return objectList;
        }

        public List<GH_Vector> GetAgentVelocitiesAsGhVectors()
        {
            List<GH_Vector> ghVectorList = new List<GH_Vector>();
            foreach (BuilderAgent agent in this.Agents)
                ghVectorList.Add(new GH_Vector(agent.Velocity));
            return ghVectorList;
        }

        public List<BuilderAgent> FindNeighbors(BuilderAgent agent, double distance)
        {
            List<BuilderAgent> locomotionAgentList = new List<BuilderAgent>();
            foreach (BuilderAgent agent1 in this.Agents)
            {
                if (agent != agent1 && agent.Position.DistanceTo(agent1.Position) < distance)
                    locomotionAgentList.Add(agent1);
            }
            return locomotionAgentList;
        }

        public override bool IsFinished()
        {
            return this.TotalDisplacement < this.DisplacementThreshold;
        }
    }

}
