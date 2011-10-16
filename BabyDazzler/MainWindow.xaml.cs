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
using BabyDazzler.Dazzlers;

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
            int framesPerSecond = 30;

            // Construct timer that fires 30 times per second (30 FPS)
            DispatcherTimer t = new DispatcherTimer();

            t.Interval = TimeSpan.FromMilliseconds(1000 / framesPerSecond);

            t.Tick += new EventHandler(refreshFrameEvent);

            return t;
        }

        private void refreshFrameEvent(object sender, EventArgs e)
        {
            DrawFrame();
        }



        public void DrawFrame()
        {
            //VisualDazzleObj visDazzle = new VisualDazzleObj((this.Height * .20), (this.Width * .20));

            VisualDazzleObj visDazzle = new VisualDazzleObj((this.Height * .20));

            Shape visDazzelView = visDazzle.GetView();
            
            Canvas.SetTop(visDazzelView, random.Next(Convert.ToInt32(this.Height)));
            Canvas.SetLeft(visDazzelView, random.Next(Convert.ToInt32(this.Width)));

            WindowCanvas.Children.Add(visDazzelView);
        }
    }
}
