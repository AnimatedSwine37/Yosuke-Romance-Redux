﻿using p4gpc.events.yosukeromance.next.Configuration;
using p4gpc.events.yosukeromance.next.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using CriFs.V2.Hook;
using CriFs.V2.Hook.Interfaces;

namespace p4gpc.events.yosukeromance.next
{
	/// <summary>
	/// Your mod logic goes here.
	/// </summary>
	public class Mod : ModBase // <= Do not Remove.
	{
		/// <summary>
		/// Provides access to the mod loader API.
		/// </summary>
		private readonly IModLoader _modLoader;

		/// <summary>
		/// Provides access to the Reloaded.Hooks API.
		/// </summary>
		/// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
		private readonly IReloadedHooks? _hooks;

		/// <summary>
		/// Provides access to the Reloaded logger.
		/// </summary>
		private readonly ILogger _logger;

		/// <summary>
		/// Entry point into the mod, instance that created this class.
		/// </summary>
		private readonly IMod _owner;

		/// <summary>
		/// Provides access to this mod's configuration.
		/// </summary>
		private Config _configuration;

		/// <summary>
		/// The configuration of the currently executing mod.
		/// </summary>
		private readonly IModConfig _modConfig;

		public Mod(ModContext context)
		{
			_modLoader = context.ModLoader;
			_hooks = context.Hooks;
			_logger = context.Logger;
			_owner = context.Owner;
			_configuration = context.Configuration;
			_modConfig = context.ModConfig;


			// For more information about this template, please see
			// https://reloaded-project.github.io/Reloaded-II/ModTemplate/

			// If you want to implement e.g. unload support in your mod,
			// and some other neat features, override the methods in ModBase.

			// TODO: Implement some mod logic

			var criFsController = _modLoader.GetController<ICriFsRedirectorApi>();
			if (criFsController == null || !criFsController.TryGetTarget(out var criFsApi))
			{
				_logger.WriteLine($"Something shit it's pants", System.Drawing.Color.Red);
				return;
			}

			if (_configuration.Rank6)
			{
				criFsApi.AddProbingPath("Rank6");
			}
			if (_configuration.Rank7)
			{
				criFsApi.AddProbingPath("Rank7");
			}
			if (_configuration.Rank8)
			{
				criFsApi.AddProbingPath("Rank8");
			}
			if (_configuration.Rank9)
			{
				criFsApi.AddProbingPath("Rank9");
			}
			if (_configuration.Rank10)
			{
				criFsApi.AddProbingPath("Rank10");
			}
			if (_configuration.CampScene)
			{
				criFsApi.AddProbingPath("CampScene");
			}


			//if (_configuration.Testing)
			//{
			//	criFsApi.AddProbingPath("Testing");
			//}

			//if (_configuration.Christmas)
			//{
			//	criFsApi.AddProbingPath("Christmas");
			//}
			//if (_configuration.Valentine)
			//{
			//	criFsApi.AddProbingPath("Valentine");
			//}
		}

		#region Standard Overrides
		public override void ConfigurationUpdated(Config configuration)
		{
			// Apply settings from configuration.
			// ... your code here.
			_configuration = configuration;
			_logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
		}
		#endregion

		#region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public Mod() { }
#pragma warning restore CS8618
		#endregion
	}
}