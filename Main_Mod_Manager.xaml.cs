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

        string NoFailDownloadURL = ""; // No Fail Mod URL
        string UnlimitedUpgradesDownloadURL = ""; // Unlimited Upgrades URL
        string InstantDeathDownloadURL = ""; // Instant Death URL
        string NoFailCollectionDownloadURL = ""; // No Fail Collection URL
        string UltimateCollectionDownloadURL = ""; // Ultimate Collection URL

        public Main_Mod_Manager()
        {
            InitializeComponent();
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

        public void NoFailDownloadButton_Click(object sender, RoutedEventArgs e)
        {
            string SteamDirectory = @"D:\SteamLibrary\steamapps\common\Mini Motorways\Mini Motorways_Data\Managed\App.dll";

            if (File.Exists(SteamDirectory))
            {
                MakeSteamBackupFile(); // Re-name App.dll ==> Old_App.dll

                using (System.Net.WebClient wc = new WebClient())
                {
                    wc.DownloadFileAsync(
                        new System.Uri(NoFailDownloadURL), // Download Path
                        "D:\\SteamLibrary\\steamapps\\common\\Mini Motorways\\Mini Motorways_Data\\Managed\\App.dll" // Path To Save File
                    );
                }
                MessageBox.Show("Your game has been updated with: No Fail Modification.");
            }
            else
            {
                MessageBox.Show("Woops. It seems you have a custom directory for the game set. As this is only the BETA version of the Mod Manager you'll have to wait until the next update to use this tool.");
            }
        } // No Fail Mod

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string SteamDirectory = @"D:\SteamLibrary\steamapps\common\Mini Motorways\Mini Motorways_Data\Managed\App.dll";

            if (File.Exists(SteamDirectory))
            {
                MakeSteamBackupFile(); // Re-name App.dll ==> Old_App.dll

                using (System.Net.WebClient wc = new WebClient())
                {
                    wc.DownloadFileAsync(
                        new System.Uri(UnlimitedUpgradesDownloadURL), // Download Path
                        "D:\\SteamLibrary\\steamapps\\common\\Mini Motorways\\Mini Motorways_Data\\Managed\\App.dll" // Path To Save File
                    );
                }
                MessageBox.Show("Your game has been updated with: Unlimited Upgrades Mod");
            }
            else
            {
                MessageBox.Show("Woops. It seems you have a custom directory for the game set. As this is only the BETA version of the Mod Manager you'll have to wait until the next update to use this tool.");
            } // Unlimited Upgrades Mod
        } // Unlimited Upgrades Mod

        private void InstantDeathButton_Click(object sender, RoutedEventArgs e)
        {
            string SteamDirectory = @"D:\SteamLibrary\steamapps\common\Mini Motorways\Mini Motorways_Data\Managed\App.dll";

            if (File.Exists(SteamDirectory))
            {
                MakeSteamBackupFile(); // Re-name App.dll ==> Old_App.dll

                using (System.Net.WebClient wc = new WebClient())
                {
                    wc.DownloadFileAsync(
                        new System.Uri(InstantDeathDownloadURL), // Download Path
                        "D:\\SteamLibrary\\steamapps\\common\\Mini Motorways\\Mini Motorways_Data\\Managed\\App.dll" // Path To Save File
                    );
                }
                MessageBox.Show("Your game has been updated with: Unlimited Upgrades Mod");
            }
            else
            {
                MessageBox.Show("Woops. It seems you have a custom directory for the game set. As this is only the BETA version of the Mod Manager you'll have to wait until the next update to use this tool.");
            }
        } // Instant Death Mod

        private void NoFailCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            string SteamDirectory = @"D:\SteamLibrary\steamapps\common\Mini Motorways\Mini Motorways_Data\Managed\App.dll";

            if (File.Exists(SteamDirectory))
            {
                MakeSteamBackupFile(); // Re-name App.dll ==> Old_App.dll

                using (System.Net.WebClient wc = new WebClient())
                {
                    wc.DownloadFileAsync(
                        new System.Uri(NoFailCollectionDownloadURL), // Download Path
                        "D:\\SteamLibrary\\steamapps\\common\\Mini Motorways\\Mini Motorways_Data\\Managed\\App.dll" // Path To Save File
                    );
                }
                MessageBox.Show("Your game has been updated with: The NoFail Collection Pack.");
            }
            else
            {
                MessageBox.Show("Woops. It seems you have a custom directory for the game set. As this is only the BETA version of the Mod Manager you'll have to wait until the next update to use this tool.");
            }
        } // No Fail Collection ( No Fail + Unlimited Upgrades )

        private void UltimateCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            string SteamDirectory = @"D:\SteamLibrary\steamapps\common\Mini Motorways\Mini Motorways_Data\Managed\App.dll";

            if (File.Exists(SteamDirectory))
            {
                MakeSteamBackupFile(); // Re-name App.dll ==> Old_App.dll

                using (System.Net.WebClient wc = new WebClient())
                {
                    wc.DownloadFileAsync(
                        new System.Uri(UltimateCollectionDownloadURL), // Download Path
                        "D:\\SteamLibrary\\steamapps\\common\\Mini Motorways\\Mini Motorways_Data\\Managed\\App.dll" // Path To Save File
                    );
                }
                MessageBox.Show("Your game has been updated with: The Ulimate Collection Pack.");
            }
            else
            {
                MessageBox.Show("Woops. It seems you have a custom directory for the game set. As this is only the BETA version of the Mod Manager you'll have to wait until the next update to use this tool.");
            }
        } // Ulimate Collection ( All Mods )

        public void MakeSteamBackupFile()
        {
            File.Move(@"D:\SteamLibrary\steamapps\common\Mini Motorways\Mini Motorways_Data\Managed\App.dll", @"D:\SteamLibrary\steamapps\common\Mini Motorways\Mini Motorways_Data\Managed\Old_App.dll");
        } // Backup Process [ Re-name App.dll ==> Old_App.dll ]
    }
}
