﻿using System;
using System.IO;
using System.Reflection;

// Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
// {
//     if (args.Name.StartsWith("CefSharp"))
//     {
//         string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
//         string architectureSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
//             Environment.Is64BitProcess ? "x64" : "x86",
//             assemblyName);

//         return File.Exists(architectureSpecificPath)
//             ? Assembly.LoadFile(architectureSpecificPath)
//             : null;
//     }

//     return null;
// }

// AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;

using var game = new cefsharptesting.Game1();
game.Run();
