﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// Libs MediaPlayer
using Microsoft.Win32;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
//Custom libs
using MinimalMediaPlayer.Controller;

namespace MinimalMediaPlayer
{
	public partial class MainWindow : Window
	{
		private bool mediaPlayerIsPlaying = false;
		private bool isLoop = true;
		private bool userIsDraggingSlider = false;
		private CtrlMusic ctrlmusic = new CtrlMusic();

		// Use App without Command-line parameters
		public MainWindow()
		{
			InitializeComponent();
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
		}

		// Use App with Command-line parameters
		public MainWindow(string args)
		{
			InitializeComponent();
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
			mePlayer.Source = new Uri(args);
			ctrlmusic.AddSong(mePlayer.Source.LocalPath);
			mePlayer.Play();
			mediaPlayerIsPlaying = true;
			lblSongName.Text = ctrlmusic.getTitle();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
			{
				sliProgress.Minimum = 0;
				sliProgress.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
				sliProgress.Value = mePlayer.Position.TotalSeconds;
			}
		}

		private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.wmv;*.mp4)|*.mp3;*.mpg;*.mpeg;*.wmv;*.mp4|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == true)
			{
				mePlayer.Source = new Uri(openFileDialog.FileName);
				ctrlmusic.AddSong(mePlayer.Source.LocalPath);
				mePlayer.Play();
				mediaPlayerIsPlaying = true;
				lblSongName.Text = ctrlmusic.getTitle();
			}
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

		private void btnVolumeP_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Volume += 0.1;
		}

		private void btnVolumeM_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Volume -= 0.1;
		}

		private void btnVolumeMute_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Volume = 0;
		}

		private void btnLoop_Click(object sender, RoutedEventArgs e)
		{
            if (isLoop)
            {
				btnLoop.Background = Brushes.Gray;
			}
            else
            {
				btnLoop.Background = Brushes.Transparent;
			}
			isLoop = !isLoop;
		}
		private void mediaElement_OnMediaEnded(object sender, RoutedEventArgs e)
		{
			if (isLoop)
			{
				mePlayer.Position = new TimeSpan(0, 0, 1);
				mePlayer.Play();
				mediaPlayerIsPlaying = true;
			}
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
	}
}
