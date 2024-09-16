using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VKR.Algorihm;
using VKR.Entities;

namespace VKR.Tools
{
    public class Draw
    {
        /// <summary> Изображение сборочного чертежа </summary>
        public Bitmap Image { get; set; }
        /// <summary> Масштаб изображения </summary>
        private double Scale { get; set; }
        /// <summary> Размер границы печатной платы </summary>
        private float Border { get; set; }
        /// <summary> Отступ от границ рамки окна </summary>
        private float Margin { get; set; }

        private bool Rotated { get; set; }

        public Draw(int panelForDraw_width, int panelForDraw_height)
        {
            Rotated = false;
            Image = new Bitmap(panelForDraw_width, panelForDraw_height);
            Border = (float)(0.005 * Math.Min(Image.Width, Image.Height));
            Margin = (float)(0.003 * Math.Min(Image.Width, Image.Height));
        }

        public void DrawPCB(PCB pcb)
        {
            Pen black_pen = new Pen(Color.Black, (float)Border);

            float newWidth = 0, newHeight = 0;

            if (pcb.Width < pcb.Height)
            {
                Rotated = true;
                Scale = Math.Min((Image.Width - Border * 2 - Margin * 2) / pcb.Height, (Image.Height - Border * 2 - Margin * 2) / pcb.Width);
                newWidth = (float)(pcb.Height * Scale);
                newHeight = (float)(pcb.Width * Scale);
            }
            else
            {
                Scale = Math.Min((Image.Width - Border * 2 - Margin * 2) / pcb.Width, (Image.Height - Border * 2 - Margin * 2) / pcb.Height);
                newWidth = (float)(pcb.Width * Scale);
                newHeight = (float)(pcb.Height * Scale);
            }

            Graphics graph = Graphics.FromImage(Image);
            graph.Clear(Color.White);

            graph.DrawRectangle(black_pen, Border + Margin, Image.Height - Border - Margin - newHeight, newWidth, newHeight);
        }

        public void DrawComponents(Components components)
        {
            Pen gray_pen = new Pen(Color.Gray, Border * 0.4f);
            float size_font = Border * 1.5f;
            Font font = new Font(FontFamily.GenericMonospace, size_font);

            Graphics graph = Graphics.FromImage(Image);

            foreach (Entities.Component component in components.ListComponentsRef) 
            {
                float x = 0, y = 0, width = 0, height = 0;
                if (Rotated)
                {
                    x = (float)(component.Y * Scale) + Border + Margin;
                    y = (float)(component.X * Scale) + Border + Margin;
                    if (component.Angle == 0 || component.Angle == 180)
                    {
                        width = (float)(component.Footprint.Height * Scale);
                        height = (float)(component.Footprint.Width * Scale);
                    }
                    else
                    {
                        width = (float)(component.Footprint.Width * Scale);
                        height = (float)(component.Footprint.Height * Scale);
                    }
                }
                else
                {
                    x = (float)(component.X * Scale) + Border + Margin;
                    y = (float)(component.Y * Scale) + Border + Margin;
                    if (component.Angle == 0 || component.Angle == 180)
                    {
                        width = (float)(component.Footprint.Width * Scale);
                        height = (float)(component.Footprint.Height * Scale);
                    }
                    else
                    {
                        width = (float)(component.Footprint.Height * Scale);
                        height = (float)(component.Footprint.Width * Scale);
                    }
                }

                graph.DrawRectangle(gray_pen, x - width / 2, Image.Height - y - height / 2, width, height);
                DrawPins(component);
                graph.DrawString(component.Designator, font, Brushes.Black, x - size_font * 1.5f, Image.Height - y - size_font);
            }
        }

        private void DrawPins(Entities.Component component)
        {
            SolidBrush red_brush = new SolidBrush(Color.Red);

            Graphics graph = Graphics.FromImage(Image);
            foreach (Pin pin in component.PinsRef.ListofPinsRef)
            {
                float x = 0, y = 0;
                if (Rotated)
                {
                    if (component.Angle == 0 || component.Angle == 180)
                    {
                        x = (float)((pin.Y + component.Y) * Scale) + Border + Margin;
                        y = (float)((pin.X + component.X) * Scale) + Border + Margin;
                    }
                    else
                    {
                        x = (float)((pin.X + component.X) * Scale) + Border + Margin;
                        y = (float)((pin.Y + component.Y) * Scale) + Border + Margin;
                    }
                }
                else
                {
                    if (component.Angle == 0 || component.Angle == 180)
                    {
                        x = (float)((pin.X + component.X) * Scale) + Border + Margin;
                        y = (float)((pin.Y + component.Y) * Scale) + Border + Margin;
                    }
                    else
                    {
                        x = (float)((pin.Y + component.Y) * Scale) + Border + Margin;
                        y = (float)((pin.X + component.X) * Scale) + Border + Margin;
                    }
                }
                float radius = Border * 0.6f;

                graph.FillEllipse(red_brush, x - radius, Image.Height - y - radius, radius * 2, radius * 2);
            }
        }

        public void DrawZones(Zones zones)
        {
            Pen blue_pen = new Pen(Color.Blue, Border * 0.4f);

            Graphics graph = Graphics.FromImage(Image);
            foreach (Zone zone in zones.ListofZonesRef)
            {
                float x = 0, y = 0, width = 0, height = 0;
                if (Rotated)
                {
                    x = (float)(zone.Y * Scale) + Border + Margin;
                    y = (float)(zone.X * Scale + Border + Margin);
                    width = (float)(zone.Height * Scale);
                    height = (float)(zone.Width * Scale);
                }
                else
                {
                    x = (float)(zone.X * Scale) + Border + Margin;
                    y = (float)(zone.Y * Scale + Border + Margin);
                    width = (float)(zone.Width * Scale);
                    height = (float)(zone.Height * Scale);
                }

                graph.DrawRectangle(blue_pen, x - width / 2, Image.Height - y - height / 2, width, height);
            }
        }

