using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge
{
    public partial class Form1 : Form
    {
        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.victory);
        SoundPlayer soundPlayer2 = new SoundPlayer(Properties.Resources.blown);
        SoundPlayer soundPlayer3 = new SoundPlayer(Properties.Resources.scored);
        SoundPlayer soundPlayer4 = new SoundPlayer(Properties.Resources.rocketThrust);

        Image OIP = Properties.Resources.OIP;

        Font drawFont = new Font("Arial", 10, FontStyle.Bold);

        Rectangle background = new Rectangle(0, 0, 700, 300);

        Rectangle player1rocket = new Rectangle(0, 50, 50, 20);
        Rectangle player2rocket = new Rectangle(0, 180, 50, 20);
        int playerSpeed = 10;

        new List<Rectangle> ballList = new List<Rectangle>();
        new List<int> ballSpeeds = new List<int>();

        int player1Score = 0;
        int player2Score = 0;
        int time = 500;

        bool aPressed = false;
        bool dPressed = false;
        bool leftPressed = false;
        bool rightPressed = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        Random randGen = new Random();
        int randValue = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void InitializeGame()
        {
            titleScreen.Visible = false;
            subtitleScreen.Visible = false;
            timerOutput.Visible = true;
            player1ScoreOutput.Visible = true;
            player2ScoreOutput.Visible = true;
            gameTimer.Enabled = true;
            time = 500;
            player1Score = 0;
            player2Score = 0;
            ballList.Clear();
            ballSpeeds.Clear();
            player1rocket = new Rectangle(0, 50, 50, 20);
            player2rocket = new Rectangle(0, 180, 50, 20);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
                case Keys.Escape:
                    if (gameTimer.Enabled == false)
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.Space:
                    if (gameTimer.Enabled == false)
                    {
                        InitializeGame();
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            time--;

            for (int i = 0; i < ballList.Count; i++)
            {
                int y = ballList[i].Y + ballSpeeds[i];

                ballList[i] = new Rectangle(ballList[i].X, y, 10, 15);
            }

            if (aPressed == true && player1rocket.X > 0)
            {
                player1rocket.X -= playerSpeed;
                soundPlayer4.Play();
            }
            else if (dPressed == true)
            {
                player1rocket.X += playerSpeed;
                soundPlayer4.Play();
            }
            if (leftPressed == true && player2rocket.X > 0)
            {
                player2rocket.X -= playerSpeed;
                soundPlayer4.Play();
            }
            else if (rightPressed == true)
            {
                player2rocket.X += playerSpeed;
                soundPlayer4.Play();
            }

            randValue = randGen.Next(0, 100);
            if (randValue < 15)
            {
                randValue = randGen.Next(100, 600);
                Rectangle ball = new Rectangle(randValue, -10, 10, 20);
                ballList.Add(ball);
                ballSpeeds.Add(randGen.Next(5, 15));
            }

            for (int i = 0; i < ballList.Count; i++)
            {
                if (ballList[i].Y > this.Height)
                {
                    ballList.RemoveAt(i);
                    ballSpeeds.RemoveAt(i);
                }
            }

            for (int i = 0; i < ballList.Count; i++)
            {
                if (ballList[i].IntersectsWith(player1rocket))
                {
                    soundPlayer2.Play();
                    player1rocket.X = 0;
                }
                else if (ballList[i].IntersectsWith(player2rocket))
                {
                    soundPlayer2.Play();
                    player2rocket.X = 0;
                }
            }

            if (player1rocket.X + player1rocket.Width > this.Width)
            {
                soundPlayer3.Play();
                player1Score++;
                player1rocket.X = 0;
            }
            else if (player2rocket.X + player2rocket.Width > this.Width)
            {
                soundPlayer3.Play();
                player2Score++;
                player2rocket.X = 0;
            }

            if (time == 0)
            {
                gameTimer.Stop();
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameTimer.Enabled == false && time > 0)
            {
                titleScreen.Text = "Space Racer Lite";
                subtitleScreen.Text = "Press Space to begin!";
                timerOutput.Visible = false;
                player1ScoreOutput.Visible = false;
                player2ScoreOutput.Visible = false;
            }
            else if (gameTimer.Enabled == true)
            {
                timerOutput.Text = $"Time Left: {time}";
                player1ScoreOutput.Text = $"Player 1 Score: {player1Score}";
                player2ScoreOutput.Text = $"Player 2 Score: {player2Score}";

                e.Graphics.DrawImage(OIP, background);

                e.Graphics.FillRectangle(grayBrush, 0, 125, this.Width, 5);

                //draw player rockets
                e.Graphics.FillRectangle(whiteBrush, player1rocket);
                e.Graphics.FillRectangle(whiteBrush, player2rocket);

                //draw balls
                for (int i = 0; i < ballList.Count; i++)
                {
                    e.Graphics.FillEllipse(redBrush, ballList[i]);
                }
            }
            else
            {
                timerOutput.Visible = false;
                player1ScoreOutput.Visible = false;
                player2ScoreOutput.Visible = false;

                titleScreen.Visible = true;
                subtitleScreen.Visible = true;

                titleScreen.Text = "GAME OVER";
                if (player1Score > player2Score)
                {
                    subtitleScreen.Text = "Player 1 Wins!";
                    subtitleScreen.Text += $"\nPress Space to Start or Esc to Exit";
                    soundPlayer.Play();
                }
                else if (player2Score > player1Score)
                {

                    subtitleScreen.Text = "Player 2 Wins!";
                    subtitleScreen.Text += $"\nPress Space to Start or Esc to Exit";
                    soundPlayer.Play();
                }
                else if (time == 0 && player2Score == player1Score)
                {
                    subtitleScreen.Text = "It's a tie!";
                    subtitleScreen.Text += $"\nPress Space to Start or Esc to Exit";
                    soundPlayer.Play();
                }
            }
        }
    }
}
