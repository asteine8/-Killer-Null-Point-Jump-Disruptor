using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.AmmoEjectionDef;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.AmmoEjectionDef.SpawnType;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.ShapeDef.Shapes;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef.GuidanceType;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef.ShieldDef.ShieldType;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.AreaEffectType;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.Texture;
using static JDD_Mod_Thread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.TracerBaseDef;
namespace JDD_Mod_Thread
{ // Don't edit above this line
    partial class Weapons
    {
        private AmmoDef JD_Disruptor_Ammo_Small => new AmmoDef
        {
            AmmoMagazine = "Energy",  // Magazine SBC SubtypeID, for Ammo Users, "Energy" for Energy-Weapons.
            AmmoRound = "JD_Disruptor_Ammo-small",  // In-game Name
            HybridRound = true, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.06f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 1000f,  //Damage Numbers. A Steel Plate is worth 100 units.
            Mass = 10000f, // in kilograms. Force Applied Onto Target. 
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying. This is in hits, to simplify. A value of 10, means 10 hits.
            BackKickForce = 900000f,  // Force applied to User upon firing.
            DecayPerShot = 0f,  // Damage to Weapon System, on Firing.
            HardPointUsable = true, // set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.
            EnergyMagazineSize = 1,


            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,  // Your Ammo's physical shape for detecting hits. 
                Diameter = 1,  
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled.  Block-Peneration Value. This value is only used to manually set it, as projectiles will have this effect regardless.
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef  //Shrapnel spawns on Projectile death, when enabled.
            {
                AmmoRound = "",  // Ammo Class ID goes here.
                Fragments = 0,  // Number of Spawns.
                Degrees = 0, 
                Reverse = false,
                RandomizeDir = false, // randomzie between forward and backward directions
            },
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {   //Ammo Pattern for Weapon. If empty, this is disabled.
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage. A Steel plate is worth 100 units.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon. If they are vulnerable, this Ammo will destroy voxels.
                SelfDamage = false, // true = allow self damage.

                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f, 
                FallOff = new FallOffDef
                {
                    Distance = 1000f, // Distance at which max damage begins falling off.
                    MinMultipler = 1f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage. If 1, 100% damage at all ranges.
                },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = -1f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = -1f,
                    Heavy = -1f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 0,  // Modifier for Ammo when hitting a Shield.  Emp adds bonus damage & a shield activation delay in addition to this value.
                    Type = Bypass,  // Used by Shield Enhancers. Options are Kinetic, Energy, Emp , and Bypass. Bypass ignores shielding, and enables BypassModifier.
                    BypassModifier = -1f,  // % of damage loss upon bypassing a Shield, for this Projectile.
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test1",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef  // This section controls AOE effects, and area damage.
            {
                AreaEffect = JumpNullField, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 100000f, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 50f,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 0,
                    PulseChance = 0,
                },
                Explosions = new ExplosionDef  // Special effects for when exploding.
                {
                    NoVisuals = false,
                    NoSound = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 0,
                    DetonationRadius = 0,
                },
                EwarFields = new EwarFieldsDef  // Additional Status Effect Modifiers & settings.
                {
                    Duration = 600,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 2,
                    TriggerRange = 60f,
                },
            },
            Beams = new BeamDef
            {
                Enable = false,  //If true, this ammo is now a Hitscan beam, unless TravelTime is not 0.
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None, 
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,  // Used typically for Missiles, this is the starting speed & accel increase per second. At 10, your shot starts at 10m\s, and gains 10m\s per second.
                DesiredSpeed = 350,  // This is in meters-per-second.
                MaxTrajectory = 1500f,  // This is in meters. 1000, is 1k distance.
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 0, // How long the weapon must fire before it reaches MaxTrajectory. This is used by Beams, to make them not instant.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is. Not not raise above 2.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn. Do not raise above 1. It will glitch.
                    TrackingDelay = 1, // Measured in Shape diameter units traveled. Assume value of 1 Diameter is equal to one meter.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's. Use this, for non-turrets to ensure they lock properly.
                    MaxTargets = 0, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                },
                Mines = new MinesDef   // Mine Settings, for creating Minefields.
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,  // In meters.
                    FieldTime = 1800,  // Divie by 100, for Seconds.
                    Cloak = false,  // If Mine becomes invisible.
                    Persist = false,  // If is saved between loads & unloads of the Game. 
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = false,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        Color = Color(red: 0, green: 0, blue: 0, alpha: 0),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "EnergyExp1",
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 17, green: 0, blue: 41, alpha: 200),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = .3f,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0f, end: 0f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 4f,
                        Width = .75f,
                        Color = Color(red: 25, green: 0, blue: 80, alpha: 1f), // Main Color
                    },
                    Trail = new TrailDef
                    {
                        Enable = true,
                        Material = "WeaponLaser",
                        DecayTime = 3,
                        Color = Color(red: 66, green: 42, blue: 0, alpha: 0.5f), // Back Color 43, 0, 74 (front) 56, 32, 0 (back)
                        Back = false,
                        CustomWidth = .2f,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 4f,
                        MaxLength = 4f,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",  // Audio played to nearby players, in proximity.
                HitSound = "jdd_explode",  // Audio played on hit, to non-shielded blocks.
                ShieldHitSound = "jdd_explode",
                PlayerHitSound = "jdd_explode",
                VoxelHitSound = "jdd_explode",
                FloatingHitSound = "jdd_explode",
                HitPlayChance = 1f,
                HitPlayShield = true,
            }, // Don't edit below this line
            Ejection = new AmmoEjectionDef
            {
                Type = Particle, // Particle or Item (Inventory Component)
                Speed = 100f, // Speed inventory is ejected from in dummy direction
                SpawnChance = 0.5f, // chance of triggering effect (0 - 1)
                CompDef = new ComponentDef
                {
                    ItemDefinition = "", //InventoryComponent name
                    LifeTime = 0, // how long item should exist in world
                    Delay = 0, // delay in ticks after shot before ejected
                }
            },
        };
       }
}
