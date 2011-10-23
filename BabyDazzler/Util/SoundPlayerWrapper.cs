using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;

namespace BabyDazzler.Util
{
    static class SoundPlayerWrapper
    {
        /* This is static because there should only be one instance of it. */
        private static SoundPlayer soundPlayer;

        private static Thread soundThread;

        /* Until resource handling is implemented, take file name
         * 
         * TODO: Change to accept a resource 
         */
        static public void PlaySound(String fileName)
        {
            soundPlayer = new SoundPlayer(fileName);

            if (soundThread == null 
                || soundThread.ThreadState == ThreadState.Stopped)
            {
                soundThread = new Thread(new ThreadStart(soundRun));
                soundThread.Start();
            }
            /* Otherwise, thread is not stopped or null -- do nothing */
        }

        static private void soundRun()
        {
            /* If not already loaded, load and block until loaded. */
            if (!soundPlayer.IsLoadCompleted)
            {
                soundPlayer.Load();
            }

            soundPlayer.PlaySync();
        }
        public static Boolean IsSoundPlaying
        {
            get {
                if( SoundPlayerWrapper.soundThread != null 
                    && SoundPlayerWrapper.soundThread.ThreadState == ThreadState.Running )
                    return true;
                else
                    return false; 
            }
        }
    }
}
