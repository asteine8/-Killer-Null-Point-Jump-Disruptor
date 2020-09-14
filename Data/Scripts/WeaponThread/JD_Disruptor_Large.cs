using static JDD_Mod_Thread.WeaponStructure;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.HardPointDef;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.ModelAssignmentsDef;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.HardPointDef.HardwareDef.ArmorState;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.HardPointDef.Prediction;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.TargetingDef.BlockTypes;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.TargetingDef.Threat;

namespace JDD_Mod_Thread {   
    partial class Weapons {
        // Don't edit above this line
        WeaponDefinition JD_Disruptor_Large => new WeaponDefinition {   // ExampleWeapon_ClassID is your Custom ID for this gun.

            Assignments = new ModelAssignmentsDef 
            {
                MountPoints = new[] {
                    new MountPointDef {  // FixedMounts, leave Muzzle, Azimuth, and Elevation as "None" to become non-turrets.
                        SubtypeId = "JD_Disruptor_Large",  // Your Cubeblock SubtypeID, for your Gun.
                        AimPartId = "None",  // This line is no longer used, Keep it as "None"
                        MuzzlePartId = "None",   // Where your Muzzles are located. Do not include subpart_ when listing it here.
                        AzimuthPartId = "None",  // The subpart that handles Spinning. Do not include subpart_ when listing it here.
                        ElevationPartId = "None",  // The subpart that handles up & down. Do not include subpart_ when listing it here.
                        DurabilityMod = 1f,  // Affects Durability of Turret to weapons-fire.
                    },
                   
                },
                Barrels = new [] {
                    "muzzle_projectile_001",  // Your Muzzle name. Do not use Letters for progression, IE Barrel_A, Barrel_B, Barrel_C, only Numbers, like Barrel_1, Barrel_2, Barrel_3
                },
            },
            Targeting = new TargetingDef  
            {
                Threats = new[] {
                    Grids,  // Target Types. Your options include , Grids, Projectiles, Characters.
                },
                SubSystems = new[] {
                    Thrust, Utility, Offense, Power, Production, Any,   // Block type Priorities for targeting. Use only "Any" to not use this feature. Decoys are in Utilities.
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                IgnoreDumbProjectiles = false, // Don't fire at non-smart projectiles.
                LockedSmartOnly = false, // Only fire at smart projectiles that are locked on to parent grid.
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.  This is size in meters.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                MaxTargetDistance = 0, // 0 = unlimited, Maximum target distance that targets will be automatically shot at. This is also in Meters.
                MinTargetDistance = 0, // 0 = unlimited, Min target distance that targets will be automatically shot at.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between.   Having Low Numbers, can result in frequent retargeting or turret idling.  Weapons with High numbers of Homing projectiles, suggest larger values.
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed.
            },
            HardPoint = new HardPointDef 
            {
                WeaponName = "Null-Point Jump Disrupter", // name of weapon in terminal in-game.
                DeviateShotAngle = 0f, // Inaccuracy in Degrees, when firing. A value of 1, results in, up to 1 degree off from the center-point of your muzzle(s)
                AimingTolerance = 1f, // 0 - 180 firing angle. How off-target your gun will allow firing if Turret.
                AimLeadingPrediction = Off, // Off, Basic, Accurate, Advanced. How advanced the aim-prediction will be, if Turret.
                DelayCeaseFire = 20, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..). How long this thing keeps firing after you let go of trigger. Affects both Turrets & Fixed-mounts.
                AddToleranceToTracking = false, 

                Ui = new UiDef {
                    RateOfFire = false,  // Enables Slider In-game, to modify ROF
                    DamageModifier = false,  // Enables Slider In-game, to modify damage resistences.
                    ToggleGuidance = false,  // Enables Slider In-game to disable any tracking if the ammo has any.
                    EnableOverload =  false,  // Enables Slider, to allow weapon to fire instead of shutting down, if Overheated.
                },
                Ai = new AiDef {
                    TrackTargets = false,   // If Turret actually tracks targets in list.
                    TurretAttached = false,  // If this Weapon has a Turret, a Turret means elevation & rotation motors.
                    TurretController = false,  // If this weapon can be fired by the Turret.
                    PrimaryTracking = false, 
                    LockOnFocus = false,  // If this weapon will automatically fire on the grid's locked target. This affects non-turrets too.
                },
                HardWare = new HardwareDef {
                    RotateRate = 0.01f,
                    ElevateRate = 0.01f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -9,
                    MaxElevation = 50,
                    FixedOffset = false,
                    InventorySize = 15f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef {
                    GridWeaponCap = 0,  // Number of Weapons of this type, allowed on Grid. If Multi-Turret, Game goes with lowest limit.
                    RotateBarrelAxis = 0,
                    EnergyPriority = 2,  // How demanding this is, when draining Energy. 2 is Standard, where it competes with shields. 0 , means this is the last thing to get energy , if the grid is overloading.
                    MuzzleCheck = false,  // If weapon checks muzzles for clearance, when firing dumbfire rounds.
                    Debug = false,  // This enables in-game debug options in terminal & displays Lines for aim, muzzles & similar. Do not leave on, outside of bug-testing.
                },
                Loading = new LoadingDef {
                    RateOfFire = 120, // Rate of Fire. 3600 ROF is suggested for Beam-Weapons, as that is to match tick-rate. 
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,  // Number of Muzzles used at once. If 2, then 2 of # will fire at the same time. If you use 4, and have 4 Muzzles, all 4 will fire as a Single-Shot, releasing 4 projectiles.
                    TrajectilesPerBarrel = 1, // Number of projectiles created per Muzzle, Per "Fire" Event. If this is 2, every muzzle launches two projectiles each time when fired.
                    SkipBarrels = 0,  // Skips Muzzles in firing order. Value of 1, on a 6-Muzzle user, would fire 1,3, 4, 6, 2, 5 in that order.
                    ReloadTime = 1200, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).  If your Weapon is a Beam, This is now Charge-Rate.
                    DelayUntilFire = 290, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).  How long the weapon wait after fire-trigger to actually fire.
                    HeatPerShot = 0, //heat generated per shot. If 0, System does not use Heat.
                    MaxHeat = 70000, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .95f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 9000, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 1,  // This is basically your Magazine capacity, before needing to reload.
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).  This is reload-time for Energy-Weapons. Or timing between bursts for Non-Energy weapons.
                    FireFullBurst = false,  // If weapon is forced to fire the entire burst size.
                    GiveUpAfterBurst = false,  // If Weapon re-targets after full burst.
                },
                Audio = new HardPointAudioDef {
                    PreFiringSound = "JDD_PreFire_2",  // Audio for Warm-up effect.
                    FiringSound = "jdd_firing3_extended", // Audio Sound for Firing.
                    FiringSoundPerShot = true,  // If False, the audio for Firing, is then Looped.
                    ReloadSound = "", 
                    NoAmmoSound = "",
                    HardPointRotationSound = "",  // Sound triggered when Turret moves.
                    BarrelRotationSound = "", 
                    FireSoundEndDelay = 10, // Measured in game ticks(6 = 100ms, 60 = 1 seconds, etc..). Delay after firing, that Audio is cut-off.
                },
                Graphics = new HardPointParticleDef {

                    Barrel1 = new ParticleDef {
                        Name = "", // Smoke_LargeGunShot , ParticleEffect SubtypeID goes here.
                        Color = Color(red: 0, green: 0, blue: 0, alpha: 1), // This line is no longer in Service. Edit these values in the particle.
                        Offset = Vector(x: 0, y: -1, z: 0), // Position in Meters from your Muzzle position

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 50,
                            MaxDuration = 6,
                            Scale = 1f,
                        },
                    },
                    Barrel2 = new ParticleDef {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 0, green: 0, blue: 0, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 150,
                            MaxDuration = 6,
                            Scale = 1f,
                        },
                    },
                },
            },
            Ammos = new [] {   // This contains the Class IDs of your Ammo types for this Weapon.
                JD_Disruptor_Ammo_Large,
                JD_Disruptor_Ammo_DamagingLarge
            },
            //Animations = AdvancedAnimation,  // Remove the // from this line, and use the Class ID of your Animation CS file to enable.
            // Don't edit below this line
        };
    }
}