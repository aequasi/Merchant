using Merchant.Loaders;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Merchant.GUI
{
    public partial class CMD : Form
    {
        private Merchant Navigator { get; }
        private ProfileLoader ProfileLoader { get; }

        public CMD(Merchant navigator, ProfileLoader profileLoader)
        {
            Navigator = navigator;
            ProfileLoader = profileLoader;
            InitializeComponent();
        }
        private void GUI_Load(object sender, EventArgs e)
        {

        }
        private void LoadProfileButton_Click(object sender, EventArgs e) => ProfileLoader.LoadProfile(LoadProfileOFD);
        private void LoadProfileOFD_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}