using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SpaceRace
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(199, 315, 21, 35);
        Rectangle player2 = new Rectangle(397, 315, 21, 35);

        Rectangle timerRectangle = new Rectangle(300, 75, 10, 300);

        int heroSpeed = 5;
        int timer = 0;

        List<Rectangle> rightObstacles = new List<Rectangle>();
        List<Rectangle> leftObstacles = new List<Rectangle>();
        
        List<int> rightSpeeds = new List<int>();
        List<int> leftSpeeds = new List<int>();

        string gameState = "waiting";

        int obstacleSizeX = 40;
        int obstacleSizeY = 10;

        int player1Score = 0;
        int player2Score = 0;

        bool upDown = false;
        bool downDown = false;
        bool rightDown = false;
        bool leftDown = false;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();

        SoundPlayer thruster = new SoundPlayer(Properties.Resources.thruster);
        SoundPlayer point = new SoundPlayer(Properties.Resources.point);
        SoundPlayer blip = new SoundPlayer(Properties.Resources.blip);



        public Form1()
        {
            InitializeComponent();
            Graphics g = this.CreateGraphics();
        }

        public void GameInitialize()
        {
            player1.Location = new Point(199, 315);
            player2.Location = new Point(397, 315);

            //player1Rocket.Location = new Point(199, 315);
            //player2Rocket.Location = new Point(397, 315);

            player1Score = 0;
            player2Score = 0;

            timerRectangle.Y = 75;
            timer = 0;

            titleLabel.Text = "";
            subtitleLabel.Text = "";
            player1scoreLabel.Text = "0";
            player2scoreLabel.Text = "0";
    
            gameTimer.Enabled = true;
            gameState = "running";

            rightObstacles.Clear();
            leftObstacles.Clear();
            rightSpeeds.Clear();
            leftSpeeds.Clear();

           // player1Bar.Value = 100;
            //player2Bar.Value = 100;

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;

                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "Over" || gameState == "Win" || gameState == "Player1 Win" || gameState == "Player2 Win" || gameState == "Time Up")
                    {
                        GameInitialize();
                    }

                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "Over" || gameState == "Win" || gameState == "Player1 Win" || gameState == "Player2 Win" || gameState == "Time Up")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;

                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;


            //move the obstacles
            //check if each button has been pressed and move the obstacles if boost is applied
                if (rightDown == true)
                {
                    //checks the right obstacles list X value if it is over the middle of the screen
                    //if it is slow that obstacle's speed
                    for (int i = 0; i < rightObstacles.Count; i++)
                    {
                        if (rightObstacles[i].X > 300 && player2Bar.Value > 2)
                        {
                            rightSpeeds[i] = 1;

                        }
                    }

                    //checks the progress bar value to check if it is empty
                    //if it isn't empty continue to drain
                    if (player2Bar.Value > 1)
                    {
                        player2Bar.Value -= 2;
                    }

                }
                //if the button is not pressed and the bar is not full fill the bar back up
                else if (rightDown == false && player2Bar.Value < 100)
                {
                    player2Bar.Value++;
                }
                //if neither of the directional boost buttons are pressed and the bar is not empty reset speeds of all right obstacles
                else if (rightDown == false && dDown == false || player2Bar.Value < 2)
                {
                    for (int i = 0; i < rightObstacles.Count; i++)
                    {
                        rightSpeeds[i] = 6;
                    }
                }

            //repeat of last section with different button and different obstacle side
            if (leftDown == true)
            {
                for (int i = 0; i < leftObstacles.Count; i++)
                {
                    if (leftObstacles[i].X > 300 && player2Bar.Value > 2)
                    {
                        leftSpeeds[i] = 1;

                    }
                }

                if (player2Bar.Value > 1)
                {
                    player2Bar.Value -= 2;
                }
            }
            else if (leftDown == false && player2Bar.Value < 100)
            {
                player2Bar.Value++;
            }
            else if (leftDown == false && aDown == false || player2Bar.Value < 2)
            {
                for (int i = 0; i < leftObstacles.Count; i++)
                {
                    leftSpeeds[i] = 6;
                }
            }

            //repeat of last section with different button
            if (aDown == true)
            {
                for (int i = 0; i < leftObstacles.Count; i++)
                {
                    if (leftObstacles[i].X < 300 && player1Bar.Value > 2)
                    {
                        leftSpeeds[i] = 1;

                    }

                }

                if (player1Bar.Value > 1)
                {
                    player1Bar.Value -= 2;
                }

            }
            else if (aDown == false && player1Bar.Value < 100)
            {
                player1Bar.Value++;
            }
            else if (aDown == false && leftDown == false || player1Bar.Value < 2)
            {
                for (int i = 0; i < leftObstacles.Count; i++)
                {
                    leftSpeeds[i] = 6;
                }
            }

            //repeat of last section with different button and direction
            if (dDown == true)
            {
                for (int i = 0; i < rightObstacles.Count; i++)
                {
                    if (rightObstacles[i].X < 300 && player1Bar.Value > 2)
                    {
                        rightSpeeds[i] = 1;

                    }
                }

                if (player1Bar.Value > 1)
                {
                    player1Bar.Value -= 2;
                }
            }
            else if (dDown == false && player1Bar.Value < 100)
            {
                player1Bar.Value++;
            }
            else if (dDown == false && rightDown == false || player1Bar.Value < 2)
            {
                for (int i = 0; i < rightObstacles.Count; i++)
                {
                    rightSpeeds[i] = 6;
                }
            }
        
           
                //every 20 ticks add a new obstacle with a new speed to the list 
                //randomize a y value so that they don't spawn at the exact same level
                if (timer % 20 == 0)

                {

                    int y = randGen.Next(0, 275);
                    int y2 = randGen.Next(0, 275);
                    leftObstacles.Add(new Rectangle(750, y, 20, 5));
                    rightObstacles.Add(new Rectangle(-100, y2, 20, 5));
                    leftSpeeds.Add(randGen.Next(1, 6));
                    rightSpeeds.Add(randGen.Next(1, 6));
                }

                //every 10 ticks move the label that acts as a timer down 
                if (timer % 10 == 0)//&& timerRectangle.Y < 600 )
                {
                    //timerRectangle.Y = timerRectangle.Y - 1;
                    timerRectangle.Location = new Point(timerRectangle.X, timerRectangle.Y + 3);
                }
                //if the time rectangle reaches the bottom of the screen end the game and change the gameState variable to "Time Up"
                if (timerRectangle.Y > this.Height - 40)
                {
                    gameTimer.Enabled = false;
                    gameState = "Time Up";
                }


                //wait for 100 timer ticks so that the players can't move while the obstacles on not yet on the screen
                if (timer < 100)
                {

                }

                //after 100 ticks enable the player to move the player
                //check each button press and move player either forward or backward
                else
                {
                    if (upDown == true && player2.Y > -5)
                    {
                        player2.Y -= heroSpeed;
                    }

                    if (downDown == true && player2.Y < this.Height - player2.Height - 50)
                    {
                        player2.Y += heroSpeed;
                    }

                    if (wDown == true && player1.Y > -5)
                    {
                        player1.Y -= heroSpeed;
                    }

                    if (sDown == true && player1.Y < this.Height - player1.Height - 50)
                    {
                        player1.Y += heroSpeed;
                    }

                }

                // move all obstacles moving left across the screen
                for (int i = 0; i < leftObstacles.Count(); i++)
                {
                    //find the new postion of x based on speed
                    int x = leftObstacles[i].X - leftSpeeds[i];

                    //replace the rectangle in the list with updated one using new x
                    leftObstacles[i] = new Rectangle(x, leftObstacles[i].Y, obstacleSizeX, obstacleSizeY);
                }

                // move all obstacles moving right across the screen
                for (int i = 0; i < rightObstacles.Count(); i++)
                {
                    //find the new postion of x based on speed
                    int n = rightObstacles[i].X + rightSpeeds[i];

                    //replace the rectangle in the list with updated one using new x
                    rightObstacles[i] = new Rectangle(n, rightObstacles[i].Y, obstacleSizeX, obstacleSizeY);
                }


                //check if obstacle is beyond play area and remove it if it is
                for (int i = 0; i < leftObstacles.Count(); i++)
                {
                    if (leftObstacles[i].X < 0)
                    {
                        leftObstacles.RemoveAt(i);
                        leftSpeeds.RemoveAt(i);

                    }
                }

                for (int i = 0; i < rightObstacles.Count(); i++)
                {
                    if (rightObstacles[i].X > 600)
                    {
                        rightObstacles.RemoveAt(i);
                        rightSpeeds.RemoveAt(i);
                    }
                }

                //check collision of player and obstacle
                //if there is a collision stop the timer to end the game
                //also playing sound every time there is a collision
                for (int i = 0; i < leftObstacles.Count(); i++)
                {
                    if (player1.IntersectsWith(leftObstacles[i]))
                    {
                        blip.Play();

                        player1.Location = new Point(200, 325);
                    }

                }

                for (int i = 0; i < leftObstacles.Count(); i++)
                {
                    if (player2.IntersectsWith(leftObstacles[i]))
                    {
                        blip.Play();

                        player2.Location = new Point(400, 325);
                    }
                }

                for (int p = 0; p < rightObstacles.Count(); p++)
                {
                    if (player1.IntersectsWith(rightObstacles[p]))
                    {
                        blip.Play();

                        player1.Location = new Point(200, 325);
                        //player1Rocket.Location = new Point(200, 325);

                    }
                }

                for (int n = 0; n < rightObstacles.Count(); n++)
                {
                    if (player2.IntersectsWith(rightObstacles[n]))
                    {
                        blip.Play();

                        player2.Location = new Point(400, 325);

                    }
                }


                //Check if either player has passed the top bounds of the screen
                //if so reset them back to the start and add 1 point to their score
                //play point sound
                if (player1.Y < 0)
                {
                    point.Play();

                    player1.Location = new Point(200, 300);
                    player1Score++;
                    player1scoreLabel.Text = $"{player1Score}";
                }

                if (player2.Y < 0)
                {
                    point.Play();    

                    player2.Location = new Point(400, 300);

                    player2Score++;
                    player2scoreLabel.Text = $"{player2Score}";

                }

                //check player score, if either player's score eqauls 3 end game and change gameState variable
                if (player1Score == 3)
                {
                    gameTimer.Enabled = false;
                    gameState = "Player1 Win";
                }

                if (player2Score == 3)
                {
                    gameTimer.Enabled = false;
                    gameState = "Player2 Win";
                }

            Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //check the state of the gameState variable and do different title screen based on each
            if (gameState == "waiting")
            {
                titleLabel.Text = "Space Race";
                subtitleLabel.Text = "Press Space to Start or Escape to Exit";

            }
            else if (gameState == "running")
            {
                titleLabel.Visible = false;
                subtitleLabel.Visible = false;

                //draw the player rocket images where the player rectangles are
                e.Graphics.DrawImage(Properties.Resources.rocket, player1);
                e.Graphics.DrawImage(Properties.Resources.rocket, player2);

                //draw timer rectangle
                e.Graphics.FillRectangle(whiteBrush, timerRectangle);

                //draw all left obstacles
                for (int i = 0; i < leftObstacles.Count(); i++)
                {
                    e.Graphics.FillEllipse(goldBrush, leftObstacles[i]);
                }

                //draw all right obstacles
                for (int n = 0; n < rightObstacles.Count(); n++)
                {
                    e.Graphics.FillEllipse(goldBrush, rightObstacles[n]);
                }

            }
            //different title screens for each player
            else if (gameState == "Player1 Win")
            {
                titleLabel.Visible = true;
                subtitleLabel.Visible = true;

                titleLabel.Text = "Player 1 Wins!!! ";
                subtitleLabel.Text = "Press Space to Start or Escape to Exit";
            }
            else if (gameState == "Player2 Win")
            {
                titleLabel.Visible = true;
                subtitleLabel.Visible = true;

                titleLabel.Text = "Player 2 Wins!!!";
                subtitleLabel.Text = "Press Space to Play again or Escape to Exit";
            }
            //if time runs out check if one player's score is greather than the other, if yes then make that player win, 
            //if both players are tied display "Tie"
            else if(gameState == "Time Up")
            {
                titleLabel.Visible = true;
                subtitleLabel.Visible = true;

                if (player1Score == player2Score)
                {
                    subtitleLabel.Text = "Press Space to Start or Escape to Exit";
                    titleLabel.Text = "Tie";
                }
                else if (player1Score > player2Score)
                {
                    subtitleLabel.Text = "Press Space to Start or Escape to Exit";
                    titleLabel.Text = "Player 1 Wins!!!";
                }
                else
                {
                    subtitleLabel.Text = "Press Space to Start or Escape to Exit";
                    titleLabel.Text = "Player 2 Wins!!!";
                }
            }
        }
    }
}
