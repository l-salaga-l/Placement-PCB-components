using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using VKR.Entities;

namespace VKR.Tools
{
    public static class Util
    {
        public static void GetCoordinate()
        {
            if (Project.instance.Name == "Цифровой преобразователь температуры")
            {
                List<(string, (double, double))> coord = new List<(string, (double, double))>()
                {
                    ("XS5", (15.5, 5.5)),
                    ("XS4", (5, 5.5)),
                    ("HL1", (23, 8.5)),
                    ("R22", (22, 12.5)),
                    ("R21", (26, 12.5)),
                    ("R20", (30, 12.5)),
                    ("DD5", (28.5, 17.5)),
                    ("R9", (22.5, 15)),
                    ("C33", (22.5, 17)),
                    ("R23", (23, 19.5)),
                    ("XS1", (25.5, 23)),
                    ("C28", (22, 25.5)),
                    ("C31", (26, 25)),
                    ("C5", (8.5, 12.5)),
                    ("C6", (15.5, 14.5)),
                    ("R7", (12, 12.5)),
                    ("R8", (15.5, 12.5)),
                    ("C13", (12, 14.5)),
                    ("DD1", (13.5, 20)),
                    ("R6", (2.5, 12.5)),
                    ("R11", (2, 14.5)),
                    ("C8", (6, 14.5)),
                    ("R10", (6.5, 16.5)),
                    ("C12", (2, 17)),
                    ("C18", (6.5, 18.5)),
                    ("C9", (2.5, 19)),
                    ("C17", (9, 20.5)),
                    ("R5", (5.5, 22.5)),
                    ("R18", (9, 23)),
                    ("C11", (2, 21.5)),
                    ("DA2", (2, 25)),
                    ("R3", (6.5, 25.5)),
                    ("R14", (11.5, 25)),
                    ("R13", (15, 25)),
                    ("R12", (13, 27)),
                    ("C10", (9, 27.5)),
                    ("C15", (11.5, 32)),
                    ("C14", (3, 32)),
                    ("C16", (10.5, 34.5)),
                    ("C25", (3.5, 34.5)),
                    ("DA1", (7, 33)),
                    ("A1", (8, 38)),
                    ("C24", (4, 44.5)),
                    ("L1", (7.5, 52)),
                    ("ZQ1", (21, 36.5)),
                    ("DD4", (28.5, 37.5)),
                    ("C32", (19.5, 40)),
                    ("R19", (23, 40)),
                    ("C27", (22.5, 43)),
                    ("C29", (26, 43)),
                    ("C30", (29.5, 43)),
                    ("DD2", (20, 50.5)),
                    ("C26", (19, 54.5)),
                    ("DD3", (29.5, 65.5)),
                    ("DA3", (23.5, 65.5)),
                    ("C23", (30.5, 70.5)),
                    ("C20", (25, 70)),
                    ("R1", (21.5, 70)),
                    ("R2", (17.5, 70)),
                    ("C21", (18.5, 66.5)),
                    ("C22", (18, 64)),
                    ("R17", (15, 68)),
                    ("R16", (14, 70)),
                    ("VD1", (13, 64)),
                    ("VD2", (6.5, 64)),
                    ("C19", (7.5, 69)),
                    ("XS2", (20.5, 81)),
                    ("XS3", (10, 81)),
                    ("HL2", (2.5, 78))
                };
                foreach (var item in coord)
                {
                    Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1).X = item.Item2.Item1;
                    Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1).Y = item.Item2.Item2;
                }

            }
            else if (Project.instance.Name == "Плата управления")
            {
                List<(string, (double, double))> coord = new List<(string, (double, double))>()
                {
                    ("DA1", (65.75, 7)),
                    ("R7", (47.75, 7)),
                    ("DA2", (65.75, 21)),
                    ("R8", (47.75, 24.5)),
                    ("DA3", (70.75, 35.25)),
                    ("R9", (50.75, 38.5)),
                    ("DA5", (68, 59.5)),
                    ("R11", (49.25, 57)),
                    ("X2", (72.75, 45.75)),
                    ("DA4", (66.25, 74.5)),
                    ("R10", (47.25, 74.5)),
                    ("R1", (37.25, 40)),
                    ("R3", (37, 31.5)),
                    ("X1", (29.5, 21.25)),
                    ("R6", (27.25, 16.5)),
                    ("R4", (23.25, 20.75)),
                    ("C6", (9.25, 16.75)),
                    ("R5", (17.25, 16.25)),
                    ("C1", (16.5, 21)),
                    ("R13", (9.25, 21.5)),
                    ("SB1", (7.5, 28)),
                    ("R14", (9.75, 35.5)),
                    ("R2", (9.75, 40.25)),
                    ("DD1", (24, 33)),
                    ("C2", (9, 48.25)),
                    ("C3", (25.75, 50.25)),
                    ("X3", (17.25, 63.75)),
                    ("C5", (25.75, 68.5)),
                    ("C4", (22.75, 73.5)),
                    ("HG1", (11.5, 71.25)),
                    ("R12", (9, 61.75)),
                    ("Z1", (17.75, 48))
                };
                foreach (var item in coord)
                {
                    Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1).X = item.Item2.Item1;
                    Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1).Y = item.Item2.Item2;
                }
            }
        }

        public static void GetPower()
        {
            if (Project.instance.Name == "Цифровой преобразователь температуры")
            {
                List<(string, double)> coord = new List<(string, double)>()
                {
                    ("XS5", 0),
                    ("XS4", 0),
                    ("HL1", 0.75),
                    ("R22", 0.063),
                    ("R21", 0.063),
                    ("R20", 0.063),
                    ("DD5", 1),
                    ("R9", 0.063),
                    ("C33", 0.17),
                    ("R23", 0.125),
                    ("XS1", 0),
                    ("C28", 0.17),
                    ("C31", 0.17),
                    ("C5", 0.17),
                    ("C6", 0.17),
                    ("R7", 0.063),
                    ("R8", 0.063),
                    ("C13", 0.17),
                    ("DD1", 1),
                    ("R6", 0.125),
                    ("R11", 0.125),
                    ("C8", 0.17),
                    ("R10", 0.063),
                    ("C12", 0.17),
                    ("C18", 0.17),
                    ("C9", 0.17),
                    ("C17", 0.17),
                    ("R5", 0.063),
                    ("R18", 0.063),
                    ("C11", 0.17),
                    ("DA2", 0.24),
                    ("R3", 0.063),
                    ("R14", 0.063),
                    ("R13", 0.063),
                    ("R12", 0.063),
                    ("C10", 0.17),
                    ("C15", 0.17),
                    ("C14", 0.17),
                    ("C16", 0.17),
                    ("C25", 0.17),
                    ("DA1", 0.24),
                    ("A1", 1),
                    ("C24", 0.17),
                    ("L1", 1.875),
                    ("ZQ1", 0.57),
                    ("DD4", 1),
                    ("C32", 0.17),
                    ("R19", 0.063),
                    ("C27", 0.17),
                    ("C29", 0.17),
                    ("C30", 0.17),
                    ("DD2", 1),
                    ("C26", 0.17),
                    ("DD3", 1),
                    ("DA3", 5.4),
                    ("C23", 0.17),
                    ("C20", 0.17),
                    ("R1", 0.063),
                    ("R2", 0.063),
                    ("C21", 0.17),
                    ("C22", 0.17),
                    ("R17", 0.063),
                    ("R16", 0.063),
                    ("VD1", 0.8),
                    ("VD2", 0.8),
                    ("C19", 0.36),
                    ("XS2", 0),
                    ("XS3", 0),
                    ("HL2", 0.75)
                };
                foreach (var item in coord)
                {
                    Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1).PowerDissipation = item.Item2;
                }

            }
            else if (Project.instance.Name == "Плата управления")
            {
                List<(string, double)> coord = new List<(string, double)>()
                {
                    ("DA1", 0.225),
                    ("R7", 0.25),
                    ("DA2", 0.225),
                    ("R8", 0.25),
                    ("DA3", 0.225),
                    ("R9", 0.25),
                    ("DA5", 0.225),
                    ("R11", 0.25),
                    ("X2", 2.5),
                    ("DA4", 0.225),
                    ("R10", 0.25),
                    ("R1", 0.25),
                    ("R3", 0.25),
                    ("X1", 1.875),
                    ("R6", 0.25),
                    ("R4", 0.25),
                    ("C6", 0.5),
                    ("R5", 0.25),
                    ("C1", 0.5),
                    ("R13", 0.25),
                    ("SB1", 0.75),
                    ("R14", 0.25),
                    ("R2", 0.25),
                    ("DD1", 0.0275),
                    ("C2", 0.5),
                    ("C3", 0.5),
                    ("X3", 2.5),
                    ("C5", 0.5),
                    ("C4", 0.5),
                    ("HG1", 0.025),
                    ("R12", 0.25),
                    ("Z1", 0.5)
                };
                foreach (var item in coord)
                {
                    Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1).PowerDissipation = item.Item2;
                }
            }
        }

        public static void GetSizeZones()
        {
            foreach (var zone in Project.instance.ZonesRef.ListofZonesRef)
            {
                double x_max = 0;
                double x_min = double.MaxValue;
                double y_max = 0;
                double y_min = double.MaxValue;

                foreach (var component in zone.ComponentsRef.ListComponentsRef)
                {
                    Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).ComponentsRef.ListComponentsRef
                        .Find(x => x.Designator == component.Designator).X = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == component.Designator).X;
                    Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).ComponentsRef.ListComponentsRef
                        .Find(x => x.Designator == component.Designator).Y = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == component.Designator).Y;

                    Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).ComponentsRef.ListComponentsRef
                         .Find(x => x.Designator == component.Designator).Footprint.Width = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == component.Designator).Footprint.Width;
                    Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).ComponentsRef.ListComponentsRef
                        .Find(x => x.Designator == component.Designator).Footprint.Height = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == component.Designator).Footprint.Height;


                    if (x_max < component.X + component.Footprint.Width / 2)
                    {
                        x_max = component.X + component.Footprint.Width / 2;
                    }
                    if (x_min > component.X - component.Footprint.Width / 2)
                    {
                        x_min = component.X - component.Footprint.Width / 2;
                    }
                    if (y_max < component.Y + component.Footprint.Height / 2)
                    {
                        y_max = component.Y + component.Footprint.Height / 2;
                    }
                    if (y_min > component.Y - component.Footprint.Height / 2)
                    {
                        y_min = component.Y - component.Footprint.Height / 2;
                    }
                }

                Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).Width = x_max - x_min;
                Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).Height = y_max - y_min;
                Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).X = (x_max - x_min) / 2 + x_min;
                Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).Y = (y_max - y_min) / 2 + y_min;
            }
        }

            public static void GetZones()
            {
            if (Project.instance.Name == "Цифровой преобразователь температуры")
            {
                List<(string, int)> zones = new List<(string, int)>()
                {
                    ("XS5", 1),
                    ("XS4", 1),
                    ("HL1", 1),
                    ("R22", 2),
                    ("R21", 2),
                    ("R20", 2),
                    ("DD5", 2),
                    ("R9", 2),
                    ("C33", 2),
                    ("R23", 2),
                    ("XS1", 2),
                    ("C28", 2),
                    ("C31", 2),
                    ("C5", 3),
                    ("C6", 3),
                    ("R7", 3),
                    ("R8", 3),
                    ("C13", 3),
                    ("DD1", 3),
                    ("R6", 3),
                    ("R11", 3),
                    ("C8", 3),
                    ("R10", 3),
                    ("C12", 3),
                    ("C18", 3),
                    ("C9", 3),
                    ("C17", 3),
                    ("R5", 3),
                    ("R18", 3),
                    ("C11", 3),
                    ("DA2", 3),
                    ("R3", 3),
                    ("R14", 3),
                    ("R13", 3),
                    ("R12", 3),
                    ("C10", 3),
                    ("C15", 4),
                    ("C14", 4),
                    ("C16", 4),
                    ("C25", 4),
                    ("DA1", 4),
                    ("A1", 4),
                    ("C24", 4),
                    ("L1", 4),
                    ("ZQ1", 5),
                    ("DD4", 5),
                    ("C32", 5),
                    ("R19", 5),
                    ("C27", 5),
                    ("C29", 5),
                    ("C30", 5),
                    ("DD2", 5),
                    ("C26", 5),
                    ("DD3", 6),
                    ("DA3", 6),
                    ("C23", 6),
                    ("C20", 6),
                    ("R1", 6),
                    ("R2", 6),
                    ("C21", 6),
                    ("C22", 6),
                    ("R17", 6),
                    ("R16", 6),
                    ("VD1", 6),
                    ("VD2", 6),
                    ("C19", 6),
                    ("XS2", 7),
                    ("XS3", 7),
                    ("HL2", 7)
                };

                foreach (var item in zones)
                {
                    Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1).CodeZone = item.Item2;

                    if (Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == item.Item2) == null)
                    {
                        Entities.Zone zone = new Entities.Zone();
                        zone.Id = item.Item2;
                        zone.Name = $"Зона №{item.Item2}";
                        Project.instance.ZonesRef.ListofZonesRef.Add(zone);
                    }

                    Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == item.Item2).ComponentsRef.ListComponentsRef
                        .Add(Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1));
                }
            }
            else if (Project.instance.Name == "Плата управления")
            {
                List<(string, int)> zones = new List<(string, int)>()
                {
                    ("DA1", 1),
                    ("R7", 1),
                    ("DA2", 2),
                    ("R8", 2),
                    ("DA3", 3),
                    ("R9", 3),
                    ("DA5", 4),
                    ("R11", 4),
                    ("X2", 5),
                    ("DA4", 6),
                    ("R10", 6),
                    ("R1", 7),
                    ("R3", 7),
                    ("X1", 7),
                    ("R6", 7),
                    ("R4", 7),
                    ("C6", 7),
                    ("R5", 7),
                    ("C1", 7),
                    ("R13", 7),
                    ("SB1", 7),
                    ("R14", 7),
                    ("R2", 7),
                    ("DD1", 7),
                    ("C2", 8),
                    ("C3", 8),
                    ("X3", 8),
                    ("C5", 8),
                    ("C4", 8),
                    ("HG1", 8),
                    ("R12", 8),
                    ("Z1", 8)
                };
                foreach (var item in zones)
                {
                    Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1).CodeZone = item.Item2;

                    if (Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == item.Item2) == null)
                    {
                        Entities.Zone zone = new Entities.Zone();
                        zone.Id = item.Item2;
                        zone.Name = $"Зона №{item.Item2}";
                        Project.instance.ZonesRef.ListofZonesRef.Add(zone);
                    }

                    Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == item.Item2).ComponentsRef.ListComponentsRef
                        .Add(Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == item.Item1));
                }
            }
        }
        public static void ResetAngle()
        {
            foreach (var component in Project.instance.Scheme.ComponentsRef.ListComponentsRef)
            {
                Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == component.Designator).Angle = 0;
            }
        }
    }
}

