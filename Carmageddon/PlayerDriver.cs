﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using NFSEngine.Audio;
using PlatformEngine;
using Carmageddon.Physics;
using Microsoft.Xna.Framework.Input;

namespace Carmageddon
{
    class PlayerDriver : IDriver
    {
        
        public Vehicle Vehicle {get; set; }

        IListener _audioListener;

        public PlayerDriver()
        {
            _audioListener = Engine.Audio.GetListener();
            _audioListener.DistanceFactor = 2f;
            _audioListener.RolloffFactor = 1f;
        }

        public bool ModerateSteeringAtSpeed { get { return true; } }

        public void OnRaceStart()
        {
            Vehicle.Chassis.Motor.Gearbox.CurrentGear = 1;
        }

        public void Update()
        {
            VehicleChassis chassis = Vehicle.Chassis;
            
            if (PlayerVehicleController.Brake != 0)
                chassis.Brake(PlayerVehicleController.Brake);
            else
                chassis.Accelerate(PlayerVehicleController.Acceleration);
            
            chassis.Steer(-PlayerVehicleController.Turn);

            if (PlayerVehicleController.Handbrake)
                chassis.PullHandbrake();
            else
                chassis.ReleaseHandbrake();

            if (Engine.Input.WasPressed(Keys.R))
                Vehicle.Reset();

            _audioListener.BeginUpdate();
            _audioListener.Position = Vehicle.Chassis.Actor.GlobalPosition;
            _audioListener.Orientation = Vehicle.Chassis.Actor.GlobalOrientation;
            _audioListener.Velocity = Vector3.Zero;
            _audioListener.CommitChanges();
        }
    }
}
