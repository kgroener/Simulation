﻿using Simulation.Interface.Specimen;
using Simulation.Models;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Numerics;

namespace Simulation.World.Specimen
{
    internal class SpecimenManager
    {
        private Random _random;

        [ImportMany]
        public IEnumerable<ISpecimenFactory> SpecimenFactories { get; set; }

        public SpecimenManager()
        {
            CompositionContainer.Resolve(this);

            _random = new Random();
        }

        public int SpecimenCount => SpecimenFactories.Count();

        public void PopulateWorld(SimulationWorld world, int maximumWorldPopulation)
        {
            var allowedGenerationSize = Math.Max(1, maximumWorldPopulation / SpecimenCount);

            var specimenAbstracts = SpecimenFactories.SelectMany((v) => v.CreateGeneration(allowedGenerationSize).Take(allowedGenerationSize));

            var specimen = specimenAbstracts.Select(s => new Specimen(world, s, new Vector2(_random.Next(200, 500), _random.Next(200, 500)), _random.NextDouble() * Math.PI * 2));

            world.Populate(specimen);
        }
    }
}
