using FilenameBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RenderBuddy;
using System.Collections.Generic;
using System.Linq;

namespace ParallaxBackgroundBuddy
{
	/// <summary>
	/// This is the background that is drawn to a rect using parallax
	/// </summary>
	public class ParallaxBackground
	{
		#region Properties

		public List<ParallaxLayer> Layers { get; private set; }

		#endregion //Properties

		#region Methods

		public ParallaxBackground()
		{
			Layers = new List<ParallaxLayer>();
		}

		public void Sort()
		{
			Layers.OrderByDescending(x => x.MovementDelta);
		}

		public void AddLayer(Filename textureFilename, float movementDelta, IRenderer renderer)
		{
			Layers.Add(new ParallaxLayer(textureFilename, movementDelta, renderer));
		}

		public void Draw(SpriteBatch spriteBatch, Rectangle destinationRect, Vector2 movementOffset)
		{
			for (int i = 0; i < Layers.Count; i++)
			{
				Layers[i].Draw(spriteBatch, destinationRect, movementOffset);
			}
		}

		#endregion //Methods
	}
}
