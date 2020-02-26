using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public class Music
        {
            public string[] name;
            public string[] path;
            public string[] artist;
            public string[] style;
            public string[] year;
        }

        Music song = new Music();
        string[] fav;
        string a = "", s = "", y = "";
        int[] played;
        int count;
        public class counters
        {
           public int c1 = 0;
           public int c2 = 0;
           public int c3 = 0;
           public int c4 = 0;
           public int c5 = 0;
           
        }

        counters c = new counters();
        

        public Form1()
        {
            InitializeComponent();
        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              int count= listBox1.Items.Count;
                if (panel1.Visible == false)
                {
                    axWindowsMediaPlayer1.URL = song.path[listBox1.SelectedIndex];
                }
                else
                {
                    textBox1.Text = song.name[listBox1.SelectedIndex];
                }
                label4.Text = song.year[listBox1.SelectedIndex];
                label5.Text = song.style[listBox1.SelectedIndex];
                label6.Text = song.artist[listBox1.SelectedIndex];
                played[listBox1.SelectedIndex]++;
            }
            catch (IndexOutOfRangeException r) { }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            song.path = new string[100];
            song.artist = new string[100];
            song.style = new string[100];
            song.year = new string[100];
            song.name = new string[100];

            if ((new FileInfo("pathlist.txt").Length > 0)&&(new FileInfo("songlist.txt").Length > 0)) {

                StreamReader s = new StreamReader("songlist.txt");
                {
                   
                    string line;
                    while ((line = s.ReadLine()) != "")
                    {
                        listBox1.Items.Add(line);
                        song.name[c.c1] = line;
                        c.c1++;
                    }
                }s.Close();
                    

                StreamReader p = new StreamReader("pathlist.txt");
                {
                    string line;
                    
                    while ((line = p.ReadLine()) != "")
                    {
                        song.path[c.c2] = line;
                        c.c2++;
                    }
                    p.Close();
                }

                StreamReader a = new StreamReader("artist.txt");
                {
                    string line;

                    while ((line = a.ReadLine()) != null)
                    {
                        song.artist[c.c3] = line;
                        c.c3++;
                    }
                    a.Close();
                }
                StreamReader st = new StreamReader("style.txt");
                {
                    string line;

                    while ((line = st.ReadLine()) != null)
                    {
                        song.style[c.c4] = line;
                        c.c4++;
                    }
                    st.Close();
                }
                StreamReader y = new StreamReader("year.txt");
                {
                    string line;

                    while ((line = y.ReadLine()) != null)
                    {
                        song.year[c.c5] = line;
                        c.c5++;
                    }
                    y.Close();
                }
            }
            count = listBox1.Items.Count;
            fav = new string[count + 1];
            played = new int[count + 1];
            for (int i = 0; i < count + 1; i++)
            {
                played[i] = 0;
                fav[i] = "";
            }

            

        }

       

       

        private void addSongsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            
            file.Filter = "Mp3 Files|*.mp3";
            if (file.ShowDialog() == DialogResult.OK)
            {
                song.name[c.c1] = file.SafeFileName;
                song.path[c.c2] = file.FileName;              
                listBox1.Items.Add(song.name[c.c1]);
                c.c2++;
                c.c1++;
            }
        }

        private void savePlaylistToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StreamWriter SaveFile = new StreamWriter("songlist.txt");
            for (int i = 0; i < song.name.Length; i++)
            {
                SaveFile.WriteLine(song.name[i]);
            }
            SaveFile.Close();

            StreamWriter SaveFile2 = new StreamWriter("pathlist.txt");
            for (int i = 0; i < song.path.Length; i++)
            {
                SaveFile2.WriteLine(song.path[i]);
            }
            SaveFile2.Close();

            StreamWriter SaveFile3 = new StreamWriter("artist.txt");
            for (int i = 0; i < song.artist.Length; i++)
            {
                SaveFile3.WriteLine(song.artist[i]);
            }
            SaveFile3.Close();

            StreamWriter SaveFile4 = new StreamWriter("style.txt");
            for (int i = 0; i < song.style.Length; i++)
            {
                SaveFile4.WriteLine(song.style[i]);
            }
            SaveFile4.Close();

            StreamWriter SaveFile5 = new StreamWriter("year.txt");
            for (int i = 0; i < song.year.Length; i++)
            {
                SaveFile5.WriteLine(song.year[i]);
            }
            SaveFile5.Close();

            MessageBox.Show("playlist saved");
        }

        private void deleteSongToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void favoritesToolStripMenuItem_Click(object sender, EventArgs e)
       {
            for (int p = 0; p < count+1; p++)
            { fav[p] = song.name[p]; }
            int temp;
            string temp2;
            int i, j;
            for (i = 0; i < count ; i++)
            {
                for (j = 0; j < count - i ; j++) {
                    if (played[j] < played[j + 1])
                    {
                        temp = played[j];
                        played[j] = played[j + 1];
                        played[j + 1] = temp;
                        temp2 = fav[j];
                        fav[j] = fav[j + 1];
                        fav[j + 1] = temp2;
                    }
                }
            }          
            string toDisplay = string.Join(Environment.NewLine, fav);
            MessageBox.Show(toDisplay);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int r = rand.Next(0, count); 
            
            try
            {
                int count = listBox1.Items.Count;
                if (panel1.Visible == false)
                {
                    axWindowsMediaPlayer1.URL = song.path[r];
                }
                else
                {
                    textBox1.Text = song.name[r];
                }
                label4.Text = song.year[r];
                label5.Text = song.style[r];
                label6.Text = song.artist[r];
                
            }
            catch (IndexOutOfRangeException re) { }
        }

        private void deleteSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            panel1.Visible = true;
            try
            { 
             if( (panel1.Visible = true)&&(song.name[listBox1.SelectedIndex]!=null))
                textBox1.Text = song.name[listBox1.SelectedIndex];
            }
            catch (IndexOutOfRangeException r) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

            string temp1, temp2, temp3, temp4, temp5;

            bool flag = false;
            for(int i=0;i<count;i++ )
            {
                if (textBox1.Text == song.name[i])
                {
                    flag = true;
                  for(int j=i+1; j < count; j++)
                    {
                        temp1 = song.name[j];
                        song.name[j] = song.name[j - 1];
                        song.name[j - 1] = temp1;

                        temp2 = song.path[j];
                        song.path[j] = song.path[j - 1];
                        song.path[j - 1] = temp2;

                        temp3 = song.artist[j];
                        song.artist[j] = song.artist[j - 1];
                        song.artist[j - 1] = temp3;

                        temp4 = song.style[j];
                        song.style[j] = song.style[j - 1];
                        song.style[j - 1] = temp4;

                        temp5 = song.year[j];
                        song.year[j] = song.year[j - 1];
                        song.year[j - 1] = temp5;
                    }
                }
            }
            if (flag==true)
            {
                listBox1.Items.Remove(song.name[count-1]);

                song.name[count-1] = "";
                song.path[count-1] = "";
                song.artist[count-1] = "";
                song.style[count-1] = "";
                song.year[count-1] = "";
                panel1.Visible = false;
            }
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;

        }

        private void editSongInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                                                    
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button4.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                song.artist[listBox1.SelectedIndex] = textBox2.Text;
                song.style[listBox1.SelectedIndex] = textBox3.Text;
                song.year[listBox1.SelectedIndex] = textBox4.Text;
            }
            catch (IndexOutOfRangeException r) { }
            label4.Text = song.year[listBox1.SelectedIndex];
            label5.Text = song.style[listBox1.SelectedIndex];
            label6.Text = song.artist[listBox1.SelectedIndex];

            textBox2.Text=song.artist[listBox1.SelectedIndex];
            textBox3.Text = song.style[listBox1.SelectedIndex];
            textBox4.Text = song.year[listBox1.SelectedIndex];

            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button4.Visible = false;

           

           
        }
    }
}
