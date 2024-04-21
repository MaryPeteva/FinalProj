using Microsoft.CodeAnalysis;
using OnlyTools.Infrastructure.Data.Models;

namespace OnlyTools.Infrastructure.Data.Seed
{
    internal class ToolsSeeder
    {
        private readonly OnlyToolsDbContext _context;
        public ToolsSeeder(OnlyToolsDbContext context)
        {
            _context = context;
        }

        private async void SeedAsync()
        {
            if (!_context.Tools.Any())
            {
                var tipCategories = new List<Tool>() {
                    new Tool
                    {
                        Id = 1,
                        Name = "BLACK+DECKER 20V MAXCordless Drill/Driver",
                        Description = "30 PC. SET Includes a wide variety of bits and accessories for drilling and driving tasks.Compact, lightweight design for versatile use.\r\n24-POSITION CLUTCH Prevents stripping and overdriving screws for added control.Ergonomic design.Interchangeable battery system.\r\n",
                        RentPrice = 9.99M,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 2,
                        Name = "Greenworks 24V Compact Circular Saw",
                        Description = "High efficiency brushless motor delivers up to 50% more run-time and increased performance.Delivers up to 6500 RPM speed with Max cutting depth at 0º in 1.52\" (38.5mm) and at 45º in 1.12\" (28.5mm).Come with a Vacuum suction tube to connect with cleaners to keep your working deck clean and clear.Compact saw body with LED worklight for comfortable grip and working in dark and tight spaces.Provides 20% more power and 35% more run-time, and delivers fade-free power.",
                        RentPrice = 10.00m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 3,
                        Name = "CRAFTSMAN Small Angle Grinder 4-1/2 inch, 6 Amp",
                        Description = "41/2 in. Grinder powered by 6 amp motor producing 12, 000 RPMs.Tool-free guard makes for quick and easy adjustments.Spindle lock for quick and easy wheel changes.3position handle allows for control in different applications.Contoured overmolded handle for added comfort during use.",
                        RentPrice = 10.00m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 4,
                        Name = "Greenworks 24V Orbital Sander Kit",
                        Description = "Lightweight and portable easy to use.Motor delivers 5,000-11,000 OPM speed.Removable dust collection bag.80-grit hook-and-loop sanding disc, 5 sanding pad and removable dust collection bag.Provides 20% more power and 35% more run-time, and delivers fade-free power with no memory loss after charging.",
                        RentPrice = 10.00m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 5,
                        Name = "Makita XVJ03Z 18V LXT Lithium-Ion Cordless Jig Saw",
                        Description = "Makita motor 2,600 spm.3 orbital settings plus straight cutting for use in a wide range of materials.Tool-less blade change lever allows for faster blade installation and removal.Large 2-finger variable speed trigger for added convenience.Heavy gauge, precision machined base.",
                        RentPrice = 9.95m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 6,
                        Name = "VEVOR 1 Inch SDS-Plus Rotary Hammer Drill",
                        Description = "8Amp motor, 2.4J impact energy, 1 max drill dia. 800W rotary hammer drill for wood, steel, concrete, brick. 4 modes: drill, hammer, hammer drill, chisel adj. High speed: 1470rpm, 5200bpm. 360 handle, SDS-Plus chuck, reverse design.Suitable for wood, masonry, concrete, brick, metal.",
                        RentPrice = 8.55m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 7,
                        Name = "WEN 6530 6-Amp Electric Hand Planer, 3-1/4-Inch",
                        Description = "6 Amp motor provides up to 34,000 cuts per minute.16 positive stops adjust the cutting depth anywhere from 0 to 1/8 inches.Make rabbets up to 1 inch in size with the 5/16 inch rabbeting guide.Lightweight design weighs in at a mere 6 pounds",
                        RentPrice = 6.99m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 8,
                        Name = "SEEKONE Heat Gun 1800W",
                        Description = "SEEKONE 1800W heat gun quickly heat up to 650 in 1.5 seconds. The black dial provides rheostat-type heating, the high / low switch on its handle provides air flow control. Temperature range from 122F to 1202F. Overload protector to avoid damage.Ergonomic design handle.",
                        RentPrice = 5.85m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 9,
                        Name = "ENERTWIST Cordless Screwdriver, 8V Max 10Nm",
                        Description = "8V motor,  10Nm max torque. Manual mode 10Nm max.21 clutch 1 drill setting. No load speed 230 RPM and holds 1 inch bit tips.Battery powered by 1500mAh built-in lithium battery. Screw 300pcs M4*40mm in specification continuously after fully charged.Adjustable Dual Position Handle. Built-in LED Light.",
                        RentPrice = 6.33m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 10,
                        Name = "Skil 7510-01 120 Volt 3-InchX 18-InchBelt Sander",
                        Description = "Pressure control technology.6A of power sands any type of wood surface.Micro-filtration captures and contains fine dust particles.Auto track belt alignment keeps belt centered.Vacuum compatible - fits standard 1-1/4 IN. vacuum hoses\r\nFlush edge sanding sands right up to the edge for maximum capacity",
                        RentPrice = 10.00m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 1,
                        Category = await _context.ToolCategories.FindAsync(1),
                    },
                    new Tool
                    {
                        Id = 11,
                        Name = "SUNHZMCKP Magnetic Screwdriver Set 66-Piece",
                        Description = "screwdriver kit S2 Alloy Steel. Impact resistance high torque and hardness.Triangle stereo handle design to prevent rolling,hang hole design.5PC phillips screwdrivers5PC slotted screwdrivers4PC torx screwdrivers，9PC precision screwdrivers1PC 40in1 screwdriver，1PC Magnetize&demagnetize，40PC Bit set.",
                        RentPrice = 15.00m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                        Id = 12,
                        Name = "20 oz Hammer",
                        Description = "Rip claw head , flat hammerhead.Vibration reduction TPR ergonomic grip.Forged from one piece steel.Magnetic nail starter for rapid nail driving, perfect for one-hand operation.Construction, home improvement, general repairs and maintenance, woodworking, art hanging, and more.",
                        RentPrice = 2.99m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                        Id = 13,
                        Name = "Basics Plier Tools, Set of 4, Black,silver",
                        Description = "4-piece pliers set includes 8-inch slip joint, 8-inch long nose, 8-inch lineman, and 7-inch diagonal.Machined jaws help grip items securely for ultimate control.Non-slip handles help ensure a safe, secure grip\r\nMeets or exceeds ANSI specifications",
                        RentPrice = 3.56m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                        Id = 14,
                        Name = "Plumbing Adjustable Wrench 6 inch x 2.50 x 0.6",
                        Description = "6 inch adjustable plumbing wrench with inch/metric measurement scale.Drop-forged, heat-treated Cr-V steel construction.Bi-color plastic soft-grip handles with slim head and tapered jaws.Precision-machined slide jaw and worm gear for the perfect fit and easy adjustment.Dimensions: 6x2.50x0.6 inches",
                        RentPrice = 3.50m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                         Id = 15,
                        Name = "Fiskars Pro Retractable Folding Utility Knife",
                        Description = "Retractable, folding utility knife with replaceable CarbonMax blade with reinforced metal end.Utility knife constructed with full-body metal.Fiskars CarbonMax blades.Dual-locking system. Easy-to-use ergonomic handle.One-handed, flip-open design. Blades snap in or out easily.",
                        RentPrice = 2.00m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                        Id = 16,
                        Name = "LEXIVON 25Ft/7.5m AutoLock Tape Measure",
                        Description = "Firm grip Anti-skid high impact rubberized ABS case. AutoLock mechanism.1 Inch wide nylon coated blade. Dual side matte finish white & yellow scale.True zero multi-catch hook for both internal and external accurate measurements.Easy to read fractional graphics, Stud center markings every 16 and 19.2",
                        RentPrice = 1.99m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                        Id = 17,
                        Name = "ENERTWIST 13pcs Wood Chisel Set 8 CRV",
                        Description = "kit contains: 1/4, 3/8, 1/2, 5/8, 3/4, 1, 1-1/4 and 1-1/2 chisels, full length of carpenter chisels.The sharpening stone with the honing guide will allow you to sharpen the tools at a 25 and 30 degree angle, so it can be used not just for wood chisels but also for plane irons.",
                        RentPrice = 15.00m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                        Id = 18,
                        Name = "Notch Legacy 13 Saw with Scabbard",
                        Description = "High carbon Japanese SK5 steel\r\nFull Tang Blade\r\nTeeth on the blades are tri-edge, triple-sharp teeth\r\nMolded scabbard with rollers is included\r\nWeight: 0.95 lbs.",
                        RentPrice = 5.99m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                        Id = 19,
                        Name = "MAXPOWER 4-Pieces Pry Bar Set",
                        Description = "12-inch Utility Pry Bar, double claw with end chisel nail puller, Made of Drop Forged and Heat-treated Alloy Steel\r\n8-inch End Cutting Pliers, Carpenter pincers\r\n7-inch and 10-inch Flat Pry Bar, double claw with end of nail puller\r\nCorrosion-resistant black plated finish",
                        RentPrice = 5.55m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                        Id = 20,
                        Name = "LENOX Tools Hacksaw, Compact",
                        Description = "I-Beam construction allows the hacksaw blade to tension up to 50,000 psi\r\nHacksaw frame accepts most LENOX reciprocating saw blades to be used as a jab saw\r\nStores up to 5 extra 12-inch hacksaw blades in the I-Beam\r\nComes with one 12-inch, 24 TPI hacksaw blade",
                        RentPrice = 10.20m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 2,
                        Category = await _context.ToolCategories.FindAsync(2),
                    },
                    new Tool
                    {
                        Id = 21,
                        Name = "Fiskars Softgrip Pruner with Replaceable Blade",
                        Description = "Cut stems and branches up to 1 inch diameter with an ultra-durable pruner featuring a replaceable blade for continual cutting performance\r\nForged steel construction offers superior strength and lasting durability\r\nFully hardened, precision-ground, bypass-style steel blade stays sharp",
                        RentPrice = 5.20m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 3,
                        Category = await _context.ToolCategories.FindAsync(3),
                    },
                    new Tool
                    {
                        Id = 22,
                        Name = "Fiskars Softgrip Pruner with Replaceable Blade",
                        Description = "Cut stems and branches up to 1 inch diameter with an ultra-durable pruner featuring a replaceable blade for continual cutting performance\r\nForged steel construction offers superior strength and lasting durability\r\nFully hardened, precision-ground, bypass-style steel blade stays sharp",
                        RentPrice = 5.20m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 3,
                        Category = await _context.ToolCategories.FindAsync(3),
                    },
                    new Tool
                    {
                        Id = 23,
                        Name = "Shovel for Digging",
                        Description = "Round Small Shovel with Wooden D-Handle, Metal Garden Shovel for Gardening, 28 Inches. Longer Service Life: The blade of this round small shovel is made of carbon steel, which can effectively improve the hardness by high temperature quenching, and the surface has anti-rust coating to avoid rusting.",
                        RentPrice = 0.0m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 4,
                        Category = await _context.ToolCategories.FindAsync(4),
                    },
                    new Tool
                    {
                        Id = 24,
                        Name = "Garden Hoe",
                        Description = "Corona GT 3244 Extended Reach Hoe and Cultivator, Red, No Size,40.16 x 9.65 x 5.51 inches, Gray. For working in raised -bed gardens small garden and tight access locations. ComfortGEL grips deliver comfort to gardeners who seek an easier more therapeutic gardening experience.",
                        RentPrice = 0.0m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 4,
                        Category = await _context.ToolCategories.FindAsync(4),
                    },
                    new Tool
                    {
                        Id = 25,
                        Name = "Trowel",
                        Description = "FANHAO Heavy Duty Garden Trowels Cast-Aluminum with Non-Slip Rubber Grip, Idea for Transplanting, Weeding, Digging and Planting. FANHAO Garden tools set contains 3 pieces high quality hand tools.FANHAO heavy duty hand tools is crafted for durability can withstand the toughest roots, rocks and soil. ",
                        RentPrice = 0.0m,
                        OwnerID = Guid.Parse(""),
                        Owner = await _context.Users.FindAsync(""),
                        CategoryId = 4,
                        Category = await _context.ToolCategories.FindAsync(4),
                    },
                    new Tool
                    {
                         Id = 26,
                         Name= "Rake",
                         Description = "TABOR TOOLS Adjustable Metal Rake - Collapsible & Telescopic - Garden, Yard, & Lawn - Ideal for Leaves, Shrubs & Small Areas. J16A. This tool will allow you to quickly clean leaves, grass clippings, and small debris off your lawn. It's the versatility of this rake that makes it such a find. ",
                         RentPrice= 0.0m,
                         OwnerID= Guid.Parse(""),
                         Owner= await _context.Users.FindAsync(""),
                         CategoryId= 4,
                         Category= await _context.ToolCategories.FindAsync(4),
                     },
                     new Tool
                     {
                         Id = 27,
                         Name= "Wheelbarrow",
                         Description = "2 Wheel Wheelbarrow, 330 Pounds Capacity Yard Cart with Padded Handlebar, 14 Inch Pneumatic Tires for High Stability, Ideal for Moving Soil, Plant Shrub, Gardening Tool, Easy Assembly. VERSATILE YARD CART= With a load tray capacity of five cubic feet.",
                         RentPrice= 0.0m,
                         OwnerID = Guid.Parse(""),
                         Owner= await _context.Users.FindAsync(""),
                         CategoryId= 4,
                         Category = await _context.ToolCategories.FindAsync(4),
                     },
                     new Tool
                    {
                         Id = 28,
                        Name= "Garden Fork",
                        Description= "epoxy coated head for improved resistance to rust, scratches, humidity & alkali attack.Solid forged carbon steel head and long lipped socket, riveted for added strength. Hammer finish powder coated head for improved resistance to rust, scratches, humidity and alkalis found in soil.",
                                RentPrice = 0.0m,
                                OwnerID = Guid.Parse(""),
                                Owner = await _context.Users.FindAsync(""),
                                CategoryId = 4,
                                Category = await _context.ToolCategories.FindAsync(4),
                     },
                     new Tool
                     {
                         Id = 29,
                         Name = "Hedge Shears",
                         Description = "TABOR TOOLS B212A Telescopic Hedge Shears with Wavy Blade and Extendable Steel Handles. Extendable Manual Hedge Clippers for Trimming Borders, Boxwood, and Tall Bushes.This hedge trimmer is the ideal tool for trimming and shaping your shrubs and decorative topiary plants.",
                         RentPrice = 0.0m,
                         OwnerID = Guid.Parse(""),
                         Owner = await _context.Users.FindAsync(""),
                         CategoryId = 4,
                         Category = await _context.ToolCategories.FindAsync(4),
                     },
                      new Tool
                      {
                          Id = 30,
                           Name = "Watering Can",
                           Description = "Chapin 47998 100 % Recycled Plastic Watering Can, Removable Nozzle, Leak Free, Drip Free, Black with White Nozzle. 100 % RECYCLED POLYMER = guilt free from environmental concerns, the tank is made from 100 % recycled polymer, better for the environment and less in the landfill.",
                           RentPrice = 0.0m,
                           OwnerID = Guid.Parse(""),
                           Owner = await _context.Users.FindAsync(""),
                           CategoryId = 4,
                           Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 31,
                           Name = "Lawn Mower",
                           Description = "Worx 40V 17 Cordless Lawn Mower for Small Yards, 2 -in-1 Battery Lawn Mower Cuts Quiet, Compact & Lightweight Push Lawn Mower with 7 - Position Height Adjustment – 2 Batteries & Charger Included",
                           RentPrice = 0.0m,
                           OwnerID = Guid.Parse(""),
                           Owner = await _context.Users.FindAsync(""),
                           CategoryId = 4,
                           Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 32,
                          Name = "Adjustable Bench Hand Plane with 2-Inch Blade",
                          Description = "Professional quality: Durable cast iron body provides stability and strength;\r\nExcellent control: Impact-resistant plastic handle with contoured grip;\r\nDurable steel blade: Durable steel alloy blade makes quality cuts;\r\nEasy adjustments: Adjustable gear that allows you to achieve precise results;",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 33,
                          Name = "10-Pieces Woodworking Wood Chisel Set, Wooden Box",
                          Description = "Accurately pre-sharpened by machine for all chisels.All blades are made from Chrome-Vanadium steel and hardened to Rockwell C60, so blades will hold an edge for years of use.Teak wood handle is harder and comfortable for using.Chisel (6mm, 10mm, 13mm, 19mm, 25mm, 32mm, 38mm, 50mm);\r\n",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 34,
                          Name = "3 in 1 Professional Jeweler's Saw Set ",
                          Description = "Saw Frame 144 Blades Wooden Pin Clamp Wood Metal mix stanless and wood",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 35,
                          Name = "Wood Router Tool, Enhulk Compact Trim Router",
                          Description = "Ideal wood trim router kit for beginners and DIYers. The tool kit includes router, basic accessories (1/4'' bits ONLY) and guides, everything you need to start right out of the box.Ready to meet your various DIY needs.Heavy-duty cast aluminum body fixed base are engineered for durability.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 36,
                          Name = "VEVOR Benchtop Wood Lathe",
                          Description = "Professional DIY: Our benchtop wood lathe is designed with an 18-inch workbench and powerful capabilities, meeting the needs of professional woodworkers and providing a convenient solution for your woodworking projects.Featuring a high-quality aluminum alloy base and a solid steel headstock.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 37,
                          Name = "2pcs Adjustable SpokeShave with Flat Base",
                          Description = "Package include 2 sizes adjustable spokeshave and 4 replaceable blades and 1pcs portable woodworking planes.Our philosophy is to serve customers,caring, peace of mind, more confidence.Adjustable SpokeShave total length is 10 and 9. Blade length is 43.8mm/1.72 and 52mm/2.05Portable Woodworking Plane",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 38,
                          Name = "19PCS Metal & Rasp File Set",
                          Description = "The files are made of premium material T12 carbon steel and the body hardness up to 62～66HRC. The teeth were deeply quenched and coated for durable filing performance.File, de-burr, shape, trim, and smooth Metal, Wood, Jewelry, Plastics, Ceramics, Glass and just about anything else.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 39,
                          Name = "KAKURI Japanese Block Plane 50mm for Woodworking",
                          Description = "Ideal Japanese type woodworking hand planer for surface finishing of wood. You can make smooth chamfers by polishing the wood with this handtool. it is easy to apply force evenly, and accurate and efficient straight carpentry work is possible.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 40,
                          Name = "Preston Tenon Saw - 10/250mm",
                          Description = "Traditional tenon saw with a heavy steel back for control and rigidity.SK5 alloy steel blade.Traditional tooth pattern 15tpi.Solid beech handle with a lacquered finish.Size: 10\"/250mm x 0.6mm x 15tpi blade.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 41,
                          Name = "Wood Carving Tools Set for Spoon Bowl Cup, RVETOL",
                          Description = "6pcs wood knives of different shapes(hook knife, whittling knife, detail knife, trimming knife, oblique knife, round handle long chisel knife), 6pcs black big knife cover, 6pcs plastic small knife cover, 1 pair cut resistant gloves, wood carving spoon, sandpaper",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 4,
                          Category = await _context.ToolCategories.FindAsync(4),
                      },
                      new Tool
                      {
                          Id = 42,
                          Name = "LEXIVON 25Ft/7.5m AutoLock Tape Measure",
                          Description = "Firm grip Anti-skid high impact rubberized ABS case. AutoLock mechanism controls blade retraction. 1 Inch wide nylon coated blade resists rust & corrosion. Dual side matte finish white & yellow scale print.True zero multi-catch hook for both internal and external accurate measurements.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 43,
                          Name = "BOSCH GLM100-23 100ft Laser Measure",
                          Description = "Simple, user-friendly layout features two-button operation: one for measuring, one for rounding.Features long range measuring with extreme accuracy and measures distances up to 100 feet to within 1/16 inch. Measures in meters, feet inches, with fractions or decimals.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 44,
                          Name = "24-inch Torpedo Level Magnetic Box",
                          Description = "Intuitive and easy to use: TOOLZILLA Torpedo Level has top read features with stable bubbles that quickly determine the surface level (measuring accuracy of 0.5mm/m)Accurate, non-slip measurement for both DIY and professional use, 9-inch torpedo level made with high-quality materials",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 45,
                          Name = "Kynup Digital Caliper",
                          Description = "Kynup digital caliper has a measurement range of 0 - 6/ 0 - 150 mm; accuracy to 0.001/0.02mm and resolution to 0.0005/0.01mm. Perfect and accurate caliper measuring tool for household or DIY measurement. Please choose stainless steel digital caliper for more accurate measuring.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 46,
                          Name = "Metal Geometry Set",
                          Description = "Aluminum Mat Ruler Set For All Levels Designed in the USA.Package Includes 4 Piece: 8 - 30/60 Triangle, 5.5 - 45/90 Triangle, 12 Flat Ruler, 180 - 6 Protractor.The Scale Ruler Set Is Made From Pure Aluminum Mixed With Other Elements To Create A High-Strength Alloy.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 47,
                          Name = "Angle Protractor",
                          Description = "It's constructed of durable stainless steel and features a 6 adjustable arm for setting the bevel, transferring angles, and finding your measurement.This square head protractor has a 0 to 180-degree semi-circle scale in forward and reverses directions to measure all angles on the job.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 48,
                          Name = "Digital Electronic Level and Angle Gauge",
                          Description = "Measure angles, check relative angles with zero calibration feature, or use as a digital level with ease.Reverse contrast display improves visibility in low light conditions and automatically rotates when upside-down for easy viewing. Measure between 0-90, or 0-180 degrees",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 49,
                          Name = "Zozen Measuring Wheel",
                          Description = "Measures in feet and inches. Measure distance wheel against a usual tape measure and it will be the same measurements. Whether private or industrial purposes, the measurement of straight line and curve line is easy.One key reset, Larger bracket, Redesigned joints, Threaded TPR tires.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 50,
                          Name = "THORVALD 6-in-1 Carpenter Square",
                          Description = "Easily measure, trace, and take angles using only one woodworking square!  With our 6in1 carpenter tools, you have everything you need.It combines six carpentry tools in one accessory, including a square, two protractors, three marking gauges, two rulers, a drill gauge, and a wrench.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 51,
                          Name = "Plumb Bob Magnetic Kit-15",
                          Description = "8oz and 15oz construction plumb bobs are made of high-quality steel, which is corrosion-resistant and provides long-term use protection. We will provide a plumb line string reel containing 14.5 ft nylon braided wire that can quickly and automatically retractable, which is management and portability.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 5,
                          Category = await _context.ToolCategories.FindAsync(5),
                      },
                      new Tool
                      {
                          Id = 52,
                          Name = "AMERICAN MUTT Brick Hammer",
                          Description = "The hammer block feature ensures robust impact, making it a must-have for professionals and DIY enthusiasts alike.This stone mason hammer is an essential addition to your masonry tools for brick projects. Its 20oz head offers the perfect balance for efficient striking and control.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 6,
                          Category = await _context.ToolCategories.FindAsync(6),
                      },
                      new Tool
                      {
                          Id = 53,
                          Name = "5 Piece Professional Masonry Trowel Set",
                          Description = "Set with a 13 brick jointer, 6 pointing trowel, 7 gauging trowel, 11 brick trowel and 11 plastering trowel.All tools are created with hardened tempered steel for long lasting durability and excellent for heavy and frequent usage.Handles are designed with rubber for comfortable grip.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 6,
                          Category = await _context.ToolCategories.FindAsync(6),
                      },
                      new Tool
                      {
                          Id = 54,
                          Name = "QLT By MARSHALLTOWN Mortar Hoe",
                          Description = "Forged from a single piece of carbon steel, MARSHALLTOWN Mortar Hoes are specially designed with circle cutouts to help you mix mortar to the right consistency.Contractor-grade QLT brand.6 3/8 x 5 inch blade.21 Inch contoured wood handle.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 6,
                          Category = await _context.ToolCategories.FindAsync(6),
                      },
                      new Tool
                      {
                          Id = 55,
                          Name = "Estwing 1-3/4-Inch Wide Hex Shaft Masonry Chisel",
                          Description = "Designed to score and shape hardened materials like stone, concrete and brick.1-3/4-INCH TIP - 1-3/4-inch wide cutting edge for precision use without damaging surrounding materialDrop forged from EN9 high carbon steel for lasting strength and durability Hardened edge for cleaner, faster scoring",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 6,
                          Category = await _context.ToolCategories.FindAsync(6),
                      },
                      new Tool
                      {
                          Id = 56,
                          Name = "Tile Grouter’s Float",
                          Description = "MARSHALLTOWN Tile Floats are perfect when laying tile, working with epoxy, or other situations\r\nPure gum rubber face is bonded to the dense rubber pad which is cemented to an aluminum backing plate\r\nEdges are beveled and the two front corners are rounded\r\n12 X 4 Inches with a Plastic Handle",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 6,
                          Category = await _context.ToolCategories.FindAsync(6),
                      },
                      new Tool
                      {
                          Id = 57,
                          Name = "Brick Jointer Handheld Builder",
                          Description = "sizes: 1/2in, 5/8in, 3/4in, 7/8in.A storage cover is provided for easy carrying and storage, which will bring more convenience to your work.Sophisticated production, excellent quality, hard and wear-resistant, and long service life.\r\nThe comfortable cast aluminum handle is more flexible.",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 6,
                          Category = await _context.ToolCategories.FindAsync(6),
                      },
                      new Tool
                      {
                          Id = 58,
                          Name = "Masonry Brush",
                          Description = "Made of solvent resistant and polystyrene bristles\r\nHandle has a hang-up hole for easy storage in shop or garage\r\nThis 6-1/2 inch Masonry Brush features four rows of Tampico Colored bristles Bristles have a 3-1/2 inch trim",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 6,
                          Category = await _context.ToolCategories.FindAsync(6),
                      },
                      new Tool
                      {
                          Id = 59,
                          Name = "Plugging Chisel, 10by3/16-Inch",
                          Description = "3/160 plugging chisel\r\nDrop-forged from high-grade tool steel\r\nBlack finish\r\nPolished edges\r\nFor cutting mortar out between bricks, for cornice work, and for cutting out hardened material ",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 6,
                          Category = await _context.ToolCategories.FindAsync(6),
                      },
                      new Tool
                      {
                          Id = 60,
                          Name = "Goldblatt G11280 Brick Tongs",
                          Description = "Professional Grade Brick Tongs, Rugged\r\nEasily Adjust To Carry From 6 To 11 Bricks\r\nMade Of A Light Weight Metal Alloy\r\nCarry 6-11 bricks per load\r\nHeavy duty\r\nCarry 6-11 bricks per load\r\nHeavy duty",
                          RentPrice = 5.20m,
                          OwnerID = Guid.Parse(""),
                          Owner = await _context.Users.FindAsync(""),
                          CategoryId = 6,
                          Category = await _context.ToolCategories.FindAsync(6),
                      },
                };
            }
        }
    }
}

