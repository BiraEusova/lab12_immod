using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8_immod
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private const double lambda = 100;

        private string Team1 = "1";
        private string Team2 = "2";
        private string Team3 = "3";
        private string Team4 = "4";
        private string Team5 = "5";
        private string Team6 = "6";
        private string Team7 = "7";
        private string Team8 = "8";


        public Form1()
        {
            InitializeComponent();
        }

        int Poisson()
        {
            int m = -1;
            double S = 0;
            do
            {
                m += 1;
                double alpha = random.NextDouble();
                S += Math.Log10(alpha);

            } while (S >= -lambda);

            return m;
        }

        string PlayTwoTeams(string teamFirst, string teamSecond)
        {
            int first = Poisson();
            int second = Poisson();

            while (first == second)
            {
                first = Poisson();
                second = Poisson();
            }

            if (first > second)
                return teamFirst;
            else
                return teamSecond;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string winTeam1 = PlayTwoTeams(Team1, Team2);
            labelFirstStep1.Text = winTeam1;
            string winTeam2 = PlayTwoTeams(Team3, Team4);
            labelFirstStep2.Text = winTeam2;
            string winTeam3 = PlayTwoTeams(Team5, Team6);
            labelFirstStep3.Text = winTeam3;
            string winTeam4 = PlayTwoTeams(Team7, Team8);
            labelFirstStep4.Text = winTeam4;
            string winTeamF1 = PlayTwoTeams(winTeam1, winTeam2);
            labelSemifinal1.Text = winTeamF1;
            string winTeamF2 = PlayTwoTeams(winTeam3, winTeam4);
            labelSemifinal2.Text = winTeamF2;
            string Champion = PlayTwoTeams(winTeamF1, winTeamF2);
            labelFinal.Text = Champion;
            labelWinner.Text = Champion;
        }
    }
}
