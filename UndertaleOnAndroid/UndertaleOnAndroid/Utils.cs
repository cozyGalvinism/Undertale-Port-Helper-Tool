using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Ionic.Zip;

namespace UndertaleOnAndroid
{
    public static class Utils
    {
        private static FileInfo[] utFiles;

        public static string UndertaleLocation { get; set; }
        public static bool MusicFound { get; set; }
        public static bool DataWinFound { get; set; }
        public static string Pwd { get; set; }
        public static FileInfo[] Files
        {
            get
            {
                return utFiles;
            }
        }

        public static void CheckUndertaleLocation()
        {
            try
            {
                DirectoryInfo undertale = new DirectoryInfo(UndertaleLocation);
                utFiles = undertale.GetFiles();
                frmHT.instance.rtbLog.AppendText("Checking if directory is valid... ");
                if (utFiles.FirstOrDefault(x => x.Name.ToLower() == "undertale.exe").Exists)
                {
                    frmHT.instance.rtbLog.AppendText("valid!\n Checking if music is present... ");
                    MusicFound = CheckForMusic(utFiles);
                    frmHT.instance.rtbLog.AppendText((MusicFound ? "present!" : "not present!") + "\nChecking if data.win is in the directory... ");
                    DataWinFound = CheckForWin(utFiles);
                    frmHT.instance.rtbLog.AppendText(DataWinFound ? "available!\nClick on Create to build the APK!\n" : "not available!\nYour game files don't seem to be intact... please inform the coder!\n");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry! This is no valid Undertale location! Without it, you can't progress further :(");
            }
        }

        private static bool CheckForWin(FileInfo[] files)
        {
            try
            {
                if (files.FirstOrDefault(x => x.Name.ToLower() == "data.win").Exists)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool CheckForMusic(FileInfo[] files)
        {
            try
            {
                if (files.FirstOrDefault(x => x.Name.ToLower() == "mus_flowey.ogg").Exists)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void PatchAndInclude(FileInfo win)
        {
            if (DataWinFound)
            {
                try
                {
                    frmHT.instance.rtbLog.AppendText("Copying data.win... ");
                    win.CopyTo(@".\Patch\data.win", true);
                    frmHT.instance.rtbLog.AppendText("copied!\nPatching data.win to game.droid... ");
                    Process xdelta = Process.Start("cmd.exe", "/C \"" + Path.Combine(Pwd, "Patch\\xdelta.exe") + "\" -d -s Patch\\data.win Patch\\DOWNTALEv1001TOv100.xdelta Patch\\game.droid");
                    xdelta.WaitForExit();
                    frmHT.instance.rtbLog.AppendText("patched!\nAdding the file into APK... ");
                    FileInfo gamedroid = new FileInfo(Path.Combine(Pwd, @"Patch\game.droid"));
                    ZipFile apk = ZipFile.Read(Path.Combine(Pwd, @"Additional Files\UndertaleWrapper.apk"));
                    apk.RemoveEntry("assets\\game.droid");
                    apk.AddFile(gamedroid.FullName, "assets");
                    apk.Save();
                    if (MusicFound)
                    {
                        frmHT.instance.rtbLog.AppendText("added!\nCopying and adding the music in... ");
                        Directory.CreateDirectory(Path.Combine(Pwd, "assets"));
                        foreach(FileInfo f in Files)
                        {
                            if (f.Extension == ".ogg" || f.Extension == "ogg" || f.Name == "credits.txt")
                            {
                                f.CopyTo(Path.Combine(Pwd, "assets", f.Name));
                            }
                        }
                        Process aapt = new Process();
                        aapt.StartInfo.FileName = "cmd.exe";
                        aapt.StartInfo.WorkingDirectory = Pwd;
                        aapt.StartInfo.Arguments = "/C aapt.exe add -f -v \"Additional Files\\UndertaleWrapper.apk\" assets/credits.txt assets/mus_a2.ogg assets/mus_alphysfix.ogg assets/mus_amalgam.ogg assets/mus_ambientwater.ogg assets/mus_anothermedium.ogg assets/mus_bad.ogg assets/mus_barrier.ogg assets/mus_battle1.ogg assets/mus_battle2.ogg assets/mus_bergentruckung.ogg assets/mus_bgflameA.ogg assets/mus_birdnoise.ogg assets/mus_birdsong.ogg assets/mus_boss1.ogg assets/mus_cast_1.ogg assets/mus_cast_2.ogg assets/mus_cast_3.ogg assets/mus_cast_4.ogg assets/mus_cast_5.ogg assets/mus_cast_6.ogg assets/mus_cast_7.ogg assets/mus_chokedup.ogg assets/mus_churchbell.ogg assets/mus_computer.ogg assets/mus_confession.ogg assets/mus_coolbeat.ogg assets/mus_core.ogg assets/mus_coretransition.ogg assets/mus_core_ambience.ogg assets/mus_creepy_ambience.ogg assets/mus_crickets.ogg assets/mus_cymbal.ogg assets/mus_dance_of_dog.ogg assets/mus_date.ogg assets/mus_date_fight.ogg assets/mus_date_tense.ogg assets/mus_deeploop2.ogg assets/mus_disturbing.ogg assets/mus_dogappear.ogg assets/mus_dogmeander.ogg assets/mus_dogroom.ogg assets/mus_dogsong.ogg assets/mus_dontgiveup.ogg assets/mus_doorclose.ogg assets/mus_dooropen.ogg assets/mus_drone.ogg assets/mus_dummybattle.ogg assets/mus_dununnn.ogg assets/mus_elevator.ogg assets/mus_elevator_last.ogg assets/mus_endarea_parta.ogg assets/mus_endarea_partb.ogg assets/mus_endingexcerpt1.ogg assets/mus_endingexcerpt2.ogg assets/mus_express_myself.ogg assets/mus_fallendown2.ogg assets/mus_fearsting.ogg assets/mus_flowey.ogg assets/mus_f_6s_1.ogg assets/mus_f_6s_2.ogg assets/mus_f_6s_3.ogg assets/mus_f_6s_4.ogg assets/mus_f_6s_5.ogg assets/mus_f_6s_6.ogg assets/mus_f_alarm.ogg assets/mus_f_destroyed.ogg assets/mus_f_destroyed2.ogg assets/mus_f_destroyed3.ogg assets/mus_f_finale_1.ogg assets/mus_f_finale_1_l.ogg assets/mus_f_finale_2.ogg assets/mus_f_finale_3.ogg assets/mus_f_intro.ogg assets/mus_f_newlaugh.ogg assets/mus_f_newlaugh_low.ogg assets/mus_f_part1.ogg assets/mus_f_part2.ogg assets/mus_f_part3.ogg assets/mus_f_saved.ogg assets/mus_f_wind1.ogg assets/mus_f_wind2.ogg assets/mus_gameover.ogg assets/mus_ghostbattle.ogg assets/mus_harpnoise.ogg assets/mus_hereweare.ogg assets/mus_hotel.ogg assets/mus_hotel_battle.ogg assets/mus_house1.ogg assets/mus_house2.ogg assets/mus_intronoise.ogg assets/mus_kingdescription.ogg assets/mus_lab.ogg assets/mus_leave.ogg assets/mus_menu0.ogg assets/mus_menu1.ogg assets/mus_menu2.ogg assets/mus_menu3.ogg assets/mus_menu4.ogg assets/mus_menu5.ogg assets/mus_menu6.ogg assets/mus_mettafly.ogg assets/mus_mettatonbattle.ogg assets/mus_mettaton_ex.ogg assets/mus_mettaton_neo.ogg assets/mus_mettaton_pretransform.ogg assets/mus_mettmusical1.ogg assets/mus_mettmusical2.ogg assets/mus_mettmusical3.ogg assets/mus_mettmusical4.ogg assets/mus_mettsad.ogg assets/mus_mett_applause.ogg assets/mus_mett_cheer.ogg assets/mus_mode.ogg assets/mus_mtgameshow.ogg assets/mus_muscle.ogg assets/mus_musicbox.ogg assets/mus_myemeow.ogg assets/mus_mysteriousroom2.ogg assets/mus_mystery.ogg assets/mus_napstachords.ogg assets/mus_napstahouse.ogg assets/mus_news.ogg assets/mus_news_battle.ogg assets/mus_ohyes.ogg assets/mus_oogloop.ogg assets/mus_operatile.ogg assets/mus_options_fall.ogg assets/mus_options_summer.ogg assets/mus_options_winter.ogg assets/mus_papyrus.ogg assets/mus_papyrusboss.ogg assets/mus_piano.ogg assets/mus_prebattle1.ogg assets/mus_predummy.ogg assets/mus_race.ogg assets/mus_rain.ogg assets/mus_rain_deep.ogg assets/mus_repeat_1.ogg assets/mus_repeat_2.ogg assets/mus_reunited.ogg assets/mus_rimshot.ogg assets/mus_ruins.ogg assets/mus_ruinspiano.ogg assets/mus_sansdate.ogg assets/mus_sfx_a_grab.ogg assets/mus_sfx_chainsaw.ogg assets/mus_sfx_hypergoner_charge.ogg assets/mus_sfx_hypergoner_laugh.ogg assets/mus_sfx_rainbowbeam_hold.ogg assets/mus_shop.ogg assets/mus_sigh_of_dog.ogg assets/mus_silence.ogg assets/mus_smallshock.ogg assets/mus_smile.ogg assets/mus_snoresymphony.ogg assets/mus_snowwalk.ogg assets/mus_snowy.ogg assets/mus_spider.ogg assets/mus_spoopy.ogg assets/mus_spoopy_holiday.ogg assets/mus_spoopy_wave.ogg assets/mus_star.ogg assets/mus_sticksnap.ogg assets/mus_story.ogg assets/mus_story_stuck.ogg assets/mus_st_happytown.ogg assets/mus_st_him.ogg assets/mus_st_meatfactory.ogg assets/mus_st_troubledingle.ogg assets/mus_temshop.ogg assets/mus_temvillage.ogg assets/mus_tension.ogg assets/mus_tone2.ogg assets/mus_tone3.ogg assets/mus_toomuch.ogg assets/mus_toriel.ogg assets/mus_town.ogg assets/mus_tv.ogg assets/mus_undyneboss.ogg assets/mus_undynefast.ogg assets/mus_undynepiano.ogg assets/mus_undynescary.ogg assets/mus_undynetheme.ogg assets/mus_undynetruetheme.ogg assets/mus_vsasgore.ogg assets/mus_waterfall.ogg assets/mus_waterquiet.ogg assets/mus_wawa.ogg assets/mus_whoopee.ogg assets/mus_wind.ogg assets/mus_woofenstein.ogg assets/mus_woofenstein_loop.ogg assets/mus_wrongnumbersong.ogg assets/mus_wrongworld.ogg assets/mus_xpart.ogg assets/mus_xpart_2.ogg assets/mus_xpart_a.ogg assets/mus_xpart_b.ogg assets/mus_xpart_back.ogg assets/mus_x_undyne.ogg assets/mus_x_undyne_pre.ogg assets/mus_yourbestfriend_3.ogg assets/mus_zzz_c.ogg assets/mus_zzz_c2.ogg assets/mus_zz_megalovania.ogg assets/mus_z_ending.ogg assets/snd_ballchime.ogg assets/snd_bombfall.ogg assets/snd_bombsplosion.ogg assets/snd_buzzing.ogg assets/snd_curtgunshot.ogg assets/snd_fall2.ogg assets/snd_flameloop.ogg assets/snd_heavydamage.ogg assets/snd_mushroomdance.ogg";
                        aapt.StartInfo.UseShellExecute = false;
                        aapt.Start();
                        aapt.WaitForExit();
                    }
                    frmHT.instance.rtbLog.AppendText("added!\nSigning apk... ");
                    Process sign = new Process();
                    sign.StartInfo.FileName = "cmd.exe";
                    sign.StartInfo.WorkingDirectory = Path.Combine(Pwd, "signtool\\");
                    sign.StartInfo.Arguments = "/C java -jar lib.jar -w testkey.x509.pem testkey.pk8 \"..\\Additional Files\\UndertaleWrapper.apk\" \"..\\Additional Files\\UndertaleWrapper-signed.apk\"";
                    sign.StartInfo.UseShellExecute = false;
                    sign.Start();
                    sign.WaitForExit();
                    frmHT.instance.rtbLog.AppendText("signed!\n Copy all files from Additional Files (except UndertaleWrapper.apk) to your phone and install UndertaleWrapper-signed.apk!\n\n");
                    LogCredits();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }else
            {
                MessageBox.Show("No data.win file!");
            }
        }

        public static void LogCredits()
        {
            frmHT.instance.rtbLog.AppendText("CREDITS:\nToby Fox for writing Undertale\nMrPowerGamerBR for porting the game to Android\nJeanolos for writing an easy to use method to create the apk\nLink to the original reddit post: https://www.reddit.com/r/Undertale/comments/3yblsf/tutorial_droidtale_unofficial_and_hacky_undertale/");
        }
    }
}
