using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Media;
using System.Resources;
using BabyDazzler.Dazzlers;
using BabyDazzler.Util;

namespace BabyDazzler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer player;
        private DispatcherTimer frameTimer;
        private Random random;

        public MainWindow()
        {
            random = new Random();
            // Construct timer that fires around 30 times per second (30 FPS)
            // Todo: get rid of magic number.
            frameTimer = initTimer();

            player = new SoundPlayer();
            player.SoundLocation = "pop.wav";
            player.Load();

            InitializeComponent();

            frameTimer.Start();
        }

        private DispatcherTimer initTimer()
        {
            DispatcherTimer t = new DispatcherTimer();
            //TODO: Fix magic number
            t.Interval = TimeSpan.FromMilliseconds(10);

            t.Tick += new EventHandler(refreshFrameEvent);

            return t;
        }

        private void refreshFrameEvent(object sender, EventArgs e)
        {
            DrawFrame();
        }

        public void AddShape()
        {
            const int NUM_SHAPES_TO_ADD = 5;

            VisualDazzleObj visDazzle;

            for (int i = 0; i < NUM_SHAPES_TO_ADD; i++)
            {
                visDazzle = new VisualDazzleObj((this.Height * .20), random);

                Shape visDazzelView = visDazzle.GetView();

                Canvas.SetTop(visDazzelView, random.Next(Convert.ToInt32(this.Height)));
                Canvas.SetLeft(visDazzelView, random.Next(Convert.ToInt32(this.Width)));

                WindowCanvas.Children.Add(visDazzelView);
            }

            /* TODO: Refactor to use resource manager */
            SoundPlayerWrapper.PlaySound("pop.wav");
           
        }

        private void playSound()
        {
//            this.player.
            this.player.PlaySync();
        }

        public void DrawFrame()
        {
            /* Go through WindowCanvas's children and lower the shapes' alpha count. Fully transparent 
             * shapes get removed for GC.
             */
            List<Shape> shapesToRemove = new List<Shape>();
            SolidColorBrush brush;
            Color color;

            foreach (Shape s in WindowCanvas.Children)
            { 
                brush = (SolidColorBrush) s.Fill;
                // Copy color object
                color = brush.Color;
                
                if (color.A > 1)
                {
                    color.A--;
                    ((SolidColorBrush)s.Fill).Color = color;
                }
                else
                {
                    /* This one is fully transparent. Mark for removal */
                    shapesToRemove.Add(s);
                }
            }

            foreach (Shape s in shapesToRemove)
            {
                WindowCanvas.Children.Remove(s);
            }
        }
    }
}
