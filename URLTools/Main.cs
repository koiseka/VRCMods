﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using URLTools;
using System.IO;
using System.Net;
using System.Reflection;

namespace URLTools
{
    public static class BuildShit
    {
        public const string Name = "URLTools";
        public const string Author = "Penny";
        public const string Version = "1.0.4";
        public const string DownloadLink = "https://github.com/PennyBunny/VRCMods/";
        public const string Description = "Use this mod to copy or open user, world and instance web pages";
    }
    public class Main : MelonMod
    {
        internal static readonly MelonLogger.Instance log = new MelonLogger.Instance(BuildShit.Name, ConsoleColor.Cyan);
        private static int scenesLoaded = 0;
        public override void OnApplicationStart()
        {
            LoadRemodCore(out _);
            BundleManager.InIt();
            log.Msg("URLTools Loaded");
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (scenesLoaded <= 2)
            {
                scenesLoaded++;
                if (scenesLoaded == 2)
                {
                    MelonCoroutines.Start(UIBuild.OnQuickMenu());
                }
            }
        }

        private void LoadRemodCore(out Assembly loadedAssembly)
        {
            byte[] bytes = null;
            var wc = new WebClient();
        

            try
            {
                loadedAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(ass => ass.FullName.Contains("ReMod.Core")) ?? 
                                 Assembly.Load(new WebClient().DownloadData("https://github.com/RequiDev/ReMod.Core/releases/latest/download/ReMod.Core.dll"));
            }
            catch (WebException e)
            {
                MelonLogger.Error($"Unable to Load Core Dep RemodCore: {e}");
            }
            catch (BadImageFormatException e)
            {
                loadedAssembly = null;
            }
            loadedAssembly = null;
        }

    }
}
