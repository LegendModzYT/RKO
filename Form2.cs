using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XDevkit;
using XDevkitPlusPlus;
using JRPC_Client;
using DevComponents.DotNetBar;
using System.Diagnostics;





namespace RGH_Test
{



    public partial class Form1 : Office2007Form
    {
        public static uint uint_0;
        public static uint uint_9 = uint_0;
        public int int_0 = 0;
        IXboxConsole RGH;
        WebClient WebClient = new WebClient();

        private string LocalVersion()
        {
            return "4";
        }

        private string WIP()
        {
            return "WIP";
        }

        private void updater()
        {
            var RemoteVersion = WebClient.DownloadString("https://pastebin.com/raw/usFJgtxH");
            if (!RemoteVersion.Contains(LocalVersion())) 
            {
                MessageBoxEx.Show("An Update Is Avaliable!\nYou will now be redirected to the new download.");
                Process.Start("https://discord.io/acktool"); 
                Application.Exit(); 
                Close();
            }
        }

        private void wip()
        {
            var RemoteVersion = WebClient.DownloadString("https://pastebin.com/raw/usFJgtxH");
            if (!RemoteVersion.Contains(LocalVersion())) // ANYTHING IN THIS BLOCK WILL BE EXECUTED WHEN AN UPDATE IS AVALIABLE
            {
                MessageBoxEx.Show("Tool is now being finalized and is about to be released!\nPlease press OK to be redirected to the new download."); // MESSAGE OX TO TELL THE USER AN UPDATE IS AVALIABLE
                Process.Start("https://discord.io/acktool"); // this link opens when an update is avaliable
                Application.Exit(); // OPENS LINK ABOVE, THEN CLOSES TOOL
                Close(); // SAME AS ABOVE
            }
        }



        public Form1()
        {
            InitializeComponent();
            updater();
            WIP();
        }

        public static bool activeConnection;

        private void BO1_ZM_CMD(string command)
        {
            RGH.CallVoid(0x8230FD58, 0, command);
        }

