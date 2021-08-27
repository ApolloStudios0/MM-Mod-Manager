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

        string NoFailDownloadURL = "https://www.dropbox.com/s/u0hd8tzy9bd90jx/App.dll?dl=0"; // No Fail URL
        string UnlimitedUpgradesDownloadURL = "https://www.dropbox.com/s/msvsrp553en6i01/App.dll?dl=0"; // Unlimited Upgrades URL
        string InstantDeathDownloadURL = "https://www.dropbox.com/s/ymqbnwz00ncjos1/App.dll?dl=0"; // Instant Death URL
        string NoFailCollectionDownloadURL = "https://www.dropbox.com/s/9sa2gcmo4q2xkvt/App.dll?dl=0"; // No Fail Collection URL
        string InstantDeathCollectionDownloadURL = "https://www.dropbox.com/s/l0gfmnaxz0qg0ef/App.dll?dl=0"; // Instant Death Collection URL

        string DefaultSteamDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\Mini Motorways\Mini Motorways_Data\Managed\";

        public Main_Mod_Manager()
        {
            InitializeComponent();

            URLdict.Add("NoFailButton", NoFailDownloadURL);
            URLdict.Add("UnlimitedUpgradesButton", UnlimitedUpgradesDownloadURL);
            URLdict.Add("InstantDeathButton", InstantDeathDownloadURL);
            URLdict.Add("NoFailCollectionButton", NoFailCollectionDownloadURL);
            URLdict.Add("InstantDeathCollectionButton", InstantDeathCollectionDownloadURL);
        }

        // Menu Buttons & Version Checks

        private void Button_Click(object sender, RoutedEventArgs e) // Check Mod Manager Version
        {
            string SoftVerNum = "v1.0.1"; // Software Version [ Hardcoded For Now ]
            MessageBox.Show($"You're all up to date. {SoftVerNum}");
        }

        private void CheckGameVersionButton_Click(object sender, RoutedEventArgs e) // Check Game Version
        {
            MessageBox.Show("Game version is located in settings ingame.", "Not Implemented Yet.");
        }

        private void RemoveAllModsButton_Click(object sender, RoutedEventArgs e) // Remove All Modifications (Restored & Replaced Manually)
        {
            MessageBox.Show("Verify integrity of game files in steam to clear all modifications.", "Not Implemented Yet");
        }

        private void ContactMeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contact Me On Discord @ Nebula#0123");
        }

        private void DeveloperPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsDeveloper)
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
            string mod = button.Name.ToString();

            using (System.Net.WebClient wc = new WebClient())
            {
                if (File.Exists(DefaultSteamDirectory + "App.dll"))
                {
                    MakeSteamBackupFile(); // Re-name App.dll ==> Old_App.dll

                    wc.DownloadFileAsync(
                        new System.Uri(URLdict[mod]), // Download Path
                        DefaultSteamDirectory + "App.dll" // Path To Save File
                    );
                    string modName = mod.Replace("Button", "");
                    MessageBox.Show("Your game has been updated with: " + modName, "Download was successful");
                }
                else
                {
                    wc.DownloadFileAsync(
                        new System.Uri(URLdict[mod]), // Download Path
                        "App.dll" // Path To Save File
                    );
                    MessageBox.Show(
                        "It seems you have a custom directory for the game.\n\n" +
                        "Replace the App.dll in:\n" +
                        "\"Mini Motorways/Mini Motorways_Data/Managed\"\n\n" +
                        "with the new modded App.dll found in:\n" +
                        Environment.CurrentDirectory, 
                        "ERROR: Game files not located");
                }
            }
        }

        public void MakeSteamBackupFile()
        {
            try
            {
                File.Move(DefaultSteamDirectory + "App.dll", DefaultSteamDirectory + "Old_App.dll");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        } // Backup Process [ Re-name App.dll ==> Old_App.dll ]
    }
}
