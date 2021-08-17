using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Net;

namespace MiniMotorways_Mod_Manager
{

    public partial class Main_Mod_Manager : Window
    {
        // Variables & Configurations

        bool IsDeveloper = true; // Enables / Disables DevTools ( Log File )

        Dictionary<string, string> URLdict = new Dictionary<string, string>();

        string NoFailDownloadURL = ""; // No Fail URL
        string UnlimitedUpgradesDownloadURL = ""; // Unlimited Upgrades URL
        string InstantDeathDownloadURL = ""; // Instant Death URL
        string NoFailCollectionDownloadURL = ""; // No Fail Collection URL
        string InstantDeathCollectionDownloadURL = ""; // Instant Death Collection URL

        string DefaultSteamDirectory = @"C:\SteamLibrary\steamapps\common\Mini Motorways\Mini Motorways_Data\Managed\";

        public Main_Mod_Manager()
        {
            InitializeComponent();

            URLdict.Add("NoFail", NoFailDownloadURL);
            URLdict.Add("UnlimitedUpgrades", UnlimitedUpgradesDownloadURL);
            URLdict.Add("InstantDeath", InstantDeathDownloadURL);
            URLdict.Add("NoFailCollection", NoFailCollectionDownloadURL);
            URLdict.Add("InstantDeathCollection", InstantDeathCollectionDownloadURL);
        }

        // Menu Buttons & Version Checks

        private void Button_Click(object sender, RoutedEventArgs e) // Check Mod Manager Version
        {
            string SoftVerNum = "v1.0.1"; // Software Version [ Hardcoded For Now ]
            MessageBox.Show($"You're all up to date. {SoftVerNum}");
        }

        private void CheckGameVersionButton_Click(object sender, RoutedEventArgs e) // Check Game Version
        {
            MessageBox.Show("Not Implemented Yet.");
        }

        private void RemoveAllModsButton_Click(object sender, RoutedEventArgs e) // Remove All Modifications (Restored & Replaced Manually)
        {
            MessageBox.Show("Not Implemented Yet.");
        }

        private void ContactMeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contact Me On Discord @ Nebula#0123");
        }

        private void DeveloperPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if(IsDeveloper)
            {
                var DeveloperTools = new DevWindow();
                DeveloperTools.Show();
            }
            else
            {
                MessageBox.Show("Hm.. You're not a developer!");
            }
        }


        // Modifications & Backups

        public void DownloadMod_Click(object sender, RoutedEventArgs e)
        {
            
            var button = sender as Button;
            string mod = button.Attributes["Mod"].ToString();

            using (System.Net.WebClient wc = new WebClient())
            {
                if (File.Exists(SteamDirectory))
                {
                    MakeSteamBackupFile(); // Re-name App.dll ==> Old_App.dll

                    wc.DownloadFileAsync(
                        new System.Uri(URLdict[mod]), // Download Path
                        DefaultSteamDirectory + "App.dll" // Path To Save File
                    );
                    MessageBox.Show("Your game has been updated with: {0}.", mod);
                }
                else
                {
                    wc.DownloadFileAsync(
                        new System.Uri(URLdict[mod]), // Download Path
                        "App.dll" // Path To Save File
                    );
                    MessageBox.Show("Woops. It seems you have a custom directory for the game set. Replace the App.dll in \"Mini Motorways/Mini Motorways_Data/Managed\".");
                }
            }
        }


        public void MakeSteamBackupFile()
        {
            File.Move(DefaultSteamDirectory + "App.dll", DefaultSteamDirectory + "Old_App.dll");
        } // Backup Process [ Re-name App.dll ==> Old_App.dll ]
    }
}