        private void BO2_MP_CMD(string command)
        {
            RGH.CallVoid(0x824015E0, 0, command);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Appearance = Appearance.Button;
            MessageBoxEx.Show("Welcome to my tool!\nIf you want updated Versions, Visit my discord at\nhttp://discord.io/acktool\nHave a great day!!", "ayoooo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();
        }

        private void ConnectToConsole_Click(object sender, EventArgs e)
        {

            if (RGH.Connect(out RGH))
            {

                //BO2_MP_CMD("setPublicMatchClassSetNameFromLocString 0 \"^1^6[^5ack <3^6]\"");
                RGH.XNotify("ack's RGH Tool Connected! Enjoy <3", 13);
                activeConnection = true;
                
                MessageBoxEx.Show("Connected!", "Yay !!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //RGH.WriteString(0xA67AD112, "^6[^7Custom Games^5]");
                //RGH.WriteString(0xA679CE32, "^6[^7Public Match^5]");
                //RGH.WriteString(0xA6791F2C, "^6[^7Classes^5]");
                RGH.WriteString(0xA67703F6, "^6[^7^7ack <3^5]"); //A67C46C7

            }
            else
            {
                MessageBoxEx.Show("Couldnt Connect to your Console!\nMake sure you have JRPC2 set as a Plugin.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                activeConnection = false;
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (activeConnection)
            {
                RGH.XNotify(textBoxX1.Text, 3);
            }

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabFormPanel1_Click(object sender, EventArgs e)
        {

        }

        private void line1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("god");
                RGH.XNotify("Godmode Toggled!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void buttonX3_Click(object sender, EventArgs e)
        //{
        //    BO1_ZM_CMD(textBoxX2.Text);
        //}

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("noclip");
                RGH.XNotify("Noclip Toggled!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("cg_fov 90");
                RGH.XNotify("FOV Changed");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void buttonX5_Click_1(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("ufo");
                RGH.XNotify("UFO Mode Toggled!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX6_Click(object sender, EventArgs e) //0x82DC33B4 is point offset, setting to 2147483647
        {
            //byte[] Values = { 0xff, 0xff, 0xff, 0xff };
            //JRPC.SetMemory(0x82DC33B4, Values);
            RGH.SetMemory(0x82DC33B4, new byte[] { 0x7F, 0xFF, 0xCF });
            RGH.XNotify("Money Time");
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("give ammo");
                RGH.XNotify("Ammo Filled!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("notarget");
                RGH.XNotify("No Target Toggled!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("dropweapon");
                RGH.XNotify("See ya, Idiot!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("give ray_gun_upgraded_zm");
                BO1_ZM_CMD("give thundergun_upgraded_zm");
                BO1_ZM_CMD("give tesla_gun_upgraded_zm");
                BO1_ZM_CMD("give freezegun_upgraded_zm");
                BO1_ZM_CMD("sniper_explosive_upgraded_zm");
                BO1_ZM_CMD("shrink_ray_upgraded_zm");
                BO1_ZM_CMD("microwavegun_upgraded_zm");
                RGH.XNotify("Best Weapons Given!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void buttonX9_Click_1(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("bind DPAD_UP god;bind DPAD_LEFT noclip;bind DPAD_DOWN dropweapon;bind DPAD_RIGHT notarget");
                RGH.XNotify("Restart Game to Disable");
                RGH.XNotify("Binds Activated!");
                MessageBoxEx.Show("Down - Drop Gun\nLeft - Noclip\nRight - NoTarget\nUp - God Mode\nRestart Game to Reset!", "Binds Set!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("toggle cg_thirdperson");
                RGH.XNotify("Third Person Enabled!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            try
            {
                BO1_ZM_CMD("notarget");
                RGH.XNotify("NoTarget Toggled!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Program Created by me, ack, made as a Passion Project type thing.\nBig thanks to Godzilla for Helping me a bunch !!!\nThanks to Cicada for End Game, Zones and Gamertag Changing, and being an Inspiration\nAlso some Gamertag stuff is inspired by Eclipse cuz I thought it was kool.....", "Credit where Credit's due...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }



        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Random rand = new Random();
            int A = rand.Next(245, 255);
            int R = rand.Next(254, 255);
            int G = rand.Next(254, 255);
            int B = rand.Next(254, 255); labelX6.ForeColor = Color.FromArgb(A, R, G, B);
        }

        private void labelX7_Click(object sender, EventArgs e)
        {

        }

        private void line5_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void line6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) //Prestige testing
        {


        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            BO2_MP_CMD($"statsetbyname PLEVEL \"{numericUpDown3.Value.ToString()}\"");
        }

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonX15_Click(object sender, EventArgs e)

        {
            try
            {
                BO2_MP_CMD("toggle cg_drawFPS");
                BO2_MP_CMD("cg_fov 90");
                byte[] Bo2RBON = { 0x1 };
                RGH.SetMemory(0x821F5B7F, Bo2RBON);
                byte[] Bo2VSATON = { 0x1 };
                RGH.SetMemory(0x821B8FD3, Bo2VSATON);
                byte[] Bo2ColorON = { 0x1F, 0xFF, 00, 00, 0x3F, 0xFF, 00 };
                RGH.SetMemory(0x83C56038, Bo2ColorON);
                RGH.XNotify("[ack] Bo2 Offhost Cheats - On!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonX17_Click(object sender, EventArgs e)
        {


        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
        }


        private void buttonX16_Click(object sender, EventArgs e)
        {
            try
            {
                BO2_MP_CMD("cg_fov 65");
                byte[] bo2ChamsOff = { 0x7F, 0xA6, 0xEB, 0x78 };
                RGH.SetMemory(0x821FC04C, bo2ChamsOff);
                byte[] Bo2ColorOff = { 0x01, 0x01, 0x0, 0x01 };
                RGH.SetMemory(0x83C56038, Bo2ColorOff);
                byte[] Bo2RBOff = { 0x0 };
                RGH.SetMemory(0x821F5B7F, Bo2RBOff);
                byte[] Bo2VSATOff = { 0x0 };
                RGH.SetMemory(0x821B8FD3, Bo2VSATOff);
                RGH.XNotify("[ack] Bo2 Offhost Cheats - Off!");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Failed to send Command!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX17_Click_1(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Chams are Permanent!\nWill be Blue after Offhost is Disabled\nRestart game to remove", "Uh Oh !!!!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void tabStrip1_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {

        }

        private void buttonX18_Click(object sender, EventArgs e) //0x826A5FBC
        {
            //3B, 40, E4, C7 - -6969
            //3B 55 55 55 = -1.08E
            RGH.XNotify("[ack] Class Limit - Removed!");
            byte[] bo2ClassTest = { 0x3B, 0x55, 0x55, 0x55 };
            RGH.SetMemory(0x826A5FBC, bo2ClassTest);
            MessageBoxEx.Show("Class Limits will now be some negative number !!", "Classes: Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void buttonX19_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("[H] = Host Mods\n[OH] = OffHost Mods", "Quick Tips", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonX20_Click(object sender, EventArgs e)
        {
            BO2_MP_CMD($"statsetbyname rankxp \"{numericUpDown4.Value.ToString()}\"");
        }

        private void buttonX21_Click(object sender, EventArgs e)
        {
            //0x8435292E
            RGH.SetMemory(0x8435292E, new byte[] { 0xff });
        }

        private void textBoxX3_TextChanged_1(object sender, EventArgs e) // 0x026C0658
        {

        }

        private void buttonX22_Click(object sender, EventArgs e)
        {
            RGH.CallVoid(0x824015E0, 0, $"cmd mr {RGH.ReadInt32(0x82C15758)} -1 killserverpc");
            RGH.XNotify("Game Ended!!!", 3);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(200, 255); buttonX13.TextColor = Color.FromArgb(A, R, G, B);
        }

        private void buttonX23_Click(object sender, EventArgs e) //0x83C3FE38
        {
            //RGH.SetMemory(0x83C3FE98, new byte[] { 0xFF, 0x85 });
            //RGH.SetMemory(0x83C3FE38, new byte[] { 0xFF, 0x85 });
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Angleup()
        {
            RGH.WriteFloat(0x83C3FE98, 360);
        }

        private void Angledown()
        {
            RGH.WriteFloat(0x83C3FE38, 360);
        }

        private void Ladder360()
        {
            RGH.WriteFloat(0x83C40078, 360);
        }

        private void buttonX24_Click(object sender, EventArgs e)
        {
            Angleup();
            Angledown();
            Ladder360();
            MessageBoxEx.Show("Look all the way up/down for maximum ownage.\nResets after every game!\nPress it again to re-enable", "Frontflip time babey", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonX23_Click_1(object sender, EventArgs e)
        {
            if (activeConnection)
            {
                Set80GT(textBoxX3.Text);
                RGH.XNotify($"Gamertag is now: \"{textBoxX3.Text}\"");
            }
        }

        private void textBoxX3_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void Set80GT(string gamertag)
        {
            /*The Reversed Bytes Being Written Into 0x82C55D00 Are The Following PPC Intructions
             * Entry Address = 0x82C55D00
             * mr r3, r4
             * lis r11, 0x82c5
             * addi r4, r11, 0x5d60
             * lis r11, 0x824a
             * addi r11, r11, 0xdca0
             * li r5, 0x20
             * mtctr r11
             * bctr*/
            RGH.SetMemory(0x82C55D00, new byte[] { 0x7C, 0x83, 0x23, 0x78, 0x3D, 0x60, 0x82, 0xC5, 0x38, 0x8B, 0x5D, 0x60, 0x3D, 0x60, 0x82, 0x4A, 0x39, 0x6B, 0xDC, 0xA0, 0x38, 0xA0, 0x00, 0x20, 0x7D, 0x69, 0x03, 0xA6, 0x4E, 0x80, 0x04, 0x20 });//Injects hook into empty memory
            /*Entry Address = 0x8293D724
             * lis r11, 0x82c5
             * addi r11, r11, 0x5d00
             * mtctr r11
             * bctr*/
            RGH.SetMemory(0x8293D724, new byte[] { 0x3D, 0x60, 0x82, 0xC5, 0x39, 0x6B, 0x5D, 0x00, 0x7D, 0x69, 0x03, 0xA6, 0x4E, 0x80, 0x04, 0x20 });//PatchInJumps XamGetUserName to the hook previously written
            RGH.SetMemory(0x8259B6A7, new byte[] { 0x00 });//Patch 1
            RGH.SetMemory(0x822D1110, new byte[] { 0x40 });//Patch 2
            RGH.SetMemory(0x841E1B30, Encoding.ASCII.GetBytes($"{gamertag}\0"));//In Game
            RGH.SetMemory(0x82C55D60, Encoding.UTF8.GetBytes($"{gamertag}\0"));//Write 32 Chars Pregame

        }

        private void textBoxX3_TextChanged_3(object sender, EventArgs e)
        {

        }

        private void buttonX25_Click(object sender, EventArgs e)
        {
            Set80GT("^Hui_globe");
            RGH.XNotify("Globe Name Set!");
        }

        private void buttonX26_Click(object sender, EventArgs e)
        {
            Set80GT("^Hnet_new_animation");
            RGH.XNotify("Connection Interrupted Name Set!");
        }

        private void buttonX27_Click(object sender, EventArgs e)
        {
            if (this.checkBoxX3.Checked)
            {
                Set80GT("\x005E\x0048\x00FF\x00FF\x00FF\x0001\x0002\x000A\x0015\x0053\x0048\x00FF\x00FF\x00FF\x0000");
                Set80GT("\x005E\x0048\x00FF\x00FF\x00FF\x0001\x0002\x000A\x0015\x0053\x0049\x00FF\x00FF\x00FF\x0000");
                System.Threading.Thread.Sleep(750);
                Set80GT(textBoxX4.Text);
                RGH.XNotify("Pregame Host Frozen Silently.");
            }
            else
            {
                Set80GT("^1Bye^H/compass_staticRetard!");
                System.Threading.Thread.Sleep(450);
                Set80GT("\x005E\x0048\x00FF\x00FF\x00FF\x0001\x0002\x000A\x0015\x0053\x0048\x00FF\x00FF\x00FF\x0000");
                Set80GT("\x005E\x0048\x00FF\x00FF\x00FF\x0001\x0002\x000A\x0015\x0053\x0049\x00FF\x00FF\x00FF\x0000");
                System.Threading.Thread.Sleep(1000);
                Set80GT(textBoxX4.Text);
                RGH.XNotify("Pregame Host Frozen! Toxic...");
            }
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX28_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Change the 'Default GT' Text box to whatever gamertag you'd like to have after the Wifi Troll/Pregame Freeze has been done.\nClicking the 'Silent' Box will make it to where you'll freeze Host with nobody knowing. (Freeze will not work on stealt Antifreezes)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonX21_Click_1(object sender, EventArgs e)
        {
            Set80GT("^Hcompass_static");
            RGH.XNotify("Static Gamertag Set!");
        }

        private void buttonX29_Click(object sender, EventArgs e)
        {
            //
            Set80GT("^Hhud_anim_cobra");
            RGH.XNotify("Helicopter GT Set!");
        }

        private void buttonX30_Click(object sender, EventArgs e)
        {
            Set80GT("^Hyoutube_logo");
            RGH.XNotify("YouTube Logo Set!");
        }

        private void buttonX31_Click(object sender, EventArgs e)
        {
            Set80GT("^Hui_smoke");
            RGH.XNotify("Smoke Set!");
        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX32_Click(object sender, EventArgs e)
        {
            RGH.XNotify($"Troll Activated Against: \"{textBoxX5.Text}\"");
            Set80GT($"^6Hey, ^5 \"{textBoxX5.Text}\"");
            System.Threading.Thread.Sleep(2200);
            Set80GT("^1Liking that Wifi??");
            System.Threading.Thread.Sleep(2200);
            Set80GT("^5Keep being a ^6Retard...");
            System.Threading.Thread.Sleep(2200);
            Set80GT("^3And that shit's gonna go");
            System.Threading.Thread.Sleep(1750);
            Set80GT("^Hping_bar_04");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hping_bar_03");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hping_bar_02");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hping_bar_01");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hnet_new_animation");
            System.Threading.Thread.Sleep(2750); //^Hcompass_static
            Set80GT("^Hcompass_static");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hcompass_static #OFFLINE");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hcompass_static");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hcompass_static #OFFLINE");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hcompass_static");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hcompass_static #OFFLINE");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hcompass_static");
            System.Threading.Thread.Sleep(750);
            Set80GT("^Hcompass_static #OFFLINE");
            System.Threading.Thread.Sleep(750);
            Set80GT(textBoxX4.Text);



        }

        private void buttonX33_Click(object sender, EventArgs e)
        {
            BO2_MP_CMD("statwriteddl clantagstats clanname " + textBoxX6.Text + "");
            MessageBoxEx.Show("Clantag is PreGame for now, and is sorta buggy lol, will figure it out later.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonX34_Click(object sender, EventArgs e)
        {
            RGH.CallVoid(0x824015E0, 0, $"updatestats");
            RGH.CallVoid(0x824015E0, 0, $"updategamerprofile");
            RGH.CallVoid(0x824015E0, 0, $"updatestats");
            RGH.CallVoid(0x824015E0, 0, $"updategamerprofile");
            RGH.CallVoid(0x824015E0, 0, $"updatestats");
            RGH.CallVoid(0x824015E0, 0, $"updategamerprofile");

        }

        private void buttonX35_Click(object sender, EventArgs e)
        {
            BO2_MP_CMD("resetstats");
        }

        private void textBoxX9_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX36_Click(object sender, EventArgs e)
        {
            RGH.XNotify("Pregame Host Freeze Troll: Activated");
            Set80GT("^1Freezing Hosts Console in...");
            System.Threading.Thread.Sleep(2000);
            Set80GT("^Hhud_mp_num_big_3");
            System.Threading.Thread.Sleep(1000);
            Set80GT("^Hhud_mp_num_big_2");
            System.Threading.Thread.Sleep(1000);
            Set80GT("^Hhud_mp_num_big_1");
            System.Threading.Thread.Sleep(1000);
            Set80GT("^Hhud_mp_num_big_0");
            System.Threading.Thread.Sleep(1000);
            Set80GT("^1Bye^H/compass_staticRetard!");
            System.Threading.Thread.Sleep(450);
            Set80GT("\x005E\x0048\x00FF\x00FF\x00FF\x0001\x0002\x000A\x0015\x0053\x0048\x00FF\x00FF\x00FF\x0000");
            Set80GT("\x005E\x0048\x00FF\x00FF\x00FF\x0001\x0002\x000A\x0015\x0053\x0049\x00FF\x00FF\x00FF\x0000");
            System.Threading.Thread.Sleep(250);
            Set80GT(textBoxX4.Text);
            RGH.XNotify("Yeah, That'll teach him I guess.");

            Set80GT(textBoxX4.Text);
        }

        private void labelX10_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX6_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            //RGH.WriteString(0xA67AD112, this.textBoxX8.Text + "\0"); //Custom Games
            //RGH.WriteString(0xA679CE32, this.textBoxX2.Text + "\0"); //Public Match
            //RGH.WriteString(0xA6791F2C, this.textBoxX9.Text + "\0"); //Create a Class
            //RGH.WriteString(0xA67A0650, this.textBoxX10.Text + "\0"); //Barracks
            //RGH.WriteString(0xA67A2CB4, this.textBoxX11.Text + "\0"); //Theater
            //RGH.WriteString(0xA67C7918, this.textBoxX12.Text + "\0"); //League
            //RGH.XNotify("Zones Set Successfully!");
        }

        private void buttonX3_Click_1(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Will Rename some Text on your screen\nIf your zone says MPUI_(example)_CAPS, that means its too long.", "What", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Https://Discord.io/acktool");
        }

        private void labelX9_Click_1(object sender, EventArgs e)
        {

        }

        private void switchButton1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxX1.Checked)
            {
                this.timer3.Start();
            }
            else
            {
                this.timer3.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int color = new Random().Next(0, 7);
            BO2_MP_CMD("statwriteddl clantagstats clanname ^" + color);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Set80GT(textBoxX3.Text);
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxX2.Checked)
            {
                RGH.XNotify("RTE Tag [ON]");
                this.timer4.Start();
            }
            else
            {
                RGH.XNotify("RTE Tag [OFF]");
                this.timer4.Stop();
                Set80GT(textBoxX3.Text);
            }
        }

        private void Updates_Click(object sender, EventArgs e)
        {

        }

        private void buttonX4_Click_1(object sender, EventArgs e)
        {
        }

        private void buttonX4_Click_2(object sender, EventArgs e)
        {
            BO2_MP_CMD("disconnect");

        }

        private void buttonX5_Click_2(object sender, EventArgs e)
        {
            BO2_MP_CMD(textBoxX13.Text);
        }

        private void buttonX6_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBoxX3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxX3.Checked)
            {
                this.checkBoxX3.TextColor = Color.Lime;
                this.buttonX27.TextColor = Color.Lime;

            }
            else
            {
                this.checkBoxX3.TextColor = Color.Red;
                this.buttonX27.TextColor = Color.Red;

            }
        }

        private void checkBoxX4_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void buttonX6_Click_2(object sender, EventArgs e)
        {

        }

        private void buttonX7_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void buttonX8_Click_1(object sender, EventArgs e)
        {
            RGH.SendFile("SupItsTom_Offhost_Dont_Move.xex", "HDD:\\SupItsTom_Offhost_Dont_Move.xex");
            Task.Delay(100);
            RGH.CallVoid("xboxkrnl.exe", 409, "HDD:\\SupItsTom_Offhost_Dont_Move.xex", 8, 0, 0);
            RGH.XNotify("SupItsTom's Offhost Loaded!", 14);
            MessageBoxEx.Show("Open: LT + Left DPAD\nLeft/Right DPAD for other Menus\nDPAD Up and Down to scroll\nand X to Select.\nThanks to SupItsTom for the Offhost!", "How to use.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.buttonX9.Enabled = true;
            this.buttonX8.Enabled = false;
        }

        private void textBoxX2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonX9_Click_2(object sender, EventArgs e)
        {
            RGH.CallVoid("xboxkrnl.exe", 417, "HDD:\\Offhost_Dont_Move.xex", 8, 0, 0);
            RGH.XNotify("Unloading Offhost", 14);
            this.buttonX9.Enabled = false;
            this.buttonX8.Enabled = true;
        }

        private void buttonX9_Click_3(object sender, EventArgs e)
        {
            MessageBoxEx.Show("For Experienced users who know what shaders are and how to use them.\nI wont provide a shader list.\nGet it yourself from Google\nAlso if its a checkerboard or you freeze that means its not a valid shader.", "?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
        private void buttonX6_Click_3(object sender, EventArgs e)
        {
        }

        private void textBoxX14_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX11_Click_1(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Big thanks to Mari for donating even though the tool is free!", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonX2_Click_2(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Big thanks to Mari for donating even though the tool is free!", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonX10_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxX4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.checkBoxX4.Checked == true)
            {
                this.checkBoxX4.TextColor = Color.Green;
                this.checkBoxX4.Text = "Force Host [ON]";
                BO2_MP_CMD("party_connectToOthers 00; partyMigrate_disabled 01; sv_endGameIfISuck 0; badhost_endgameifisuck 0\u200B; set party_gamestarttimelength 2; set party_pregamestarttimerlength 2; set party_timer 25");
                RGH.XNotify("Force Host [ON]");

            }
            if (this.checkBoxX4.Checked == false)
            {
                this.checkBoxX4.TextColor = Color.White;
                this.checkBoxX4.Text = "Force Host [OFF]";
                BO2_MP_CMD("party_connectToOthers 01; partyMigrate_disabled 00;");
                RGH.XNotify("Force Host [OFF]");
            }
        }

        private void buttonX3_Click_2(object sender, EventArgs e)
        {
            //RGH.CallVoid(0x824015E0, 0, $"xpartygo;");
            byte[] numArray = new byte[4]
      {
        (byte) 96,
        (byte) 0,
        (byte) 0,
        (byte) 0
      };
            RGH.SetMemory(2183636224U, numArray);
            RGH.CallVoid(2185237984U, 0, "set party_minplayers 1; xpartygo");
            RGH.XNotify("Game has been Force Started!!");
        }
        public uint BO2SV = 2185427824;
        private void buttonX11_Click_2(object sender, EventArgs e)   //Pasted from R34s, idc tbh all his shit is pasted from Shit Tool or Eclipse
        {
            RGH.CallVoid(2185427824, -1, 0, "5 \"" + this.textBoxX2.Text + "\"");
            RGH.XNotify("Hope they weren't winning or anything.");

            //A67703f6 friends offset
        }

        private void buttonX12_Click_1(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Kicks the ENTIRE LOBBY, Including you.", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Get the Leading Stealth Provider with UNBEATABLE Prices and Stunning Cheats, to make sure you're on top of the competition.\nGrab yourself a Token at Cipher.Services Today.", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("http://Cipher.Services");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("meow\n meow\n  meow\n   meow\n    meow\n   meow\n  meow\n meow\n meow\n  meow   \n    meow\n   meow\n  meow\n meow\nmeow", " ", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        }

        private void buttonX19_Click_1(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.checkBox1.ForeColor = Color.Lime;
                this.checkBox1.Text = "Force Host [ON]";
                BO2_MP_CMD("party_connectToOthers 00; partyMigrate_disabled 01; sv_endGameIfISuck 0; badhost_endgameifisuck 0\u200B; set party_gamestarttimelength 2; set party_pregamestarttimerlength 2; set party_timer 25");
                RGH.XNotify("Force Host [ON]");

            }
            if (this.checkBox1.Checked == false)
            {
                this.checkBox1.ForeColor = Color.White;
                this.checkBox1.Text = "Force Host [OFF]";
                BO2_MP_CMD("party_connectToOthers 01; partyMigrate_disabled 00;");
                RGH.XNotify("Force Host [OFF]");
            }
        }

        private void groupPanel6_Click(object sender, EventArgs e)
        {

        }

        private async void gs_Tick(object sender, EventArgs e)
        {
        }

        private void checkBoxX5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBoxX5_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private async void buttonX24_Click_1(object sender, EventArgs e)
        {

            var proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));

            if (proc == null)
            {
            }

            if (string.Equals(proc.MainWindowTitle, "Spotify", StringComparison.InvariantCultureIgnoreCase))
            {
                
            }
            Set80GT("^6L");
            await Task.Delay(250);
            Set80GT("^5Li");
            await Task.Delay(250);
            Set80GT("^6Lis");
            await Task.Delay(250);
            Set80GT("^5List");
            await Task.Delay(250);
            Set80GT("^6Liste");
            await Task.Delay(250);
            Set80GT("^5Listen");
            await Task.Delay(250);
            Set80GT("^6Listeni");
            await Task.Delay(250);
            Set80GT("^5Listenin");
            await Task.Delay(250);
            Set80GT("^6Listening");
            await Task.Delay(250);
            Set80GT("^5Listening T");
            await Task.Delay(250);
            Set80GT("^6Listening To");
            await Task.Delay(250);
            Set80GT("^5Listening To.");
            await Task.Delay(250);
            Set80GT("^6Listening To..");
            await Task.Delay(250);
            Set80GT("^5Listening To...");
            await Task.Delay(250);
            Set80GT("^6Listening To.");
            await Task.Delay(250);
            Set80GT("^5Listening To..");
            await Task.Delay(250);
            Set80GT("^6Listening To...");
            await Task.Delay(250);
            Set80GT("^5" + proc.MainWindowTitle);
            await Task.Delay(250);
            Set80GT("^6" + proc.MainWindowTitle);
            await Task.Delay(250);
            Set80GT("^5" + proc.MainWindowTitle);
            await Task.Delay(250);
            Set80GT("^6" + proc.MainWindowTitle);
            await Task.Delay(250);
            Set80GT("^5" + proc.MainWindowTitle);
            await Task.Delay(250);
            Set80GT("^6" + proc.MainWindowTitle);
            await Task.Delay(250);
            Set80GT("^5" + proc.MainWindowTitle);
            await Task.Delay(250);
            Set80GT("^6" + proc.MainWindowTitle);
            await Task.Delay(250);
            Set80GT("on ^2Spotify");
            await Task.Delay(2500);
            Set80GT(textBoxX4.Text);

        }

        private void bunifuColorTransition1_ColorChanged(object sender, Bunifu.UI.WinForms.BunifuColorTransition.ColorChangedEventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}







