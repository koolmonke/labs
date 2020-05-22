using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryMatchingGame
{
    public partial class MemoryGame : Form
    {
        readonly Random random = new Random();
        readonly List<Point> Points = new List<Point>();
        PictureBox FlippedImage1;
        PictureBox FlippedImage2;
        int FlippedCount = 0;
        int LevelUp = 30;
        int TimeLevel = 60;
        int Score = 0;
        public MemoryGame()
        {
            InitializeComponent();

        }

        private void MemoryGame_Load(object sender, EventArgs e)
        {
            label1.Text = "3";
            foreach (PictureBox picture in GamePanel.Controls)
            {

                picture.Enabled = false;
                Points.Add(picture.Location);
            }
            foreach (PictureBox picture in GamePanel.Controls)
            {
                int next = random.Next(Points.Count);
                Point p = Points[next];
                picture.Location = p;
                Points.Remove(p);
            }

            ScoreTimer.Start();
            CountdownTimer.Start();
            img1.Image = Properties.Resources.img1;
            dupimg1.Image = Properties.Resources.img1;
            img2.Image = Properties.Resources.img2;
            dupimg2.Image = Properties.Resources.img2;
            img3.Image = Properties.Resources.img3;
            dupimg3.Image = Properties.Resources.img3;
            img4.Image = Properties.Resources.img4;
            dupimg4.Image = Properties.Resources.img4;
            img5.Image = Properties.Resources.img5;
            dupimg5.Image = Properties.Resources.img5;
            img6.Image = Properties.Resources.img6;
            dupimg6.Image = Properties.Resources.img6;
            img7.Image = Properties.Resources.img7;
            dupimg7.Image = Properties.Resources.img7;
            img8.Image = Properties.Resources.img8;
            dupimg8.Image = Properties.Resources.img8;
            img9.Image = Properties.Resources.img9;
            dupimg9.Image = Properties.Resources.img9;
            img10.Image = Properties.Resources.img10;
            dupimg10.Image = Properties.Resources.img10;

        }
        private void ResetButton_Click(object sender, EventArgs e)
        { 
            ResetButton.BackColor = Color.Transparent;
            ResetButton.Text = "Переиграть";
            ScoreCounter.Text = "0";
            timeLeft.Text = "60";
            levelValue.Text = "1";
            MemoryGame_Load(sender, e);
        }

        private void ScoreTimer_Tick(object sender, EventArgs e)
        {
            ScoreTimer.Stop();
            foreach (PictureBox picture in GamePanel.Controls)
            {
                picture.Enabled = true;
                picture.Cursor = Cursors.Hand;
                picture.Image = Properties.Resources.cover;
            }

        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(label1.Text);
            timer -= 1;
            label1.Text = Convert.ToString(timer);
            if (timer == 0)
            {
                CountdownTimer.Stop();
                TimeRemaining.Start();
            }
        }
        private void TimeRemaining_Tick(object sender, EventArgs e)
        {  
            int timer = Convert.ToInt32(timeLeft.Text);
            timer -= 1;
            timeLeft.Text = Convert.ToString(timer);
            if (timer == 0)
            {
                TimeRemaining.Stop();
                MessageBox.Show($"Вы набрали {ScoreCounter.Text} на уровне : {levelValue.Text}");
                ScoreCounter.Text = "0";
                ResetButton.BackColor = Color.Red;
                ResetButton.Text = "Сыграть еще?";
            }
        }

        private void ChangeLevel()
        {
          
            Score += Convert.ToInt32(ScoreCounter.Text);
            MessageBox.Show("Следующий уровень!");
            if (Convert.ToInt32(ScoreCounter.Text) >= LevelUp)
            {
                ScoreCounter.Text = "0";
                TimeLevel -= 5;
                timeLeft.Text = Convert.ToString(TimeLevel);
                levelValue.Text = Convert.ToString(Convert.ToInt32(levelValue.Text) + 1);
                LevelUp += 5;
                if (TimeLevel <= 15)
                {
                    MessageBox.Show("Ты прошел игру!");
                    Application.Exit();
                }
                MemoryGame_Load(this, null);
            }
            else
            {
                MessageBox.Show($"Игра окончена! Ты набрал: {Score}");
                ResetButton.BackColor = Color.Red;
                ResetButton.Text = "Сыграть еще?";
            }
        }
  
        #region Cards
        private void img1_Click(object sender, EventArgs e)
        {
            img1.Image = Properties.Resources.img1;
            CheckImages(img1, dupimg1);
        }

        private void img2_Click(object sender, EventArgs e)
        {
            img2.Image = Properties.Resources.img2;
            CheckImages(img2, dupimg2);
        }

        private void img3_Click(object sender, EventArgs e)
        {
            img3.Image = Properties.Resources.img3;
            CheckImages(img3, dupimg3);
        }

        private void img4_Click(object sender, EventArgs e)
        {
            img4.Image = Properties.Resources.img4;
            CheckImages(img4, dupimg4);
        }

        private void img5_Click(object sender, EventArgs e)
        {
            img5.Image = Properties.Resources.img5;
            CheckImages(img5, dupimg5);
        }

        private void img6_Click(object sender, EventArgs e)
        {
            img6.Image = Properties.Resources.img6;
            CheckImages(img6, dupimg6);
        }

        private void img7_Click(object sender, EventArgs e)
        {
            img7.Image = Properties.Resources.img7;
            CheckImages(img7, dupimg7);
        }

        private void img8_Click(object sender, EventArgs e)
        {
            img8.Image = Properties.Resources.img8;
            CheckImages(img8, dupimg8);
        }

        private void img9_Click(object sender, EventArgs e)
        {
            img9.Image = Properties.Resources.img9;
            CheckImages(img9, dupimg9);
        }

        private void img10_Click(object sender, EventArgs e)
        {
            img10.Image = Properties.Resources.img10;
            CheckImages(img10, dupimg10);
        }


        private void dupimg1_Click(object sender, EventArgs e)
        {
            dupimg1.Image = Properties.Resources.img1;
            CheckImages(dupimg1, img1);
        }


        private void dupimg2_Click(object sender, EventArgs e)
        {
            dupimg2.Image = Properties.Resources.img2;
            CheckImages(dupimg2, img2);
        }

        private void dupimg3_Click(object sender, EventArgs e)
        {
            dupimg3.Image = Properties.Resources.img3;
            CheckImages(dupimg3, img3);
        }

        private void dupimg4_Click(object sender, EventArgs e)
        {
            dupimg4.Image = Properties.Resources.img4;
            CheckImages(dupimg4, img4);
        }

        private void dupimg5_Click(object sender, EventArgs e)
        {
            dupimg5.Image = Properties.Resources.img5;
            CheckImages(dupimg5, img5);
        }

        private void dupimg6_Click(object sender, EventArgs e)
        {
            dupimg6.Image = Properties.Resources.img6;
            CheckImages(dupimg6, img6);
        }

        private void dupimg7_Click(object sender, EventArgs e)
        {
            dupimg7.Image = Properties.Resources.img7;
            CheckImages(dupimg7, img7);
        }

        private void dupimg8_Click(object sender, EventArgs e)
        {
            dupimg8.Image = Properties.Resources.img8;
            CheckImages(dupimg8, img8);
        }

        private void dupimg9_Click(object sender, EventArgs e)
        {
            dupimg9.Image = Properties.Resources.img9;
            CheckImages(dupimg9, img9);
        }

        private void dupimg10_Click(object sender, EventArgs e)
        {
            dupimg10.Image = Properties.Resources.img10;
            CheckImages(dupimg10, img10);
        }
        #endregion

        private void FlipTime_Tick(object sender, EventArgs e)
        {
          
            FlipTime.Stop();
            FlippedImage1.Image = Properties.Resources.cover;
            FlippedImage2.Image = Properties.Resources.cover;
            FlippedImage1 = null;
            FlippedImage2 = null;

        }
        private void CheckImages(PictureBox pic1, PictureBox pic2)
        {
          

            if (FlippedImage1 == null)
            {
                FlippedImage1 = pic1;
            }
            else if (FlippedImage1 != null && FlippedImage2 == null)
            {
                if (FlippedImage1 != pic1)
                    FlippedImage2 = pic1;
            }
            if (FlippedImage1 != null && FlippedImage2 != null)
            {
                if (FlippedImage1.Tag == FlippedImage2.Tag)
                {
                    FlippedImage1 = null;   
                    FlippedImage2 = null;
                    pic2.Enabled = false;
                    pic1.Enabled = false;
                    FlippedCount++;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    FlipTime.Start();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                }

            }

            if (FlippedCount == 10)
            {
                FlippedCount = 0;
                ChangeLevel();
            }
        }
    }
}