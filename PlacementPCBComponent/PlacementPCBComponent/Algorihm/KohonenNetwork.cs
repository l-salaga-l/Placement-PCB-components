using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using VKR.Entities;

namespace VKR.Algorihm
{
    public class KohonenNetwork
    {
        private Neurons neurons;
        private System.Windows.Size size_area;
        private double grid;
        private int t = 0;
        private Neuron winner = null;
        private Random random = new Random();
        private double F_WL_OPT = 0, F_EMC_OPT = 0, F_T_OPT = 0;
        private AlgorithmParameters parameters;

        public Neurons NeuronsRef
        {
            get => neurons; set => neurons = value;
        }

        public System.Windows.Size SizeArea
        {
            get => size_area; set => size_area = value;
        }

        public double Grid
        {
            get => grid; set => grid = value;
        }

        public AlgorithmParameters AlgorithmParametersRef
        {
            get => parameters; set => parameters = value;
        }

        public KohonenNetwork() 
        {
            parameters = new AlgorithmParameters();
        }

        private void Iteration()
        {
            SetWinner();

            double xi = winner.X;
            double yi = winner.Y;

            (double fij_x, double fij_y) = Get_Fij();
            double F_ij = Math.Sqrt(fij_x * fij_x + fij_y * fij_y);

            double vi_x = xi + fij_x / F_ij;
            double vi_y = yi + fij_y / F_ij;

            foreach(Neuron neuron in neurons.NeuronRef) 
            {
                if (neuron.Possibility == true && neuron.Id == winner.Id) 
                {
                    double x_t = neuron.X;
                    double x_t_1 = x_t + nu() * (vi_x - x_t);
                    neuron.X = f_x(neuron, x_t_1);

                    double y_t = neuron.Y;
                    double y_t_1 = y_t + nu() * (vi_y - y_t);
                    neuron.Y = f_y(neuron, y_t_1);
                }
            }
        }

        public Neurons Iterations()
        {
            double previous_function = 0;
            int repeat = 0, max_repeat = 3;

            Randomize();

            t = 1;

            while (t < parameters.T_max)
            {
                Iteration();

                double current_function = GetFunction();

                if (current_function == previous_function)
                {
                    repeat++;
                    if (repeat == max_repeat)
                    {
                        break;
                    }
                }

                previous_function = current_function;

                t++;
            }

            return neurons;
        }

        private void SetWinner()
        {
            if (winner == null) winner = new Neuron();

            List<Neuron> neuron_winners = neurons.NeuronRef.FindAll(x => x.Possibility == true);

            int index = random.Next(neuron_winners.Count);

            winner = neuron_winners[index];

        }

        private void Randomize()
        {
            List<(double, double)> coordinates = new List<(double, double)>();
            foreach (Neuron neuron in neurons.NeuronRef)
            {
                if (neuron.Possibility == true)
                {
                    double x = -1, y = -1;
                    while (x == -1 && y == -1) 
                    {
                        x = f_x(neuron, random.NextDouble() * size_area.Width);
                        y = f_y(neuron, random.NextDouble() * size_area.Height);

                        if (!coordinates.Contains((x, y)))
                        {
                            coordinates.Add((x, y));
                            break;
                        }
                        else
                        {
                            x = -1; y = -1;
                        }
                    }
                    neuron.X = x;
                    neuron.Y = y;
                }
            }
        }

        private double f_x(Neuron neuron, double x)
        {
            if (x <= neuron.Width / 2)
            {
                return neuron.Width / 2;
            }
            else if (x >= size_area.Width - neuron.Width / 2)
            {
                return size_area.Width - neuron.Width / 2;
            }
            else
            {
                return (int)(x / grid) * grid;
            }
        }

        private double f_y(Neuron neuron, double y)
        {
            if (y <= neuron.Height / 2)
            {
                return neuron.Height / 2;
            }
            else if (y >= size_area.Height - neuron.Height / 2)
            {
                return size_area.Height - neuron.Height / 2;
            }
            else
            {
                return (int)(y / grid) * grid;
            }
        }

        private (double, double) Get_Fij()
        {
            int n = neurons.NeuronRef.Count;
            double Fij_x = 0;
            double Fij_y = 0;

            foreach (Neuron neuron in neurons.NeuronRef)
            {
                if (neuron.Id != winner.Id)
                {
                    double dx = Math.Abs(neuron.X - winner.X);
                    double dy = Math.Abs(neuron.Y - winner.Y);

                    double d = Math.Sqrt(dx * dx + dy * dy);

                    double Fij = 0, ID = 0, WL = 0;
                    double dij = 0;

                    (ID, dij) = IDij(neuron, winner);
                    WL = WLij(neuron, winner);
                    if (dij != 0)
                        Fij += nu() * WL / dij - (1 - nu()) * ID;

                    if (d != 0)
                    {
                        Fij_x += Fij * dx / d;
                        Fij_y += Fij * dy / d;
                    }
                }
            }

            return (Fij_x, Fij_y);
        }

