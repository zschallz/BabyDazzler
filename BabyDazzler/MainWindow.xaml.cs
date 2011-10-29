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
        private DispatcherTimer frameTimer;
        private Random random;

        public MainWindow()
        {
            random = new Random();
            // Construct timer that fires around 30 times per second (30 FPS)
            // Todo: get rid of magic number.
            frameTimer = initTimer();

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

        public void HandleKeystroke()
        {
            /* Define total number of shapes per keystroke to add here */
            const int NUM_SHAPES_TO_ADD = 5;

            VisualDazzle visDazzle;

            for (int i = 0; i < NUM_SHAPES_TO_ADD; i++)
            {
                /* Create a new visual dazzler thats at least 20% of the window's size */
                visDazzle = new VisualDazzle((this.Height * .20), random);

                Shape visDazzelView = visDazzle.GetView();

                /* Position shape from the visual dazzler in a random location on the
                 * canvas and add it to the canvas. */
                Canvas.SetTop(visDazzelView, random.Next(Convert.ToInt32(this.Height)));
                Canvas.SetLeft(visDazzelView, random.Next(Convert.ToInt32(this.Width)));

                WindowCanvas.Children.Add(visDazzelView);
            }

            /* TODO: Check into whether dynamic resource lookup will be needed. */
            //SoundDazzle sd = new SoundDazzle(key);
            //SoundPlayerWrapper.PlaySound(BabyDazzler.Properties.Resources.f_major_3rd);

        }

        /* This method is called every time that a frame is to be served (from the timer) */
        public void DrawFrame()
        {
            List<Shape> shapesToRemove = new List<Shape>();
            SolidColorBrush brush;
            Color color;

            foreach (Shape s in WindowCanvas.Children)
            { 
                brush = (SolidColorBrush) s.Fill;
                // Copy color object
                color = brush.Color;
                
                /* As long as the shape is not fully transparent */
                if (color.A > 1)
                {
                    /* Lower the alpha level of each shape and update
                     * the shape's color to reflect the lower alpha level */
                    color.A--;
                    ((SolidColorBrush)s.Fill).Color = color;
                }
                else
                {
                    /* This one is fully transparent. Mark for removal */
                    shapesToRemove.Add(s);
                }
            }

            /* Remove all shapes that are marked for removal from the Canvas
             * so that they can be disposed of */
            foreach (Shape s in shapesToRemove)
            {
                WindowCanvas.Children.Remove(s);
            }
        }
    }
}
