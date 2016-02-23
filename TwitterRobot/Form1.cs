using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TweetSharp;
using TwitterRobot.Model;

namespace TwitterRobot
{
    public partial class Form1 : Form
    {
        //API KEY VALUES MARKED AS *
        public static TwitterService service = new TwitterService("**", "**", "**-**", "**");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("500 follow silinecek, emin misin?", "Onay", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var follows = service.ListFriendIdsOf(new ListFriendIdsOfOptions() { ScreenName = "sihirdarsozluk" });
                for (int i = follows.Count - 1; i > follows.Count - 501; i--)
                {
                    try
                    {
                        service.UnfollowUser(new UnfollowUserOptions() { UserId = follows[i] });
                    }
                    catch { }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Hayır dedin, bir işlem yapılmadı.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("1000 follow silinecek, emin misin?", "Onay", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var follows = service.ListFriendIdsOf(new ListFriendIdsOfOptions() { ScreenName = "sihirdarsozluk" });
                for (int i = follows.Count - 1; i > follows.Count - 1001; i--)
                {
                    try
                    {
                        service.UnfollowUser(new UnfollowUserOptions() { UserId = follows[i] });
                    }
                    catch { }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Hayır dedin, bir işlem yapılmadı.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("seçilen parametrelerle takibe başlanacak, emin misin?", "Onay", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var alreadyFollowed = ModelController.GetAlreadyFollowedList();
                    TwitterCursorList<long> check = service.ListFollowerIdsOf(new ListFollowerIdsOfOptions() { ScreenName = textBox1.Text });
                    TwitterCursorList<long> followersResult = null;

                    for (int i = 1; i <= Convert.ToInt32(comboBox1.SelectedItem.ToString()); i++)
                    {
                        if (i == 1)
                        {
                            followersResult = check;
                        }
                        else
                        {
                            check = service.ListFollowerIdsOf(new ListFollowerIdsOfOptions() { ScreenName = textBox1.Text, Cursor = check.NextCursor });
                        }
                    }
                    followersResult = check;

                    int from = Convert.ToInt32(textBox2.Text);
                    int to = Convert.ToInt32(textBox3.Text);

                    for (int i = from; i < to; i++)
                    {
                        try
                        {
                            if (!alreadyFollowed.Any(a => a.twitterID == followersResult[i]))
                            { 
                                service.FollowUser(new FollowUserOptions() { UserId = followersResult[i] });
                                TwitterUser user = service.GetUserProfileFor(new GetUserProfileForOptions() { UserId = followersResult[i] });
                                if (user != null)
                                {
                                    ModelController.insertUserToAlreadyFollowed(user.Id, user.ScreenName);
                                }
                                else 
                                {
                                    ModelController.insertUserToAlreadyFollowed(followersResult[i], string.Empty);
                                }
                            }
                        }
                        catch
                        {
                            ModelController.insertUserToAlreadyFollowed(followersResult[i], string.Empty);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Hata");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Hayır dedin, bir işlem yapılmadı.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            TwitterUser operationUser = service.GetUserProfileFor(new GetUserProfileForOptions() { ScreenName = textBox1.Text });
            button4.Text = operationUser.FollowersCount.ToString();
            button3.Enabled = true;
            int count = (operationUser.FollowersCount / 5000) + 1;
            for (int i = 1; i <= count; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}