        private double GetID()
        {
            double ID = 0;
            for (int i = 0; i <  neurons.NeuronRef.Count - 2; i++) 
            {
                for (int j = i; j < neurons.NeuronRef.Count - 1; j++) 
                {
                    (double _, double a) = IDij(neurons.NeuronRef[i], neurons.NeuronRef[j]);
                    ID += a;
                }
            }
            return ID;
        }

        private double GetFunction()
        {
            double F_WL = 0, F_EMC = 0, F_T = 0;

            for (int i = 0; i < neurons.NeuronRef.Count - 1; i++) 
            {
                for (int j = i + 1; j < neurons.NeuronRef.Count; j++)
                {
                    Neuron neuron_i = neurons.NeuronRef[i];
                    Neuron neuron_j = neurons.NeuronRef[j];

                    F_WL += WLij(neuron_i, neuron_j);

                    double dx = Math.Abs(neuron_i.X - neuron_j.X);
                    double dy = Math.Abs(neuron_i.Y - neuron_j.Y);

                    double d = Math.Sqrt(dx * dx + dy * dy);

                    if (F_EMC < d) F_EMC = d;

                    if (neuron_i.Power + neuron_j.Power != 0)
                    {
                        F_T += (neuron_i.Power + neuron_j.Power) / d;
                    }
                }
            }

            if (F_T_OPT == 0 || F_T < F_T_OPT)
            {
                F_T_OPT = F_T;
            }

            if (F_EMC_OPT == 0 || F_EMC < F_EMC_OPT)
            {
                F_EMC_OPT = F_EMC;
            }

            if (F_WL_OPT == 0 || F_WL < F_WL_OPT)
            {
                F_WL_OPT = F_WL;
            }
            if (F_T == 0)
            {
                F_T = 1; F_T_OPT = 1;
            }

            double F = parameters.A1 * F_WL / F_WL_OPT + parameters.A2 * F_EMC / F_EMC_OPT + parameters.A3 * F_T / F_T_OPT;

            return F;
        }

        private double nu()
        {
            return parameters.Nu0 * (1 - t / parameters.T_max);
        }

        private (double, double) IDij(Neuron neuron_i, Neuron neuron_j)
        {
            double dx = Math.Abs(neuron_i.X - neuron_j.X);
            double dy = Math.Abs(neuron_i.Y - neuron_j.Y);

            double d = Math.Sqrt(dx * dx + dy * dy);

            double wi = neuron_i.Width;
            double wj = neuron_j.Width;

            double hi = neuron_i.Height;
            double hj = neuron_j.Height;

            double dij = 0;

            if (dx == 0 && dy == 0)
            {
                dij = Math.Min((wi + wj) / 2, (hi + hj) / 2);
            }
            else if (dx == 0)
            {
                dij = Math.Min((wi + wj) / 2, (hi + hj) / 2 * d / dy);
            }
            else if (dy == 0)
            {
                dij = Math.Min((wi + wj) / 2 * d / dx, (hi + hj) / 2);
            }
            else
            {
                dij = Math.Min((wi + wj) / 2 * d / dx, (hi + hj) / 2 * d / dy);
            }

            if (dij > d)
            {
                return (Math.Pow(dij - d, 2), dij);
            }

            return (0, dij);
        }

        private double WLij(Neuron neuron_i, Neuron neuron_j)
        {
            double Fij = 0;

            foreach (var pins in neuron_i.Connection)
            {
                if (pins.Item2.IdNeuron == neuron_j.Id)
                {
                    int t = pins.Item1.Id;
                    int l = pins.Item2.Id;

                    double x1 = neuron_i.X + pins.Item1.X;
                    double x2 = neuron_j.X + pins.Item2.X;

                    double y1 = neuron_i.Y + pins.Item1.Y;
                    double y2 = neuron_j.Y + pins.Item2.Y;

                    double dx = Math.Abs(x1 - x2);
                    double dy = Math.Abs(y1 - y2);
                    double d = Math.Sqrt(dx * dx + dy * dy);

                    Fij += d;
                }
            }

            return Fij;
        }
    }
}
