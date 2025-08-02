using Ant_3_Arena.Properties;
using Ant3Arena.Application.Interfaces;
using Ant3Arena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ant_3_Arena
{
    public partial class AntArena : Form
    {
        private readonly IAntService _antService;

        private readonly List<Ant> ants;

        public AntArena(IAntService antConfigService)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Resources.bg;

            _antService = antConfigService;            

            Bitmap bitmap = Resources.Ant;
            Size clientSize = ClientSize;

            ants = _antService.GetAnts(bitmap, clientSize);
        }

        private void AntArena_Paint(object sender, PaintEventArgs e)
        {
            foreach (Ant ant in ants)
            {
                e.Graphics.DrawImage(ant.AntImage, ant.X, ant.Y, 32, 36);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ant ant in ants)
            {
                ant.Move(ClientSize);
            }

            Invalidate();
        }

        private void AntArena_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }
    }
}