using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OoT_Item_Tracker
{
        public partial class OoT_Item_Tracker_GUI : Form
        {
                int skullCount = 0;
                int HPCount = 0;
                string currentType = "Horizontal";
                string currentScreen = "Item";
                int size = 64;
                int size32 = 32;
                int size48 = 48;
                int size96 = 96;
                int size103 = 103;
                int sizeFont = 19;
                Dictionary<int, string> items;
                Dictionary<string, int> itemLevels;
                Dictionary<string, int> maxLevels;
                Dictionary<string, Point> HorPos;
                Dictionary<string, Point> BoxPos;
                Dictionary<string, Point> SinglePos;

                public OoT_Item_Tracker_GUI()
                {
                        InitializeComponent();
                }

                private void OoT_Item_Tracker_Load(object sender, EventArgs e)
                {
                        //dont have stone of agony, gerudo card, light med, kokiri boots, or kokiri tunic
                        items = new Dictionary<int, string>() {
                                {0,"DekuStick" },
                                {1,"DekuNut"},
                                {2,"Bombs" },
                                {3,"Bow" },
                                {4,"FireArrows" },
                                {5,"DinsFire" },
                                {6,"Slingshot" },
                                {7,"FairyOcarina" },
                                {8,"Chus" },
                                {9,"Hookshot" },
                                {10,"IceArrows" },
                                {11,"FW" },
                                {12,"Boomerang" },
                                {13,"Lens" },
                                {14,"MagicBeans" },
                                {15,"Hammer" },
                                {16,"LightArrows" },
                                {17,"NayrusLove" },
                                {18,"Bottle1" },
                                {19,"Bottle2" },
                                {20,"Bottle3" },
                                {21,"Bottle4" },
                                {22,"ChildTrade" },
                                {23,"AdultTrade" },
                                {24,"StoneOfAgony" },
                                {25,"GerudoCard" },
                                {26,"HP_" },
                                {27,"Song1" },
                                {28,"Song2" },
                                {29,"Song3" },
                                {30,"Song4" },
                                {31,"Song5" },
                                {32,"Song6" },
                                {33,"Minuet" },
                                {34,"Bolero" },
                                {35,"Serenade" },
                                {36,"Requiem" },
                                {37,"Nocturne" },
                                {38,"Prelude" },
                                {39,"ForestMed" },
                                {40,"FireMed" },
                                {41,"WaterMed" },
                                {42,"SpiritMed" },
                                {43,"ShadowMed" },
                                {44,"Kokiri" },
                                {45,"Goron" },
                                {46,"Zora" },
                                {47,"IronBoots" },
                                {48,"HoverBoots" },
                                {49,"GoronTunic" },
                                {50,"ZoraTunic" },
                                {51,"DekuShield" },
                                {52,"HylianShield" },
                                {53,"MirrorShield" },
                                {54,"KokiriSword" },
                                {55,"MasterSword" },
                                {56,"BigGoronSword" },
                                {57,"SilverScale" },
                                {58,"GoronBracelet" }
                        };

                        //set all item starting levels to 0
                        itemLevelsNew();
                        
                        maxLevels = new Dictionary<string, int>() {
                                {"DekuStick", 3 },
                                {"DekuNut", 3 },
                                {"Bombs", 3 },
                                {"Bow", 3 },
                                {"FireArrows", 1 },
                                {"DinsFire", 1 },
                                {"Slingshot", 3 },
                                {"FairyOcarina", 2 },
                                {"Chus", 1 },
                                {"Hookshot", 2 },
                                {"IceArrows", 1 },
                                {"FW", 1 },
                                {"Boomerang", 1 },
                                {"Lens", 1 },
                                {"MagicBeans", 1 },
                                {"Hammer", 1 },
                                {"LightArrows", 1 },
                                {"NayrusLove", 1 },
                                {"Bottle1", 1 },
                                {"Bottle2", 1 },
                                {"Bottle3", 1 },
                                {"Bottle4", 1 },
                                {"ChildTrade", 11 },
                                {"AdultTrade", 11 },
                                {"StoneOfAgony", 1 },
                                {"GerudoCard", 1 },
                                {"HP_", 3 },
                                {"Song1", 1 },
                                {"Song2", 1 },
                                {"Song3", 1 },
                                {"Song4", 1 },
                                {"Song5", 1 },
                                {"Song6", 1 },
                                {"Minuet", 1 },
                                {"Bolero", 1 },
                                {"Serenade", 1 },
                                {"Requiem", 1 },
                                {"Nocturne", 1 },
                                {"Prelude", 1 },
                                {"LightMed", 1 },
                                {"ForestMed", 1 },
                                {"FireMed", 1 },
                                {"WaterMed", 1 },
                                {"SpiritMed", 1 },
                                {"ShadowMed", 1 },
                                {"Kokiri", 1 },
                                {"Goron", 1 },
                                {"Zora", 1 },
                                {"IronBoots", 1 },
                                {"HoverBoots", 1 },
                                {"GoronTunic", 1 },
                                {"ZoraTunic", 1 },
                                {"DekuShield", 1 },
                                {"HylianShield", 1 },
                                {"MirrorShield", 1 },
                                {"KokiriSword", 1 },
                                {"MasterSword", 1 },
                                {"BigGoronSword", 1 },
                                {"SilverScale", 2 },
                                {"GoronBracelet", 3 }
                        };

                        //setup the locations for size 64 type horizontal
                        HorPos = new Dictionary<string, Point>() {
                                {"DekuStick", new Point(55, 76) },
                                {"DekuNut", new Point(128, 76) },
                                {"Bombs", new Point(201, 76) },
                                {"Bow", new Point(274, 76) },
                                {"FireArrows", new Point(350, 76) },
                                {"DinsFire", new Point(420, 76) },
                                {"Slingshot", new Point(55, 149) },
                                {"FairyOcarina", new Point(128, 149) },
                                {"Chus", new Point(201, 149) },
                                {"Hookshot", new Point(274, 149) },
                                {"IceArrows", new Point(350, 149) },
                                {"FW", new Point(420, 149) },
                                {"Boomerang", new Point(55, 222) },
                                {"Lens", new Point(128, 222) },
                                {"MagicBeans", new Point(201, 222) },
                                {"Hammer", new Point(274, 222) },
                                {"LightArrows", new Point(350, 222) },
                                {"NayrusLove", new Point(420, 222) },
                                {"Bottle1", new Point(55, 295) },
                                {"Bottle2", new Point(128, 295) },
                                {"Bottle3", new Point(201, 295) },
                                {"Bottle4", new Point(274, 295) },
                                {"ChildTrade", new Point(420, 295) },
                                {"AdultTrade", new Point(350, 295) },
                                {"HP_", new Point(694, 81) },
                                {"Song1", new Point(567, 204) },
                                {"Song2", new Point(609, 204) },
                                {"Song3", new Point(650, 204) },
                                {"Song4", new Point(690, 204) },
                                {"Song5", new Point(730, 204) },
                                {"Song6", new Point(770, 204) },
                                {"Minuet", new Point(568, 252) },
                                {"Bolero", new Point(609, 252) },
                                {"Serenade", new Point(650, 252) },
                                {"Requiem", new Point(690, 252) },
                                {"Nocturne", new Point(730, 252) },
                                {"Prelude", new Point(770, 252) },
                                {"LightMed", new Point(916, 78) },
                                {"ForestMed", new Point(979, 121) },
                                {"FireMed", new Point(980, 191) },
                                {"WaterMed", new Point(916, 233) },
                                {"SpiritMed", new Point(853, 191) },
                                {"ShadowMed", new Point(853, 121) },
                                {"StoneOfAgony", new Point(566, 74) },
                                {"GerudoCard", new Point(622, 74) },
                                {"Kokiri", new Point(857, 311) },
                                {"Goron", new Point(918, 311) },
                                {"Zora", new Point(978, 311) },
                                {"KokiriBoots", new Point(1193, 296) },
                                {"IronBoots", new Point(1263, 295) },
                                {"HoverBoots", new Point(1333, 295) },
                                {"KokiriTunic", new Point(1193, 221) },
                                {"GoronTunic", new Point(1263, 222) },
                                {"ZoraTunic", new Point(1333, 221) },
                                {"DekuShield", new Point(1193, 149) },
                                {"HylianShield", new Point(1263, 149) },
                                {"MirrorShield", new Point(1333, 149) },
                                {"KokiriSword", new Point(1193, 76) },
                                {"MasterSword", new Point(1263, 76) },
                                {"BigGoronSword", new Point(1333, 76) },
                                {"SilverScale", new Point(1101, 295) },
                                {"GoronBracelet", new Point(1101, 221) },
                                {"BombBag", new Point(1101, 149) },
                                {"SkullCount_Label", new Point(567, 133) }
                        };

                        //setup the locations for size 64 type boxy boxy trevy wevy
                        BoxPos = new Dictionary<string, Point>() {
                                {"DekuStick", new Point(55, 76) },
                                {"DekuNut", new Point(128, 76) },
                                {"Bombs", new Point(201, 76) },
                                {"Bow", new Point(274, 76) },
                                {"FireArrows", new Point(350, 76) },
                                {"DinsFire", new Point(420, 76) },
                                {"Slingshot", new Point(55, 149) },
                                {"FairyOcarina", new Point(128, 149) },
                                {"Chus", new Point(201, 149) },
                                {"Hookshot", new Point(274, 149) },
                                {"IceArrows", new Point(350, 149) },
                                {"FW", new Point(420, 149) },
                                {"Boomerang", new Point(55, 222) },
                                {"Lens", new Point(128, 222) },
                                {"MagicBeans", new Point(201, 222) },
                                {"Hammer", new Point(274, 222) },
                                {"LightArrows", new Point(350, 222) },
                                {"NayrusLove", new Point(420, 222) },
                                {"Bottle1", new Point(55, 295) },
                                {"Bottle2", new Point(128, 295) },
                                {"Bottle3", new Point(201, 295) },
                                {"Bottle4", new Point(274, 295) },
                                {"ChildTrade", new Point(420, 295) },
                                {"AdultTrade", new Point(350, 295) },
                                {"HP_", new Point(154, 440) },
                                {"Song1", new Point(27, 561) },
                                {"Song2", new Point(69, 561) },
                                {"Song3", new Point(110, 561) },
                                {"Song4", new Point(150, 561) },
                                {"Song5", new Point(190, 561) },
                                {"Song6", new Point(230, 561) },
                                {"Minuet", new Point(28, 609) },
                                {"Bolero", new Point(69, 609) },
                                {"Serenade", new Point(110, 609) },
                                {"Requiem", new Point(150, 609) },
                                {"Nocturne", new Point(190, 609) },
                                {"Prelude", new Point(230, 609) },
                                {"LightMed", new Point(377, 439) },
                                {"ForestMed", new Point(439, 480) },
                                {"FireMed", new Point(440, 550) },
                                {"WaterMed", new Point(376, 594) },
                                {"SpiritMed", new Point(313, 551) },
                                {"ShadowMed", new Point(312, 481) },
                                {"StoneOfAgony", new Point(22, 433) },
                                {"GerudoCard", new Point(81, 434) },
                                {"Kokiri", new Point(319, 671) },
                                {"Goron", new Point(378, 671) },
                                {"Zora", new Point(436, 671) },
                                { "KokiriBoots", new Point(653, 481) },
                                { "IronBoots", new Point(723, 481) },
                                { "HoverBoots", new Point(793, 481) },
                                { "KokiriTunic", new Point(653, 408) },
                                { "GoronTunic", new Point(723, 408) },
                                { "ZoraTunic", new Point(793, 408) },
                                {"DekuShield", new Point(653, 336) },
                                {"HylianShield", new Point(723, 336) },
                                {"MirrorShield", new Point(793, 336) },
                                {"KokiriSword", new Point(653, 261) },
                                {"MasterSword", new Point(723, 261) },
                                {"BigGoronSword", new Point(793, 261) },
                                {"SilverScale", new Point(561, 480) },
                                {"GoronBracelet", new Point(561, 408) },
                                {"BombBag", new Point(561, 336) },
                                {"SkullCount_Label", new Point(25, 492) }
                        };

                        //setup the locations for size 64 type boxy boxy trevy wevy
                        SinglePos = new Dictionary<string, Point>() {
                                {"DekuStick", new Point(55, 76) },
                                {"DekuNut", new Point(128, 76) },
                                {"Bombs", new Point(201, 76) },
                                {"Bow", new Point(274, 76) },
                                {"FireArrows", new Point(350, 76) },
                                {"DinsFire", new Point(420, 76) },
                                {"Slingshot", new Point(55, 149) },
                                {"FairyOcarina", new Point(128, 149) },
                                {"Chus", new Point(201, 149) },
                                {"Hookshot", new Point(274, 149) },
                                {"IceArrows", new Point(350, 149) },
                                {"FW", new Point(420, 149) },
                                {"Boomerang", new Point(55, 222) },
                                {"Lens", new Point(128, 222) },
                                {"MagicBeans", new Point(201, 222) },
                                {"Hammer", new Point(274, 222) },
                                {"LightArrows", new Point(350, 222) },
                                {"NayrusLove", new Point(420, 222) },
                                {"Bottle1", new Point(55, 295) },
                                {"Bottle2", new Point(128, 295) },
                                {"Bottle3", new Point(201, 295) },
                                {"Bottle4", new Point(274, 295) },
                                {"ChildTrade", new Point(420, 295) },
                                {"AdultTrade", new Point(350, 295) },
                                {"HP_", new Point(153, 81) },
                                {"Song1", new Point(26, 204) },
                                {"Song2", new Point(68, 204) },
                                {"Song3", new Point(109, 204) },
                                {"Song4", new Point(149, 204) },
                                {"Song5", new Point(189, 204) },
                                {"Song6", new Point(229, 204) },
                                {"Minuet", new Point(27, 252) },
                                {"Bolero", new Point(68, 252) },
                                {"Serenade", new Point(109, 252) },
                                {"Requiem", new Point(149, 252) },
                                {"Nocturne", new Point(189, 252) },
                                {"Prelude", new Point(229, 252) },
                                {"LightMed", new Point(375, 78) },
                                {"ForestMed", new Point(438, 121) },
                                {"FireMed", new Point(439, 191) },
                                {"WaterMed", new Point(375, 233) },
                                {"SpiritMed", new Point(312, 191) },
                                {"ShadowMed", new Point(312, 121) },
                                {"StoneOfAgony", new Point(25, 74) },
                                {"GerudoCard", new Point(81, 74) },
                                {"Kokiri", new Point(316, 311) },
                                {"Goron", new Point(377, 311) },
                                {"Zora", new Point(437, 311) },
                                {"KokiriBoots", new Point(300, 296) },
                                {"IronBoots", new Point(370, 295) },
                                {"HoverBoots", new Point(440, 295) },
                                {"KokiriTunic", new Point(300, 221) },
                                {"GoronTunic", new Point(370, 222) },
                                {"ZoraTunic", new Point(440, 221) },
                                {"DekuShield", new Point(300, 149) },
                                {"HylianShield", new Point(370, 149) },
                                {"MirrorShield", new Point(440, 149) },
                                {"KokiriSword", new Point(300, 76) },
                                {"MasterSword", new Point(370, 76) },
                                {"BigGoronSword", new Point(440, 76) },
                                {"SilverScale", new Point(21, 295) },
                                {"GoronBracelet", new Point(21, 221) },
                                {"BombBag", new Point(21, 149) },
                                {"SkullCount_Label", new Point(26, 133) }
                        };
                        
                }

                private void updateIcon(PictureBox icon, MouseEventArgs me)
                {
                        if (me.Button == System.Windows.Forms.MouseButtons.Left)
                        {

                                //change the item's level
                                if (itemLevels[icon.Name] < maxLevels[icon.Name])
                                {
                                        itemLevels[icon.Name]++;
                                }

                                //change the icon
                                if (icon.Name.Contains("Bottle"))
                                {
                                        icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Bottle_64");
                                }
                                else if (icon.Name.Contains("Song"))
                                {
                                        icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("GrayNote_64");
                                }
                                else if (icon.Name == "HP_")
                                {
                                        HPCount++;
                                        if (HPCount == 4)
                                        {
                                                icon.BackgroundImage = null;
                                                HPCount = 0;
                                        }
                                        else
                                        {
                                                icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(icon.Name + HPCount.ToString() + "_64");
                                        }
                                }
                                else
                                {
                                        if (itemLevels[icon.Name] > 1)
                                        {
                                                icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(icon.Name + itemLevels[icon.Name].ToString() + "_64");
                                        }
                                        else
                                        {
                                                icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(icon.Name + "_64");
                                        }
                                }
                        }
                        else if (me.Button == System.Windows.Forms.MouseButtons.Right)
                        {

                                //change the item's level
                                if (itemLevels[icon.Name] > 0)
                                {
                                        itemLevels[icon.Name]--;
                                }

                                //change the icons image
                                if (icon.Name.Contains("Bottle"))
                                {
                                        icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Bottle_none_64");
                                }
                                else if (icon.Name == "HP_")
                                {
                                        HPCount--;
                                        if (HPCount == -1)
                                        {
                                                icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(icon.Name + "3_64");
                                                HPCount = 3;
                                        }
                                        else
                                        {
                                                icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(icon.Name + HPCount.ToString() + "_64");
                                        }
                                }
                                else
                                {
                                        if (itemLevels[icon.Name] > 1)
                                        {
                                                icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(icon.Name + itemLevels[icon.Name].ToString() + "_64");
                                        }
                                        else if (itemLevels[icon.Name] == 1)
                                        {
                                                icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(icon.Name + "_64");
                                        }
                                        else
                                        {
                                                icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(icon.Name + "_none_64");
                                        }
                                }
                        }
                        else
                        {
                                itemLevels[icon.Name] = 0;
                                icon.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(icon.Name + "_none_64");
                        }
                }

                //updates the location of all the items on the screen
                private void updateLocations(Dictionary<string, Point> locations, double multiplierX = 1, double multpilierY = 1)
                {
                        DekuStick.Location = new System.Drawing.Point(Convert.ToInt32(locations["DekuStick"].getX() * multiplierX), Convert.ToInt32((locations["DekuStick"].getY() - 25) * multpilierY) + 25);
                        DekuNut.Location = new System.Drawing.Point(Convert.ToInt32(locations["DekuNut"].getX() * multiplierX), Convert.ToInt32((locations["DekuNut"].getY() - 25) * multpilierY) + 25);
                        Bombs.Location = new System.Drawing.Point(Convert.ToInt32(locations["Bombs"].getX() * multiplierX), Convert.ToInt32((locations["Bombs"].getY() - 25) * multpilierY) + 25);
                        Bow.Location = new System.Drawing.Point(Convert.ToInt32(locations["Bow"].getX() * multiplierX), Convert.ToInt32((locations["Bow"].getY() - 25) * multpilierY) + 25);
                        FireArrows.Location = new System.Drawing.Point(Convert.ToInt32(locations["FireArrows"].getX() * multiplierX), Convert.ToInt32((locations["FireArrows"].getY() - 25) * multpilierY) + 25);
                        DinsFire.Location = new System.Drawing.Point(Convert.ToInt32(locations["DinsFire"].getX() * multiplierX), Convert.ToInt32((locations["DinsFire"].getY() - 25) * multpilierY) + 25);
                        Slingshot.Location = new System.Drawing.Point(Convert.ToInt32(locations["Slingshot"].getX() * multiplierX), Convert.ToInt32((locations["Slingshot"].getY() - 25) * multpilierY) + 25);
                        FairyOcarina.Location = new System.Drawing.Point(Convert.ToInt32(locations["FairyOcarina"].getX() * multiplierX), Convert.ToInt32((locations["FairyOcarina"].getY() - 25) * multpilierY) + 25);
                        Chus.Location = new System.Drawing.Point(Convert.ToInt32(locations["Chus"].getX() * multiplierX), Convert.ToInt32((locations["Chus"].getY() - 25) * multpilierY) + 25);
                        Hookshot.Location = new System.Drawing.Point(Convert.ToInt32(locations["Hookshot"].getX() * multiplierX), Convert.ToInt32((locations["Hookshot"].getY() - 25) * multpilierY) + 25);
                        IceArrows.Location = new System.Drawing.Point(Convert.ToInt32(locations["IceArrows"].getX() * multiplierX), Convert.ToInt32((locations["IceArrows"].getY() - 25) * multpilierY) + 25);
                        FW.Location = new System.Drawing.Point(Convert.ToInt32(locations["FW"].getX() * multiplierX), Convert.ToInt32((locations["FW"].getY() - 25) * multpilierY) + 25);
                        Boomerang.Location = new System.Drawing.Point(Convert.ToInt32(locations["Boomerang"].getX() * multiplierX), Convert.ToInt32((locations["Boomerang"].getY() - 25) * multpilierY) + 25);
                        Lens.Location = new System.Drawing.Point(Convert.ToInt32(locations["Lens"].getX() * multiplierX), Convert.ToInt32((locations["Lens"].getY() - 25) * multpilierY) + 25);
                        MagicBeans.Location = new System.Drawing.Point(Convert.ToInt32(locations["MagicBeans"].getX() * multiplierX), Convert.ToInt32((locations["MagicBeans"].getY() - 25) * multpilierY) + 25);
                        Hammer.Location = new System.Drawing.Point(Convert.ToInt32(locations["Hammer"].getX() * multiplierX), Convert.ToInt32((locations["Hammer"].getY() - 25) * multpilierY) + 25);
                        LightArrows.Location = new System.Drawing.Point(Convert.ToInt32(locations["LightArrows"].getX() * multiplierX), Convert.ToInt32((locations["LightArrows"].getY() - 25) * multpilierY) + 25);
                        NayrusLove.Location = new System.Drawing.Point(Convert.ToInt32(locations["NayrusLove"].getX() * multiplierX), Convert.ToInt32((locations["NayrusLove"].getY() - 25) * multpilierY) + 25);
                        Bottle1.Location = new System.Drawing.Point(Convert.ToInt32(locations["Bottle1"].getX() * multiplierX), Convert.ToInt32((locations["Bottle1"].getY() - 25) * multpilierY) + 25);
                        Bottle2.Location = new System.Drawing.Point(Convert.ToInt32(locations["Bottle2"].getX() * multiplierX), Convert.ToInt32((locations["Bottle2"].getY() - 25) * multpilierY) + 25);
                        Bottle3.Location = new System.Drawing.Point(Convert.ToInt32(locations["Bottle3"].getX() * multiplierX), Convert.ToInt32((locations["Bottle3"].getY() - 25) * multpilierY) + 25);
                        Bottle4.Location = new System.Drawing.Point(Convert.ToInt32(locations["Bottle4"].getX() * multiplierX), Convert.ToInt32((locations["Bottle4"].getY() - 25) * multpilierY) + 25);
                        ChildTrade.Location = new System.Drawing.Point(Convert.ToInt32(locations["ChildTrade"].getX() * multiplierX), Convert.ToInt32((locations["ChildTrade"].getY() - 25) * multpilierY) + 25);
                        AdultTrade.Location = new System.Drawing.Point(Convert.ToInt32(locations["AdultTrade"].getX() * multiplierX), Convert.ToInt32((locations["AdultTrade"].getY() - 25) * multpilierY) + 25);
                        Song1.Location = new System.Drawing.Point(Convert.ToInt32(locations["Song1"].getX() * multiplierX), Convert.ToInt32((locations["Song1"].getY() - 25) * multpilierY) + 25);
                        Song2.Location = new System.Drawing.Point(Convert.ToInt32(locations["Song2"].getX() * multiplierX), Convert.ToInt32((locations["Song2"].getY() - 25) * multpilierY) + 25);
                        Song3.Location = new System.Drawing.Point(Convert.ToInt32(locations["Song3"].getX() * multiplierX), Convert.ToInt32((locations["Song3"].getY() - 25) * multpilierY) + 25);
                        Song4.Location = new System.Drawing.Point(Convert.ToInt32(locations["Song4"].getX() * multiplierX), Convert.ToInt32((locations["Song4"].getY() - 25) * multpilierY) + 25);
                        Song5.Location = new System.Drawing.Point(Convert.ToInt32(locations["Song5"].getX() * multiplierX), Convert.ToInt32((locations["Song5"].getY() - 25) * multpilierY) + 25);
                        Song6.Location = new System.Drawing.Point(Convert.ToInt32(locations["Song6"].getX() * multiplierX), Convert.ToInt32((locations["Song6"].getY() - 25) * multpilierY) + 25);
                        Minuet.Location = new System.Drawing.Point(Convert.ToInt32(locations["Minuet"].getX() * multiplierX), Convert.ToInt32((locations["Minuet"].getY() - 25) * multpilierY) + 25);
                        Bolero.Location = new System.Drawing.Point(Convert.ToInt32(locations["Bolero"].getX() * multiplierX), Convert.ToInt32((locations["Bolero"].getY() - 25) * multpilierY) + 25);
                        Serenade.Location = new System.Drawing.Point(Convert.ToInt32(locations["Serenade"].getX() * multiplierX), Convert.ToInt32((locations["Serenade"].getY() - 25) * multpilierY) + 25);
                        Requiem.Location = new System.Drawing.Point(Convert.ToInt32(locations["Requiem"].getX() * multiplierX), Convert.ToInt32((locations["Requiem"].getY() - 25) * multpilierY) + 25);
                        Nocturne.Location = new System.Drawing.Point(Convert.ToInt32(locations["Nocturne"].getX() * multiplierX), Convert.ToInt32((locations["Nocturne"].getY() - 25) * multpilierY) + 25);
                        Prelude.Location = new System.Drawing.Point(Convert.ToInt32(locations["Prelude"].getX() * multiplierX), Convert.ToInt32((locations["Prelude"].getY() - 25) * multpilierY) + 25);
                        LightMed.Location = new System.Drawing.Point(Convert.ToInt32(locations["LightMed"].getX() * multiplierX), Convert.ToInt32((locations["LightMed"].getY() - 25) * multpilierY) + 25);
                        ForestMed.Location = new System.Drawing.Point(Convert.ToInt32(locations["ForestMed"].getX() * multiplierX), Convert.ToInt32((locations["ForestMed"].getY() - 25) * multpilierY) + 25);
                        FireMed.Location = new System.Drawing.Point(Convert.ToInt32(locations["FireMed"].getX() * multiplierX), Convert.ToInt32((locations["FireMed"].getY() - 25) * multpilierY) + 25);
                        WaterMed.Location = new System.Drawing.Point(Convert.ToInt32(locations["WaterMed"].getX() * multiplierX), Convert.ToInt32((locations["WaterMed"].getY() - 25) * multpilierY) + 25);
                        SpiritMed.Location = new System.Drawing.Point(Convert.ToInt32(locations["SpiritMed"].getX() * multiplierX), Convert.ToInt32((locations["SpiritMed"].getY() - 25) * multpilierY) + 25);
                        ShadowMed.Location = new System.Drawing.Point(Convert.ToInt32(locations["ShadowMed"].getX() * multiplierX), Convert.ToInt32((locations["ShadowMed"].getY() - 25) * multpilierY) + 25);
                        HP_.Location = new System.Drawing.Point(Convert.ToInt32(locations["HP_"].getX() * multiplierX), Convert.ToInt32((locations["HP_"].getY() - 25) * multpilierY) + 25);
                        StoneOfAgony.Location = new System.Drawing.Point(Convert.ToInt32(locations["StoneOfAgony"].getX() * multiplierX), Convert.ToInt32((locations["StoneOfAgony"].getY() - 25) * multpilierY) + 25);
                        GerudoCard.Location = new System.Drawing.Point(Convert.ToInt32(locations["GerudoCard"].getX() * multiplierX), Convert.ToInt32((locations["GerudoCard"].getY() - 25) * multpilierY) + 25);
                        SkullCount_Label.Location = new System.Drawing.Point(Convert.ToInt32(locations["SkullCount_Label"].getX() * multiplierX), Convert.ToInt32((locations["SkullCount_Label"].getY() - 25) * multpilierY) + 25);
                        Kokiri.Location = new System.Drawing.Point(Convert.ToInt32(locations["Kokiri"].getX() * multiplierX), Convert.ToInt32((locations["Kokiri"].getY() - 25) * multpilierY) + 25);
                        Goron.Location = new System.Drawing.Point(Convert.ToInt32(locations["Goron"].getX() * multiplierX), Convert.ToInt32((locations["Goron"].getY() - 25) * multpilierY) + 25);
                        Zora.Location = new System.Drawing.Point(Convert.ToInt32(locations["Zora"].getX() * multiplierX), Convert.ToInt32((locations["Zora"].getY() - 25) * multpilierY) + 25);
                        KokiriBoots.Location = new System.Drawing.Point(Convert.ToInt32(locations["KokiriBoots"].getX() * multiplierX), Convert.ToInt32((locations["KokiriBoots"].getY() - 25) * multpilierY) + 25);
                        IronBoots.Location = new System.Drawing.Point(Convert.ToInt32(locations["IronBoots"].getX() * multiplierX), Convert.ToInt32((locations["IronBoots"].getY() - 25) * multpilierY) + 25);
                        HoverBoots.Location = new System.Drawing.Point(Convert.ToInt32(locations["HoverBoots"].getX() * multiplierX), Convert.ToInt32((locations["HoverBoots"].getY() - 25) * multpilierY) + 25);
                        KokiriTunic.Location = new System.Drawing.Point(Convert.ToInt32(locations["KokiriTunic"].getX() * multiplierX), Convert.ToInt32((locations["KokiriTunic"].getY() - 25) * multpilierY) + 25);
                        GoronTunic.Location = new System.Drawing.Point(Convert.ToInt32(locations["GoronTunic"].getX() * multiplierX), Convert.ToInt32((locations["GoronTunic"].getY() - 25) * multpilierY) + 25);
                        ZoraTunic.Location = new System.Drawing.Point(Convert.ToInt32(locations["ZoraTunic"].getX() * multiplierX), Convert.ToInt32((locations["ZoraTunic"].getY() - 25) * multpilierY) + 25);
                        DekuShield.Location = new System.Drawing.Point(Convert.ToInt32(locations["DekuShield"].getX() * multiplierX), Convert.ToInt32((locations["DekuShield"].getY() - 25) * multpilierY) + 25);
                        HylianShield.Location = new System.Drawing.Point(Convert.ToInt32(locations["HylianShield"].getX() * multiplierX), Convert.ToInt32((locations["HylianShield"].getY() - 25) * multpilierY) + 25);
                        MirrorShield.Location = new System.Drawing.Point(Convert.ToInt32(locations["MirrorShield"].getX() * multiplierX), Convert.ToInt32((locations["MirrorShield"].getY() - 25) * multpilierY) + 25);
                        KokiriSword.Location = new System.Drawing.Point(Convert.ToInt32(locations["KokiriSword"].getX() * multiplierX), Convert.ToInt32((locations["KokiriSword"].getY() - 25) * multpilierY) + 25);
                        MasterSword.Location = new System.Drawing.Point(Convert.ToInt32(locations["MasterSword"].getX() * multiplierX), Convert.ToInt32((locations["MasterSword"].getY() - 25) * multpilierY) + 25);
                        BigGoronSword.Location = new System.Drawing.Point(Convert.ToInt32(locations["BigGoronSword"].getX() * multiplierX), Convert.ToInt32((locations["BigGoronSword"].getY() - 25) * multpilierY) + 25);
                        GoronBracelet.Location = new System.Drawing.Point(Convert.ToInt32(locations["GoronBracelet"].getX() * multiplierX), Convert.ToInt32((locations["GoronBracelet"].getY() - 25) * multpilierY) + 25);
                        SilverScale.Location = new System.Drawing.Point(Convert.ToInt32(locations["SilverScale"].getX() * multiplierX), Convert.ToInt32((locations["SilverScale"].getY() - 25) * multpilierY) + 25);
                        BombBag.Location = new System.Drawing.Point(Convert.ToInt32(locations["BombBag"].getX() * multiplierX), Convert.ToInt32((locations["BombBag"].getY() - 25) * multpilierY) + 25);
                }

                private void DekuStick_Click(object sender, EventArgs e)
                {
                        updateIcon(DekuStick, (MouseEventArgs)e);
                }

                private void DekuNut_Click(object sender, EventArgs e)
                {
                        updateIcon(DekuNut, (MouseEventArgs)e);
                }

                private void Bombs_Click(object sender, EventArgs e)
                {
                        updateIcon(Bombs, (MouseEventArgs)e);
                        if (itemLevels["Bombs"] != 0)
                        {
                                BombBag.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("BombBag" + itemLevels["Bombs"].ToString() + "_64");
                        }
                        else
                        {
                                BombBag.BackgroundImage = null;
                        }
                }

                private void Bow_Click(object sender, EventArgs e)
                {
                        updateIcon(Bow, (MouseEventArgs)e);
                        if (itemLevels["Bow"] != 0)
                        {
                                //Quiver.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Quiver" + itemLevels["Bow"].ToString() + "_64");
                        }
                        else
                        {
                                Quiver.BackgroundImage = null;
                        }
                }

                private void FireArrows_Click(object sender, EventArgs e)
                {
                        updateIcon(FireArrows, (MouseEventArgs)e);
                }

                private void DinsFire_Click(object sender, EventArgs e)
                {
                        updateIcon(DinsFire, (MouseEventArgs)e);
                }

                private void Slingshot_Click(object sender, EventArgs e)
                {
                        updateIcon(Slingshot, (MouseEventArgs)e);
                        if (itemLevels["Slingshot"] != 0 )
                        {
                                //SeedBag.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("SeedBag" + itemLevels["Slingshot"].ToString() + "_64");
                        }
                        else
                        {
                                SeedBag.BackgroundImage = null;
                        }
                }

                private void FairyOcarina_Click(object sender, EventArgs e)
                {
                        updateIcon(FairyOcarina, (MouseEventArgs)e);
                }

                private void Chus_Click(object sender, EventArgs e)
                {
                        updateIcon(Chus, (MouseEventArgs)e);
                }

                private void Hookshot_Click(object sender, EventArgs e)
                {
                        updateIcon(Hookshot, (MouseEventArgs)e);
                }

                private void IceArrows_Click(object sender, EventArgs e)
                {
                        updateIcon(IceArrows, (MouseEventArgs)e);
                }

                private void FW_Click(object sender, EventArgs e)
                {
                        updateIcon(FW, (MouseEventArgs)e);
                }

                private void Boomerang_Click(object sender, EventArgs e)
                {
                        updateIcon(Boomerang, (MouseEventArgs)e);
                }

                private void Lens_Click(object sender, EventArgs e)
                {
                        updateIcon(Lens, (MouseEventArgs)e);
                }

                private void MagicBeans_Click(object sender, EventArgs e)
                {
                        updateIcon(MagicBeans, (MouseEventArgs)e);
                }

                private void Hammer_Click(object sender, EventArgs e)
                {
                        updateIcon(Hammer, (MouseEventArgs)e);
                }

                private void LightArrows_Click(object sender, EventArgs e)
                {
                        updateIcon(LightArrows, (MouseEventArgs)e);
                }

                private void NayrusLove_Click(object sender, EventArgs e)
                {
                        updateIcon(NayrusLove, (MouseEventArgs)e);
                }

                private void Bottle1_Click(object sender, EventArgs e)
                {
                        updateIcon(Bottle1, (MouseEventArgs)e);
                }

                private void Bottle2_Click(object sender, EventArgs e)
                {
                        updateIcon(Bottle2, (MouseEventArgs)e);
                }

                private void Bottle3_Click(object sender, EventArgs e)
                {
                        updateIcon(Bottle3, (MouseEventArgs)e);
                }

                private void Bottle4_Click(object sender, EventArgs e)
                {
                        updateIcon(Bottle4, (MouseEventArgs)e);
                }

                private void StoneOfAgony_Click(object sender, EventArgs e)
                {
                        updateIcon(StoneOfAgony, (MouseEventArgs)e);
                }

                private void GerudoCard_Click(object sender, EventArgs e)
                {
                        updateIcon(GerudoCard, (MouseEventArgs)e);
                }

                private void Song1_Click(object sender, EventArgs e)
                {
                        updateIcon(Song1, (MouseEventArgs)e);
                }

                private void Song2_Click(object sender, EventArgs e)
                {
                        updateIcon(Song2, (MouseEventArgs)e);
                }

                private void Song3_Click(object sender, EventArgs e)
                {
                        updateIcon(Song3, (MouseEventArgs)e);
                }

                private void Song4_Click(object sender, EventArgs e)
                {
                        updateIcon(Song4, (MouseEventArgs)e);
                }

                private void Song5_Click(object sender, EventArgs e)
                {
                        updateIcon(Song5, (MouseEventArgs)e);
                }

                private void Song6_Click(object sender, EventArgs e)
                {
                        updateIcon(Song6, (MouseEventArgs)e);
                }

                private void SkullCount_Label_Click(object sender, EventArgs e)
                {
                        MouseEventArgs me = (MouseEventArgs)e;
                        if (me.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                                if (skullCount < 100)
                                {
                                        skullCount++;
                                }
                        }
                        else
                        {
                                if (skullCount > 0)
                                {
                                        skullCount--;
                                }
                        }
                        if (skullCount == 100)
                        {
                                SkullCount_Label.ForeColor = Color.Green;
                        }
                        else
                        {
                                SkullCount_Label.ForeColor = Color.White;
                        }
                        SkullCount_Label.Text = skullCount.ToString();
                }

                private void ForestMed_Click(object sender, EventArgs e)
                {
                        updateIcon(ForestMed, (MouseEventArgs)e);
                }

                private void FireMed_Click(object sender, EventArgs e)
                {
                        updateIcon(FireMed, (MouseEventArgs)e);
                }

                private void WaterMed_Click(object sender, EventArgs e)
                {
                        updateIcon(WaterMed, (MouseEventArgs)e);
                }

                private void SpiritMed_Click(object sender, EventArgs e)
                {
                        updateIcon(SpiritMed, (MouseEventArgs)e);
                }

                private void ShadowMed_Click(object sender, EventArgs e)
                {
                        updateIcon(ShadowMed, (MouseEventArgs)e);
                }

                private void Kokiri_Click(object sender, EventArgs e)
                {
                        updateIcon(Kokiri, (MouseEventArgs)e);
                }

                private void Goron_Click(object sender, EventArgs e)
                {
                        updateIcon(Goron, (MouseEventArgs)e);
                }

                private void Zora_Click(object sender, EventArgs e)
                {
                        updateIcon(Zora, (MouseEventArgs)e);
                }

                private void Minuet_Click(object sender, EventArgs e)
                {
                        updateIcon(Minuet, (MouseEventArgs)e);
                }

                private void Bolero_Click(object sender, EventArgs e)
                {
                        updateIcon(Bolero, (MouseEventArgs)e);
                }

                private void Serenade_Click(object sender, EventArgs e)
                {
                        updateIcon(Serenade, (MouseEventArgs)e);
                }

                private void Requiem_Click(object sender, EventArgs e)
                {
                        updateIcon(Requiem, (MouseEventArgs)e);
                }

                private void Nocturne_Click(object sender, EventArgs e)
                {
                        updateIcon(Nocturne, (MouseEventArgs)e);
                }

                private void Prelude_Click(object sender, EventArgs e)
                {
                        updateIcon(Prelude, (MouseEventArgs)e);
                }

                private void HP__Click(object sender, EventArgs e)
                {
                        updateIcon(HP_, (MouseEventArgs)e);
                }

                private void IronBoots_Click(object sender, EventArgs e)
                {
                        updateIcon(IronBoots, (MouseEventArgs)e);
                }

                private void HoverBoots_Click(object sender, EventArgs e)
                {
                        updateIcon(HoverBoots, (MouseEventArgs)e);
                }

                private void KokiriTunic_Click(object sender, EventArgs e)
                {
                        
                }

                private void GoronTunic_Click(object sender, EventArgs e)
                {
                        updateIcon(GoronTunic, (MouseEventArgs)e);
                }

                private void ZoraTunic_Click(object sender, EventArgs e)
                {
                        updateIcon(ZoraTunic, (MouseEventArgs)e);
                }

                private void DekuShield_Click(object sender, EventArgs e)
                {
                        updateIcon(DekuShield, (MouseEventArgs)e);
                }

                private void HylianShield_Click(object sender, EventArgs e)
                {
                        updateIcon(HylianShield, (MouseEventArgs)e);
                }

                private void MirrorShield_Click(object sender, EventArgs e)
                {
                        updateIcon(MirrorShield, (MouseEventArgs)e);
                }

                private void KokiriSword_Click(object sender, EventArgs e)
                {
                        updateIcon(KokiriSword, (MouseEventArgs)e);
                }

                private void MasterSword_Click(object sender, EventArgs e)
                {
                        updateIcon(MasterSword, (MouseEventArgs)e);
                }

                private void BigGoronSword_Click(object sender, EventArgs e)
                {
                        updateIcon(BigGoronSword, (MouseEventArgs)e);
                }

                private void SilverScale_Click(object sender, EventArgs e)
                {
                        updateIcon(SilverScale, (MouseEventArgs)e);
                }

                private void GoronBracelet_Click(object sender, EventArgs e)
                {
                        updateIcon(GoronBracelet, (MouseEventArgs)e);
                }

                private void AdultTrade_Click(object sender, EventArgs e)
                {
                        updateIcon(AdultTrade, (MouseEventArgs)e);
                }

                private void ChildTrade_Click(object sender, EventArgs e)
                {
                        updateIcon(ChildTrade, (MouseEventArgs)e);
                }

                private void BombBag_Click(object sender, EventArgs e)
                {
                        updateIcon(Bombs, (MouseEventArgs)e);
                        if (itemLevels["Bombs"] != 0)
                        {
                                BombBag.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("BombBag" + itemLevels["Bombs"].ToString() + "_64");
                        }
                        else
                        {
                                BombBag.BackgroundImage = null;
                        }
                }

                private void bothToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        double mult = 1;
                        int heightFix = 35;
                        if (currentType != "Box")
                        {
                                bothToolStripMenuItem.Checked = true;
                                horizontalToolStripMenuItem.Checked = false;
                                singleToolStripMenuItem.Checked = false;

                                if (size == 64)
                                {
                                        mult = 1;
                                        heightFix = 25;
                                }
                                else if (size == 48)
                                {
                                        mult = 0.75;
                                }
                                else if (size == 42)
                                {
                                        mult = 0.66;
                                }

                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleMiddleCover_" + size.ToString());
                                TransformingCover_Label.Visible = true;

                                this.Width = Convert.ToInt32(905 * mult);
                                this.Height = Convert.ToInt32((780 - 25) * mult + heightFix);

                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleMiddle_" + size.ToString());

                                updateLocations(BoxPos, mult, mult);

                                if (currentType == "Single")
                                {
                                        visibleScreen("Equip", true);
                                        visibleScreen("Item", true);
                                        visibleScreen("Quest", true);
                                        R.Visible = false;
                                        Z.Visible = false;
                                }

                                currentType = "Box";
                                CoverTimer.Enabled = true;
                        }
                }

                private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        double mult = 1;
                        int heightFix = 35;
                        if (currentType != "Horizontal")
                        {
                                bothToolStripMenuItem.Checked = false;
                                horizontalToolStripMenuItem.Checked = true;
                                singleToolStripMenuItem.Checked = false;

                                if (size == 64)
                                {
                                        mult = 1;
                                        heightFix = 25;
                                }
                                else if (size == 48)
                                {
                                        mult = 0.75;
                                }
                                else if (size == 42)
                                {
                                        mult = 0.66;
                                }

                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreenCover_" + size.ToString());
                                TransformingCover_Label.Visible = true;

                                this.Width = Convert.ToInt32(1448 * mult);
                                this.Height = Convert.ToInt32((420 - 25) * mult + heightFix);

                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_" + size.ToString());

                                updateLocations(HorPos, mult, mult);

                                if (currentType == "Single")
                                {
                                        visibleScreen("Equip", true);
                                        visibleScreen("Item", true);
                                        visibleScreen("Quest", true);
                                        R.Visible = false;
                                        Z.Visible = false;
                                }

                                currentType = "Horizontal";
                                //TransformingCover.Visible = false;
                                CoverTimer.Enabled = true;

                        }
                }

                private void singleToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        double mult = 1;
                        int heightFix = 35;
                        if (currentType != "Single")
                        {
                                bothToolStripMenuItem.Checked = false;
                                horizontalToolStripMenuItem.Checked = false;
                                singleToolStripMenuItem.Checked = true;

                                if (size == 64)
                                {
                                        mult = 1;
                                        heightFix = 25;
                                }
                                else if (size == 48)
                                {
                                        mult = 0.75;
                                }
                                else if (size == 42)
                                {
                                        mult = 0.66;
                                }
                                
                                this.Width = Convert.ToInt32(554 * mult);
                                this.Height = Convert.ToInt32((420 - 25) * mult + heightFix);

                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_" + size.ToString());

                                updateZR(mult);

                                visibleScreen("Equip", false);
                                visibleScreen("Quest", false);

                                updateLocations(HorPos, mult, mult);
                                updateLocations(SinglePos, mult, mult);

                                R.Visible = true;
                                Z.Visible = true;

                                currentType = "Single";
                                currentScreen = "Item";
                        }
                }

                private void updateZR(double mult)
                {

                        R.Width = Convert.ToInt32(24 * mult);
                        R.Height = Convert.ToInt32(32 * mult);
                        Z.Width = Convert.ToInt32(24 * mult);
                        Z.Height = Convert.ToInt32(32 * mult);

                        R.Location = new System.Drawing.Point(Convert.ToInt32(510 * mult), Convert.ToInt32((183 - 25) * mult + 25));
                        Z.Location = new System.Drawing.Point(Convert.ToInt32(2 * mult), Convert.ToInt32((178 - 25) * mult + 25));

                }

                private void visibleScreen(string screen, bool visible)
                {
                        if (screen == "Quest")
                        {
                                Song1.Visible = visible;
                                Song2.Visible = visible;
                                Song3.Visible = visible;
                                Song4.Visible = visible;
                                Song5.Visible = visible;
                                Song6.Visible = visible;
                                Minuet.Visible = visible;
                                Bolero.Visible = visible;
                                Serenade.Visible = visible;
                                Requiem.Visible = visible;
                                Nocturne.Visible = visible;
                                Prelude.Visible = visible;
                                SkullCount_Label.Visible = visible;
                                HP_.Visible = visible;
                                StoneOfAgony.Visible = visible;
                                GerudoCard.Visible = visible;
                                LightMed.Visible = visible;
                                ForestMed.Visible = visible;
                                FireMed.Visible = visible;
                                WaterMed.Visible = visible;
                                SpiritMed.Visible = visible;
                                ShadowMed.Visible = visible;
                                Kokiri.Visible = visible;
                                Goron.Visible = visible;
                                Zora.Visible = visible;
                        }
                        else if (screen == "Item")
                        {
                                DekuStick.Visible = visible;
                                DekuNut.Visible = visible;
                                Bombs.Visible = visible;
                                Bow.Visible = visible;
                                DinsFire.Visible = visible;
                                Slingshot.Visible = visible;
                                Boomerang.Visible = visible;
                                FW.Visible = visible;
                                NayrusLove.Visible = visible;
                                Hammer.Visible = visible;
                                Bottle1.Visible = visible;
                                Bottle2.Visible = visible;
                                Bottle3.Visible = visible;
                                Bottle4.Visible = visible;
                                Lens.Visible = visible;
                                AdultTrade.Visible = visible;
                                ChildTrade.Visible = visible;
                                Hookshot.Visible = visible;
                                Chus.Visible = visible;
                                MagicBeans.Visible = visible;
                                FairyOcarina.Visible = visible;
                                FireArrows.Visible = visible;
                                IceArrows.Visible = visible;
                                LightArrows.Visible = visible;
                        }
                        else
                        {
                                KokiriBoots.Visible = visible;
                                IronBoots.Visible = visible;
                                HoverBoots.Visible = visible;
                                KokiriTunic.Visible = visible;
                                GoronTunic.Visible = visible;
                                ZoraTunic.Visible = visible;
                                DekuShield.Visible = visible;
                                HylianShield.Visible = visible;
                                MirrorShield.Visible = visible;
                                KokiriSword.Visible = visible;
                                MasterSword.Visible = visible;
                                BigGoronSword.Visible = visible;
                                SilverScale.Visible = visible;
                                GoronBracelet.Visible = visible;
                                BombBag.Visible = visible;
                        }
                }

                private void R_Click(object sender, EventArgs e)
                {
                        if (currentScreen == "Item")
                        {
                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenSingle_" + size.ToString());
                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenCover_" + size.ToString());
                                TransformingCover_Label.Visible = true;

                                visibleScreen("Item", false);
                                visibleScreen("Equip", false);
                                visibleScreen("Quest", true);

                                currentScreen = "Quest";
                        }
                        else if (currentScreen == "Quest")
                        {
                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenSingle_" + size.ToString());
                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenCover_" + size.ToString());
                                TransformingCover_Label.Visible = true;

                                visibleScreen("Item", false);
                                visibleScreen("Equip", true);
                                visibleScreen("Quest", false);

                                currentScreen = "Equip";
                        }
                        else
                        {
                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_" + size.ToString());
                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreenCover_" + size.ToString());
                                TransformingCover_Label.Visible = true;

                                visibleScreen("Item", true);
                                visibleScreen("Equip", false);
                                visibleScreen("Quest", false);

                                currentScreen = "Item";
                        }

                        CoverTimer.Enabled = true;
                }

                private void Z_Click(object sender, EventArgs e)
                {
                        if (currentScreen == "Equip")
                        {
                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenSingle_" + size.ToString());
                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenCover_" + size.ToString());
                                TransformingCover_Label.Visible = true;

                                visibleScreen("Item", false);
                                visibleScreen("Equip", false);
                                visibleScreen("Quest", true);

                                currentScreen = "Quest";
                        }
                        else if (currentScreen == "Item")
                        {
                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenSingle_" + size.ToString());
                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenCover_" + size.ToString());
                                TransformingCover_Label.Visible = true;

                                visibleScreen("Item", false);
                                visibleScreen("Equip", true);
                                visibleScreen("Quest", false);

                                currentScreen = "Equip";
                        }
                        else
                        {

                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_" + size.ToString());
                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreenCover_" + size.ToString());
                                TransformingCover_Label.Visible = true;

                                visibleScreen("Item", true);
                                visibleScreen("Equip", false);
                                visibleScreen("Quest", false);

                                currentScreen = "Item";
                        }
                        CoverTimer.Enabled = true;
                }

                private void updateSizes()
                {
                        DekuStick.Width = size;
                        DekuStick.Height = size;
                        DekuNut.Width = size;
                        DekuNut.Height = size;
                        Bombs.Width = size;
                        Bombs.Height = size;
                        Bow.Width = size;
                        Bow.Height = size;
                        DinsFire.Width = size;
                        DinsFire.Height = size;
                        FireArrows.Width = size;
                        FireArrows.Height = size;
                        FairyOcarina.Width = size;
                        FairyOcarina.Height = size;
                        Boomerang.Height = size;
                        Boomerang.Width = size;
                        Hammer.Height = size;
                        Hammer.Width = size;
                        Slingshot.Width = size;
                        Slingshot.Height = size;
                        Bottle1.Width = size;
                        Bottle1.Height = size;
                        Bottle2.Width = size;
                        Bottle2.Height = size;
                        Bottle3.Width = size;
                        Bottle3.Height = size;
                        Bottle4.Width = size;
                        Bottle4.Height = size;
                        Hookshot.Width = size;
                        Hookshot.Height = size;
                        Lens.Height = size;
                        Lens.Width = size;
                        FW.Width = size;
                        FW.Height = size;
                        NayrusLove.Width = size;
                        NayrusLove.Height = size;
                        Chus.Height = size;
                        Chus.Width = size;
                        MagicBeans.Width = size;
                        MagicBeans.Height = size;
                        AdultTrade.Width = size;
                        AdultTrade.Height = size;
                        ChildTrade.Height = size;
                        ChildTrade.Width = size;
                        LightArrows.Width = size;
                        LightArrows.Height = size;
                        IceArrows.Width = size;
                        IceArrows.Height = size;
                        StoneOfAgony.Width = size48;
                        StoneOfAgony.Height = size48;
                        GerudoCard.Width = size48;
                        GerudoCard.Height = size48;
                        Song1.Width = size32;
                        Song1.Height = size48;
                        Song2.Width = size32;
                        Song2.Height = size48;
                        Song3.Width = size32;
                        Song3.Height = size48;
                        Song4.Width = size32;
                        Song4.Height = size48;
                        Song5.Width = size32;
                        Song5.Height = size48;
                        Song6.Width = size32;
                        Song6.Height = size48;
                        HP_.Width = size96;
                        HP_.Height = size96;
                        Minuet.Width = size32;
                        Minuet.Height = size48;
                        Bolero.Width = size32;
                        Bolero.Height = size48;
                        Serenade.Width = size32;
                        Serenade.Height = size48;
                        Requiem.Width = size32;
                        Requiem.Height = size48;
                        Nocturne.Width = size32;
                        Nocturne.Height = size48;
                        Prelude.Width = size32;
                        Prelude.Height = size48;
                        LightMed.Width = size48;
                        LightMed.Height = size48;
                        ForestMed.Width = size48;
                        ForestMed.Height = size48;
                        FireMed.Width = size48;
                        FireMed.Height = size48;
                        ShadowMed.Width = size48;
                        ShadowMed.Height = size48;
                        WaterMed.Width = size48;
                        WaterMed.Height = size48;
                        SpiritMed.Width = size48;
                        SpiritMed.Height = size48;
                        Kokiri.Height = size48;
                        Kokiri.Width = size48;
                        Goron.Height = size48;
                        Goron.Width = size48;
                        Zora.Height = size48;
                        Zora.Width = size48;
                        KokiriBoots.Width = size;
                        KokiriBoots.Height = size;
                        IronBoots.Width = size;
                        IronBoots.Height = size;
                        HoverBoots.Width = size;
                        HoverBoots.Height = size;
                        KokiriTunic.Width = size;
                        KokiriTunic.Height = size;
                        GoronTunic.Width = size;
                        GoronTunic.Height = size;
                        ZoraTunic.Width = size;
                        ZoraTunic.Height = size;
                        DekuShield.Width = size;
                        DekuShield.Height = size;
                        HylianShield.Width = size;
                        HylianShield.Height = size;
                        MirrorShield.Width = size;
                        MirrorShield.Height = size;
                        KokiriSword.Width = size;
                        KokiriSword.Height = size;
                        MasterSword.Width = size;
                        MasterSword.Height = size;
                        BigGoronSword.Width = size;
                        BigGoronSword.Height = size;
                        SilverScale.Width = size;
                        SilverScale.Height = size;
                        GoronBracelet.Width = size;
                        GoronBracelet.Height = size;
                        BombBag.Width = size;
                        BombBag.Height = size;
                        SkullCount_Label.Height = size48;
                        SkullCount_Label.Width = size103;
                        SkullCount_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("Skulltula_" + size.ToString());
                        SkullCount_Label.Font = new Font(SkullCount_Label.Font.FontFamily, sizeFont);
                }

                private void smallToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        double mult = 1;
                        if (smallToolStripMenuItem.Checked == false)
                        {
                                //this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_48");
                                size = 48;
                                size32 = 24;
                                size48 = 36;
                                size96 = 72;
                                size103 = 77;
                                sizeFont = 14;
                                mult = 0.75;

                                if (currentType == "Horizontal")
                                {
                                        this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_48");
                                        TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreenCover_48");
                                        TransformingCover_Label.Visible = true;
                                        this.Width = 1090;
                                        this.Height = 330;
                                        updateLocations(HorPos, 0.75, 0.75);
                                }
                                else if (currentType == "Box")
                                {
                                        this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleMiddle_48");
                                        TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleMiddleCover_48");
                                        TransformingCover_Label.Visible = true;
                                        this.Width = 678;
                                        this.Height = 585;
                                        updateLocations(BoxPos, 0.75, 0.75);
                                }
                                else
                                {
                                        if (currentScreen == "Item")
                                        {
                                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_48");
                                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleCover_48");
                                                TransformingCover_Label.Visible = true;
                                        }
                                        else if (currentScreen == "Equip")
                                        {
                                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenSingle_48");
                                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenCover_48");
                                                TransformingCover_Label.Visible = true;
                                        }
                                        else
                                        {
                                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenSingle_48");
                                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenCover_48");
                                                TransformingCover_Label.Visible = true;
                                        }
                                        
                                        this.Width = 415;
                                        this.Height = 330;
                                        updateLocations(SinglePos, 0.75, 0.75);
                                }

                                updateSizes();

                                updateZR(mult);

                                mediumToolStripMenuItem.Checked = false;
                                smallToolStripMenuItem.Checked = true;
                                smallerToolStripMenuItem.Checked = false;

                                CoverTimer.Enabled = true;
                        }
                }

                private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        double mult = 1;
                        if (mediumToolStripMenuItem.Checked == false)
                        {
                                size = 64;
                                size32 = 32;
                                size48 = 48;
                                size96 = 96;
                                size103 = 103;
                                sizeFont = 19;
                                mult = 1;

                                if (currentType == "Horizontal")
                                {
                                        this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_64");
                                        TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreenCover_64");
                                        TransformingCover_Label.Visible = true;
                                        this.Width = 1448;
                                        this.Height = 420;
                                        updateLocations(HorPos);
                                }
                                else if (currentType == "Box")
                                {
                                        this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleMiddle_64");
                                        TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleMiddleCover_64");
                                        TransformingCover_Label.Visible = true;
                                        this.Width = 905;
                                        this.Height = 780;
                                        updateLocations(BoxPos);
                                }
                                else
                                {
                                        if (currentScreen == "Item")
                                        {
                                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_64");
                                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreenCover_64");
                                                TransformingCover_Label.Visible = true;
                                        }
                                        else if (currentScreen == "Equip")
                                        {
                                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenSingle_64");
                                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenCover_64");
                                                TransformingCover_Label.Visible = true;
                                        }
                                        else
                                        {
                                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenSingle_64");
                                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenCover_64");
                                                TransformingCover_Label.Visible = true;
                                        }
                                        
                                        this.Width = 554;
                                        this.Height = 420;
                                        updateLocations(SinglePos);
                                }

                                updateSizes();

                                updateZR(mult);

                                smallToolStripMenuItem.Checked = false;
                                mediumToolStripMenuItem.Checked = true;
                                smallerToolStripMenuItem.Checked = false;

                                CoverTimer.Enabled = true;
                        }
                }

                private void smallerToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        double mult = 1;
                        if (smallerToolStripMenuItem.Checked == false)
                        {
                                size = 42;
                                size32 = 21;
                                size48 = 31;
                                size96 = 63;
                                size103 = 67;
                                sizeFont = 12;
                                mult = 0.66;

                                if (currentType == "Horizontal")
                                {
                                        this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_42");
                                        TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreenCover_42");
                                        TransformingCover_Label.Visible = true;
                                        this.Width = 955;
                                        this.Height = 295;
                                        updateLocations(HorPos, mult, mult);
                                }
                                else if (currentType == "Box")
                                {
                                        this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleMiddle_42");
                                        TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleMiddleCover_42");
                                        TransformingCover_Label.Visible = true;
                                        this.Width = 597;
                                        this.Height = 523;
                                        updateLocations(BoxPos, mult, mult);
                                }
                                //if type = single
                                else
                                {
                                        if (currentScreen == "Item")
                                        {
                                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreen_42");
                                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("TripleScreenCover_42");
                                                TransformingCover_Label.Visible = true;
                                        }
                                        else if (currentScreen == "Equip")
                                        {
                                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenSingle_42");
                                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("EquipmentScreenCover_42");
                                                TransformingCover_Label.Visible = true;
                                        }
                                        else
                                        {
                                                this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenSingle_42");
                                                TransformingCover_Label.Image = (Image)Properties.Resources.ResourceManager.GetObject("QuestScreenCover_42");
                                                TransformingCover_Label.Visible = true;
                                        }

                                        this.Width = 365;
                                        this.Height = 295;
                                        updateLocations(SinglePos, mult, mult);
                                }

                                updateSizes();

                                updateZR(mult);

                                smallToolStripMenuItem.Checked = false;
                                mediumToolStripMenuItem.Checked = false;
                                smallerToolStripMenuItem.Checked = true;

                                CoverTimer.Enabled = true;
                        }
                }

                private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
                {

                }

                private void CoverTimer_Tick(object sender, EventArgs e)
                {
                        TransformingCover_Label.Visible = false;
                }

                private void LightMed_Click(object sender, EventArgs e)
                {
                        updateIcon(LightMed, (MouseEventArgs)e);
                }

                private void resetToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset the tracker?", "Tracker Reseter", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                                //set each item level to 0
                                itemLevelsNew();

                                //change each item on screen to the "none" image
                                clearIcons();

                                //change font color for skull count to white
                                SkullCount_Label.ForeColor = Color.White;
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                }

                private void clearIcons()
                {
                        DekuStick.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("DekuStick_none_64");
                        DekuNut.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("DekuNut_none_64");
                        Bombs.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Bombs" + "_none_64");
                        Bow.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Bow" + "_none_64");
                        FireArrows.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("FireArrows" + "_none_64");
                        DinsFire.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("DinsFire" + "_none_64");
                        Slingshot.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Slingshot" + "_none_64");
                        Boomerang.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Boomerang" + "_none_64");
                        FairyOcarina.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("FairyOcarina" + "_none_64");
                        Hammer.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Hammer" + "_none_64");
                        IceArrows.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("IceArrows" + "_none_64");
                        LightArrows.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("LightArrows" + "_none_64");
                        NayrusLove.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NayrusLove" + "_none_64");
                        FW.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("FW" + "_none_64");
                        Chus.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Chus" + "_none_64");
                        Hookshot.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Hookshot" + "_none_64");
                        Lens.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Lens" + "_none_64");
                        MagicBeans.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("MagicBeans" + "_none_64");
                        Bottle1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Bottle" + "_none_64");
                        Bottle2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Bottle" + "_none_64");
                        Bottle3.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Bottle" + "_none_64");
                        Bottle4.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Bottle" + "_none_64");
                        ChildTrade.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("ChildTrade" + "_none_64");
                        AdultTrade.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("AdultTrade" + "_none_64");
                        GerudoCard.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("GerudoCard" + "_none_64");
                        StoneOfAgony.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("StoneOfAgony" + "_none_64");
                        Song1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Song1" + "_none_64");
                        Song2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Song2" + "_none_64");
                        Song3.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Song3" + "_none_64");
                        Song4.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Song4" + "_none_64");
                        Song5.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Song5" + "_none_64");
                        Song6.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Song6" + "_none_64");
                        Bolero.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Bolero" + "_none_64");
                        Minuet.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Minuet" + "_none_64");
                        Prelude.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Prelude" + "_none_64");
                        Serenade.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Serenade" + "_none_64");
                        Requiem.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Requiem" + "_none_64");
                        Nocturne.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Nocturne" + "_none_64");
                        LightMed.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("LightMed" + "_none_64");
                        ForestMed.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("ForestMed" + "_none_64");
                        FireMed.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("FireMed" + "_none_64");
                        WaterMed.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("WaterMed" + "_none_64");
                        SpiritMed.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("SpiritMed" + "_none_64");
                        ShadowMed.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("ShadowMed" + "_none_64");
                        HP_.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("HP_" + "_none_64");
                        Kokiri.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Kokiri" + "_none_64");
                        Goron.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Goron" + "_none_64");
                        Zora.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Zora" + "_none_64");
                        skullCount = 0;
                        SkullCount_Label.Text = "0";
                        IronBoots.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("IronBoots" + "_none_64");
                        HoverBoots.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("HoverBoots" + "_none_64");
                        GoronTunic.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("GoronTunic" + "_none_64");
                        ZoraTunic.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("ZoraTunic" + "_none_64");
                        DekuShield.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("DekuShield" + "_none_64");
                        HylianShield.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("HylianShield" + "_none_64");
                        MirrorShield.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("MirrorShield" + "_none_64");
                        KokiriSword.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("KokiriSword" + "_none_64");
                        MasterSword.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("MasterSword" + "_none_64");
                        BigGoronSword.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("BigGoronSword" + "_none_64");
                        SilverScale.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("SilverScale" + "_none_64");
                        GoronBracelet.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("GoronBracelet" + "_none_64");
                        BombBag.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("BombBag" + "_none_64");
                }

                private void itemLevelsNew()
                {
                        HPCount = 0;
                        itemLevels = new Dictionary<string, int>() {
                                {"DekuStick", 0 },
                                {"DekuNut", 0 },
                                {"Bombs", 0 },
                                {"Bow", 0 },
                                {"FireArrows", 0 },
                                {"DinsFire", 0 },
                                {"Slingshot", 0 },
                                {"FairyOcarina", 0 },
                                {"Chus", 0 },
                                {"Hookshot", 0 },
                                {"IceArrows", 0 },
                                {"FW", 0 },
                                {"Boomerang", 0 },
                                {"Lens", 0 },
                                {"MagicBeans", 0 },
                                {"Hammer", 0 },
                                {"LightArrows", 0 },
                                {"NayrusLove", 0 },
                                {"Bottle1", 0 },
                                {"Bottle2", 0 },
                                {"Bottle3", 0 },
                                {"Bottle4", 0 },
                                {"ChildTrade", 0 },
                                {"AdultTrade", 0 },
                                {"StoneOfAgony", 0 },
                                {"GerudoCard", 0 },
                                {"HP_", 0 },
                                {"Song1", 0 },
                                {"Song2", 0 },
                                {"Song3", 0 },
                                {"Song4", 0 },
                                {"Song5", 0 },
                                {"Song6", 0 },
                                {"Minuet", 0 },
                                {"Bolero", 0 },
                                {"Serenade", 0 },
                                {"Requiem", 0 },
                                {"Nocturne", 0 },
                                {"Prelude", 0 },
                                {"LightMed", 0 },
                                {"ForestMed", 0 },
                                {"FireMed", 0 },
                                {"WaterMed", 0 },
                                {"SpiritMed", 0 },
                                {"ShadowMed", 0 },
                                {"Kokiri", 0 },
                                {"Goron", 0 },
                                {"Zora", 0 },
                                {"IronBoots", 0 },
                                {"HoverBoots", 0 },
                                {"GoronTunic", 0 },
                                {"ZoraTunic", 0 },
                                {"DekuShield", 0 },
                                {"HylianShield", 0 },
                                {"MirrorShield", 0 },
                                {"KokiriSword", 0 },
                                {"MasterSword", 0 },
                                {"BigGoronSword", 0 },
                                {"SilverScale", 0 },
                                {"GoronBracelet", 0 }
                        };
                }
        }
}
