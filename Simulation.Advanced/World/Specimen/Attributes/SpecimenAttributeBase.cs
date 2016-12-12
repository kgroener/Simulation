﻿using Simulation.Interface.Specimens;
using Simulation.World.Specimens.Attributes.Actuators;
using Simulation.World.Specimens.Attributes.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulation.World.Specimens.Attributes
{
    internal abstract class SpecimenAttributeBase : ISpecimenAttributeInternal
    {
        private readonly ISpecimenInternal _specimen;

        public SpecimenAttributeBase(ISpecimenInternal specimen)
        {
            _specimen = specimen;
        }

        IEnumerable<ISpecimenActuator> ISpecimenAttribute.Actuators => Actuators;
        IEnumerable<ISpecimenSensor> ISpecimenAttribute.Sensors => Sensors; 

        public abstract IEnumerable<ISpecimenActuatorInternal> Actuators { get; }
        public abstract IEnumerable<ISpecimenSensorInternal> Sensors { get; }

        public abstract double Weight { get; }

        public ISpecimenInternal Specimen => _specimen;
    }
}
