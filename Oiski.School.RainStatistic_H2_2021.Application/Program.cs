using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using System;

namespace Oiski.School.RainStatistic_H2_2021.Application
{
    class Program
    {
        static void Main (string[] args)
        {
            #region Engine Setup
            Console.SetWindowSize(80, 40);
            ColorRenderer renderer = new ColorRenderer();
            renderer.DefaultColor = new RenderColor(ConsoleColor.Red, ConsoleColor.Black);
            OiskiEngine.ChangeRenderer(renderer);
            OiskiEngine.Run();
            #endregion

            RaindropContainer container = null;

            RenderColor textColor = new RenderColor(ConsoleColor.Cyan, ConsoleColor.Black);
            RenderColor borderColor = new RenderColor(ConsoleColor.DarkBlue, ConsoleColor.Black);

            #region Main Menu
            Menu mainMenu = new Menu();

            #region Header
            ColorableLabel header = new ColorableLabel("Oiski's Raindrop Statistic", textColor, borderColor, _attachToEngine: false);
            header.Position = new Vector2(Vector2.CenterX(header.Size.x), 5);

            mainMenu.Controls.AddControl(header);
            #endregion

            #region Data Menu Button
            ColorableOption toDataMenu = new ColorableOption("Data Section", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = Vector2.Zero
            };
            toDataMenu.BorderStyle(BorderArea.Horizontal, '~');
            toDataMenu.Position = new Vector2(Vector2.CenterX(toDataMenu.Size.x), header.Position.y + 6);

            toDataMenu.OnSelect += (s) =>
            {
                #region Hide Main Menu
                OiskiEngine.Input.ResetSlection();
                OiskiEngine.Input.ResetInput();
                mainMenu.Show(false);
                #endregion

                //  Show Data Menu
            };

            mainMenu.Controls.AddControl(toDataMenu);
            #endregion

            #region Result Menu Button
            ColorableOption toResultMenu = new ColorableOption("Result Section", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 1)
            };
            toResultMenu.Position = new Vector2(Vector2.CenterX(toResultMenu.Size.x), toDataMenu.Position.y + 6);

            toResultMenu.OnSelect += (s) =>
            {
                #region Hide Main Menu
                OiskiEngine.Input.ResetSlection();
                OiskiEngine.Input.ResetInput();
                mainMenu.Show(false);
                #endregion

                //  Show Result Menu
            };

            mainMenu.Controls.AddControl(toResultMenu);
            #endregion

            #region Exit Button
            ColorableOption exit = new ColorableOption("Exit", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 2)
            };
            exit.Position = new Vector2(Vector2.CenterX(exit.Size.x), toResultMenu.Position.y + 6);

            exit.OnSelect += (s) =>
            {
                Environment.Exit(0);
            };

            mainMenu.Controls.AddControl(exit);
            #endregion

            mainMenu.Show();
            #endregion

            #region Data Menu
            //  Establish Data Menu
            #endregion

            #region Result Menu
            //  Establish Result Menu
            #endregion
        }
    }
}