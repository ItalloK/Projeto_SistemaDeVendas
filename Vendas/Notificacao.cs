using System;
using System.Drawing;
using System.Windows.Forms;

namespace Supermercado
{
    public partial class Notificacao : Form
    {
        int toastX, toastY;
        int initialY;

        public Notificacao(string type, string message)
        {
            InitializeComponent();

            lbType.Text = type;
            lbMessage.Text = message;

            switch (type)
            {
                case "SUCESSO":
                    toastBorder.BackColor = Color.FromArgb(0, 150, 6);
                    picIcon.Image = Properties.Resources.sucess;
                    break;
                case "AVISO":
                    toastBorder.BackColor = Color.FromArgb(255, 199, 0);
                    picIcon.Image = Properties.Resources.warning;
                    break;
                case "ERRO":
                    toastBorder.BackColor = Color.FromArgb(255, 0, 0);
                    picIcon.Image = Properties.Resources.error;
                    break;
                case "INFO":
                    toastBorder.BackColor = Color.FromArgb(1, 119, 189);
                    picIcon.Image = Properties.Resources.info;
                    break;
            }
        }

        private void Notificacao_Load(object sender, EventArgs e)
        {
            Position();
            toastTimer.Start();
        }

        private void toastTimer_Tick(object sender, EventArgs e)
        {
            toastY -= 10;
            this.Location = new Point(toastX, toastY);

            if (toastY <= initialY - 100)
            {
                toastTimer.Stop();
                var delay = new Timer();
                delay.Interval = 2000;
                delay.Tick += (s, args) => {
                    delay.Stop();
                    delay.Dispose();
                    toastHide.Interval = 15;
                    toastHide.Start();
                };
                delay.Start();
            }
        }

        private void toastHide_Tick(object sender, EventArgs e)
        {
            toastY += 1; 
            this.Location = new Point(toastX, toastY);

            if (toastY >= Screen.PrimaryScreen.WorkingArea.Height)
            {
                toastHide.Stop();
                this.Close();
            }
        }

        private void Position()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            toastX = screenWidth - this.Width - 5;
            toastY = screenHeight;
            initialY = toastY;

            this.Location = new Point(toastX, toastY);
        }
    }
}
