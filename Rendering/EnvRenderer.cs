﻿using System;
using ClassicalSharp.GraphicsAPI;

namespace ClassicalSharp.Renderers {

	public abstract class EnvRenderer : IDisposable {
		
		public Map Map;
		public Game Window;	
		public OpenGLApi Graphics;
		
		public virtual void Init() {
			Graphics = Window.Graphics;
			Window.OnNewMap += OnNewMap;
			Window.OnNewMapLoaded += OnNewMapLoaded;
			Window.EnvVariableChanged += EnvVariableChanged;
		}		
		
		public virtual void OnNewMap( object sender, EventArgs e ) {
		}
		
		public virtual void OnNewMapLoaded( object sender, EventArgs e ) {
		}
		
		public virtual void Dispose() {
			Window.OnNewMap -= OnNewMap;
			Window.OnNewMapLoaded -= OnNewMapLoaded;
			Window.EnvVariableChanged -= EnvVariableChanged;
		}
		
		public abstract void Render( double deltaTime );
		
		void EnvVariableChanged( object sender, EnvVariableEventArgs e ) {
			if( e.Variable == EnvVariable.SkyColour ) {
				SkyColourChanged();
			} else if( e.Variable == EnvVariable.FogColour ) {
				FogColourChanged();
			} else if( e.Variable == EnvVariable.CloudsColour ) {
				CloudsColourChanged();
			}
		}
		
		protected abstract void SkyColourChanged();
		
		protected abstract void FogColourChanged();
		
		protected abstract void CloudsColourChanged();
		
		public abstract void EnableAmbientLighting();
		
		public abstract void DisableAmbientLighting();
	}
}
