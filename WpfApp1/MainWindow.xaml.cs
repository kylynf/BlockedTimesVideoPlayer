using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;
using System.IO;

namespace WpfTutorialSamples.Audio_and_Video
{
    public partial class AudioVideoPlayerCompleteSample : Window
    {
        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;

        public AudioVideoPlayerCompleteSample()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(.01);
            timer.Tick += timer_Tick;
            timer.Start();

            //blockedTimesCB_Populate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = mePlayer.Position.TotalSeconds;

                skipBlockedTimes();

                //sliProgress.Value = String.Format("{0} / {1}", mePlayer.Position.ToString(@"hh\:mm\:ss"), mePlayer.Position.TotalSeconds.ToString(@"hh\:mm\:ss"));
            }
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp4;*.mpg;*.mpeg)|*.mp4;*.mpg;*.mpeg| All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mePlayer.Source = new Uri(openFileDialog.FileName);
                mePlayer.Play();
                mediaPlayerIsPlaying = true;
                string filterFileName = openFileDialog.FileName + ".blk";
                blockedTimesCB_Populate(filterFileName);
            }
            //string file = getFilteredFile(openFileDialog.FileName);
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (mePlayer != null) && (mePlayer.Source != null);
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mePlayer.Play();
            mediaPlayerIsPlaying = true;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mePlayer.Pause();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mePlayer.Stop();
            mediaPlayerIsPlaying = false;
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            mePlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            mePlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }

        //private string getFilteredFile(string VideoFileName)
        //{
        //    string mOpenFile = null;
        //    string filterfile = "Sorry, file is not found";
        //    mePlayer.Source = new Uri(VideoFileName);
        //    if (true)
        //    { //code here to check if it worked             
        //        mOpenFile = VideoFileName;

        //        filterfile = mOpenFile + ".blk";
        //        return filterfile;
        //    }


        //}

        private void blockedTimesCB_Populate(string FilterFileName)
        {
            //string FilterFileName = @"C:\Users\kylyn\OneDrive\Desktop\WpfApp1\horse.blk";
            string startBlockTime;
            string endBlockTime;

            if (blockedTimesCB.Items.Count == 0)
            {

                if (FilterFileName != null)
                {
                    try
                    {
                        //Console.WriteLine(FilterFileName);
                        System.IO.StreamReader file = new System.IO.StreamReader(FilterFileName);
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            string[] tokens = line.Split(' ');
                            if (tokens.Length == 3)
                            {
                                startBlockTime = tokens[0];
                                endBlockTime = tokens[2];
                            }

                            blockedTimesCB.Items.Add(line);

                        }
                    }
                    catch (IOException)
                    {
                    }
                }
            }
            else {
                blockedTimesCB.Items.Clear();

            }
        }

        private double TimeStringToDouble(string time)
        {
            string timestring = time;
            //double doubleValue = (double)Convert.ToInt32(timestring.Replace(":", ""), 16);
            string[] parts = time.Split(':');
            string hours = parts[0];
            string mins = parts[1];
            string secs = parts[2];
            double doubleValue = double.Parse(parts[0]) + double.Parse(parts[1]) + double.Parse(parts[2]);
            //Console.WriteLine(doubleValue);
            return doubleValue;
        }

        private void skipBlockedTimes()
        {

            for (int i = 0; i < blockedTimesCB.Items.Count; i++)
            {
                string[] tokens = blockedTimesCB.Items[i].ToString().Split(' ');
                TimeSpan startTime = TimeSpan.FromSeconds(TimeStringToDouble(tokens[0]));
                TimeSpan endTime = TimeSpan.FromSeconds(TimeStringToDouble(tokens[2]));
                if (mePlayer.Position >= startTime && mePlayer.Position < endTime)
                {
                    mePlayer.Position = endTime;
                    sliProgress.Value = mePlayer.Position.TotalSeconds;
                }

            }


        }
    }
}
