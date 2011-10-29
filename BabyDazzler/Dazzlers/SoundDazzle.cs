using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BabyDazzler.Util;

namespace BabyDazzler.Dazzlers
{
    class SoundDazzle
    {
        Key key;

        public SoundDazzle(Key key)
        {
            this.key = key;
            playSoundDazzle();
        }

        public void playSoundDazzle()
        {
            if (isKeyFirstRow())
            {
                SoundPlayerWrapper.PlaySound(BabyDazzler.Properties.Resources.f_major_5th);
            }
            else if (isKeySecondRow())
            {
                SoundPlayerWrapper.PlaySound(BabyDazzler.Properties.Resources.f_minor_5th);
            }
            else if (isKeyThirdRow())
            {
                SoundPlayerWrapper.PlaySound(BabyDazzler.Properties.Resources.f_major_4th);
            }
            else if (isKeyFourthRow())
            {
                SoundPlayerWrapper.PlaySound(BabyDazzler.Properties.Resources.f_minor_4th);
            }
            else if (isKeyFifthRow())
            {
                SoundPlayerWrapper.PlaySound(BabyDazzler.Properties.Resources.f_major_3rd);
            }
            else if (isKeySixthRow())
            {
                SoundPlayerWrapper.PlaySound(BabyDazzler.Properties.Resources.f_minor_3rd);
            }
            else
            {
                SoundPlayerWrapper.PlaySound(BabyDazzler.Properties.Resources.pop);
                SimpleLogger.Log("Unhandled keystroke: " + key);
            }
        }

        private bool isKeySixthRow()
        {
            if (key == Key.LeftCtrl || key == Key.LeftAlt ||
                key == Key.LWin || key == Key.Space ||
                key == Key.RWin || key == Key.RightAlt ||
                key == Key.Left || key == Key.Up ||
                key == Key.Right || key == Key.Down)
            {
                return true;
            }
            else
                return false;
        }

        private bool isKeyFifthRow()
        {
            if (key == Key.LeftShift || key == Key.Z ||
                key == Key.X || key == Key.C ||
                key == Key.V || key == Key.B ||
                key == Key.N || key == Key.M ||
                key == Key.OemComma || key == Key.OemPeriod ||
                key == Key.OemQuestion || key == Key.RightShift)
            {
                return true;
            }
            else
                return false;
        }

        private bool isKeyFourthRow()
        {
            if (key == Key.Capital || key == Key.CapsLock ||
                key == Key.A || key == Key.S ||
                key == Key.D || key == Key.F ||
                key == Key.G || key == Key.H ||
                key == Key.J || key == Key.K ||
                key == Key.L || key == Key.Oem1 /* " */ ||
                key == Key.Oem3 /* ' */ || key == Key.Return)
            {
                return true;
            }
            else
                return false;
        }

        private bool isKeyThirdRow()
        {
            if (key == Key.Tab ||
                key == Key.Q || key == Key.W ||
                key == Key.E || key == Key.R ||
                key == Key.T || key == Key.Y ||
                key == Key.U || key == Key.I ||
                key == Key.O || key == Key.P ||
                key == Key.OemOpenBrackets || key == Key.Oem6 /* ] */ ||
                key == Key.OemQuotes /* \ */)
            {
                return true;
            }
            else
                return false;
        }

        private bool isKeySecondRow()
        {
            if (key == Key.Oem8 /* ` */ || key == Key.D1 ||
                key == Key.D2 || key == Key.D3 ||
                key == Key.D3 || key == Key.D4 ||
                key == Key.D5 || key == Key.D6 ||
                key == Key.D7 || key == Key.D8 ||
                key == Key.D9 || key == Key.D0 ||
                key == Key.OemMinus || key == Key.OemPlus ||
                key == Key.Back || key == Key.Home ||
                key == Key.End || key == Key.NumLock)
            {
                return true;
            }
            else
                return false;
        }

        private bool isKeyFirstRow()
        {
            if (key == Key.Escape ||
                key == Key.F1 || key == Key.F2 ||
                key == Key.F3 || key == Key.F4 ||
                key == Key.F5 || key == Key.F6 ||
                key == Key.F7 || key == Key.F8 ||
                key == Key.F9 || key == Key.F10 ||
                key == Key.F11 || key == Key.F12 ||
                key == Key.F14 || key == Key.F15 ||
                key == Key.F16 || key == Key.F17 ||
                key == Key.F18 || key == Key.F19 ||
                key == Key.F20 || key == Key.F21 ||
                key == Key.F22 || key == Key.F23 ||
                key == Key.F24 ||
                key == Key.MediaNextTrack || key == Key.MediaPreviousTrack ||
                key == Key.MediaPlayPause || key == Key.MediaStop ||
                key == Key.VolumeUp || key == Key.VolumeDown || key == Key.VolumeMute)
            {
                return true;
            }
            else
                return false;
        }
    }
}