        public void DrawForbiddenZones(ForbiddenZones zones)
        {
            Pen red_pen = new Pen(Color.Red, Border * 0.4f);
            HatchBrush hBrush = new HatchBrush(
               HatchStyle.BackwardDiagonal,
               Color.Red,
               Color.Transparent);

            Graphics graph = Graphics.FromImage(Image);
            foreach (ForbiddenZone zone in zones.ListForbiddenZoneRef)
            {
                float x = 0, y = 0, width = 0, height = 0;
                if (Rotated)
                {
                    x = (float)(zone.Y * Scale) + Border + Margin;
                    y = (float)(zone.X * Scale + Border + Margin);
                    width = (float)(zone.Height * Scale);
                    height = (float)(zone.Width * Scale);
                }
                else
                {
                    x = (float)(zone.X * Scale) + Border + Margin;
                    y = (float)(zone.Y * Scale + Border + Margin);
                    width = (float)(zone.Width * Scale);
                    height = (float)(zone.Height * Scale);
                }

                graph.DrawRectangle(red_pen, x - width / 2, Image.Height - y - height / 2, width, height);
                graph.FillRectangle(hBrush, x - width / 2, Image.Height - y - height / 2, width, height);
            }
        }

        public void DrawFunction()
        {
            float size_font = Border * 3f;
            Font font = new Font(FontFamily.GenericMonospace, size_font);

            Graphics graph = Graphics.FromImage(Image);

            (double F_WL, double F_EMC, double F_T) = GetFunction_F_Wl();
            if (Rotated)
            {
                graph.DrawString($"F_WL = {Math.Round(F_WL / 100, 2)}", font, Brushes.Black, Margin, Margin + size_font);
                graph.DrawString($"F_EMC = {Math.Round(F_EMC / 100, 2)}", font, Brushes.Black, Margin, Margin * 2 + size_font * 3);
                graph.DrawString($"F_T = {Math.Round(F_T, 4)}", font, Brushes.Black, Margin, Margin * 4 + size_font * 5);
            }
            else
            {
                graph.DrawString($"F_WL = {Math.Round(F_WL / 100, 2)}", font, Brushes.Black, Image.Width - Margin - size_font * 24, Margin + size_font);
                graph.DrawString($"F_EMC = {Math.Round(F_EMC / 100, 2)}", font, Brushes.Black, Image.Width - Margin - size_font * 24, Margin * 2 + size_font * 3);
                graph.DrawString($"F_T = {Math.Round(F_T, 4)}", font, Brushes.Black, Image.Width - Margin - size_font * 24, Margin * 4 + size_font * 5);
            }
        }

        private (double, double, double) GetFunction_F_Wl()
        {
            double F_WL = 0, F_EMC = 0, F_T = 0;
            List<string> ids = new List<string>();

            foreach (Wire wire in Project.instance.Scheme.WiresRef.ListWireRef)
            {
                if (!ids.Contains(wire.Id))
                {
                    List<Wire> list = Project.instance.Scheme.WiresRef.ListWireRef.FindAll(x => x.Id == wire.Id);
                    ids.Add(wire.Id);

                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            double x_i = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == list[i].Designator).PinsRef.ListofPinsRef
                                                                                                .Find(y => y.Id == list[i].IdPin).X;
                            double y_i = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == list[i].Designator).PinsRef.ListofPinsRef
                                                                                                .Find(y => y.Id == list[i].IdPin).Y;
                            double x_j = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == list[j].Designator).PinsRef.ListofPinsRef
                                                                                                .Find(y => y.Id == list[j].IdPin).X;
                            double y_j = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == list[j].Designator).PinsRef.ListofPinsRef
                                                                                                .Find(y => y.Id == list[j].IdPin).Y;

                            x_i += Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == list[i].Designator).X;
                            x_j += Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == list[j].Designator).X;
                            y_i += Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == list[i].Designator).Y;
                            y_j += Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == list[j].Designator).Y;

                            double dx = Math.Abs(x_i - x_j);
                            double dy = Math.Abs(y_i - y_j);

                            double d = Math.Sqrt(dx * dx + dy * dy);

                            if (F_EMC < d)
                            {
                                F_EMC = d;
                            }

                            F_WL += d;
                        }
                    }
                }
            }

            for (int i = 0; i < Project.instance.Scheme.ComponentsRef.ListComponentsRef.Count - 1; i++)
            {
                for (int j = i + 1; j < Project.instance.Scheme.ComponentsRef.ListComponentsRef.Count; j++)
                {
                    double x_i = Project.instance.Scheme.ComponentsRef.ListComponentsRef[i].X;
                    double x_j = Project.instance.Scheme.ComponentsRef.ListComponentsRef[j].X;
                    double y_i = Project.instance.Scheme.ComponentsRef.ListComponentsRef[i].Y;
                    double y_j = Project.instance.Scheme.ComponentsRef.ListComponentsRef[j].Y;
                    double power_i = Project.instance.Scheme.ComponentsRef.ListComponentsRef[i].PowerDissipation;
                    double power_j = Project.instance.Scheme.ComponentsRef.ListComponentsRef[j].PowerDissipation;

                    double dx = Math.Abs(x_i - x_j);
                    double dy = Math.Abs(y_i - y_j);

                    double d = Math.Sqrt(dx * dx + dy * dy);

                    if (d != 0)
                    {
                        F_T += (power_i + power_j) / d;
                    }
                    else
                    {

                    }
                }
            }

            return (F_WL, F_EMC, F_T);
        }
    }
}
