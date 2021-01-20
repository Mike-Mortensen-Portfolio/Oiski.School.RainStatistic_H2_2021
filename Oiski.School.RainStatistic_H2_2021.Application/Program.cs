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

            Menu mainMenu = null;
            Menu dataMenu = null;
            Menu resultMenu = null;

            RaindropContainer container = null;
            int valueCounter = 1;

            RenderColor textColor = new RenderColor(ConsoleColor.Cyan, ConsoleColor.Black);
            RenderColor borderColor = new RenderColor(ConsoleColor.DarkBlue, ConsoleColor.Black);

            #region Main Menu
            mainMenu = new Menu();

            #region Header
            ColorableLabel mainMenuHeader = new ColorableLabel("Oiski's Raindrop Statistic", textColor, borderColor, _attachToEngine: false);
            mainMenuHeader.Position = new Vector2(Vector2.CenterX(mainMenuHeader.Size.x), 5);

            mainMenu.Controls.AddControl(mainMenuHeader);
            #endregion

            #region Data Menu Button
            ColorableOption toDataMenu = new ColorableOption("Data Section", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = Vector2.Zero
            };
            toDataMenu.BorderStyle(BorderArea.Horizontal, '~');
            toDataMenu.Position = new Vector2(Vector2.CenterX(toDataMenu.Size.x), mainMenuHeader.Position.y + 6);

            toDataMenu.OnSelect += (s) =>
            {
                #region Hide Main Menu
                OiskiEngine.Input.ResetSlection();
                OiskiEngine.Input.ResetInput();
                mainMenu.Show(false);
                #endregion

                dataMenu.Controls.GetSelectableControls[0].BorderStyle(BorderArea.Horizontal, '~');
                dataMenu.Show();
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

                dataMenu.Controls.GetSelectableControls[0].BorderStyle(BorderArea.Horizontal, '~');
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
            dataMenu = new Menu();

            #region Header
            ColorableLabel dataMenuHeader = new ColorableLabel("Oiski's Data Section", textColor, borderColor, _attachToEngine: false);
            dataMenuHeader.Position = new Vector2(Vector2.CenterX(dataMenuHeader.Size.x), 5);

            dataMenu.Controls.AddControl(dataMenuHeader);
            #endregion

            #region Data Amount
            #region Label
            ColorableLabel amountLabel = new ColorableLabel("Data Amount", textColor, borderColor, _attachToEngine: false);
            amountLabel.Position = new Vector2(20, dataMenuHeader.Position.y + 6);

            dataMenu.Controls.AddControl(amountLabel);
            #endregion

            #region Textfield
            ColorableTextField amountText = new ColorableTextField("Type Amount...", new RenderColor(ConsoleColor.Green, ConsoleColor.Black), borderColor, _attachToEngine: false)
            {
                SelectedIndex = Vector2.Zero,
                EraseTextOnSelect = true,
                ResetAfterFirstWrite = false
            };
            amountText.Position = new Vector2(amountLabel.Position.x + amountLabel.Size.x - 1, amountLabel.Position.y);

            amountText.OnSelect += (s) =>
            {
                if ( int.TryParse(amountText.Text, out int _dataAmount) )   //  Create new instance of the container and reset the value counter
                {
                    container = new RaindropContainer(_dataAmount);
                    valueCounter = 1;
                }
                else
                {
                    container = null;
                }
            };

            dataMenu.Controls.AddControl(amountText);
            #endregion

            #region Status Label
            ColorableLabel amountStatusLabel = new ColorableLabel("No Data", new RenderColor(ConsoleColor.Red, ConsoleColor.Black), borderColor, _attachToEngine: false);
            //statusLabel.Position = new Vector2(amountText.Position.x + amountText.Size.x - 1, amountLabel.Position.y);
            amountStatusLabel.OnUpdate += (c) =>
            {
                amountStatusLabel.Position = new Vector2(amountText.Position.x + amountText.Size.x - 1, amountLabel.Position.y);

                if ( container != null )    //  Tell the user that an instance of the container exists
                {
                    amountStatusLabel.Text = "OK";
                    amountStatusLabel.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);
                }
                else    // Tell the user that an instance of the container does not exist 
                {
                    amountStatusLabel.Text = "No Data";
                    amountStatusLabel.TextColor = new RenderColor(ConsoleColor.Red, ConsoleColor.Black);
                }
            };

            dataMenu.Controls.AddControl(amountStatusLabel);
            #endregion
            #endregion

            #region Value Collection
            #region Label
            ColorableLabel valueLabel = new ColorableLabel("Value 1", textColor, borderColor, _attachToEngine: false);
            valueLabel.Position = new Vector2(amountLabel.Position.x, amountText.Position.y + 6);

            valueLabel.OnUpdate += (c) =>
            {
                valueLabel.Text = $"Value {valueCounter}";
            };

            dataMenu.Controls.AddControl(valueLabel);
            #endregion

            #region Textfield
            ColorableTextField valueText = new ColorableTextField("Type Value...", new RenderColor(ConsoleColor.Green, ConsoleColor.Black), borderColor, _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 1),
                EraseTextOnSelect = true,
                ResetAfterFirstWrite = false
            };
            valueText.Position = new Vector2(valueLabel.Position.x + valueLabel.Size.x - 1, valueLabel.Position.y);

            valueText.OnSelect += (s) =>
            {
                valueText.Position = new Vector2(valueLabel.Position.x + valueLabel.Size.x - 1, valueLabel.Position.y);

                if ( container != null )
                {
                    if ( decimal.TryParse(valueText.Text, out decimal _value) && valueCounter < container.ValuePool.Length )
                    {
                        container.ValuePool[valueCounter - 1] = _value;
                    }

                    if ( !OiskiEngine.Input.CanWrite && valueText.Text != string.Empty )    //  When exiting the write state of the TextField and the string input is not empty
                    {
                        valueCounter++;
                    }
                }
            };

            dataMenu.Controls.AddControl(valueText);
            #endregion

            #region Status Label
            ColorableLabel valueStatusLabel = new ColorableLabel("No Data", new RenderColor(ConsoleColor.Red, ConsoleColor.Black), borderColor, _attachToEngine: false);

            valueStatusLabel.OnUpdate += (c) =>
            {
                valueStatusLabel.Position = new Vector2(valueText.Position.x + valueText.Size.x - 1, valueLabel.Position.y);

                if ( container != null && valueCounter > container.ValuePool.Length )   //    Tell the user that all data has been collected
                {
                    valueStatusLabel.Text = "All Data Collected";
                    valueLabel.Text = $"Value {container.ValuePool.Length}";
                    valueStatusLabel.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);
                }
                else    //  Tell the user how many values are yet to be collected
                {
                    valueStatusLabel.Text = $"{( ( container != null ) ? ( $"{container.ValuePool.Length - valueCounter} Left" ) : ( "No Data" ) )}";
                    valueStatusLabel.TextColor = new RenderColor(ConsoleColor.Red, ConsoleColor.Black);
                }
            };

            dataMenu.Controls.AddControl(valueStatusLabel);
            #endregion
            #endregion

            #region Back Button
            ColorableOption dataMenuBack = new ColorableOption("Back", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, dataMenu.Controls.GetSelectableControls.Count)
            };
            dataMenuBack.Position = new Vector2(Vector2.CenterX(dataMenuBack.Size.x), toResultMenu.Position.y + 6);

            dataMenuBack.OnSelect += (s) =>
            {
                #region Hide Data Menu
                OiskiEngine.Input.ResetInput();
                OiskiEngine.Input.ResetSlection();
                dataMenu.Show(false);
                #endregion

                valueCounter = 1;
                s.BorderStyle(BorderArea.Horizontal, '-');
                mainMenu.Show();
            };

            dataMenu.Controls.AddControl(dataMenuBack);
            #endregion
            #endregion

            #region Result Menu
            //  Establish Result Menu
            #endregion
        }
    }
}