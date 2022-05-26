using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderHopping
{
    public partial class Game : Form
    {
        //##############################################################################################
        //# Instance Variables
        static Bitmap BITMAP = Properties.Resources.Landscape;
        /// <summary>
        /// The Player presented in the picture box.
        /// </summary>
        private Player _player;
        private Rocket _rocket;
        private List<Security> _securityMeasures;
        private List<Benefit> _benefits;
        private static Random _randomNumberGenerator = new Random();
        private int _score;
        private int _rocketCount;
        public Game()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size;
            Reset();
            _pictureBox.BackgroundImage = BITMAP;
        }
        //##############################################################################################
        //# Event Handlers
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            _player.Draw(graphics);
            if (_rocket != null)
            { _rocket.Draw(graphics); }
            foreach (Benefit benefit in _benefits)
            {
                benefit.Draw(graphics);
            }

            foreach (Security security in _securityMeasures)
            {
                security.Draw(graphics);
            }
        }
        /// <summary>
        /// The timing event handler for the game. Since the majority of mechanism relies on animation
        /// timing, it is a full section.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTick(object sender, EventArgs e)
        {
            if (_score == 10)
            {
                Win("Player");
            }
            Rectangle area = _pictureBox.DisplayRectangle;
            /// <summary>
            /// Generates the random numbers for the spawning of security measures and benfits.
            /// </summary>
            // Jumping Logic //
            /// <summary>
            /// Terminates jumping, and begins falling, when the jumping timer has expired.
            /// <summary/>
            if (_player.JumpTimer < 0)
            {
                _player.Jumping = false;
                _player.Falling = true;
            }
            /// <summary>
            /// The upward motion of the jumping process, or the "jump," as opposed to the "fall."
            /// <summary/>
            if (_player.Jumping)
            {
                _player.JumpSpeed = -40;
                _player.JumpTimer -= 1;
                _player.Move();
            }
            /// <summary>
            /// The downward motion of the jumping process. N.B. that the mechanism for the directional change
            /// (from up to down), is actually contained within the _player.Move() method.
            /// <summary/>
            if (_player.Falling)
            {
                _player.FallTimer -= 1;
                _player.Move();
            }
            /// <summary>
            /// When the falling process has ended, falling can be set to false, and both the jumping
            /// and falling timers reset.
            /// <summary/>
            if (_player.FallTimer < 0)
            {
                _player.Falling = false;
                _player.JumpTimer = 8;
                _player.FallTimer = 8;
            }
            // Jupming Logic's end //
            if (_rocket != null)
            { _rocket.Move(); }
            /// <summary>
            /// Creates a border security fella.
            /// </summary>
            if (_randomNumberGenerator.Next(1000) < 40)
            {
                _securityMeasures.Add(Security.CreateSecurity(area));
            }
            for (int index = _securityMeasures.Count - 1; index >= 0; index--)
            {
                Security security = _securityMeasures[index];
                security.Move();
                /// <summary>
                /// Checks whether the Security instance is still on the picture box.
                /// </summary>
                if (security.CentreX <= 0)
                {
                    /// <summary>
                    /// Removes the Security instance if it has left the picture box.
                    /// </summary>
                    _securityMeasures.RemoveAt(index);
                }
                /// <summary>
                /// Security separation.
                /// Here, space between security measures is created by removing any created or already in play
                /// that are within a certain distance of one another. See the IsNear() method in Security.
                /// </summary>
                int index2 = index - 1;
                if (index2 >= 0)
                {
                    Security other = _securityMeasures[index2];
                    if (security.IsNear(other))
                    {
                        _securityMeasures.RemoveAt(index);
                    }
                }
                if (security.CollidedWith(_player))
                {
                    Win("Border Security");
                }
                if (_rocket != null && _rocket.CollidedWith(security))
                {
                    _securityMeasures.RemoveAt(index);
                    _rocketCount = 1;
                    _score += 1;
                    // If you prefer the sombrero rocket to disappear when it hits a target, be my guest and
                    // add the code below back in. I personally find it glorious to see the Sombrero floating
                    // away though. So there you have it.
                    //_rocket = null;
                }
            }
            if (_randomNumberGenerator.Next(1000) > 975)
            {
                _benefits.Add(Benefit.CreateBenefit(area));
            }
            for (int index = _benefits.Count - 1; index >= 0; index--)
            {
                Benefit benefit = _benefits[index];
                if (benefit.CentreX <= 0)
                {
                    _benefits.RemoveAt(index);
                }
                else
                {
                    benefit.Move();
                    if (benefit.CollidedWith(_player))
                    {
                        _score += 1;
                        _benefits.RemoveAt(index);
                    }
                    else
                    {
                    }
                }
            }
            scoreLabel.Text = "Score: " + _score;

            _pictureBox.Refresh();
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            /// <summary>
            /// Checking whether the space bar was pressed, and a jump is not currently in progress.
            /// </summary>
            if (e.KeyCode == Keys.Space && _player.Jumping == false)
            {
                Rectangle area = _pictureBox.DisplayRectangle;
                _player.Jumping = true;
                _pictureBox.Refresh();
            }
            if (e.KeyCode == Keys.R)
            {
                Reset();
            }
        }
        private void _pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_rocketCount == 0)
            {
                _rocket = Rocket.CreateRocket(_player);
                /// <summary>
                /// This can be used to ensure that only one rocket is used during the course of the game.
                /// </summary>
                _rocketCount = 1;
                if (_rocket.CentreX > Width)
                {
                    _rocket = null;
                }
                else
                {
                    _rocket.Move();
                }
                _pictureBox.Refresh();
            }
        }

        //##############################################################################################
        //# Auxillary Methods
        private void Reset()
        {
            Tutorial(); //## Just added - needs to be tested
            Rectangle area = _pictureBox.DisplayRectangle;
            _player = Player.CreatePlayer(area);
            _securityMeasures = new List<Security>();
            _benefits = new List<Benefit>();
            _randomNumberGenerator = new Random();
            _score = 0;
            _rocketCount = 0;
            timer.Enabled = true;
            _pictureBox.Refresh();
        }
        //# Private Methods
        private void Win(string winner)
        {
            timer.Enabled = false;
            MessageBox.Show(winner + " wins!!!" + "\n" + "Press R to reset");
        }

        private void Tutorial() //## Just added - needs to be tested
        {
            MessageBox.Show("Welcome to Border Security\n" + "To win, collect 10 benefit payments without being grabbed by border security/n" +
            "You have one sombrero to defend yourself with. Use it by clicking the mouse./n" +
            "Jump = spacebar/nThrow sombrero = left click");
        }


    }
}
