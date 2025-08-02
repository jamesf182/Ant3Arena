using Ant_3_Arena.Properties;
using Ant3Arena.Domain.Entities;
using Ant3Arena.Domain.Enums;
using Ant3Arena.Domain.Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ant_3_Arena
{
    public partial class AntArena : Form
    {
        private readonly Dictionary<AntColorEnum, List<Ant>> antsByColor = [];

        public AntArena()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Resources.bg;

            Bitmap bitmap = Resources.Ant;
            Size clientSize = this.ClientSize;

            Dictionary<AntColorEnum, int> antCounts = new()
            {
                { AntColorEnum.Red, 3 },
                { AntColorEnum.Yellow, 3 },
                { AntColorEnum.Black, 3 },
                { AntColorEnum.White, 3 }
            };

            foreach (var pair in antCounts)
            {
                var color = pair.Key;
                int count = pair.Value;
                antsByColor[color] = [];

                for (int i = 0; i < count; i++)
                {
                    var ant = AntFactory.CreateAnt(color, bitmap, clientSize);
                    antsByColor[color].Add(ant);
                }
            }
        }

        private void AntArena_Paint(object sender, PaintEventArgs e)
        {
            foreach (var antList in antsByColor.Values)
            {
                foreach (var ant in antList)
                {
                    e.Graphics.DrawImage(ant.AntImage, ant.X, ant.Y, 32, 36);
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (var antList in antsByColor.Values)
            {
                foreach (var ant in antList)
                {
                    ant.Move(this.ClientSize);
                }
            }
            Invalidate();
        }

        private void AntArena_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }
    }
}